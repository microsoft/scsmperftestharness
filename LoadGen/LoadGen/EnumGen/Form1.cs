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
using Microsoft.EnterpriseManagement.Configuration.IO;
using Microsoft.EnterpriseManagement.Packaging;
using Microsoft.EnterpriseManagement.Helper;


namespace EnumGen
{
    public partial class frmEnumGen : Form
    {
        static int iNumberOfLevels;
        static int iNumberOfEnumsPerLevel;
        int iNumberOfLevelsCreated = 0;
        int iNumberOfEnumsCreated = 0;
           
        public frmEnumGen()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            iNumberOfLevelsCreated = 0;
            iNumberOfEnumsCreated = 0;
            EnterpriseManagementGroup emg = new EnterpriseManagementGroup(txtSCSMServerName.Text);
            ManagementPackEnumeration mpeBase = Helper.GetEnumerationByName(txtBaseEnumName.Text, emg);
            ManagementPack mpNew = new ManagementPack(txtNewMPName.Text, txtNewMPName.Text, new Version("1.0.0.0"), emg);
            iNumberOfLevels = (int)nudNumberOfLevelsToCreate.Value;
            iNumberOfEnumsPerLevel = (int)nudNumberOfEnumsToCreatePerLevel.Value;
            CreateEnumerationsAtALevel("Enum", ref mpeBase, ref mpNew, iNumberOfEnumsPerLevel);
            DialogResult dr = MessageBox.Show(String.Format("Number of enums to be created: {0}", iNumberOfEnumsCreated.ToString()), "Write to MP XML file?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                mpNew.AcceptChanges();
                ManagementPackXmlWriter mpxw = new ManagementPackXmlWriter(txtFolderToWriteFileTo.Text);
                mpxw.WriteManagementPack(mpNew);
            }
        }

        private void CreateEnumerationsAtALevel(string strBaseEnumName, ref ManagementPackEnumeration mpeBase, ref ManagementPack mpNew, int iNumberOfEnums)
        {
            int i = 0;
            do
            {
                //Create an enumeration
                ManagementPackEnumeration mpe = CreateEnumeration(String.Format("{0}.{1}", strBaseEnumName, (i+1).ToString()), ref mpeBase, ref mpNew);
                //If you haven't already reached the bottom of the levels, create the children of this enumeration
                if (iNumberOfLevelsCreated < iNumberOfLevels-1)
                {
                    iNumberOfLevelsCreated++;
                    CreateEnumerationsAtALevel(mpe.Name, ref mpe, ref mpNew, iNumberOfEnumsPerLevel);
                }

                i++;
                //If we are all done creating enums at this level then go back up a level.
                if (i == iNumberOfEnums)

                {
                    iNumberOfLevelsCreated--;
                }

            } while (i < iNumberOfEnums);
            
        }

        private ManagementPackEnumeration CreateEnumeration(string strName, ref ManagementPackEnumeration mpeBase, ref ManagementPack mpNew)
        {
            ManagementPackEnumeration mpeNew = new ManagementPackEnumeration(mpNew, strName, ManagementPackAccessibility.Public);
            mpeNew.Parent = mpeBase;
            mpeNew.DisplayName = String.Format("Test Value {0}",strName);
            iNumberOfEnumsCreated++;
            return mpeNew;
        }
    }
}
