namespace EnumGen
{
    partial class frmEnumGen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSCSMServerName = new System.Windows.Forms.Label();
            this.lblNewMPName = new System.Windows.Forms.Label();
            this.lblBaseEnumName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNumberOfEnumsToCreatePerLevel = new System.Windows.Forms.Label();
            this.txtSCSMServerName = new System.Windows.Forms.TextBox();
            this.txtNewMPName = new System.Windows.Forms.TextBox();
            this.txtBaseEnumName = new System.Windows.Forms.TextBox();
            this.nudNumberOfLevelsToCreate = new System.Windows.Forms.NumericUpDown();
            this.nudNumberOfEnumsToCreatePerLevel = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblFolderToWriteMPFileTo = new System.Windows.Forms.Label();
            this.txtFolderToWriteFileTo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfLevelsToCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfEnumsToCreatePerLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSCSMServerName
            // 
            this.lblSCSMServerName.AutoSize = true;
            this.lblSCSMServerName.Location = new System.Drawing.Point(13, 13);
            this.lblSCSMServerName.Name = "lblSCSMServerName";
            this.lblSCSMServerName.Size = new System.Drawing.Size(101, 13);
            this.lblSCSMServerName.TabIndex = 0;
            this.lblSCSMServerName.Text = "SCSM server name:";
            // 
            // lblNewMPName
            // 
            this.lblNewMPName.AutoSize = true;
            this.lblNewMPName.Location = new System.Drawing.Point(13, 63);
            this.lblNewMPName.Name = "lblNewMPName";
            this.lblNewMPName.Size = new System.Drawing.Size(80, 13);
            this.lblNewMPName.TabIndex = 1;
            this.lblNewMPName.Text = "New MP name:";
            // 
            // lblBaseEnumName
            // 
            this.lblBaseEnumName.AutoSize = true;
            this.lblBaseEnumName.Location = new System.Drawing.Point(13, 113);
            this.lblBaseEnumName.Name = "lblBaseEnumName";
            this.lblBaseEnumName.Size = new System.Drawing.Size(92, 13);
            this.lblBaseEnumName.TabIndex = 2;
            this.lblBaseEnumName.Text = "Base enum name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Number of levels to create:";
            // 
            // lblNumberOfEnumsToCreatePerLevel
            // 
            this.lblNumberOfEnumsToCreatePerLevel.AutoSize = true;
            this.lblNumberOfEnumsToCreatePerLevel.Location = new System.Drawing.Point(13, 213);
            this.lblNumberOfEnumsToCreatePerLevel.Name = "lblNumberOfEnumsToCreatePerLevel";
            this.lblNumberOfEnumsToCreatePerLevel.Size = new System.Drawing.Size(181, 13);
            this.lblNumberOfEnumsToCreatePerLevel.TabIndex = 4;
            this.lblNumberOfEnumsToCreatePerLevel.Text = "Number of enums to create per level:";
            // 
            // txtSCSMServerName
            // 
            this.txtSCSMServerName.Location = new System.Drawing.Point(16, 30);
            this.txtSCSMServerName.Name = "txtSCSMServerName";
            this.txtSCSMServerName.Size = new System.Drawing.Size(178, 20);
            this.txtSCSMServerName.TabIndex = 5;
            this.txtSCSMServerName.Text = "localhost";
            // 
            // txtNewMPName
            // 
            this.txtNewMPName.Location = new System.Drawing.Point(16, 80);
            this.txtNewMPName.Name = "txtNewMPName";
            this.txtNewMPName.Size = new System.Drawing.Size(178, 20);
            this.txtNewMPName.TabIndex = 6;
            this.txtNewMPName.Text = "NewMP";
            // 
            // txtBaseEnumName
            // 
            this.txtBaseEnumName.Location = new System.Drawing.Point(16, 130);
            this.txtBaseEnumName.Name = "txtBaseEnumName";
            this.txtBaseEnumName.Size = new System.Drawing.Size(178, 20);
            this.txtBaseEnumName.TabIndex = 7;
            this.txtBaseEnumName.Text = "IncidentClassificationEnum";
            // 
            // nudNumberOfLevelsToCreate
            // 
            this.nudNumberOfLevelsToCreate.Location = new System.Drawing.Point(16, 180);
            this.nudNumberOfLevelsToCreate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfLevelsToCreate.Name = "nudNumberOfLevelsToCreate";
            this.nudNumberOfLevelsToCreate.Size = new System.Drawing.Size(120, 20);
            this.nudNumberOfLevelsToCreate.TabIndex = 8;
            this.nudNumberOfLevelsToCreate.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudNumberOfEnumsToCreatePerLevel
            // 
            this.nudNumberOfEnumsToCreatePerLevel.Location = new System.Drawing.Point(16, 230);
            this.nudNumberOfEnumsToCreatePerLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfEnumsToCreatePerLevel.Name = "nudNumberOfEnumsToCreatePerLevel";
            this.nudNumberOfEnumsToCreatePerLevel.Size = new System.Drawing.Size(120, 20);
            this.nudNumberOfEnumsToCreatePerLevel.TabIndex = 9;
            this.nudNumberOfEnumsToCreatePerLevel.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(414, 304);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblFolderToWriteMPFileTo
            // 
            this.lblFolderToWriteMPFileTo.AutoSize = true;
            this.lblFolderToWriteMPFileTo.Location = new System.Drawing.Point(16, 257);
            this.lblFolderToWriteMPFileTo.Name = "lblFolderToWriteMPFileTo";
            this.lblFolderToWriteMPFileTo.Size = new System.Drawing.Size(141, 13);
            this.lblFolderToWriteMPFileTo.TabIndex = 11;
            this.lblFolderToWriteMPFileTo.Text = "Folder to write the MP file to:";
            // 
            // txtFolderToWriteFileTo
            // 
            this.txtFolderToWriteFileTo.Location = new System.Drawing.Point(16, 274);
            this.txtFolderToWriteFileTo.Name = "txtFolderToWriteFileTo";
            this.txtFolderToWriteFileTo.Size = new System.Drawing.Size(371, 20);
            this.txtFolderToWriteFileTo.TabIndex = 12;
            this.txtFolderToWriteFileTo.Text = "C:\\";
            // 
            // frmEnumGen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 339);
            this.Controls.Add(this.txtFolderToWriteFileTo);
            this.Controls.Add(this.lblFolderToWriteMPFileTo);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.nudNumberOfEnumsToCreatePerLevel);
            this.Controls.Add(this.nudNumberOfLevelsToCreate);
            this.Controls.Add(this.txtBaseEnumName);
            this.Controls.Add(this.txtNewMPName);
            this.Controls.Add(this.txtSCSMServerName);
            this.Controls.Add(this.lblNumberOfEnumsToCreatePerLevel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblBaseEnumName);
            this.Controls.Add(this.lblNewMPName);
            this.Controls.Add(this.lblSCSMServerName);
            this.Name = "frmEnumGen";
            this.Text = "EnumGen";
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfLevelsToCreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfEnumsToCreatePerLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSCSMServerName;
        private System.Windows.Forms.Label lblNewMPName;
        private System.Windows.Forms.Label lblBaseEnumName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNumberOfEnumsToCreatePerLevel;
        private System.Windows.Forms.TextBox txtSCSMServerName;
        private System.Windows.Forms.TextBox txtNewMPName;
        private System.Windows.Forms.TextBox txtBaseEnumName;
        private System.Windows.Forms.NumericUpDown nudNumberOfLevelsToCreate;
        private System.Windows.Forms.NumericUpDown nudNumberOfEnumsToCreatePerLevel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblFolderToWriteMPFileTo;
        private System.Windows.Forms.TextBox txtFolderToWriteFileTo;
    }
}

