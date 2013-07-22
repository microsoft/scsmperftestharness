using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Helper;

namespace NotificationRuleEditor
{
    public partial class NotificationRuleEditor : Form
    {
        enum SubscriptionType
        {
            Add = 0,
            Update = 1
        }

        public NotificationRuleEditor()
        {
            InitializeComponent();
        }

        private void btnDisableAll_Click(object sender, EventArgs e)
        {
            SetRuleStatus(false);
        }

        private void btnEnableAll_Click(object sender, EventArgs e)
        {
            SetRuleStatus(true);
        }

        private void SetRuleStatus(bool bEnabled)
        {
            EnterpriseManagementGroup emg = new EnterpriseManagementGroup(txtManagementServer.Text);
            string strRuleCriteria = "Name LIKE 'NotificationSubscription%'";
            ManagementPackRuleCriteria mprc = new ManagementPackRuleCriteria(strRuleCriteria);
            IList<ManagementPackRule> listRules = emg.Monitoring.GetRules(mprc);
            double dRulesCount = listRules.Count;
            double i = 0;
            pbProgress.Value = 0;
            pbProgress.Style = ProgressBarStyle.Continuous;
            pbProgress.Show();
            //TODO: Undo this MP hackery.
            ManagementPack mp = null;
            foreach (ManagementPackRule rule in listRules)
            {
                i++;
                if (rule.Enabled != ManagementPackMonitoringLevel.@false && bEnabled == false)
                {
                    rule.Enabled = ManagementPackMonitoringLevel.@false;
                    rule.Status = ManagementPackElementStatus.PendingUpdate;
                    //TODO: Undo this MP hackery.
                    mp = rule.GetManagementPack();
                }
                else  if (rule.Enabled != ManagementPackMonitoringLevel.@true && bEnabled == true)
                {
                    rule.Enabled = ManagementPackMonitoringLevel.@true;
                    rule.Status = ManagementPackElementStatus.PendingUpdate;
                    //TODO: Undo this MP hackery.
                    mp = rule.GetManagementPack();
                }
                double dProgress = i / (dRulesCount) * 100;
                pbProgress.Value = (int)dProgress;
            }
            pbProgress.Style = ProgressBarStyle.Marquee;
            lblStatus.Text = "Accepting changes to MP...";
            mp.AcceptChanges();
            pbProgress.Style = ProgressBarStyle.Continuous;
            pbProgress.Value = 100;
            lblStatus.Text= "Done!";
            lblStatus.ForeColor = Color.Red;
            lblStatus.Height = lblStatus.Height * 3;

            return;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            EnterpriseManagementGroup emg = new EnterpriseManagementGroup(txtManagementServer.Text);

            ManagementPackEnumeration mpeSRAreaBase = Helper.GetEnumerationByName("ServiceRequestAreaEnum", emg);
            ManagementPackEnumeration mpeCRAreaBase = Helper.GetEnumerationByName("ChangeAreaEnum", emg);
            ManagementPackEnumeration mpeProblemClassificationBase = Helper.GetEnumerationByName("ProblemClassificationEnum", emg);
            ManagementPackEnumeration mpeIncidentClassificationBase = Helper.GetEnumerationByName("IncidentClassificationEnum", emg);

            IList<ManagementPackEnumeration> listSRAreaEnums = emg.EntityTypes.GetChildEnumerations(mpeSRAreaBase.Id, TraversalDepth.Recursive);
            IList<ManagementPackEnumeration> listCRAreaEnums = emg.EntityTypes.GetChildEnumerations(mpeCRAreaBase.Id, TraversalDepth.Recursive);
            IList<ManagementPackEnumeration> listProblemAreaEnums = emg.EntityTypes.GetChildEnumerations(mpeProblemClassificationBase.Id, TraversalDepth.Recursive);
            IList<ManagementPackEnumeration> listIncidentAreaEnums = emg.EntityTypes.GetChildEnumerations(mpeIncidentClassificationBase.Id, TraversalDepth.Recursive);

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

            ManagementPack mp = Helper.CreateNewManagementPackInMemory("NotificationRules", "1.0.0.0", "NotificationRules", "NOTIFICATION_RULES", emg, true);

            string strMPAliasServiceRequestLibrary = Helper.MakeMPElementSafeName(mpServiceRequest.Name);
            string strMPAliasChangeRequestLibrary = Helper.MakeMPElementSafeName(mpChangeRequest.Name);
            string strMPAliasProblemLibrary = Helper.MakeMPElementSafeName(mpProblem.Name);
            string strMPAliasIncidentLibrary = Helper.MakeMPElementSafeName(mpIncident.Name);

            mp.References.Add(strMPAliasServiceRequestLibrary, mprServiceRequest);
            mp.References.Add(strMPAliasChangeRequestLibrary, mprChangeRequest);
            mp.References.Add(strMPAliasProblemLibrary, mprProblem);
            mp.References.Add(strMPAliasIncidentLibrary, mprIncident);

            ManagementPackObjectTemplate mpotNewIncident = Helper.GetObjectTemplateByName(txtNewIncidentTemplate.Text, emg);
            ManagementPackObjectTemplate mpotUpdateIncident = Helper.GetObjectTemplateByName(txtUpdateIncidentTemplate.Text, emg);
            ManagementPackObjectTemplate mpotNewServiceRequest = Helper.GetObjectTemplateByName(txtNewServiceRequestTemplate.Text, emg);
            ManagementPackObjectTemplate mpotUpdateServiceRequest = Helper.GetObjectTemplateByName(txtUpdateServiceRequestTemplate.Text, emg);
            ManagementPackObjectTemplate mpotNewChangeRequest = Helper.GetObjectTemplateByName(txtNewChangeRequestTemplate.Text, emg);
            ManagementPackObjectTemplate mpotUpdateChangeRequest = Helper.GetObjectTemplateByName(txtUpdateChangeRequestTemplate.Text, emg);
            ManagementPackObjectTemplate mpotNewProblem = Helper.GetObjectTemplateByName(txtNewProblemTemplate.Text, emg);
            ManagementPackObjectTemplate mpotUpdateProblem = Helper.GetObjectTemplateByName(txtUpdateProblemTemplate.Text, emg);

            EnterpriseManagementObject emoUser = Helper.GetUserFromEmailAddress(txtEmailAddress.Text, emg);

            double dRulesToCreate = listSRAreaEnums.Count + listCRAreaEnums.Count + listProblemAreaEnums.Count + listIncidentAreaEnums.Count;
            pbProgress.Show();
            pbProgress.Value = 0;
            double i = 0;

            ManagementPackProperty mppSRArea = Helper.GetManagementPackClassPropertyByName("System.WorkItem.ServiceRequest", "Area", emg);
            ManagementPackProperty mppCRArea = Helper.GetManagementPackClassPropertyByName("System.WorkItem.ChangeRequest", "Area", emg);
            ManagementPackProperty mppProblemClassification = Helper.GetManagementPackClassPropertyByName("System.WorkItem.Problem", "Classification", emg);
            ManagementPackProperty mppIncidentClassification = Helper.GetManagementPackClassPropertyByName("System.WorkItem.Incident", "Classification", emg);

            foreach (ManagementPackEnumeration mpeSRArea in listSRAreaEnums)
            {
                i++;
                CreateAddNotificationRule(mpcServiceRequest, mpeSRArea, strMPAliasServiceRequestLibrary, mppSRArea, ref mp, emoUser, mpotNewServiceRequest, emg);
                pbProgress.Value = (int)(i / dRulesToCreate * 100);
            }
            CreateUpdateNotificationRule(mpcServiceRequest, strMPAliasServiceRequestLibrary, mppSRArea, ref mp, emoUser, mpotUpdateServiceRequest, emg);

            foreach (ManagementPackEnumeration mpeCRArea in listCRAreaEnums)
            {
                i++;
                CreateAddNotificationRule(mpcChangeRequest, mpeCRArea, strMPAliasChangeRequestLibrary, mppCRArea, ref mp, emoUser, mpotNewChangeRequest, emg);
                pbProgress.Value = (int)(i / dRulesToCreate * 100);
            }
            CreateUpdateNotificationRule(mpcChangeRequest, strMPAliasChangeRequestLibrary, mppCRArea, ref mp, emoUser, mpotUpdateChangeRequest, emg);


            foreach (ManagementPackEnumeration mpeProblemClassification in listProblemAreaEnums)
            {
                i++;
                CreateAddNotificationRule(mpcProblem, mpeProblemClassification, strMPAliasProblemLibrary, mppProblemClassification, ref mp, emoUser, mpotNewProblem, emg);
                pbProgress.Value = (int)(i / dRulesToCreate * 100);
            }
            CreateUpdateNotificationRule(mpcProblem, strMPAliasProblemLibrary, mppProblemClassification, ref mp, emoUser, mpotUpdateProblem, emg);

            foreach (ManagementPackEnumeration mpeIncidentClassification in listIncidentAreaEnums)
            {
                i++;
                CreateAddNotificationRule(mpcIncident, mpeIncidentClassification, strMPAliasIncidentLibrary, mppIncidentClassification, ref mp, emoUser, mpotNewIncident, emg);
                pbProgress.Value = (int)(i / dRulesToCreate * 100);
            }
            CreateUpdateNotificationRule(mpcIncident, strMPAliasIncidentLibrary, mppIncidentClassification, ref mp, emoUser, mpotUpdateIncident, emg);

            emg.ManagementPacks.ImportManagementPack(mp);
        }

        private static void CreateAddNotificationRule(ManagementPackClass mpc, ManagementPackEnumeration mpe, string strMPAlias, ManagementPackProperty mpp, ref ManagementPack mp, EnterpriseManagementObject emoUser, ManagementPackObjectTemplate mpot, EnterpriseManagementGroup emg)
        {
            string strRuleDisplayName = String.Format("{0}: Add: {1}", mpc.DisplayName, mpe.DisplayName);
            string strCriteria = ConstructAddCriteria(strMPAlias, mpc, mpp, mpe);
            Helper.CreateNotificationRule(strRuleDisplayName, Helper.MakeMPElementSafeName(strRuleDisplayName), strCriteria, emoUser, mpc, mpot, ref mp, emg);
        }

        private static void CreateUpdateNotificationRule(ManagementPackClass mpc, string strMPAlias, ManagementPackProperty mpp, ref ManagementPack mp, EnterpriseManagementObject emoUser, ManagementPackObjectTemplate mpot, EnterpriseManagementGroup emg)
        {
            string strRuleDisplayName = String.Format("{0}: Update: {1}", mpc.DisplayName, mpp.DisplayName);
            string strCriteria = ConstructUpdateCriteria(strMPAlias, mpc, mpp);
            Helper.CreateNotificationRule(strRuleDisplayName, Helper.MakeMPElementSafeName(strRuleDisplayName), strCriteria, emoUser, mpc, mpot, ref mp, emg);
        }

        private static string ConstructAddCriteria(string strMPAlias, ManagementPackClass mpc, ManagementPackProperty mpp, ManagementPackEnumeration mpe)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<AddInstance>");
            sb.Append("<Criteria>");
            sb.Append("<Expression>");
            sb.Append("<SimpleExpression>");
            sb.Append("<ValueExpression>");
            sb.Append(String.Format("<Property State=\"Post\">$Context/Property[Type='{0}!{1}']/{2}$</Property>", strMPAlias, mpc.Name, mpp.Name));
            sb.Append("</ValueExpression>");
            sb.Append("<Operator>Equal</Operator>");
            sb.Append("<ValueExpression>");
            sb.Append(String.Format("<Value>{{{0}}}</Value>", mpe.Id.ToString()));
            sb.Append("</ValueExpression>");
            sb.Append("</SimpleExpression>");
            sb.Append("</Expression>");
            sb.Append("</Criteria>");
            sb.Append("</AddInstance>");

            return sb.ToString();
        }

        private static string ConstructUpdateCriteria(string strMPAlias, ManagementPackClass mpc, ManagementPackProperty mpp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<UpdateInstance>");
            sb.Append("<Criteria>");
            sb.Append("<Expression>");
            sb.Append("<SimpleExpression>");
            sb.Append("<ValueExpression>");
            sb.Append(String.Format("<Property State=\"Pre\">$Context/Property[Type='{0}!{1}']/{2}$</Property>", strMPAlias, mpc.Name, mpp.Name));
            sb.Append("</ValueExpression>");
            sb.Append("<Operator>NotEqual</Operator>");
            sb.Append("<ValueExpression>");
            sb.Append(String.Format("<Property State=\"Post\">$Context/Property[Type='{0}!{1}']/{2}$</Property>", strMPAlias, mpc.Name, mpp.Name));
            sb.Append("</ValueExpression>");
            sb.Append("</SimpleExpression>");
            sb.Append("</Expression>");
            sb.Append("</Criteria>");
            sb.Append("</UpdateInstance>");

            return sb.ToString();
        }
    }
}
