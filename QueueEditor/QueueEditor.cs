using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Helper;

namespace QueueEditor
{
    public partial class QueueEditor : Form
    {
        public QueueEditor()
        {
            InitializeComponent();
        }

        private void btnDisableAll_Click(object sender, EventArgs e)
        {
            SetQueueStatus(false);
        }
        
        private void btnEnableAll_Click(object sender, EventArgs e)
        {
            SetQueueStatus(true);
        }

        private void SetQueueStatus(Boolean bEnabled)
        {
            EnterpriseManagementGroup emg = new EnterpriseManagementGroup(txtManagementServer.Text);
            //TODO: Switch this back to 'WorkItemGroup.%'  Had to temporarily change this due to a bad naming convention in the code that has been fixed.
            string strQueueDiscoveryCriteria = "Name LIKE '[cspi]%Discovery%'";
            ManagementPackDiscoveryCriteria mpdc = new ManagementPackDiscoveryCriteria(strQueueDiscoveryCriteria);
            IList<ManagementPackDiscovery> listDiscoveries = emg.Monitoring.GetDiscoveries(mpdc);
            pbProgress.Value = 0;
            pbProgress.Show();
            double dDiscoveriesCount = listDiscoveries.Count;
            double i = 0;
            ManagementPack mp = null;
            foreach (ManagementPackDiscovery discovery in listDiscoveries)
            {
                i++;
                if (bEnabled == true)
                {
                    discovery.Enabled = ManagementPackMonitoringLevel.@true;
                }
                else
                {
                    discovery.Enabled = ManagementPackMonitoringLevel.@false;
                }
                discovery.Status = ManagementPackElementStatus.PendingUpdate;
                mp = discovery.GetManagementPack();
                double dComplete = i / dDiscoveriesCount * 100;
                pbProgress.Value = (int)dComplete;
            }
            mp.AcceptChanges();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            EnterpriseManagementGroup emg = new EnterpriseManagementGroup(txtManagementServer.Text);
            ManagementPackEnumeration mpeSRAreaBase = Helper.GetEnumerationByName("ServiceRequestAreaEnum", emg);
            ManagementPackEnumeration mpeCRAreaBase = Helper.GetEnumerationByName("ChangeAreaEnum", emg);
            ManagementPackEnumeration mpeProblemAreaBase = Helper.GetEnumerationByName("ProblemClassificationEnum", emg);
            ManagementPackEnumeration mpeIncidentAreaBase = Helper.GetEnumerationByName("IncidentClassificationEnum", emg);

            IList<ManagementPackEnumeration> listSRAreaEnums = emg.EntityTypes.GetChildEnumerations(mpeSRAreaBase.Id, TraversalDepth.Recursive);
            IList<ManagementPackEnumeration> listCRAreaEnums = emg.EntityTypes.GetChildEnumerations(mpeCRAreaBase.Id, TraversalDepth.Recursive);
            IList<ManagementPackEnumeration> listProblemAreaEnums = emg.EntityTypes.GetChildEnumerations(mpeProblemAreaBase.Id, TraversalDepth.Recursive);
            IList<ManagementPackEnumeration> listIncidentAreaEnums = emg.EntityTypes.GetChildEnumerations(mpeIncidentAreaBase.Id, TraversalDepth.Recursive);

            ManagementPackClass mpcServiceRequest = Helper.GetClassByName("System.WorkItem.ServiceRequest", emg);
            ManagementPackClass mpcChangeRequest = Helper.GetClassByName("System.WorkItem.ChangeRequest", emg);
            ManagementPackClass mpcProblem = Helper.GetClassByName("System.WorkItem.Problem", emg);
            ManagementPackClass mpcIncident = Helper.GetClassByName("System.WorkItem.Incident", emg);

            ManagementPack mpServiceRequest = Helper.GetManagementPackByName("System.WorkItem.ServiceRequest.Library", emg);
            ManagementPack mpChangeRequest = Helper.GetManagementPackByName("System.WorkItem.ChangeRequest.Library", emg);
            ManagementPack mpProblem = Helper.GetManagementPackByName("System.WorkItem.Problem.Library", emg);
            ManagementPack mpIncident = Helper.GetManagementPackByName("System.WorkItem.Incident.Library", emg);

            ManagementPackReference mprServiceRequest = new ManagementPackReference(mpServiceRequest);
            ManagementPackReference mprChangeRequest = new ManagementPackReference(mpChangeRequest);
            ManagementPackReference mprProblem = new ManagementPackReference(mpProblem);
            ManagementPackReference mprIncident = new ManagementPackReference(mpIncident);

            ManagementPack mp = Helper.CreateNewManagementPackInMemory("Queues", "1.0.0.0", "Queues", "QUEUES", emg, true);

            string strMPAliasServiceRequestLibrary = Helper.MakeMPElementSafeName(mpServiceRequest.Name);
            string strMPAliasChangeRequestLibrary = Helper.MakeMPElementSafeName(mpChangeRequest.Name);
            string strMPAliasProblemLibrary = Helper.MakeMPElementSafeName(mpProblem.Name);
            string strMPAliasIncidentLibrary = Helper.MakeMPElementSafeName(mpIncident.Name);
            
            mp.References.Add(strMPAliasServiceRequestLibrary, mprServiceRequest);
            mp.References.Add(strMPAliasChangeRequestLibrary, mprChangeRequest);
            mp.References.Add(strMPAliasProblemLibrary, mprProblem);
            mp.References.Add(strMPAliasIncidentLibrary, mprIncident);

            double dQueuesToCreate = listSRAreaEnums.Count + listCRAreaEnums.Count + listProblemAreaEnums.Count + listIncidentAreaEnums.Count;
            pbProgress.Show();
            pbProgress.Value = 0;
            double i = 0;

            foreach (ManagementPackEnumeration mpeSRArea in listSRAreaEnums)
            {
                i++;
                ManagementPackProperty mppArea = Helper.GetManagementPackClassPropertyByName("System.WorkItem.ServiceRequest", "Area", emg);
                CreateQueue(mpcServiceRequest, mpeSRArea, strMPAliasServiceRequestLibrary, mppArea, ref mp, emg);
                pbProgress.Value = (int)(i / dQueuesToCreate * 100);
            }

            foreach (ManagementPackEnumeration mpeCRArea in listCRAreaEnums)
            {
                i++;
                ManagementPackProperty mppArea = Helper.GetManagementPackClassPropertyByName("System.WorkItem.ChangeRequest", "Area", emg);
                CreateQueue(mpcChangeRequest, mpeCRArea, strMPAliasChangeRequestLibrary, mppArea, ref mp, emg);
                pbProgress.Value = (int)(i / dQueuesToCreate * 100);
            }

            foreach (ManagementPackEnumeration mpeProblemClassification in listProblemAreaEnums)
            {
                i++;
                ManagementPackProperty mppClassification = Helper.GetManagementPackClassPropertyByName("System.WorkItem.Problem", "Classification", emg);
                CreateQueue(mpcProblem, mpeProblemClassification, strMPAliasProblemLibrary, mppClassification, ref mp, emg);
                pbProgress.Value = (int)(i / dQueuesToCreate * 100);
            }

            foreach (ManagementPackEnumeration mpeIncidentClassification in listIncidentAreaEnums)
            {
                i++;
                ManagementPackProperty mppClassification = Helper.GetManagementPackClassPropertyByName("System.WorkItem.Incident", "Classification", emg);
                CreateQueue(mpcIncident, mpeIncidentClassification, strMPAliasIncidentLibrary, mppClassification, ref mp, emg);
                pbProgress.Value = (int)(i / dQueuesToCreate * 100);
            }

            lblStatus.Text = "Importing Manamgeent Pack...";
            emg.ManagementPacks.ImportManagementPack(mp);
            lblStatus.Text = "Importing Manamgeent Pack...DONE!";
        }

        private static void CreateQueue(ManagementPackClass mpc, ManagementPackEnumeration mpe, string strMPAlias, ManagementPackProperty mpp, ref ManagementPack mp, EnterpriseManagementGroup emg)
        {
            string strQueueDisplayName = String.Format("{0}: {1}", mpc.DisplayName, mpe.DisplayName);
            string strCriteria = ConstructCriteria(strMPAlias, mpc, mpp, mpe);
            Helper.CreateQueue(strQueueDisplayName, Helper.MakeMPElementSafeName(strQueueDisplayName), strCriteria, mpc, ref mp, emg);
        }

        private static string ConstructCriteria(string strMPAlias, ManagementPackClass mpc, ManagementPackProperty mppp, ManagementPackEnumeration mpe)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Expression>");
            sb.Append("<SimpleExpression>");
            sb.Append("<ValueExpression>");
            sb.Append(String.Format("<Property>$Context/Property[Type='{0}!{1}']/{2}$</Property>", strMPAlias, mpc.Name, mppp.Name));
            //sb.Append(String.Format("<Property>$Context/Property[Type='{0}']/{1}$</Property>", mpc.Id.ToString(), mppp.Id.ToString()));
            sb.Append("</ValueExpression>");
            sb.Append("<Operator>Equal</Operator>");
            sb.Append("<ValueExpression>");
            sb.Append(String.Format("<Value>{{{0}}}</Value>", mpe.Id.ToString()));
            sb.Append("</ValueExpression>");
            sb.Append("</SimpleExpression>");
            sb.Append("</Expression>");
            return sb.ToString();
        }
    }
}
