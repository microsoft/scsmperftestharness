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


namespace Tester
{
    public partial class Tester : Form
    {
        public Tester()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestGettingARandomNumberOfIncidents();
            //TestGettingIncidentsByGUIDVsWorkItemID();
            //TestGettingIncidentsByEnumCriteria();
        }

        private void TestGettingARandomNumberOfIncidents()
        {
            EnterpriseManagementGroup emg = new EnterpriseManagementGroup(txtServerName.Text);
            ManagementPackClass mpcIncident = Helper.GetClassByName("System.WorkItem.Incident", emg);
            ManagementPack mpIncidentLibrary = mpcIncident.GetManagementPack();
            ManagementPackTypeProjection mptpIncidentFull = Helper.GetTypeProjectionByName("System.WorkItem.Incident.ProjectionType", emg);
            string strCriteria = Helper.SearchWorkItemByLikeIDCriteriaXml("2", mpIncidentLibrary.Name, mpIncidentLibrary.Version.ToString(), mpIncidentLibrary.KeyToken, mpcIncident.Name);
            IObjectProjectionReader<EnterpriseManagementObject> reader = Helper.GetBufferedObjectProjectionReader(strCriteria, 30, mptpIncidentFull, emg);
            double dIncidentIDSum = 0;
            foreach (EnterpriseManagementObjectProjection emop in reader)
            {
                string strID = emop.Object[mpcIncident, "Id"].Value.ToString();
                dIncidentIDSum += (double)Int32.Parse(strID);
            }
            MessageBox.Show(dIncidentIDSum.ToString());
        }

        private void TestGettingIncidentsByGUIDVsWorkItemID()
        {
            EnterpriseManagementGroup emg = new EnterpriseManagementGroup(txtServerName.Text);
            ManagementPackClass mpcIncident = Helper.GetClassByName("System.WorkItem.Incident", emg);
            ManagementPack mpIncidentLibrary = mpcIncident.GetManagementPack();
            IObjectReader<EnterpriseManagementObject> readerAllIncidents = emg.EntityObjects.GetObjectReader<EnterpriseManagementObject>(mpcIncident, ObjectQueryOptions.Default);
            ManagementPackTypeProjection mptpIncidentFull = Helper.GetTypeProjectionByName("System.WorkItem.Incident.ProjectionType", emg);
            double dByGUIDElapsedTime = 0;
            double dByWorkItemIDElapsedTime = 0;
            double dNumberOfTries = 1000;
            double i = 0;
            do
            {
                i++;
                int intRandomIncident = Helper.GetRandomNumber(0, readerAllIncidents.Count);
                EnterpriseManagementObject emoIncident = readerAllIncidents.ElementAtOrDefault<EnterpriseManagementObject>(intRandomIncident);
                Guid guidIncidentId = emoIncident.Id;
                string strWorkItemID = emoIncident[mpcIncident, "Id"].Value.ToString();
                
                DateTime dtByGUIDStart = DateTime.Now;
                EnterpriseManagementObjectProjection emopIncident = emg.EntityObjects.GetObjectProjectionWithAccessRights<EnterpriseManagementObject>(emoIncident.Id, mptpIncidentFull);
                DateTime dtByGUIDEnd = DateTime.Now;
                TimeSpan tsByGUID = dtByGUIDEnd - dtByGUIDStart;
                dByGUIDElapsedTime += tsByGUID.Milliseconds;

                DateTime dtByWorkItemIDStart = DateTime.Now;
                string strCriteria = Helper.SearchWorkItemByIDCriteriaXml(strWorkItemID, mpIncidentLibrary.Name, mpIncidentLibrary.Version.ToString(), mpIncidentLibrary.KeyToken, mpcIncident.Name);
                IObjectProjectionReader<EnterpriseManagementObject> readerIncident = Helper.GetBufferedObjectProjectionReader(strCriteria, 1, mptpIncidentFull, emg);
                DateTime dtByWorkItemIDEnd = DateTime.Now;
                TimeSpan tsByWorkItemID = dtByWorkItemIDEnd - dtByWorkItemIDStart;
                dByWorkItemIDElapsedTime += tsByWorkItemID.Milliseconds;
                pbProgress.Value = (int)(i / dNumberOfTries * 100);
            }
            while (i < dNumberOfTries);

            MessageBox.Show(string.Format("By GUID: {0}    By Work Item ID: {1}", dByGUIDElapsedTime.ToString(), dByWorkItemIDElapsedTime.ToString()));
    
        }

        private void TestGettingIncidentsByEnumCriteria()
        {
            EnterpriseManagementGroup emg = new EnterpriseManagementGroup(txtServerName.Text);
            ManagementPack mpIncidentLibrary = Helper.GetManagementPackByName("System.WorkItem.Incident.Library", emg);
            ManagementPackClass mpcIncident = Helper.GetClassByName("System.WorkItem.Incident", emg);
            ManagementPackProperty mppClassification = Helper.GetManagementPackClassPropertyByName("System.WorkItem.Incident", "Classification", emg);
            ManagementPackTypeProjection mptpIncident = Helper.GetTypeProjectionByName("System.WorkItem.Incident.View.ProjectionType", emg);
            ManagementPackEnumeration mpeClassificationEnterpriseApp = Helper.GetEnumerationByName("IncidentClassificationEnum.EnterpriseApplications", emg);
            string strCriteria = Helper.SearchObjectByEnumerationCriteriaXml(mpeClassificationEnterpriseApp, mpcIncident, mppClassification);

            IObjectProjectionReader<EnterpriseManagementObject> reader = Helper.GetBufferedObjectProjectionReader(strCriteria, 40, mptpIncident, emg);
            MessageBox.Show(reader.Count.ToString());
        }
    }
}
