using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using System.Collections.ObjectModel;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Packaging;

namespace Microsoft.SystemCenter.Test.LoadGen
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnStartLoad_Click(object sender, EventArgs e)
        {
            StartLoad((int)nudStartupInterval.Value);
        }

        public void StartLoad(int intStartupInterval)
        {
            Collection<Process> listProcesses = new Collection<Process>();
            DateTime dtBegin = DateTime.UtcNow;

            string strSupportGroupFilePath = txtSupportGroupFilePath.Text;

            string[] strSupportGroups = System.IO.File.ReadAllLines(strSupportGroupFilePath);

            int intSupportGroupCount = strSupportGroups.Length;
            int intWorkersCreatingIncidents = (int)Math.Abs(intSupportGroupCount * nudPercentOfWorkersCreatingIncidents.Value / 100);
            int intWorkersCreatingChangeRequests = (int)Math.Abs(intSupportGroupCount * nudPercentOfWorkersCreatingChangeRequests.Value / 100);
            int intWorkersCreatingServiceRequests = (int)Math.Abs(intSupportGroupCount * nudPercentOfWorkersCreatingServiceRequests.Value / 100);
            int intWorkersCreatingProblems = (int)Math.Abs(intSupportGroupCount * nudPercentOfWorkersCreatingProblems.Value / 100);
            int intWorkersCreatingReleases = (int)Math.Abs(intSupportGroupCount * nudPercentOfWorkersCreatingReleases.Value / 100);

            int intUpperLimitOfIncidentWorkers = intWorkersCreatingIncidents;
            int intUpperLimitOfChangeRequestWorkers = intUpperLimitOfIncidentWorkers + intWorkersCreatingChangeRequests < intSupportGroupCount ? intUpperLimitOfIncidentWorkers + intWorkersCreatingChangeRequests : 0;
            int intUpperLimitOfServiceRequestWorkers = intUpperLimitOfChangeRequestWorkers + intWorkersCreatingServiceRequests < intSupportGroupCount ? intUpperLimitOfChangeRequestWorkers + intWorkersCreatingServiceRequests : 0;
            int intUpperLimitOfProblemWorkers = intUpperLimitOfServiceRequestWorkers + intWorkersCreatingProblems < intSupportGroupCount ? intUpperLimitOfServiceRequestWorkers + intWorkersCreatingProblems : 0;
            int intUpperLimitOfReleaseWorkers = intUpperLimitOfProblemWorkers + intWorkersCreatingReleases < intSupportGroupCount ? intUpperLimitOfProblemWorkers + intWorkersCreatingReleases : 0;

            int intNumberOfIncidentsEachWorkerCreates = CalculateNumberOfWorkItemsPerWorker((int)nudNumberOfIncidentsToCreate.Value , intWorkersCreatingIncidents);
            int intNumberOfIncidentsEachWorkerCreatesPerDay = CalculateNumberOfWorkItemsPerWorker((int)nudNumberOfIncidentsToCreatePerDay.Value , intWorkersCreatingIncidents);
            int intNumberOfChangeRequestsEachWorkerCreates = CalculateNumberOfWorkItemsPerWorker((int)nudNumberOfChangeRequestsToCreate.Value , intWorkersCreatingChangeRequests);
            int intNumberOfChangeRequestsEachWorkerCreatesPerDay = CalculateNumberOfWorkItemsPerWorker((int)nudNumberOfChangeRequestsToCreatePerDay.Value , intWorkersCreatingChangeRequests);
            int intNumberOfServiceRequestsEachWorkerCreates = CalculateNumberOfWorkItemsPerWorker((int)nudNumberOfServiceRequestsToCreate.Value , intWorkersCreatingServiceRequests);
            int intNumberOfServiceRequestsEachWorkerCreatesPerDay = CalculateNumberOfWorkItemsPerWorker((int)nudNumberOfServiceRequestsToCreatePerDay.Value , intWorkersCreatingServiceRequests);
            int intNumberOfProblemsEachWorkerCreates = CalculateNumberOfWorkItemsPerWorker((int)nudNumberOfProblemsToCreate.Value , intWorkersCreatingProblems);
            int intNumberOfProblemsEachWorkerCreatesPerDay = CalculateNumberOfWorkItemsPerWorker((int)nudNumberOfProblemsToCreatePerDay.Value , intWorkersCreatingProblems);
            int intNumberOfReleasesEachWorkerCreates = CalculateNumberOfWorkItemsPerWorker((int)nudNumberOfReleasesToCreate.Value , intWorkersCreatingReleases);
            int intNumberOfReleasesEachWorkerCreatesPerDay = CalculateNumberOfWorkItemsPerWorker((int)nudNumberOfReleasesToCreatePerDay.Value , intWorkersCreatingReleases);

            int i= 1;

            CreatePerformanceCounters();

            foreach(string strSupportGroup in strSupportGroups)
            {

                Worker worker = new Worker();
                string strUserName = strSupportGroup + "User";
                string strWorkItemClassToCreate = null;

                if (i <= intUpperLimitOfIncidentWorkers)
                {
                    strWorkItemClassToCreate = "Incident";
                }
                else if (i > intUpperLimitOfIncidentWorkers &&
                         i <= intUpperLimitOfChangeRequestWorkers)
                {
                    strWorkItemClassToCreate = "ChangeRequest";
                }
                else if (i > intUpperLimitOfChangeRequestWorkers &&
                         i <= intUpperLimitOfServiceRequestWorkers)
                {
                    strWorkItemClassToCreate = "ServiceRequest";
                }
                else if (i > intUpperLimitOfServiceRequestWorkers &&
                         i <= intUpperLimitOfProblemWorkers)
                {
                    strWorkItemClassToCreate = "Problem";
                }
                else
                {
                    strWorkItemClassToCreate = "Release";
                }

                int intProcID = worker.Start(   strUserName, 
                                                txtServerName.Text, 
                                                strWorkItemClassToCreate,
                                                txtDomain.Text,
                                                intNumberOfIncidentsEachWorkerCreatesPerDay,
                                                intNumberOfIncidentsEachWorkerCreates,
                                                intNumberOfChangeRequestsEachWorkerCreatesPerDay,
                                                intNumberOfChangeRequestsEachWorkerCreates,
                                                intNumberOfServiceRequestsEachWorkerCreatesPerDay,
                                                intNumberOfServiceRequestsEachWorkerCreates,
                                                intNumberOfProblemsEachWorkerCreatesPerDay,
                                                intNumberOfProblemsEachWorkerCreates,
                                                intNumberOfReleasesEachWorkerCreatesPerDay,
                                                intNumberOfReleasesEachWorkerCreates,
                                                (int)nudNumberOfWorkingHoursPerDay.Value,
                                                (int)nudWorkItemQueryUpdateRate.Value, 
                                                (int)nudDoWorkPause.Value,
                                                (int)nudNumberOfWorkItemsToGet.Value
                                                );

                //Staggered start so we arent creating a bunch of EMGs all at the same time.
                Thread.Sleep(intStartupInterval);
                i++;
            }
            
            bool bAllProcessesExited = false;
            //Wait until all threads are aborted
            do
            {
                bAllProcessesExited = true;
                foreach (Process process in listProcesses)
                {
                    if (!process.HasExited) { bAllProcessesExited = false; }
                }
                Thread.Sleep(3000);
            } while (!bAllProcessesExited);
            DateTime dtEnd = DateTime.UtcNow;
            TimeSpan tsTotalElapsedTime = dtEnd - dtBegin;
            MessageBox.Show("Total Elapsed Time: " + tsTotalElapsedTime.ToString());
        }

        private void btnBrowseForSupportGroupFilePath_Click(object sender, EventArgs e)
        {
            DialogResult drSupportGroupFileDialogResult = openFileDialogSupportGroupFile.ShowDialog();
            if (drSupportGroupFileDialogResult == DialogResult.OK)
            {
                txtSupportGroupFilePath.Text = openFileDialogSupportGroupFile.FileName;
            }
        }

        private int CalculateNumberOfWorkItemsPerWorker(int intNumberOfWorkItemsToCreate, int intNumberOfWorkers)
        {
            if (intNumberOfWorkers > 0 &&
                intNumberOfWorkItemsToCreate > 0)
            {
                if (intNumberOfWorkItemsToCreate < intNumberOfWorkers)
                {
                    MessageBox.Show("Number of work items to create is smaller than the number of workers.  Please adjust.");
                }
                return (int)Math.Abs(intNumberOfWorkItemsToCreate / intNumberOfWorkers);
            }
            else
            {
                return 0;
            }
        }

        private void CreatePerformanceCounters()
        {
            if (PerformanceCounterCategory.Exists("SCSMPerf"))
                PerformanceCounterCategory.Delete("SCSMPerf");

            CounterCreationDataCollection ccdcCounterCollection = new CounterCreationDataCollection();

            CreatePerformanceCounter("Work Item Creation Interval", ref ccdcCounterCollection);
            CreatePerformanceCounter("Incident Work Completion Time", ref ccdcCounterCollection);
            CreatePerformanceCounter("Change Request Work Completion Time", ref ccdcCounterCollection);
            CreatePerformanceCounter("Problem Work Completion Time", ref ccdcCounterCollection);
            CreatePerformanceCounter("Service Request Work Completion Time", ref ccdcCounterCollection);
            CreatePerformanceCounter("Management Group Create Time", ref ccdcCounterCollection);
            CreatePerformanceCounter("Do Work Completion Time", ref ccdcCounterCollection);
            CreatePerformanceCounter("Caching Completion Time", ref ccdcCounterCollection);
            CreatePerformanceCounter("Incident Query Time", ref ccdcCounterCollection);
            CreatePerformanceCounter("Get Single Incident", ref ccdcCounterCollection);
            CreatePerformanceCounter("Update Incident", ref ccdcCounterCollection);

            PerformanceCounterCategory.Create("SCSMPerf", "", PerformanceCounterCategoryType.SingleInstance, ccdcCounterCollection);
        }

        private void CreatePerformanceCounter(string strCounterName, ref CounterCreationDataCollection  ccdcCounterCollection)
        {
            CounterCreationData ccd = new CounterCreationData();
            ccd.CounterName = strCounterName;
            ccd.CounterType = PerformanceCounterType.NumberOfItems32;
            ccdcCounterCollection.Add(ccd);
        }

    }

    public class Worker
    {
        public Worker()
        {
        }

        public int Start(   string strUserName, 
                            string strServerName, 
                            string strWorkItemClassToCreate,
                            string strDomain,
                            int intIncidnetsPerDay,
                            int intIncidnetsToCreate,
                            int intChangeRequestsPerDay,
                            int intChangeRequestsToCreate,
                            int intServiceRequestsPerDay,
                            int intServiceRequestsToCreate,
                            int intProblemsPerDay,
                            int intProblemsToCreate,
                            int intReleasesPerDay,
                            int intReleasesToCreate,
                            int intNumberOfWorkingHoursPerDay,
                            int intWorkItemQueryUpdateRate,
                            int intDoWorkPause,
                            int intNumberOfWorkItemsToGet
                            )
        {
            char[] charPassword = {'P', '@', 's', 's', 'w', '0', 'r', 'd'};
            System.Security.SecureString ssPassword = new System.Security.SecureString();
            foreach(char c in charPassword)
            {
                ssPassword.AppendChar(c);
            }

            ProcessStartInfo psiWorkerProcess = new ProcessStartInfo();
            psiWorkerProcess.FileName = "C:\\PerfTestHarness\\LoadGen\\LoadGen\\LoadGen\\bin\\Debug\\Loader.exe";
            psiWorkerProcess.Arguments = strServerName + " "
                                        + strWorkItemClassToCreate + " "
                                        + intIncidnetsPerDay.ToString() + " "
                                        + intIncidnetsToCreate.ToString() + " "
                                        + intChangeRequestsPerDay.ToString() + " "
                                        + intChangeRequestsToCreate.ToString() + " "
                                        + intServiceRequestsPerDay.ToString() + " "
                                        + intServiceRequestsToCreate.ToString() + " "
                                        + intProblemsPerDay.ToString() + " "
                                        + intProblemsToCreate.ToString() + " "
                                        + intReleasesPerDay.ToString() + " "
                                        + intReleasesToCreate.ToString() + " "
                                        + intNumberOfWorkingHoursPerDay.ToString() + " "
                                        + intWorkItemQueryUpdateRate + " "
                                        + intDoWorkPause + " "
                                        + intNumberOfWorkItemsToGet;

            psiWorkerProcess.Domain = strDomain;
            psiWorkerProcess.CreateNoWindow = true;
            psiWorkerProcess.Password = ssPassword;
            psiWorkerProcess.UseShellExecute = false;
            psiWorkerProcess.WorkingDirectory = "C:\\PerfTestHarness\\LoadGen\\LoadGen\\LoadGen\\bin\\Debug";
            psiWorkerProcess.UserName = strUserName;
            Process proc = new Process();
            proc.StartInfo = psiWorkerProcess;
            proc.Start();
            return proc.Id;
        }
    }
}
