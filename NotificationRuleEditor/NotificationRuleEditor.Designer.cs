namespace NotificationRuleEditor
{
    partial class NotificationRuleEditor
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
            this.lblManagementServer = new System.Windows.Forms.Label();
            this.txtManagementServer = new System.Windows.Forms.TextBox();
            this.btnDisableAll = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.btnEnableAll = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtNewIncidentTemplate = new System.Windows.Forms.TextBox();
            this.lblNewIncidentTemplate = new System.Windows.Forms.Label();
            this.lblNewServiceRequestTemplate = new System.Windows.Forms.Label();
            this.txtNewServiceRequestTemplate = new System.Windows.Forms.TextBox();
            this.lblNewChangeRequestTemplate = new System.Windows.Forms.Label();
            this.txtNewChangeRequestTemplate = new System.Windows.Forms.TextBox();
            this.lblNewProblemTemplate = new System.Windows.Forms.Label();
            this.txtNewProblemTemplate = new System.Windows.Forms.TextBox();
            this.lblUpdateProblemTemplate = new System.Windows.Forms.Label();
            this.txtUpdateProblemTemplate = new System.Windows.Forms.TextBox();
            this.lblUpdateChangeRequestTemplate = new System.Windows.Forms.Label();
            this.txtUpdateChangeRequestTemplate = new System.Windows.Forms.TextBox();
            this.lblUpdateServiceRequestTemplate = new System.Windows.Forms.Label();
            this.txtUpdateServiceRequestTemplate = new System.Windows.Forms.TextBox();
            this.lblUpdateIncidentTemplate = new System.Windows.Forms.Label();
            this.txtUpdateIncidentTemplate = new System.Windows.Forms.TextBox();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblManagementServer
            // 
            this.lblManagementServer.AutoSize = true;
            this.lblManagementServer.Location = new System.Drawing.Point(12, 9);
            this.lblManagementServer.Name = "lblManagementServer";
            this.lblManagementServer.Size = new System.Drawing.Size(104, 13);
            this.lblManagementServer.TabIndex = 0;
            this.lblManagementServer.Text = "Management server:";
            // 
            // txtManagementServer
            // 
            this.txtManagementServer.Location = new System.Drawing.Point(12, 25);
            this.txtManagementServer.Name = "txtManagementServer";
            this.txtManagementServer.Size = new System.Drawing.Size(237, 20);
            this.txtManagementServer.TabIndex = 1;
            this.txtManagementServer.Text = "scsm1.contoso.com";
            // 
            // btnDisableAll
            // 
            this.btnDisableAll.Location = new System.Drawing.Point(12, 238);
            this.btnDisableAll.Name = "btnDisableAll";
            this.btnDisableAll.Size = new System.Drawing.Size(75, 23);
            this.btnDisableAll.TabIndex = 2;
            this.btnDisableAll.Text = "Disable All";
            this.btnDisableAll.UseVisualStyleBackColor = true;
            this.btnDisableAll.Click += new System.EventHandler(this.btnDisableAll_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(174, 238);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(363, 23);
            this.pbProgress.TabIndex = 3;
            // 
            // btnEnableAll
            // 
            this.btnEnableAll.Location = new System.Drawing.Point(93, 238);
            this.btnEnableAll.Name = "btnEnableAll";
            this.btnEnableAll.Size = new System.Drawing.Size(75, 23);
            this.btnEnableAll.TabIndex = 4;
            this.btnEnableAll.Text = "Enable All";
            this.btnEnableAll.UseVisualStyleBackColor = true;
            this.btnEnableAll.Click += new System.EventHandler(this.btnEnableAll_Click);
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
            // txtNewIncidentTemplate
            // 
            this.txtNewIncidentTemplate.Location = new System.Drawing.Point(12, 66);
            this.txtNewIncidentTemplate.Name = "txtNewIncidentTemplate";
            this.txtNewIncidentTemplate.Size = new System.Drawing.Size(237, 20);
            this.txtNewIncidentTemplate.TabIndex = 6;
            this.txtNewIncidentTemplate.Text = "NotificationTemplate.NewIncident";
            // 
            // lblNewIncidentTemplate
            // 
            this.lblNewIncidentTemplate.AutoSize = true;
            this.lblNewIncidentTemplate.Location = new System.Drawing.Point(10, 50);
            this.lblNewIncidentTemplate.Name = "lblNewIncidentTemplate";
            this.lblNewIncidentTemplate.Size = new System.Drawing.Size(120, 13);
            this.lblNewIncidentTemplate.TabIndex = 7;
            this.lblNewIncidentTemplate.Text = "New Incident Template:";
            // 
            // lblNewServiceRequestTemplate
            // 
            this.lblNewServiceRequestTemplate.AutoSize = true;
            this.lblNewServiceRequestTemplate.Location = new System.Drawing.Point(10, 89);
            this.lblNewServiceRequestTemplate.Name = "lblNewServiceRequestTemplate";
            this.lblNewServiceRequestTemplate.Size = new System.Drawing.Size(161, 13);
            this.lblNewServiceRequestTemplate.TabIndex = 9;
            this.lblNewServiceRequestTemplate.Text = "New Service Request Template:";
            // 
            // txtNewServiceRequestTemplate
            // 
            this.txtNewServiceRequestTemplate.Location = new System.Drawing.Point(12, 105);
            this.txtNewServiceRequestTemplate.Name = "txtNewServiceRequestTemplate";
            this.txtNewServiceRequestTemplate.Size = new System.Drawing.Size(237, 20);
            this.txtNewServiceRequestTemplate.TabIndex = 8;
            this.txtNewServiceRequestTemplate.Text = "NotificationTemplate.NewServiceRequest";
            // 
            // lblNewChangeRequestTemplate
            // 
            this.lblNewChangeRequestTemplate.AutoSize = true;
            this.lblNewChangeRequestTemplate.Location = new System.Drawing.Point(13, 130);
            this.lblNewChangeRequestTemplate.Name = "lblNewChangeRequestTemplate";
            this.lblNewChangeRequestTemplate.Size = new System.Drawing.Size(162, 13);
            this.lblNewChangeRequestTemplate.TabIndex = 11;
            this.lblNewChangeRequestTemplate.Text = "New Change Request Template:";
            // 
            // txtNewChangeRequestTemplate
            // 
            this.txtNewChangeRequestTemplate.Location = new System.Drawing.Point(15, 146);
            this.txtNewChangeRequestTemplate.Name = "txtNewChangeRequestTemplate";
            this.txtNewChangeRequestTemplate.Size = new System.Drawing.Size(237, 20);
            this.txtNewChangeRequestTemplate.TabIndex = 10;
            this.txtNewChangeRequestTemplate.Tag = "";
            this.txtNewChangeRequestTemplate.Text = "NotificationTemplate.NewChangeRequest";
            // 
            // lblNewProblemTemplate
            // 
            this.lblNewProblemTemplate.AutoSize = true;
            this.lblNewProblemTemplate.Location = new System.Drawing.Point(13, 167);
            this.lblNewProblemTemplate.Name = "lblNewProblemTemplate";
            this.lblNewProblemTemplate.Size = new System.Drawing.Size(120, 13);
            this.lblNewProblemTemplate.TabIndex = 13;
            this.lblNewProblemTemplate.Text = "New Problem Template:";
            // 
            // txtNewProblemTemplate
            // 
            this.txtNewProblemTemplate.Location = new System.Drawing.Point(15, 183);
            this.txtNewProblemTemplate.Name = "txtNewProblemTemplate";
            this.txtNewProblemTemplate.Size = new System.Drawing.Size(237, 20);
            this.txtNewProblemTemplate.TabIndex = 12;
            this.txtNewProblemTemplate.Tag = "";
            this.txtNewProblemTemplate.Text = "NotificationTemplate.NewProblem";
            // 
            // lblUpdateProblemTemplate
            // 
            this.lblUpdateProblemTemplate.AutoSize = true;
            this.lblUpdateProblemTemplate.Location = new System.Drawing.Point(285, 167);
            this.lblUpdateProblemTemplate.Name = "lblUpdateProblemTemplate";
            this.lblUpdateProblemTemplate.Size = new System.Drawing.Size(133, 13);
            this.lblUpdateProblemTemplate.TabIndex = 21;
            this.lblUpdateProblemTemplate.Text = "Update Problem Template:";
            // 
            // txtUpdateProblemTemplate
            // 
            this.txtUpdateProblemTemplate.Location = new System.Drawing.Point(287, 183);
            this.txtUpdateProblemTemplate.Name = "txtUpdateProblemTemplate";
            this.txtUpdateProblemTemplate.Size = new System.Drawing.Size(237, 20);
            this.txtUpdateProblemTemplate.TabIndex = 20;
            this.txtUpdateProblemTemplate.Text = "NotificationTemplate.UpdateProblem";
            // 
            // lblUpdateChangeRequestTemplate
            // 
            this.lblUpdateChangeRequestTemplate.AutoSize = true;
            this.lblUpdateChangeRequestTemplate.Location = new System.Drawing.Point(285, 130);
            this.lblUpdateChangeRequestTemplate.Name = "lblUpdateChangeRequestTemplate";
            this.lblUpdateChangeRequestTemplate.Size = new System.Drawing.Size(175, 13);
            this.lblUpdateChangeRequestTemplate.TabIndex = 19;
            this.lblUpdateChangeRequestTemplate.Text = "Update Change Request Template:";
            // 
            // txtUpdateChangeRequestTemplate
            // 
            this.txtUpdateChangeRequestTemplate.Location = new System.Drawing.Point(287, 146);
            this.txtUpdateChangeRequestTemplate.Name = "txtUpdateChangeRequestTemplate";
            this.txtUpdateChangeRequestTemplate.Size = new System.Drawing.Size(237, 20);
            this.txtUpdateChangeRequestTemplate.TabIndex = 18;
            this.txtUpdateChangeRequestTemplate.Text = "NotificationTemplate.UpdateChangeRequest";
            // 
            // lblUpdateServiceRequestTemplate
            // 
            this.lblUpdateServiceRequestTemplate.AutoSize = true;
            this.lblUpdateServiceRequestTemplate.Location = new System.Drawing.Point(282, 89);
            this.lblUpdateServiceRequestTemplate.Name = "lblUpdateServiceRequestTemplate";
            this.lblUpdateServiceRequestTemplate.Size = new System.Drawing.Size(174, 13);
            this.lblUpdateServiceRequestTemplate.TabIndex = 17;
            this.lblUpdateServiceRequestTemplate.Text = "Update Service Request Template:";
            // 
            // txtUpdateServiceRequestTemplate
            // 
            this.txtUpdateServiceRequestTemplate.Location = new System.Drawing.Point(284, 105);
            this.txtUpdateServiceRequestTemplate.Name = "txtUpdateServiceRequestTemplate";
            this.txtUpdateServiceRequestTemplate.Size = new System.Drawing.Size(237, 20);
            this.txtUpdateServiceRequestTemplate.TabIndex = 16;
            this.txtUpdateServiceRequestTemplate.Text = "NotificationTemplate.UpdateServiceRequest";
            // 
            // lblUpdateIncidentTemplate
            // 
            this.lblUpdateIncidentTemplate.AutoSize = true;
            this.lblUpdateIncidentTemplate.Location = new System.Drawing.Point(282, 50);
            this.lblUpdateIncidentTemplate.Name = "lblUpdateIncidentTemplate";
            this.lblUpdateIncidentTemplate.Size = new System.Drawing.Size(133, 13);
            this.lblUpdateIncidentTemplate.TabIndex = 15;
            this.lblUpdateIncidentTemplate.Text = "Update Incident Template:";
            // 
            // txtUpdateIncidentTemplate
            // 
            this.txtUpdateIncidentTemplate.Location = new System.Drawing.Point(284, 66);
            this.txtUpdateIncidentTemplate.Name = "txtUpdateIncidentTemplate";
            this.txtUpdateIncidentTemplate.Size = new System.Drawing.Size(237, 20);
            this.txtUpdateIncidentTemplate.TabIndex = 14;
            this.txtUpdateIncidentTemplate.Text = "NotificationTemplate.UpdateIncident";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(281, 25);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(237, 20);
            this.txtEmailAddress.TabIndex = 23;
            this.txtEmailAddress.Text = "administrator@contoso.com";
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(281, 9);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(115, 13);
            this.lblEmailAddress.TabIndex = 22;
            this.lblEmailAddress.Text = "Email address to notify:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(171, 219);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 24;
            // 
            // NotificationRuleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 273);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.lblEmailAddress);
            this.Controls.Add(this.lblUpdateProblemTemplate);
            this.Controls.Add(this.txtUpdateProblemTemplate);
            this.Controls.Add(this.lblUpdateChangeRequestTemplate);
            this.Controls.Add(this.txtUpdateChangeRequestTemplate);
            this.Controls.Add(this.lblUpdateServiceRequestTemplate);
            this.Controls.Add(this.txtUpdateServiceRequestTemplate);
            this.Controls.Add(this.lblUpdateIncidentTemplate);
            this.Controls.Add(this.txtUpdateIncidentTemplate);
            this.Controls.Add(this.lblNewProblemTemplate);
            this.Controls.Add(this.txtNewProblemTemplate);
            this.Controls.Add(this.lblNewChangeRequestTemplate);
            this.Controls.Add(this.txtNewChangeRequestTemplate);
            this.Controls.Add(this.lblNewServiceRequestTemplate);
            this.Controls.Add(this.txtNewServiceRequestTemplate);
            this.Controls.Add(this.lblNewIncidentTemplate);
            this.Controls.Add(this.txtNewIncidentTemplate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnEnableAll);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnDisableAll);
            this.Controls.Add(this.txtManagementServer);
            this.Controls.Add(this.lblManagementServer);
            this.Name = "NotificationRuleEditor";
            this.Text = "Notifcation Rule Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblManagementServer;
        private System.Windows.Forms.TextBox txtManagementServer;
        private System.Windows.Forms.Button btnDisableAll;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Button btnEnableAll;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtNewIncidentTemplate;
        private System.Windows.Forms.Label lblNewIncidentTemplate;
        private System.Windows.Forms.Label lblNewServiceRequestTemplate;
        private System.Windows.Forms.TextBox txtNewServiceRequestTemplate;
        private System.Windows.Forms.Label lblNewChangeRequestTemplate;
        private System.Windows.Forms.TextBox txtNewChangeRequestTemplate;
        private System.Windows.Forms.Label lblNewProblemTemplate;
        private System.Windows.Forms.TextBox txtNewProblemTemplate;
        private System.Windows.Forms.Label lblUpdateProblemTemplate;
        private System.Windows.Forms.TextBox txtUpdateProblemTemplate;
        private System.Windows.Forms.Label lblUpdateChangeRequestTemplate;
        private System.Windows.Forms.TextBox txtUpdateChangeRequestTemplate;
        private System.Windows.Forms.Label lblUpdateServiceRequestTemplate;
        private System.Windows.Forms.TextBox txtUpdateServiceRequestTemplate;
        private System.Windows.Forms.Label lblUpdateIncidentTemplate;
        private System.Windows.Forms.TextBox txtUpdateIncidentTemplate;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Label lblStatus;
    }
}

