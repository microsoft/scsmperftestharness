namespace QueueEditor
{
    partial class QueueEditor
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
            this.btnDisableAll = new System.Windows.Forms.Button();
            this.btnEnableAll = new System.Windows.Forms.Button();
            this.lblManagementServer = new System.Windows.Forms.Label();
            this.txtManagementServer = new System.Windows.Forms.TextBox();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDisableAll
            // 
            this.btnDisableAll.Location = new System.Drawing.Point(12, 238);
            this.btnDisableAll.Name = "btnDisableAll";
            this.btnDisableAll.Size = new System.Drawing.Size(75, 23);
            this.btnDisableAll.TabIndex = 0;
            this.btnDisableAll.Text = "Disable All";
            this.btnDisableAll.UseVisualStyleBackColor = true;
            this.btnDisableAll.Click += new System.EventHandler(this.btnDisableAll_Click);
            // 
            // btnEnableAll
            // 
            this.btnEnableAll.Location = new System.Drawing.Point(93, 238);
            this.btnEnableAll.Name = "btnEnableAll";
            this.btnEnableAll.Size = new System.Drawing.Size(75, 23);
            this.btnEnableAll.TabIndex = 1;
            this.btnEnableAll.Text = "Enable All";
            this.btnEnableAll.UseVisualStyleBackColor = true;
            this.btnEnableAll.Click += new System.EventHandler(this.btnEnableAll_Click);
            // 
            // lblManagementServer
            // 
            this.lblManagementServer.AutoSize = true;
            this.lblManagementServer.Location = new System.Drawing.Point(12, 9);
            this.lblManagementServer.Name = "lblManagementServer";
            this.lblManagementServer.Size = new System.Drawing.Size(104, 13);
            this.lblManagementServer.TabIndex = 2;
            this.lblManagementServer.Text = "Management server:";
            // 
            // txtManagementServer
            // 
            this.txtManagementServer.Location = new System.Drawing.Point(15, 25);
            this.txtManagementServer.Name = "txtManagementServer";
            this.txtManagementServer.Size = new System.Drawing.Size(166, 20);
            this.txtManagementServer.TabIndex = 3;
            this.txtManagementServer.Text = "scsm1.contoso.com";
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(198, 209);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(441, 23);
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgress.TabIndex = 4;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 209);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(93, 209);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAll.TabIndex = 6;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(195, 235);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 7;
            // 
            // QueueEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 273);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.txtManagementServer);
            this.Controls.Add(this.lblManagementServer);
            this.Controls.Add(this.btnEnableAll);
            this.Controls.Add(this.btnDisableAll);
            this.Name = "QueueEditor";
            this.Text = "Queue Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDisableAll;
        private System.Windows.Forms.Button btnEnableAll;
        private System.Windows.Forms.Label lblManagementServer;
        private System.Windows.Forms.TextBox txtManagementServer;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Label lblStatus;
    }
}

