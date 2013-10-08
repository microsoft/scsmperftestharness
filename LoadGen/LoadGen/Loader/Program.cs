using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Diagnostics;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Packaging;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Helper;

namespace Microsoft.SystemCenter.Test.Loader
{
    class Program
    {
        #region Privates
        public static EnterpriseManagementGroup emg;
        private static ManagementPackObjectTemplate templateIncident;
        private static ManagementPackObjectTemplate templateChangeRequest;
        private static ManagementPackObjectTemplate templateServiceRequest;
        private static ManagementPackObjectTemplate templateProblem;
        private static ManagementPackObjectTemplate templateRelease;
        private static ManagementPackClass mpcUser;
        private static ManagementPackClass mpcIncident;
        private static ManagementPackClass mpcAnalystComment;
        private static ManagementPackClass mpcChangeRequest;
        private static ManagementPackClass mpcServiceRequest;
        private static ManagementPackClass mpcProblem;
        private static ManagementPackClass mpcComputer;
        private static ManagementPackClass mpcChangeRequestExtension;
        private static ManagementPackClass mpcServiceRequestExtension;
        private static ManagementPackClass mpcProblemExtension;
        private static ManagementPackTypeProjection mptpIncidentView;
        private static ManagementPackTypeProjection mptpIncidentFull;
        private static ManagementPackTypeProjection mptpChangeRequestView;
        private static ManagementPackTypeProjection mptpChangeRequestFull;
        private static ManagementPackTypeProjection mptpServiceRequestView;
        private static ManagementPackTypeProjection mptpServiceRequestFull;
        private static ManagementPackTypeProjection mptpProblemView;
        private static ManagementPackTypeProjection mptpProblemFull;
        private static ManagementPackRelationship mprRelatedCI;
        private static ManagementPackRelationship mprAnalystComment;
        private static ManagementPackRelationship mprWorkItemAssignedToUser;
        private static ManagementPackRelationship mprAffectedCI;
        private static EnterpriseManagementObject emoUser;
        private static ManagementPack mpSystemWorkItemLibrary;
        private static ManagementPack mpIncidentLibrary;
        private static ManagementPack mpServiceRequestLibrary;
        private static ManagementPack mpChangeRequestLibrary;
        private static ManagementPack mpProblemLibrary;
        private static ManagementPackProperty mppIncidentClassification;
        private static ManagementPackProperty mppServiceRequestArea;
        private static ManagementPackProperty mppChangeRequestArea;
        private static ManagementPackProperty mppProblemClassification;
        private static string strUserName = null;
        private static string strUserDomainName = null;
        private static double dRate = 0;
        private static double dRateInSeconds = 0;
        private static int intRateOfWorkItemQueryAndUpdates = 0;
        private static int intDoWorkPause = 0;
        private static int intNumberOfWorkItemsToGet = 0;
        private static bool bSimulateHumanWaitTime = true;
        private static DateTime dtWorkItemCreateLast;
        private static PerformanceCounter pcWorkItemCreateInterval  = new PerformanceCounter("SCSMPerf", "Work Item Creation Interval", false);
        private static PerformanceCounter pcIncidentWork            = new PerformanceCounter("SCSMPerf", "Incident Work Completion Time", false);
        private static PerformanceCounter pcChangeRequestWork       = new PerformanceCounter("SCSMPerf", "Change Request Work Completion Time", false);
        private static PerformanceCounter pcProblemWork             = new PerformanceCounter("SCSMPerf", "Problem Work Completion Time", false);
        private static PerformanceCounter pcServiceRequestWork      = new PerformanceCounter("SCSMPerf", "Service Request Work Completion Time", false);
        private static PerformanceCounter pcManagementGroupCreate   = new PerformanceCounter("SCSMPerf", "Management Group Create Time", false);
        private static PerformanceCounter pcDoWork                  = new PerformanceCounter("SCSMPerf", "Do Work Completion Time", false);
        private static PerformanceCounter pcCaching                 = new PerformanceCounter("SCSMPerf", "Caching Completion Time", false);
        private static PerformanceCounter pcIncidentQuery           = new PerformanceCounter("SCSMPerf", "Incident Query Time", false);
        private static PerformanceCounter pcGetSingleIncident       = new PerformanceCounter("SCSMPerf", "Get Single Incident", false);
        private static PerformanceCounter pcUpdateIncident          = new PerformanceCounter("SCSMPerf", "Update Incident", false);
        private static IList<ManagementPackEnumeration> listSRAreaEnums;
        private static IList<ManagementPackEnumeration> listCRAreaEnums;
        private static IList<ManagementPackEnumeration> listProblemClassificationEnums;
        private static IList<ManagementPackEnumeration> listIncidentClassificationEnums;
        #endregion

        static void Main(string[] args)
        {
            string strServerName = args[0];
            string strWorkItemTypeToCreate = args[1];
            int intIncidnetsPerDay = Int32.Parse(args[2]);
            int intIncidnetsToCreate = Int32.Parse(args[3]);
            int intChangeRequestsPerDay = Int32.Parse(args[4]);
            int intChangeRequestsToCreate = Int32.Parse(args[5]);
            int intServiceRequestsPerDay = Int32.Parse(args[6]);
            int intServiceRequestsToCreate = Int32.Parse(args[7]);
            int intProblemsPerDay = Int32.Parse(args[8]);
            int intProblemsToCreate = Int32.Parse(args[9]);
            int intReleasesPerDay = Int32.Parse(args[10]);
            int intReleasesToCreate = Int32.Parse(args[11]);
            int intNumberOfWorkingHoursPerDay = Int32.Parse(args[12]);
            intRateOfWorkItemQueryAndUpdates = Int32.Parse(args[13]);
            intDoWorkPause = Int32.Parse(args[14]);
            intNumberOfWorkItemsToGet = Int32.Parse(args[15]);

            DateTime dtCreatingManagementGroupStart = DateTime.Now;
            emg = new EnterpriseManagementGroup(strServerName);
            DateTime dtCreatingManagementGroupEnd = DateTime.Now;
            TimeSpan tsCreatingManagementGroup = dtCreatingManagementGroupEnd - dtCreatingManagementGroupStart;
            pcManagementGroupCreate.RawValue = (long)tsCreatingManagementGroup.TotalSeconds;
            Console.WriteLine(String.Format("Process user: {0}\\{1}", Environment.UserDomainName, Environment.UserName));
            Console.WriteLine("Creating Management Group (seconds): " + tsCreatingManagementGroup.TotalSeconds);

            //For debugging so you can catch the process and put it in the debugger
            //Console.WriteLine("Sleeping for 10 seconds");
            //Thread.Sleep(10000);

            DateTime dtCachingStart = DateTime.Now;
            //Get the current user and the user's associated group enum
            strUserName = Environment.UserName;
            strUserDomainName = Environment.UserDomainName;
            mpcUser = Helper.GetClassByName("System.Domain.User", emg);
            EnterpriseManagementObjectCriteria emocUser = new EnterpriseManagementObjectCriteria(String.Format("UserName = '{0}' AND Domain ='{1}'", strUserName, strUserDomainName), mpcUser);
            IObjectReader<EnterpriseManagementObject> orUser = emg.EntityObjects.GetObjectReader<EnterpriseManagementObject>(emocUser, ObjectQueryOptions.Default);
            if(orUser.Count > 0)
                emoUser = orUser.First<EnterpriseManagementObject>();
            else
                Console.WriteLine(String.Format("Logged in user: {0}\\{1} doesnt exist in the SCSM database.",strUserDomainName, strUserName));

            //Classes
            mpcIncident = Helper.GetClassByName("System.WorkItem.Incident", emg);
            mpcAnalystComment = Helper.GetClassByName("System.WorkItem.TroubleTicket.AnalystCommentLog", emg);
            mpcChangeRequest = Helper.GetClassByName("System.WorkItem.ChangeRequest", emg);
            mpcServiceRequest = Helper.GetClassByName("System.WorkItem.ServiceRequest", emg);
            mpcProblem = Helper.GetClassByName("System.WorkItem.Problem", emg);
            mpcComputer = Helper.GetClassByName("Microsoft.Windows.Computer", emg);
            mpcChangeRequestExtension = Helper.GetClassByName(Constants.CLASS_CHANGEREQUEST_EXTENSION, emg);
            mpcProblemExtension = Helper.GetClassByName(Constants.CLASS_PROBLEM_EXTENSION, emg);
            mpcServiceRequestExtension = Helper.GetClassByName(Constants.CLASS_SERVICEREQUEST_EXTENSION, emg);

            //Type Projections
            mptpIncidentView = Helper.GetTypeProjectionByName("System.WorkItem.Incident.View.ProjectionType", emg);
            mptpIncidentFull = Helper.GetTypeProjectionByName("System.WorkItem.Incident.ProjectionType", emg);
            mptpChangeRequestView = Helper.GetTypeProjectionByName("System.WorkItem.ChangeRequestViewProjection", emg);
            mptpChangeRequestFull = Helper.GetTypeProjectionByName("System.WorkItem.ChangeRequestProjection", emg);
            mptpServiceRequestView = Helper.GetTypeProjectionByName("System.WorkItem.ServiceRequestViewProjection", emg);
            mptpServiceRequestFull = Helper.GetTypeProjectionByName("System.WorkItem.ServiceRequestProjection", emg);
            mptpProblemView = Helper.GetTypeProjectionByName("System.WorkItem.ProblemViewProjection", emg);
            mptpProblemFull = Helper.GetTypeProjectionByName("System.WorkItem.Problem.ProjectionType", emg);

            //Relationships
            mprAnalystComment = Helper.GetRelationshipByName("System.WorkItem.TroubleTicketHasAnalystComment", emg);
            mprWorkItemAssignedToUser = Helper.GetRelationshipByName("System.WorkItemAssignedToUser", emg);
            mprAffectedCI = Helper.GetRelationshipByName("System.WorkItemAboutConfigItem", emg);
            mprRelatedCI = Helper.GetRelationshipByName("System.WorkItemRelatesToConfigItem", emg);

            //Management Packs
            mpSystemWorkItemLibrary = Helper.GetManagementPackByName("System.WorkItem.Library", emg);
            mpIncidentLibrary = Helper.GetManagementPackByName("System.WorkItem.Incident.Library", emg);
            mpServiceRequestLibrary = Helper.GetManagementPackByName("System.WorkItem.ServiceRequest.Library", emg);
            mpChangeRequestLibrary = Helper.GetManagementPackByName("System.WorkItem.ChangeRequest.Library", emg);
            mpProblemLibrary = Helper.GetManagementPackByName("System.WorkItem.Problem.Library", emg);
            
            //Properties
            mppIncidentClassification = Helper.GetManagementPackClassPropertyByName("System.WorkItem.Incident", "Classification", emg);
            mppServiceRequestArea = Helper.GetManagementPackClassPropertyByName("System.WorkItem.ServiceRequest", "Area", emg);
            mppChangeRequestArea = Helper.GetManagementPackClassPropertyByName("System.WorkItem.ChangeRequest", "Area", emg);
            mppProblemClassification = Helper.GetManagementPackClassPropertyByName("System.WorkItem.Problem", "Classification", emg);

            ManagementPackEnumeration mpeSRAreaBase = Helper.GetEnumerationByName("ServiceRequestAreaEnum", emg);
            ManagementPackEnumeration mpeCRAreaBase = Helper.GetEnumerationByName("ChangeAreaEnum", emg);
            ManagementPackEnumeration mpeProblemClassificationBase = Helper.GetEnumerationByName("ProblemClassificationEnum", emg);
            ManagementPackEnumeration mpeIncidentClassificationBase = Helper.GetEnumerationByName("IncidentClassificationEnum", emg);

            listSRAreaEnums = emg.EntityTypes.GetChildEnumerations(mpeSRAreaBase.Id, TraversalDepth.Recursive);
            listCRAreaEnums = emg.EntityTypes.GetChildEnumerations(mpeCRAreaBase.Id, TraversalDepth.Recursive);
            listProblemClassificationEnums = emg.EntityTypes.GetChildEnumerations(mpeProblemClassificationBase.Id, TraversalDepth.Recursive);
            listIncidentClassificationEnums = emg.EntityTypes.GetChildEnumerations(mpeIncidentClassificationBase.Id, TraversalDepth.Recursive);

            DateTime dtCachingEnd = DateTime.Now;
            TimeSpan tsCaching = dtCachingEnd - dtCachingStart;
            pcCaching.RawValue = (long)tsCaching.TotalSeconds;
            Console.WriteLine("Caching (seconds): " + tsCaching.TotalSeconds);

            Console.WriteLine("Worker work item class to create: "+ strWorkItemTypeToCreate);
            switch (strWorkItemTypeToCreate)
            {
                case "Incident":
                    CreateIncidents(intIncidnetsToCreate, intIncidnetsPerDay, intNumberOfWorkingHoursPerDay);
                    break;
                case "ChangeRequest":
                    CreateChangeRequests(intChangeRequestsToCreate, intChangeRequestsPerDay, intNumberOfWorkingHoursPerDay);
                    break;
                case "ServiceRequest":
                    CreateServiceRequests(intServiceRequestsToCreate, intServiceRequestsPerDay, intNumberOfWorkingHoursPerDay);
                    break;
                case "Problem":
                    CreateProblems(intProblemsToCreate, intProblemsPerDay, intNumberOfWorkingHoursPerDay);
                    break;
                case "Release":
                    CreateReleases(intReleasesToCreate, intReleasesPerDay, intNumberOfWorkingHoursPerDay);
                    break;
                default:
                    break;
            }

            System.Timers.Timer timerWorkItemQueryUpdate = new System.Timers.Timer((double)intRateOfWorkItemQueryAndUpdates);
            timerWorkItemQueryUpdate.Elapsed += new ElapsedEventHandler(WorkItemQueryUpdate);
            timerWorkItemQueryUpdate.Enabled = true;
            
            while (Console.Read() != 'q') ;
        }

        #region CreateWorkItems
        private static void CreateIncidents(int intNumberOfIncidentsToCreate, int intNumberPerDayRate, int intNumberOfWorkingHoursPerDay)
        {
            templateIncident = Helper.GetObjectTemplateByName(Constants.TEMPLATE_INCIDENT, emg);
            double dInterval = ConvertRateToInterval(intNumberPerDayRate, intNumberOfWorkingHoursPerDay);
            if (dInterval > 0)
            {
                System.Timers.Timer timer = new System.Timers.Timer(dInterval);
                timer.Elapsed += new ElapsedEventHandler(CreateIncidentTimerElapsed);
                timer.Enabled = true;
            }
        }
        
        private static void CreateChangeRequests(int intNumberOfChangeRequestsToCreate, int intNumberPerDayRate, int intNumberOfWorkingHoursPerDay)
        {
            templateChangeRequest = Helper.GetObjectTemplateByName(Constants.TEMPLATE_CHANGEREQUEST, emg);
            double dInterval = ConvertRateToInterval(intNumberPerDayRate, intNumberOfWorkingHoursPerDay);
            if (dInterval > 0)
            {
                System.Timers.Timer timer = new System.Timers.Timer(dInterval);
                timer.Elapsed += new ElapsedEventHandler(CreateChangeRequestTimerElapsed);
                timer.Enabled = true;
            }
        }

        private static void CreateServiceRequests(int intNumberOfServiceRequestsToCreate, int intNumberPerDayRate, int intNumberOfWorkingHoursPerDay)
        {
            templateServiceRequest = Helper.GetObjectTemplateByName(Constants.TEMPLATE_SERVICEREQUEST, emg);
            double dInterval = ConvertRateToInterval(intNumberPerDayRate, intNumberOfWorkingHoursPerDay);
            if (dInterval > 0)
            {
                System.Timers.Timer timer = new System.Timers.Timer(dInterval);
                timer.Elapsed += new ElapsedEventHandler(CreateServiceRequestTimerElapsed);
                timer.Enabled = true;
            }
        }

        private static void CreateProblems(int intNumberOfProblemsToCreate, int intNumberPerDayRate, int intNumberOfWorkingHoursPerDay)
        {
            templateProblem = Helper.GetObjectTemplateByName(Constants.TEMPLATE_PROBLEM, emg);
            double dInterval = ConvertRateToInterval(intNumberPerDayRate, intNumberOfWorkingHoursPerDay);
            if (dInterval > 0)
            {
                System.Timers.Timer timer = new System.Timers.Timer(dInterval);
                timer.Elapsed += new ElapsedEventHandler(CreateProblemTimerElapsed);
                timer.Enabled = true;
            }
        }

        private static void CreateReleases(int intNumberOfReleaseToCreate, int intNumberPerDayRate, int intNumberOfWorkingHoursPerDay)
        {
            templateRelease = Helper.GetObjectTemplateByName(Constants.TEMPLATE_RELEASE, emg);
            double dInterval = ConvertRateToInterval(intNumberPerDayRate, intNumberOfWorkingHoursPerDay);
            if (dInterval > 0)
            {
                System.Timers.Timer timer = new System.Timers.Timer(dInterval);
                timer.Elapsed += new ElapsedEventHandler(CreateReleaseTimerElapsed);
                timer.Enabled = true;
            }
        }
        

        private static void CreateIncidentTimerElapsed(object source, ElapsedEventArgs e)
        {
            CreateWorkItemsFromTemplate(templateIncident);
        }

        private static void CreateChangeRequestTimerElapsed(object source, ElapsedEventArgs e)
        {
            CreateWorkItemsFromTemplate(templateChangeRequest);
        }

        private static void CreateServiceRequestTimerElapsed(object source, ElapsedEventArgs e)
        {
            CreateWorkItemsFromTemplate(templateServiceRequest);
        }

        private static void CreateProblemTimerElapsed(object source, ElapsedEventArgs e)
        {
            CreateWorkItemsFromTemplate(templateProblem);
        }

        private static void CreateReleaseTimerElapsed(object source, ElapsedEventArgs e)
        {
            CreateWorkItemsFromTemplate(templateRelease);
        }
        #endregion

        #region DoWork

        private static void DoSomeIncidentWork()
        {
            DateTime dtIncidentWorkStart = DateTime.Now;

            //Query and get some incidents using just the view type projection
            int intRandomClassificationEnum = Helper.GetRandomNumber(0, listIncidentClassificationEnums.Count);
            ManagementPackEnumeration mpeRandomClassification = listIncidentClassificationEnums.ElementAtOrDefault<ManagementPackEnumeration>(intRandomClassificationEnum);
            string strClassificationCriteriaXml = Helper.SearchObjectByEnumerationCriteriaXml(mpeRandomClassification, mpcIncident, mppIncidentClassification);

            DateTime dtIncidentQueryStart = DateTime.Now;
            IObjectProjectionReader<EnterpriseManagementObject> readerIncidentView = Helper.GetBufferedObjectProjectionReader(strClassificationCriteriaXml, intNumberOfWorkItemsToGet, mptpIncidentView, emg);
            DateTime dtIncidentQueryFinish = DateTime.Now;
            TimeSpan tsIncidentQueryTime = dtIncidentQueryFinish - dtIncidentQueryStart;
            pcIncidentQuery.RawValue = (long)tsIncidentQueryTime.TotalSeconds;
            if (readerIncidentView == null)
            {
                Console.WriteLine("No objects to retrieve given the criteria");
            }
            else
            {
                Console.WriteLine(String.Format("{0} {1} in {2} seconds.", readerIncidentView.Count.ToString(), mpeRandomClassification.DisplayName, tsIncidentQueryTime.TotalSeconds));
                //Get a particular incident (full projection) and update it by adding an action log entry and 
                string strIncidentId = null;
                if (readerIncidentView.Count > 0)
                {
                    strIncidentId = readerIncidentView.ElementAtOrDefault<EnterpriseManagementObjectProjection>(Helper.GetRandomNumber(0, readerIncidentView.Count -1)).Object[mpcIncident, "Id"].Value.ToString();
                }

                if (strIncidentId != null)
                {
                    DateTime dtGetIncidentStart = DateTime.Now;
                    //Get the incident to update
                    string strCriteriaXml = Helper.SearchWorkItemByIDCriteriaXml(strIncidentId, mpSystemWorkItemLibrary.Name, mpSystemWorkItemLibrary.Version.ToString(), mpSystemWorkItemLibrary.KeyToken, "System.WorkItem");
                    ObjectProjectionCriteria opcIncidentFull = new ObjectProjectionCriteria(strCriteriaXml, mptpIncidentFull, emg);
                    IObjectProjectionReader<EnterpriseManagementObject> oprIncidentFull = emg.EntityObjects.GetObjectProjectionReader<EnterpriseManagementObject>(opcIncidentFull, ObjectQueryOptions.Default);
                    EnterpriseManagementObjectProjection emopIncidentFull = oprIncidentFull.First<EnterpriseManagementObjectProjection>();
                    DateTime dtGetIncidentEnd = DateTime.Now;
                    TimeSpan tsGetIncident = dtGetIncidentEnd - dtGetIncidentStart;
                    pcGetSingleIncident.RawValue = (long)tsGetIncident.TotalSeconds;
                    Console.WriteLine("Get single incident time: " + tsGetIncident.TotalSeconds);

                    if (bSimulateHumanWaitTime)
                        Thread.Sleep(intDoWorkPause);

                    //Update a couple of properties on the incident
                    emopIncidentFull.Object[mpcIncident, "Description"].Value = Guid.NewGuid().ToString();
                    int intRandomEnumID = Helper.GetRandomNumber(0, listIncidentClassificationEnums.Count);
                    ManagementPackEnumeration mpeClassification = listIncidentClassificationEnums.ElementAtOrDefault<ManagementPackEnumeration>(intRandomEnumID);
                    emopIncidentFull.Object[mpcIncident, "Classification"].Value = mpeClassification;

                    //Create a new action log entry and add it to the incident

                    CreatableEnterpriseManagementObject cemoAnalystComment = new CreatableEnterpriseManagementObject(emg, mpcAnalystComment);
                    cemoAnalystComment[mpcAnalystComment, "Id"].Value = System.Guid.NewGuid().ToString();
                    cemoAnalystComment[mpcAnalystComment, "Comment"].Value = System.Guid.NewGuid().ToString();
                    cemoAnalystComment[mpcAnalystComment, "EnteredBy"].Value = strUserName;
                    cemoAnalystComment[mpcAnalystComment, "EnteredDate"].Value = DateTime.UtcNow;

                    //If it is getting to be more than about 8 comments it is getting unrealistic.  Don't keep adding to it.
                    if (emopIncidentFull[mprAnalystComment.Target].Count < 8)
                        emopIncidentFull.Add(cemoAnalystComment, mprAnalystComment.Target);

                    //Change the assigned to user to the current user
                    foreach (IComposableProjection icpAssignedToUser in emopIncidentFull[mprWorkItemAssignedToUser.Target])
                    {
                        icpAssignedToUser.Remove();
                    }
                    emopIncidentFull.Add(emoUser, mprWorkItemAssignedToUser.Target);

                    if (bSimulateHumanWaitTime)
                        Thread.Sleep(intDoWorkPause);

                    //Commit the changes to the DB
                    DateTime dtUpdateIncidentStart = DateTime.Now;
                    emopIncidentFull.Overwrite();
                    DateTime dtUpdateIncidentEnd = DateTime.Now;
                    TimeSpan tsUpdateIncident = dtUpdateIncidentEnd - dtUpdateIncidentStart;
                    pcUpdateIncident.RawValue = (long)tsUpdateIncident.TotalSeconds;

                    DateTime dtIncidentWorkEnd = DateTime.Now;
                    TimeSpan tsIncidentWork = dtIncidentWorkEnd - dtIncidentWorkStart;
                    pcIncidentWork.RawValue = (long)tsIncidentWork.TotalSeconds;
                    Console.WriteLine("Incident work completed (seconds): " + tsIncidentWork.TotalSeconds);
                }
            }
        }

        private static void DoSomeChangeRequestWork()
        {
            DateTime dtChangeRequestWorkStart = DateTime.Now;

            //Query and get some change requests using just the view type projection
            int intRandomAreaEnum= Helper.GetRandomNumber(0, listCRAreaEnums.Count);
            ManagementPackEnumeration mpeRandomArea = listCRAreaEnums.ElementAtOrDefault<ManagementPackEnumeration>(intRandomAreaEnum);
            string strCriteria = Helper.SearchObjectByEnumerationCriteriaXml(mpeRandomArea, mpcChangeRequest, mppChangeRequestArea);

            IObjectProjectionReader<EnterpriseManagementObject> oprChangeRequestView = Helper.GetBufferedObjectProjectionReader(strCriteria, intNumberOfWorkItemsToGet, mptpChangeRequestView, emg);

            if (oprChangeRequestView == null)
            {
                Console.WriteLine("No objects to retrieve given the criteria");
            }
            else
            {
                //Get a particular incident (full projection) and update it by adding an action log entry and 
                string strChangeRequestId = null;
                if (oprChangeRequestView.Count > 0)
                {
                    strChangeRequestId = oprChangeRequestView.ElementAtOrDefault<EnterpriseManagementObjectProjection>(Helper.GetRandomNumber(0, oprChangeRequestView.Count -1)).Object[mpcChangeRequest, "Id"].Value.ToString();
                }

                if (strChangeRequestId != null)
                {
                    //Get the change request to update
                    string strCriteriaXml = Helper.SearchWorkItemByIDCriteriaXml(strChangeRequestId, mpSystemWorkItemLibrary.Name, mpSystemWorkItemLibrary.Version.ToString(), mpSystemWorkItemLibrary.KeyToken, "System.WorkItem");
                    ObjectProjectionCriteria opcChangeRequestFull = new ObjectProjectionCriteria(strCriteriaXml, mptpChangeRequestFull, emg);
                    IObjectProjectionReader<EnterpriseManagementObject> oprChangeRequestFull = emg.EntityObjects.GetObjectProjectionReader<EnterpriseManagementObject>(opcChangeRequestFull, ObjectQueryOptions.Default);
                    EnterpriseManagementObjectProjection emopChangeRequestFull = oprChangeRequestFull.First<EnterpriseManagementObjectProjection>();

                    if (bSimulateHumanWaitTime)
                        Thread.Sleep(intDoWorkPause);

                    //Update a couple of properties on the change request
                    emopChangeRequestFull.Object[mpcChangeRequest, "Description"].Value = Guid.NewGuid().ToString();
                    int intRandomEnumID = Helper.GetRandomNumber(0, listCRAreaEnums.Count);
                    ManagementPackEnumeration mpeArea = listCRAreaEnums.ElementAtOrDefault<ManagementPackEnumeration>(intRandomEnumID);
                    emopChangeRequestFull.Object[mpcChangeRequestExtension, "Area"].Value = mpeArea;


                    //Add the current user as an affected CI
                    emopChangeRequestFull.Add(emoUser, mprAffectedCI.Target);

                    if (bSimulateHumanWaitTime)
                        Thread.Sleep(intDoWorkPause);

                    //Commit the changes to the DB
                    emopChangeRequestFull.Overwrite();

                    foreach (IComposableProjection icpRelatedCI in emopChangeRequestFull[mprRelatedCI.Target])
                    {
                        icpRelatedCI.Remove();
                    }

                    emopChangeRequestFull.Overwrite();

                    DateTime dtChangeRequestWorkEnd = DateTime.Now;
                    TimeSpan tsChangeRequestWork = dtChangeRequestWorkEnd - dtChangeRequestWorkStart;
                    pcChangeRequestWork.RawValue = (long)tsChangeRequestWork.TotalSeconds;
                    Console.WriteLine("Change request work completed (seconds): " + tsChangeRequestWork.TotalSeconds);
                }
            }
        }

        private static void DoSomeServiceRequestWork()
        {
            DateTime dtServiceRequestWorkStart = DateTime.Now;

            int intRandomAreaEnum = Helper.GetRandomNumber(0, listSRAreaEnums.Count);
            ManagementPackEnumeration mpeRadomArea = listSRAreaEnums.ElementAtOrDefault<ManagementPackEnumeration>(intRandomAreaEnum);
            string strCriteria = Helper.SearchObjectByEnumerationCriteriaXml(mpeRadomArea, mpcServiceRequest, mppServiceRequestArea);
            IObjectProjectionReader<EnterpriseManagementObject> oprServiceRequestsView = Helper.GetBufferedObjectProjectionReader(strCriteria, intNumberOfWorkItemsToGet, mptpServiceRequestView, emg);

            if (oprServiceRequestsView == null)
            {
                Console.WriteLine("No objects to retrieve given the criteria");
            }
            else
            {
                //Get a particular service request (full projection) and update it by adding an action log entry and 
                string strServiceRequestId = null;
                if (oprServiceRequestsView.Count > 0)
                {
                    strServiceRequestId = oprServiceRequestsView.ElementAtOrDefault<EnterpriseManagementObjectProjection>(Helper.GetRandomNumber(0, oprServiceRequestsView.Count - 1)).Object[mpcServiceRequest, "Id"].Value.ToString();
                }

                if (strServiceRequestId != null)
                {
                    string strCriteriaXml = Helper.SearchWorkItemByIDCriteriaXml(strServiceRequestId, mpSystemWorkItemLibrary.Name, mpSystemWorkItemLibrary.Version.ToString(), mpSystemWorkItemLibrary.KeyToken, "System.WorkItem");
                    ObjectProjectionCriteria opServiceRequestFull = new ObjectProjectionCriteria(strCriteriaXml, mptpServiceRequestFull, emg);
                    IObjectProjectionReader<EnterpriseManagementObject> oprServiceRequestFull = emg.EntityObjects.GetObjectProjectionReader<EnterpriseManagementObject>(opServiceRequestFull, ObjectQueryOptions.Default);
                    EnterpriseManagementObjectProjection emopServiceRequestFull = oprServiceRequestFull.First<EnterpriseManagementObjectProjection>();

                    if (bSimulateHumanWaitTime)
                        Thread.Sleep(intDoWorkPause);

                    emopServiceRequestFull.Object[mpcServiceRequest, "Description"].Value = Guid.NewGuid().ToString();
                    int intRandomEnumId = Helper.GetRandomNumber(0, listSRAreaEnums.Count);
                    ManagementPackEnumeration mpeArea = listSRAreaEnums.ElementAtOrDefault<ManagementPackEnumeration>(intRandomEnumId);
                    emopServiceRequestFull.Object[mpcServiceRequestExtension, "Area"].Value = mpeArea;

                    emopServiceRequestFull.Overwrite();

                    DateTime dtServiceRequestWorkEnd = DateTime.Now;
                    TimeSpan tsServiceRequestWork = dtServiceRequestWorkEnd - dtServiceRequestWorkStart;
                    pcServiceRequestWork.RawValue = (long)tsServiceRequestWork.TotalSeconds;
                    Console.WriteLine("Service request work completed (seconds): " + tsServiceRequestWork.TotalSeconds);
                }
            }
        }

        private static void DoSomeProblemWork()
        {
            DateTime dtProblemWorkStart = DateTime.Now;

            int intRadomClassification = Helper.GetRandomNumber(0, listProblemClassificationEnums.Count);
            ManagementPackEnumeration mpeRandomClassification = listProblemClassificationEnums.ElementAtOrDefault<ManagementPackEnumeration>(intRadomClassification);
            string strClassificationCriteriaXml = Helper.SearchObjectByEnumerationCriteriaXml(mpeRandomClassification, mpcProblem, mppProblemClassification);
            IObjectProjectionReader<EnterpriseManagementObject> oprProblemView = Helper.GetBufferedObjectProjectionReader(strClassificationCriteriaXml, intNumberOfWorkItemsToGet, mptpProblemView, emg);

            if(oprProblemView == null)
            {
                Console.WriteLine("No objects to retrieve given the criteria");
            }
            else
            {
                //Get a particular problem (full projection) and update it by adding an action log entry and 
                string strProblemId = null;
                if (oprProblemView.Count > 0)
                {
                    strProblemId = oprProblemView.ElementAtOrDefault<EnterpriseManagementObjectProjection>(Helper.GetRandomNumber(0, oprProblemView.Count - 1)).Object[mpcProblem, "Id"].Value.ToString();
                }

                if (strProblemId != null)
                {
                    string strCriteriaXml = Helper.SearchWorkItemByIDCriteriaXml(strProblemId, mpSystemWorkItemLibrary.Name, mpSystemWorkItemLibrary.Version.ToString(), mpSystemWorkItemLibrary.KeyToken, "System.WorkItem");
                    ObjectProjectionCriteria opcProblemFull = new ObjectProjectionCriteria(strCriteriaXml, mptpProblemFull, emg);
                    IObjectProjectionReader<EnterpriseManagementObject> oprProblemFull = emg.EntityObjects.GetObjectProjectionReader<EnterpriseManagementObject>(opcProblemFull, ObjectQueryOptions.Default);
                    EnterpriseManagementObjectProjection emopProblemFull = oprProblemFull.First<EnterpriseManagementObjectProjection>();

                    emopProblemFull.Object[mpcProblem, "Description"].Value = Guid.NewGuid().ToString();
                    int intRandomEnumID = Helper.GetRandomNumber(0, listProblemClassificationEnums.Count);
                    ManagementPackEnumeration mpeClassification = listProblemClassificationEnums.ElementAtOrDefault<ManagementPackEnumeration>(intRandomEnumID);
                    emopProblemFull.Object[mpcProblemExtension, "Classification"].Value = mpeClassification;

                    //EnterpriseManagementObjectCriteria emocComputer = new EnterpriseManagementObjectCriteria();
                    ObjectQueryOptions oqoComputer = new ObjectQueryOptions();
                    oqoComputer.MaxResultCount = 5;
                    oqoComputer.DefaultPropertyRetrievalBehavior = ObjectPropertyRetrievalBehavior.All;
                    oqoComputer.ObjectRetrievalMode = ObjectRetrievalOptions.Buffered;
                    IObjectReader<EnterpriseManagementObject> orComputers = emg.EntityObjects.GetObjectReader<EnterpriseManagementObject>(mpcComputer, oqoComputer);

                    if (bSimulateHumanWaitTime)
                        Thread.Sleep(intDoWorkPause);

                    emopProblemFull.Overwrite();

                    DateTime dtProblemWorkEnd = DateTime.Now;
                    TimeSpan tsProblemWork = dtProblemWorkEnd - dtProblemWorkStart;
                    pcProblemWork.RawValue = (long)tsProblemWork.TotalSeconds;
                    Console.WriteLine("Problem work completed (seconds): " + tsProblemWork.TotalSeconds);
                }
            }
        }

        #endregion

        private static void WorkItemQueryUpdate(object source, ElapsedEventArgs e)
        {
            try
            {
                DateTime dtDoWorkStart = DateTime.Now;

                //Total time to complete is intDoWorkPause * 14
                // 4 pauses - in between each work item do work job
                // Each do work job has 2 * intDoWorkPauses as Thread.Sleeps inside of them

                Console.WriteLine("Doing Incident Work");
                DoSomeIncidentWork();

                //Wait for a bit before you do something else
                if (bSimulateHumanWaitTime)
                    Thread.Sleep(intDoWorkPause);

                Console.WriteLine("Doing Change Request Work");
                DoSomeChangeRequestWork();

                //Wait for a bit before you do something else
                if (bSimulateHumanWaitTime)
                    Thread.Sleep(intDoWorkPause);

                Console.WriteLine("Doing Service Request Work");
                DoSomeServiceRequestWork();

                //Wait for a bit before you do something else
                if (bSimulateHumanWaitTime)
                    Thread.Sleep(intDoWorkPause);

                Console.WriteLine("Doing Problem Work");
                DoSomeProblemWork();

                //Wait for a bit before you do something else
                if (bSimulateHumanWaitTime)
                    Thread.Sleep(intDoWorkPause);

                Console.WriteLine("Doing Some More Incident Work");
                DoSomeIncidentWork();

                DateTime dtDoWorkEnd = DateTime.Now;
                TimeSpan tsDoWork = dtDoWorkEnd - dtDoWorkStart;
                pcDoWork.RawValue = (long)tsDoWork.TotalSeconds;
                Console.WriteLine("Do work completed (seconds): " + tsDoWork.TotalSeconds);
                Console.WriteLine("Do work interval (seconds): " + intRateOfWorkItemQueryAndUpdates / 1000);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
            }
        }

        private static void CreateWorkItemsFromTemplate(ManagementPackObjectTemplate templateWorkItem)
        {
            try
            {
                Console.WriteLine("Creating work item...");
                EnterpriseManagementObjectProjection emopIncident = new EnterpriseManagementObjectProjection(emg, templateWorkItem);
                emopIncident.Commit();
                if (dtWorkItemCreateLast != DateTime.MinValue)
                {
                    TimeSpan tsWorkItemCreateInterval = DateTime.Now - dtWorkItemCreateLast;
                    pcWorkItemCreateInterval.RawValue = (long)tsWorkItemCreateInterval.TotalSeconds;
                    Console.WriteLine("WI Create Interval: " + tsWorkItemCreateInterval.TotalSeconds);
                    Console.WriteLine("Target WI Interval: " + dRateInSeconds);
                }
                if (dtWorkItemCreateLast != null)
                {

                }
                dtWorkItemCreateLast = DateTime.Now;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.InnerException.Message);
            }
        }

        private static double ConvertRateToInterval(int intDailyTotal, int intWorkingHoursPerDay)
        {
            if (intDailyTotal > 0 &&
                intWorkingHoursPerDay > 0)
            {
                dRate = intWorkingHoursPerDay * 60 * 60 * 1000 / intDailyTotal;
                dRateInSeconds = dRate / 1000;
                Console.WriteLine("Rate (seconds): " + dRateInSeconds);
                return (dRate);
            }
            else
            {
                return 0;
            }
        }
    }
}