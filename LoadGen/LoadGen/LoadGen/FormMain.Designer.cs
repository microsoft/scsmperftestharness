using System.Windows.Forms;

namespace Microsoft.SystemCenter.Test.LoadGen
{
    partial class FormMain : Form
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
            this.btnStartLoad = new System.Windows.Forms.Button();
            this.lblThreadStartupInterval = new System.Windows.Forms.Label();
            this.nudStartupInterval = new System.Windows.Forms.NumericUpDown();
            this.lblServerName = new System.Windows.Forms.Label();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblNumberOfIncidentToCreate = new System.Windows.Forms.Label();
            this.nudNumberOfIncidentsToCreate = new System.Windows.Forms.NumericUpDown();
            this.nudNumberOfChangeRequestsToCreate = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfChangeRequestsToCreate = new System.Windows.Forms.Label();
            this.nudNumberOfServiceRequestsToCreate = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfServiceRequestsToCreate = new System.Windows.Forms.Label();
            this.nudNumberOfServiceRequestsToCreatePerDay = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfServiceRequestsToCreatePerDay = new System.Windows.Forms.Label();
            this.nudNumberOfChangeRequestsToCreatePerDay = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfChangeRequestsToCreatePerDay = new System.Windows.Forms.Label();
            this.nudNumberOfIncidentsToCreatePerDay = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfIncidentsToCreatePerDay = new System.Windows.Forms.Label();
            this.nudPercentOfWorkersCreatingServiceRequests = new System.Windows.Forms.NumericUpDown();
            this.lblPercentOfWorkersCreatingServiceRequests = new System.Windows.Forms.Label();
            this.nudPercentOfWorkersCreatingChangeRequests = new System.Windows.Forms.NumericUpDown();
            this.lblPercentOfWorkersCreatingChangeRequests = new System.Windows.Forms.Label();
            this.nudPercentOfWorkersCreatingIncidents = new System.Windows.Forms.NumericUpDown();
            this.lblPercentWorkersCreatingIncidents = new System.Windows.Forms.Label();
            this.nudPercentOfWorkersCreatingProblems = new System.Windows.Forms.NumericUpDown();
            this.lblPercentOfWorkersCreatingProblems = new System.Windows.Forms.Label();
            this.nudNumberOfProblemsToCreatePerDay = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfProblemsToCreatePerDay = new System.Windows.Forms.Label();
            this.nudNumberOfProblemsToCreate = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfProblemsToCreate = new System.Windows.Forms.Label();
            this.nudPercentOfWorkersCreatingReleases = new System.Windows.Forms.NumericUpDown();
            this.lblPercentOfWorkersCreatingReleases = new System.Windows.Forms.Label();
            this.nudNumberOfReleasesToCreatePerDay = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudNumberOfReleasesToCreate = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfReleasesToCreate = new System.Windows.Forms.Label();
            this.nudNumberOfWorkingHoursPerDay = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfWorkingHoursPerDay = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.lblDomain = new System.Windows.Forms.Label();
            this.nudWorkItemQueryUpdateRate = new System.Windows.Forms.NumericUpDown();
            this.lblWorkItemUpdateQueryRate = new System.Windows.Forms.Label();
            this.lblSupportGroupFilePath = new System.Windows.Forms.Label();
            this.openFileDialogSupportGroupFile = new System.Windows.Forms.OpenFileDialog();
            this.txtSupportGroupFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowseForSupportGroupFilePath = new System.Windows.Forms.Button();
            this.lblDoWorkPause = new System.Windows.Forms.Label();
            this.nudDoWorkPause = new System.Windows.Forms.NumericUpDown();
            this.lblNumberOfWorkItemsToGet = new System.Windows.Forms.Label();
            this.nudNumberOfWorkItemsToGet = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartupInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfIncidentsToCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfChangeRequestsToCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfServiceRequestsToCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfServiceRequestsToCreatePerDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfChangeRequestsToCreatePerDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfIncidentsToCreatePerDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentOfWorkersCreatingServiceRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentOfWorkersCreatingChangeRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentOfWorkersCreatingIncidents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentOfWorkersCreatingProblems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfProblemsToCreatePerDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfProblemsToCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentOfWorkersCreatingReleases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfReleasesToCreatePerDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfReleasesToCreate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfWorkingHoursPerDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorkItemQueryUpdateRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDoWorkPause)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfWorkItemsToGet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartLoad
            // 
            this.btnStartLoad.Location = new System.Drawing.Point(758, 396);
            this.btnStartLoad.Name = "btnStartLoad";
            this.btnStartLoad.Size = new System.Drawing.Size(75, 23);
            this.btnStartLoad.TabIndex = 23;
            this.btnStartLoad.Text = "Start Load";
            this.btnStartLoad.UseVisualStyleBackColor = true;
            this.btnStartLoad.Click += new System.EventHandler(this.btnStartLoad_Click);
            // 
            // lblThreadStartupInterval
            // 
            this.lblThreadStartupInterval.AutoSize = true;
            this.lblThreadStartupInterval.Location = new System.Drawing.Point(6, 13);
            this.lblThreadStartupInterval.Name = "lblThreadStartupInterval";
            this.lblThreadStartupInterval.Size = new System.Drawing.Size(144, 13);
            this.lblThreadStartupInterval.TabIndex = 3;
            this.lblThreadStartupInterval.Text = "Thread startup internval (ms):";
            // 
            // nudStartupInterval
            // 
            this.nudStartupInterval.Location = new System.Drawing.Point(9, 30);
            this.nudStartupInterval.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudStartupInterval.Name = "nudStartupInterval";
            this.nudStartupInterval.Size = new System.Drawing.Size(141, 20);
            this.nudStartupInterval.TabIndex = 0;
            this.nudStartupInterval.Value = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(9, 57);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(70, 13);
            this.lblServerName.TabIndex = 6;
            this.lblServerName.Text = "Server name:";
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(12, 74);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(138, 20);
            this.txtServerName.TabIndex = 1;
            this.txtServerName.Text = "scsm2.contoso.com";
            // 
            // lblNumberOfIncidentToCreate
            // 
            this.lblNumberOfIncidentToCreate.AutoSize = true;
            this.lblNumberOfIncidentToCreate.Location = new System.Drawing.Point(197, 12);
            this.lblNumberOfIncidentToCreate.Name = "lblNumberOfIncidentToCreate";
            this.lblNumberOfIncidentToCreate.Size = new System.Drawing.Size(149, 13);
            this.lblNumberOfIncidentToCreate.TabIndex = 8;
            this.lblNumberOfIncidentToCreate.Text = "Number of incidents to create:";
            // 
            // nudNumberOfIncidentsToCreate
            // 
            this.nudNumberOfIncidentsToCreate.Location = new System.Drawing.Point(200, 29);
            this.nudNumberOfIncidentsToCreate.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudNumberOfIncidentsToCreate.Name = "nudNumberOfIncidentsToCreate";
            this.nudNumberOfIncidentsToCreate.Size = new System.Drawing.Size(181, 20);
            this.nudNumberOfIncidentsToCreate.TabIndex = 6;
            this.nudNumberOfIncidentsToCreate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumberOfIncidentsToCreate.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // nudNumberOfChangeRequestsToCreate
            // 
            this.nudNumberOfChangeRequestsToCreate.Location = new System.Drawing.Point(200, 74);
            this.nudNumberOfChangeRequestsToCreate.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudNumberOfChangeRequestsToCreate.Name = "nudNumberOfChangeRequestsToCreate";
            this.nudNumberOfChangeRequestsToCreate.Size = new System.Drawing.Size(181, 20);
            this.nudNumberOfChangeRequestsToCreate.TabIndex = 9;
            this.nudNumberOfChangeRequestsToCreate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumberOfChangeRequestsToCreate.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblNumberOfChangeRequestsToCreate
            // 
            this.lblNumberOfChangeRequestsToCreate.AutoSize = true;
            this.lblNumberOfChangeRequestsToCreate.Location = new System.Drawing.Point(197, 57);
            this.lblNumberOfChangeRequestsToCreate.Name = "lblNumberOfChangeRequestsToCreate";
            this.lblNumberOfChangeRequestsToCreate.Size = new System.Drawing.Size(186, 13);
            this.lblNumberOfChangeRequestsToCreate.TabIndex = 10;
            this.lblNumberOfChangeRequestsToCreate.Text = "Number of change requests to create:";
            // 
            // nudNumberOfServiceRequestsToCreate
            // 
            this.nudNumberOfServiceRequestsToCreate.Location = new System.Drawing.Point(200, 123);
            this.nudNumberOfServiceRequestsToCreate.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudNumberOfServiceRequestsToCreate.Name = "nudNumberOfServiceRequestsToCreate";
            this.nudNumberOfServiceRequestsToCreate.Size = new System.Drawing.Size(181, 20);
            this.nudNumberOfServiceRequestsToCreate.TabIndex = 12;
            this.nudNumberOfServiceRequestsToCreate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumberOfServiceRequestsToCreate.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblNumberOfServiceRequestsToCreate
            // 
            this.lblNumberOfServiceRequestsToCreate.AutoSize = true;
            this.lblNumberOfServiceRequestsToCreate.Location = new System.Drawing.Point(197, 106);
            this.lblNumberOfServiceRequestsToCreate.Name = "lblNumberOfServiceRequestsToCreate";
            this.lblNumberOfServiceRequestsToCreate.Size = new System.Drawing.Size(184, 13);
            this.lblNumberOfServiceRequestsToCreate.TabIndex = 12;
            this.lblNumberOfServiceRequestsToCreate.Text = "Number of service requests to create:";
            // 
            // nudNumberOfServiceRequestsToCreatePerDay
            // 
            this.nudNumberOfServiceRequestsToCreatePerDay.Location = new System.Drawing.Point(390, 124);
            this.nudNumberOfServiceRequestsToCreatePerDay.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudNumberOfServiceRequestsToCreatePerDay.Name = "nudNumberOfServiceRequestsToCreatePerDay";
            this.nudNumberOfServiceRequestsToCreatePerDay.Size = new System.Drawing.Size(219, 20);
            this.nudNumberOfServiceRequestsToCreatePerDay.TabIndex = 13;
            this.nudNumberOfServiceRequestsToCreatePerDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumberOfServiceRequestsToCreatePerDay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblNumberOfServiceRequestsToCreatePerDay
            // 
            this.lblNumberOfServiceRequestsToCreatePerDay.AutoSize = true;
            this.lblNumberOfServiceRequestsToCreatePerDay.Location = new System.Drawing.Point(387, 107);
            this.lblNumberOfServiceRequestsToCreatePerDay.Name = "lblNumberOfServiceRequestsToCreatePerDay";
            this.lblNumberOfServiceRequestsToCreatePerDay.Size = new System.Drawing.Size(222, 13);
            this.lblNumberOfServiceRequestsToCreatePerDay.TabIndex = 18;
            this.lblNumberOfServiceRequestsToCreatePerDay.Text = "Number of service requests to create per day:";
            // 
            // nudNumberOfChangeRequestsToCreatePerDay
            // 
            this.nudNumberOfChangeRequestsToCreatePerDay.Location = new System.Drawing.Point(390, 75);
            this.nudNumberOfChangeRequestsToCreatePerDay.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudNumberOfChangeRequestsToCreatePerDay.Name = "nudNumberOfChangeRequestsToCreatePerDay";
            this.nudNumberOfChangeRequestsToCreatePerDay.Size = new System.Drawing.Size(219, 20);
            this.nudNumberOfChangeRequestsToCreatePerDay.TabIndex = 10;
            this.nudNumberOfChangeRequestsToCreatePerDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumberOfChangeRequestsToCreatePerDay.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // lblNumberOfChangeRequestsToCreatePerDay
            // 
            this.lblNumberOfChangeRequestsToCreatePerDay.AutoSize = true;
            this.lblNumberOfChangeRequestsToCreatePerDay.Location = new System.Drawing.Point(387, 58);
            this.lblNumberOfChangeRequestsToCreatePerDay.Name = "lblNumberOfChangeRequestsToCreatePerDay";
            this.lblNumberOfChangeRequestsToCreatePerDay.Size = new System.Drawing.Size(224, 13);
            this.lblNumberOfChangeRequestsToCreatePerDay.TabIndex = 16;
            this.lblNumberOfChangeRequestsToCreatePerDay.Text = "Number of change requests to create per day:";
            // 
            // nudNumberOfIncidentsToCreatePerDay
            // 
            this.nudNumberOfIncidentsToCreatePerDay.Location = new System.Drawing.Point(390, 30);
            this.nudNumberOfIncidentsToCreatePerDay.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudNumberOfIncidentsToCreatePerDay.Name = "nudNumberOfIncidentsToCreatePerDay";
            this.nudNumberOfIncidentsToCreatePerDay.Size = new System.Drawing.Size(219, 20);
            this.nudNumberOfIncidentsToCreatePerDay.TabIndex = 7;
            this.nudNumberOfIncidentsToCreatePerDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumberOfIncidentsToCreatePerDay.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // lblNumberOfIncidentsToCreatePerDay
            // 
            this.lblNumberOfIncidentsToCreatePerDay.AutoSize = true;
            this.lblNumberOfIncidentsToCreatePerDay.Location = new System.Drawing.Point(387, 13);
            this.lblNumberOfIncidentsToCreatePerDay.Name = "lblNumberOfIncidentsToCreatePerDay";
            this.lblNumberOfIncidentsToCreatePerDay.Size = new System.Drawing.Size(187, 13);
            this.lblNumberOfIncidentsToCreatePerDay.TabIndex = 14;
            this.lblNumberOfIncidentsToCreatePerDay.Text = "Number of incidents to create per day:";
            // 
            // nudPercentOfWorkersCreatingServiceRequests
            // 
            this.nudPercentOfWorkersCreatingServiceRequests.Location = new System.Drawing.Point(626, 124);
            this.nudPercentOfWorkersCreatingServiceRequests.Name = "nudPercentOfWorkersCreatingServiceRequests";
            this.nudPercentOfWorkersCreatingServiceRequests.Size = new System.Drawing.Size(217, 20);
            this.nudPercentOfWorkersCreatingServiceRequests.TabIndex = 14;
            this.nudPercentOfWorkersCreatingServiceRequests.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPercentOfWorkersCreatingServiceRequests.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblPercentOfWorkersCreatingServiceRequests
            // 
            this.lblPercentOfWorkersCreatingServiceRequests.AutoSize = true;
            this.lblPercentOfWorkersCreatingServiceRequests.Location = new System.Drawing.Point(623, 107);
            this.lblPercentOfWorkersCreatingServiceRequests.Name = "lblPercentOfWorkersCreatingServiceRequests";
            this.lblPercentOfWorkersCreatingServiceRequests.Size = new System.Drawing.Size(220, 13);
            this.lblPercentOfWorkersCreatingServiceRequests.TabIndex = 24;
            this.lblPercentOfWorkersCreatingServiceRequests.Text = "Percent of workers creating service requests:";
            // 
            // nudPercentOfWorkersCreatingChangeRequests
            // 
            this.nudPercentOfWorkersCreatingChangeRequests.Location = new System.Drawing.Point(626, 75);
            this.nudPercentOfWorkersCreatingChangeRequests.Name = "nudPercentOfWorkersCreatingChangeRequests";
            this.nudPercentOfWorkersCreatingChangeRequests.Size = new System.Drawing.Size(217, 20);
            this.nudPercentOfWorkersCreatingChangeRequests.TabIndex = 11;
            this.nudPercentOfWorkersCreatingChangeRequests.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPercentOfWorkersCreatingChangeRequests.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblPercentOfWorkersCreatingChangeRequests
            // 
            this.lblPercentOfWorkersCreatingChangeRequests.AutoSize = true;
            this.lblPercentOfWorkersCreatingChangeRequests.Location = new System.Drawing.Point(623, 58);
            this.lblPercentOfWorkersCreatingChangeRequests.Name = "lblPercentOfWorkersCreatingChangeRequests";
            this.lblPercentOfWorkersCreatingChangeRequests.Size = new System.Drawing.Size(222, 13);
            this.lblPercentOfWorkersCreatingChangeRequests.TabIndex = 22;
            this.lblPercentOfWorkersCreatingChangeRequests.Text = "Percent of workers creating change requests:";
            // 
            // nudPercentOfWorkersCreatingIncidents
            // 
            this.nudPercentOfWorkersCreatingIncidents.Location = new System.Drawing.Point(626, 30);
            this.nudPercentOfWorkersCreatingIncidents.Name = "nudPercentOfWorkersCreatingIncidents";
            this.nudPercentOfWorkersCreatingIncidents.Size = new System.Drawing.Size(217, 20);
            this.nudPercentOfWorkersCreatingIncidents.TabIndex = 8;
            this.nudPercentOfWorkersCreatingIncidents.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPercentOfWorkersCreatingIncidents.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // lblPercentWorkersCreatingIncidents
            // 
            this.lblPercentWorkersCreatingIncidents.AutoSize = true;
            this.lblPercentWorkersCreatingIncidents.Location = new System.Drawing.Point(623, 13);
            this.lblPercentWorkersCreatingIncidents.Name = "lblPercentWorkersCreatingIncidents";
            this.lblPercentWorkersCreatingIncidents.Size = new System.Drawing.Size(185, 13);
            this.lblPercentWorkersCreatingIncidents.TabIndex = 20;
            this.lblPercentWorkersCreatingIncidents.Text = "Percent of workers creating incidents:";
            // 
            // nudPercentOfWorkersCreatingProblems
            // 
            this.nudPercentOfWorkersCreatingProblems.Location = new System.Drawing.Point(626, 173);
            this.nudPercentOfWorkersCreatingProblems.Name = "nudPercentOfWorkersCreatingProblems";
            this.nudPercentOfWorkersCreatingProblems.Size = new System.Drawing.Size(217, 20);
            this.nudPercentOfWorkersCreatingProblems.TabIndex = 17;
            this.nudPercentOfWorkersCreatingProblems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPercentOfWorkersCreatingProblems.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // lblPercentOfWorkersCreatingProblems
            // 
            this.lblPercentOfWorkersCreatingProblems.AutoSize = true;
            this.lblPercentOfWorkersCreatingProblems.Location = new System.Drawing.Point(623, 156);
            this.lblPercentOfWorkersCreatingProblems.Name = "lblPercentOfWorkersCreatingProblems";
            this.lblPercentOfWorkersCreatingProblems.Size = new System.Drawing.Size(185, 13);
            this.lblPercentOfWorkersCreatingProblems.TabIndex = 30;
            this.lblPercentOfWorkersCreatingProblems.Text = "Percent of workers creating problems:";
            // 
            // nudNumberOfProblemsToCreatePerDay
            // 
            this.nudNumberOfProblemsToCreatePerDay.Location = new System.Drawing.Point(390, 173);
            this.nudNumberOfProblemsToCreatePerDay.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudNumberOfProblemsToCreatePerDay.Name = "nudNumberOfProblemsToCreatePerDay";
            this.nudNumberOfProblemsToCreatePerDay.Size = new System.Drawing.Size(219, 20);
            this.nudNumberOfProblemsToCreatePerDay.TabIndex = 16;
            this.nudNumberOfProblemsToCreatePerDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumberOfProblemsToCreatePerDay.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // lblNumberOfProblemsToCreatePerDay
            // 
            this.lblNumberOfProblemsToCreatePerDay.AutoSize = true;
            this.lblNumberOfProblemsToCreatePerDay.Location = new System.Drawing.Point(387, 156);
            this.lblNumberOfProblemsToCreatePerDay.Name = "lblNumberOfProblemsToCreatePerDay";
            this.lblNumberOfProblemsToCreatePerDay.Size = new System.Drawing.Size(187, 13);
            this.lblNumberOfProblemsToCreatePerDay.TabIndex = 28;
            this.lblNumberOfProblemsToCreatePerDay.Text = "Number of problems to create per day:";
            // 
            // nudNumberOfProblemsToCreate
            // 
            this.nudNumberOfProblemsToCreate.Location = new System.Drawing.Point(200, 172);
            this.nudNumberOfProblemsToCreate.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudNumberOfProblemsToCreate.Name = "nudNumberOfProblemsToCreate";
            this.nudNumberOfProblemsToCreate.Size = new System.Drawing.Size(181, 20);
            this.nudNumberOfProblemsToCreate.TabIndex = 15;
            this.nudNumberOfProblemsToCreate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumberOfProblemsToCreate.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // lblNumberOfProblemsToCreate
            // 
            this.lblNumberOfProblemsToCreate.AutoSize = true;
            this.lblNumberOfProblemsToCreate.Location = new System.Drawing.Point(197, 155);
            this.lblNumberOfProblemsToCreate.Name = "lblNumberOfProblemsToCreate";
            this.lblNumberOfProblemsToCreate.Size = new System.Drawing.Size(149, 13);
            this.lblNumberOfProblemsToCreate.TabIndex = 26;
            this.lblNumberOfProblemsToCreate.Text = "Number of problems to create:";
            // 
            // nudPercentOfWorkersCreatingReleases
            // 
            this.nudPercentOfWorkersCreatingReleases.Location = new System.Drawing.Point(626, 225);
            this.nudPercentOfWorkersCreatingReleases.Name = "nudPercentOfWorkersCreatingReleases";
            this.nudPercentOfWorkersCreatingReleases.Size = new System.Drawing.Size(217, 20);
            this.nudPercentOfWorkersCreatingReleases.TabIndex = 20;
            this.nudPercentOfWorkersCreatingReleases.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPercentOfWorkersCreatingReleases.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lblPercentOfWorkersCreatingReleases
            // 
            this.lblPercentOfWorkersCreatingReleases.AutoSize = true;
            this.lblPercentOfWorkersCreatingReleases.Location = new System.Drawing.Point(623, 208);
            this.lblPercentOfWorkersCreatingReleases.Name = "lblPercentOfWorkersCreatingReleases";
            this.lblPercentOfWorkersCreatingReleases.Size = new System.Drawing.Size(182, 13);
            this.lblPercentOfWorkersCreatingReleases.TabIndex = 36;
            this.lblPercentOfWorkersCreatingReleases.Text = "Percent of workers creating releases:";
            // 
            // nudNumberOfReleasesToCreatePerDay
            // 
            this.nudNumberOfReleasesToCreatePerDay.Location = new System.Drawing.Point(390, 225);
            this.nudNumberOfReleasesToCreatePerDay.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudNumberOfReleasesToCreatePerDay.Name = "nudNumberOfReleasesToCreatePerDay";
            this.nudNumberOfReleasesToCreatePerDay.Size = new System.Drawing.Size(219, 20);
            this.nudNumberOfReleasesToCreatePerDay.TabIndex = 19;
            this.nudNumberOfReleasesToCreatePerDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumberOfReleasesToCreatePerDay.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(387, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(184, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Number of releases to create per day:";
            // 
            // nudNumberOfReleasesToCreate
            // 
            this.nudNumberOfReleasesToCreate.Location = new System.Drawing.Point(200, 224);
            this.nudNumberOfReleasesToCreate.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudNumberOfReleasesToCreate.Name = "nudNumberOfReleasesToCreate";
            this.nudNumberOfReleasesToCreate.Size = new System.Drawing.Size(181, 20);
            this.nudNumberOfReleasesToCreate.TabIndex = 18;
            this.nudNumberOfReleasesToCreate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNumberOfReleasesToCreate.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblNumberOfReleasesToCreate
            // 
            this.lblNumberOfReleasesToCreate.AutoSize = true;
            this.lblNumberOfReleasesToCreate.Location = new System.Drawing.Point(197, 207);
            this.lblNumberOfReleasesToCreate.Name = "lblNumberOfReleasesToCreate";
            this.lblNumberOfReleasesToCreate.Size = new System.Drawing.Size(146, 13);
            this.lblNumberOfReleasesToCreate.TabIndex = 32;
            this.lblNumberOfReleasesToCreate.Text = "Number of releases to create:";
            // 
            // nudNumberOfWorkingHoursPerDay
            // 
            this.nudNumberOfWorkingHoursPerDay.Location = new System.Drawing.Point(9, 124);
            this.nudNumberOfWorkingHoursPerDay.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudNumberOfWorkingHoursPerDay.Name = "nudNumberOfWorkingHoursPerDay";
            this.nudNumberOfWorkingHoursPerDay.Size = new System.Drawing.Size(141, 20);
            this.nudNumberOfWorkingHoursPerDay.TabIndex = 3;
            this.nudNumberOfWorkingHoursPerDay.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // lblNumberOfWorkingHoursPerDay
            // 
            this.lblNumberOfWorkingHoursPerDay.AutoSize = true;
            this.lblNumberOfWorkingHoursPerDay.Location = new System.Drawing.Point(6, 107);
            this.lblNumberOfWorkingHoursPerDay.Name = "lblNumberOfWorkingHoursPerDay";
            this.lblNumberOfWorkingHoursPerDay.Size = new System.Drawing.Size(150, 13);
            this.lblNumberOfWorkingHoursPerDay.TabIndex = 38;
            this.lblNumberOfWorkingHoursPerDay.Text = "Number of working hours/day:";
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(12, 173);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(138, 20);
            this.txtDomain.TabIndex = 4;
            this.txtDomain.Text = "contoso.com";
            // 
            // lblDomain
            // 
            this.lblDomain.AutoSize = true;
            this.lblDomain.Location = new System.Drawing.Point(9, 156);
            this.lblDomain.Name = "lblDomain";
            this.lblDomain.Size = new System.Drawing.Size(46, 13);
            this.lblDomain.TabIndex = 40;
            this.lblDomain.Text = "Domain:";
            // 
            // nudWorkItemQueryUpdateRate
            // 
            this.nudWorkItemQueryUpdateRate.Location = new System.Drawing.Point(12, 224);
            this.nudWorkItemQueryUpdateRate.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudWorkItemQueryUpdateRate.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWorkItemQueryUpdateRate.Name = "nudWorkItemQueryUpdateRate";
            this.nudWorkItemQueryUpdateRate.Size = new System.Drawing.Size(141, 20);
            this.nudWorkItemQueryUpdateRate.TabIndex = 5;
            this.nudWorkItemQueryUpdateRate.Value = new decimal(new int[] {
            1800000,
            0,
            0,
            0});
            // 
            // lblWorkItemUpdateQueryRate
            // 
            this.lblWorkItemUpdateQueryRate.AutoSize = true;
            this.lblWorkItemUpdateQueryRate.Location = new System.Drawing.Point(9, 207);
            this.lblWorkItemUpdateQueryRate.Name = "lblWorkItemUpdateQueryRate";
            this.lblWorkItemUpdateQueryRate.Size = new System.Drawing.Size(122, 13);
            this.lblWorkItemUpdateQueryRate.TabIndex = 42;
            this.lblWorkItemUpdateQueryRate.Text = "Do work frequency (ms):";
            // 
            // lblSupportGroupFilePath
            // 
            this.lblSupportGroupFilePath.AutoSize = true;
            this.lblSupportGroupFilePath.Location = new System.Drawing.Point(9, 345);
            this.lblSupportGroupFilePath.Name = "lblSupportGroupFilePath";
            this.lblSupportGroupFilePath.Size = new System.Drawing.Size(117, 13);
            this.lblSupportGroupFilePath.TabIndex = 44;
            this.lblSupportGroupFilePath.Text = "Support group file path:";
            // 
            // openFileDialogSupportGroupFile
            // 
            this.openFileDialogSupportGroupFile.FileName = "openFileDialog1";
            this.openFileDialogSupportGroupFile.Filter = "txt Files | *.txt";
            this.openFileDialogSupportGroupFile.Title = "Select Support Group File";
            // 
            // txtSupportGroupFilePath
            // 
            this.txtSupportGroupFilePath.Location = new System.Drawing.Point(9, 362);
            this.txtSupportGroupFilePath.Name = "txtSupportGroupFilePath";
            this.txtSupportGroupFilePath.Size = new System.Drawing.Size(602, 20);
            this.txtSupportGroupFilePath.TabIndex = 21;
            this.txtSupportGroupFilePath.Text = "C:\\PerfTestHarness\\SupportGroups200.txt";
            // 
            // btnBrowseForSupportGroupFilePath
            // 
            this.btnBrowseForSupportGroupFilePath.Location = new System.Drawing.Point(617, 360);
            this.btnBrowseForSupportGroupFilePath.Name = "btnBrowseForSupportGroupFilePath";
            this.btnBrowseForSupportGroupFilePath.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseForSupportGroupFilePath.TabIndex = 22;
            this.btnBrowseForSupportGroupFilePath.Text = "Browse...";
            this.btnBrowseForSupportGroupFilePath.UseVisualStyleBackColor = true;
            this.btnBrowseForSupportGroupFilePath.Click += new System.EventHandler(this.btnBrowseForSupportGroupFilePath_Click);
            // 
            // lblDoWorkPause
            // 
            this.lblDoWorkPause.AutoSize = true;
            this.lblDoWorkPause.Location = new System.Drawing.Point(12, 251);
            this.lblDoWorkPause.Name = "lblDoWorkPause";
            this.lblDoWorkPause.Size = new System.Drawing.Size(104, 13);
            this.lblDoWorkPause.TabIndex = 45;
            this.lblDoWorkPause.Text = "Do work pause (ms):";
            // 
            // nudDoWorkPause
            // 
            this.nudDoWorkPause.Location = new System.Drawing.Point(12, 268);
            this.nudDoWorkPause.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudDoWorkPause.Name = "nudDoWorkPause";
            this.nudDoWorkPause.Size = new System.Drawing.Size(141, 20);
            this.nudDoWorkPause.TabIndex = 46;
            this.nudDoWorkPause.Value = new decimal(new int[] {
            120000,
            0,
            0,
            0});
            // 
            // lblNumberOfWorkItemsToGet
            // 
            this.lblNumberOfWorkItemsToGet.AutoSize = true;
            this.lblNumberOfWorkItemsToGet.Location = new System.Drawing.Point(9, 295);
            this.lblNumberOfWorkItemsToGet.Name = "lblNumberOfWorkItemsToGet";
            this.lblNumberOfWorkItemsToGet.Size = new System.Drawing.Size(142, 13);
            this.lblNumberOfWorkItemsToGet.TabIndex = 47;
            this.lblNumberOfWorkItemsToGet.Text = "Number of work items to get:";
            // 
            // nudNumberOfWorkItemsToGet
            // 
            this.nudNumberOfWorkItemsToGet.Location = new System.Drawing.Point(12, 312);
            this.nudNumberOfWorkItemsToGet.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudNumberOfWorkItemsToGet.Name = "nudNumberOfWorkItemsToGet";
            this.nudNumberOfWorkItemsToGet.Size = new System.Drawing.Size(139, 20);
            this.nudNumberOfWorkItemsToGet.TabIndex = 48;
            this.nudNumberOfWorkItemsToGet.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 442);
            this.Controls.Add(this.nudNumberOfWorkItemsToGet);
            this.Controls.Add(this.lblNumberOfWorkItemsToGet);
            this.Controls.Add(this.nudDoWorkPause);
            this.Controls.Add(this.lblDoWorkPause);
            this.Controls.Add(this.btnBrowseForSupportGroupFilePath);
            this.Controls.Add(this.txtSupportGroupFilePath);
            this.Controls.Add(this.lblSupportGroupFilePath);
            this.Controls.Add(this.nudWorkItemQueryUpdateRate);
            this.Controls.Add(this.lblWorkItemUpdateQueryRate);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.lblDomain);
            this.Controls.Add(this.nudNumberOfWorkingHoursPerDay);
            this.Controls.Add(this.lblNumberOfWorkingHoursPerDay);
            this.Controls.Add(this.nudPercentOfWorkersCreatingReleases);
            this.Controls.Add(this.lblPercentOfWorkersCreatingReleases);
            this.Controls.Add(this.nudNumberOfReleasesToCreatePerDay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nudNumberOfReleasesToCreate);
            this.Controls.Add(this.lblNumberOfReleasesToCreate);
            this.Controls.Add(this.nudPercentOfWorkersCreatingProblems);
            this.Controls.Add(this.lblPercentOfWorkersCreatingProblems);
            this.Controls.Add(this.nudNumberOfProblemsToCreatePerDay);
            this.Controls.Add(this.lblNumberOfProblemsToCreatePerDay);
            this.Controls.Add(this.nudNumberOfProblemsToCreate);
            this.Controls.Add(this.lblNumberOfProblemsToCreate);
            this.Controls.Add(this.nudPercentOfWorkersCreatingServiceRequests);
            this.Controls.Add(this.lblPercentOfWorkersCreatingServiceRequests);
            this.Controls.Add(this.nudPercentOfWorkersCreatingChangeRequests);
            this.Controls.Add(this.lblPercentOfWorkersCreatingChangeRequests);
            this.Controls.Add(this.nudPercentOfWorkersCreatingIncidents);
            this.Controls.Add(this.lblPercentWorkersCreatingIncidents);
            this.Controls.Add(this.nudNumberOfServiceRequestsToCreatePerDay);
            this.Controls.Add(this.lblNumberOfServiceRequestsToCreatePerDay);
            this.Controls.Add(this.nudNumberOfChangeRequestsToCreatePerDay);
            this.Controls.Add(this.lblNumberOfChangeRequestsToCreatePerDay);
            this.Controls.Add(this.nudNumberOfIncidentsToCreatePerDay);
            this.Controls.Add(this.lblNumberOfIncidentsToCreatePerDay);
            this.Controls.Add(this.nudNumberOfServiceRequestsToCreate);
            this.Controls.Add(this.lblNumberOfServiceRequestsToCreate);
            this.Controls.Add(this.nudNumberOfChangeRequestsToCreate);
            this.Controls.Add(this.lblNumberOfChangeRequestsToCreate);
            this.Controls.Add(this.nudNumberOfIncidentsToCreate);
            this.Controls.Add(this.lblNumberOfIncidentToCreate);
            this.Controls.Add(this.txtServerName);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.nudStartupInterval);
            this.Controls.Add(this.lblThreadStartupInterval);
            this.Controls.Add(this.btnStartLoad);
            this.Name = "FormMain";
            this.Text = "LoadGen";
            ((System.ComponentModel.ISupportInitialize)(this.nudStartupInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfIncidentsToCreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfChangeRequestsToCreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfServiceRequestsToCreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfServiceRequestsToCreatePerDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfChangeRequestsToCreatePerDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfIncidentsToCreatePerDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentOfWorkersCreatingServiceRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentOfWorkersCreatingChangeRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentOfWorkersCreatingIncidents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentOfWorkersCreatingProblems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfProblemsToCreatePerDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfProblemsToCreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPercentOfWorkersCreatingReleases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfReleasesToCreatePerDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfReleasesToCreate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfWorkingHoursPerDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWorkItemQueryUpdateRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDoWorkPause)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfWorkItemsToGet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStartLoad;
        private Label lblThreadStartupInterval;
        private NumericUpDown nudStartupInterval;
        private Label lblServerName;
        private TextBox txtServerName;
        private Label lblNumberOfIncidentToCreate;
        private NumericUpDown nudNumberOfIncidentsToCreate;
        private NumericUpDown nudNumberOfChangeRequestsToCreate;
        private Label lblNumberOfChangeRequestsToCreate;
        private NumericUpDown nudNumberOfServiceRequestsToCreate;
        private Label lblNumberOfServiceRequestsToCreate;
        private NumericUpDown nudNumberOfServiceRequestsToCreatePerDay;
        private Label lblNumberOfServiceRequestsToCreatePerDay;
        private NumericUpDown nudNumberOfChangeRequestsToCreatePerDay;
        private Label lblNumberOfChangeRequestsToCreatePerDay;
        private NumericUpDown nudNumberOfIncidentsToCreatePerDay;
        private Label lblNumberOfIncidentsToCreatePerDay;
        private NumericUpDown nudPercentOfWorkersCreatingServiceRequests;
        private Label lblPercentOfWorkersCreatingServiceRequests;
        private NumericUpDown nudPercentOfWorkersCreatingChangeRequests;
        private Label lblPercentOfWorkersCreatingChangeRequests;
        private NumericUpDown nudPercentOfWorkersCreatingIncidents;
        private Label lblPercentWorkersCreatingIncidents;
        private NumericUpDown nudPercentOfWorkersCreatingProblems;
        private Label lblPercentOfWorkersCreatingProblems;
        private NumericUpDown nudNumberOfProblemsToCreatePerDay;
        private Label lblNumberOfProblemsToCreatePerDay;
        private NumericUpDown nudNumberOfProblemsToCreate;
        private Label lblNumberOfProblemsToCreate;
        private NumericUpDown nudPercentOfWorkersCreatingReleases;
        private Label lblPercentOfWorkersCreatingReleases;
        private NumericUpDown nudNumberOfReleasesToCreatePerDay;
        private Label label5;
        private NumericUpDown nudNumberOfReleasesToCreate;
        private Label lblNumberOfReleasesToCreate;
        private NumericUpDown nudNumberOfWorkingHoursPerDay;
        private Label lblNumberOfWorkingHoursPerDay;
        private TextBox txtDomain;
        private Label lblDomain;
        private NumericUpDown nudWorkItemQueryUpdateRate;
        private Label lblWorkItemUpdateQueryRate;
        private Label lblSupportGroupFilePath;
        private OpenFileDialog openFileDialogSupportGroupFile;
        private TextBox txtSupportGroupFilePath;
        private Button btnBrowseForSupportGroupFilePath;
        private Label lblDoWorkPause;
        private NumericUpDown nudDoWorkPause;
        private Label lblNumberOfWorkItemsToGet;
        private NumericUpDown nudNumberOfWorkItemsToGet;
    }
}