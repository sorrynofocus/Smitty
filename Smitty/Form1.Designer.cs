namespace Smitty
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label2 = new System.Windows.Forms.Label();
            this.dlg_BrowseFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDrives = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.MainDriveListView = new System.Windows.Forms.ListView();
            this.colHeaderDrive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeaderFreeUsed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuDrives = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.goHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportThisDrivesInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoCleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBoxSearchStat = new System.Windows.Forms.PictureBox();
            this.btnCancelSearch = new System.Windows.Forms.Button();
            this.lbHoursLeft = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClearFilesFound = new System.Windows.Forms.Button();
            this.lbIWIllCleanUpText = new System.Windows.Forms.Label();
            this.txtFilePattern = new System.Windows.Forms.TextBox();
            this.lbFileAmountFound = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbDirAmountFound = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbHushOutput = new System.Windows.Forms.CheckBox();
            this.checkBoxDontProcessParentFolderFiles = new System.Windows.Forms.CheckBox();
            this.lbDaysOld = new System.Windows.Forms.Label();
            this.cbLastAccessedCheck = new System.Windows.Forms.CheckBox();
            this.cbClearUserTemp = new System.Windows.Forms.CheckBox();
            this.cbLastWriteCheck = new System.Windows.Forms.CheckBox();
            this.cbDestructive = new System.Windows.Forms.CheckBox();
            this.lblDaysToRemove = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackbarDaysToOperate = new System.Windows.Forms.TrackBar();
            this.lbFilesProcessed = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btAddDirs = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserDirEntry = new System.Windows.Forms.TextBox();
            this.btnRemoveItemFromDirEntry = new System.Windows.Forms.Button();
            this.btnAddItemFromDirEntry = new System.Windows.Forms.Button();
            this.lstUserDirectoryOptions = new System.Windows.Forms.ListBox();
            this.contextMenuEnableDisableDirSearch = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DisableDirOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnableDirOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemRemoveDir = new System.Windows.Forms.ToolStripMenuItem();
            this.DialogFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.ToolTipOnComponents = new System.Windows.Forms.ToolTip(this.components);
            this.TNANotify1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuTNA = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.aBoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimerTicker_01 = new System.Windows.Forms.Timer(this.components);
            this.TimerTicker_02 = new System.Windows.Forms.Timer(this.components);
            this.TimerTicker_03_STATDrives = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageDrives.SuspendLayout();
            this.contextMenuDrives.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchStat)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarDaysToOperate)).BeginInit();
            this.contextMenuEnableDisableDirSearch.SuspendLayout();
            this.contextMenuTNA.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(588, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SMITTy is an application to perform basic maintenance on a system.  You can choos" +
    "e the options below to automate tasks.";
            // 
            // dlg_BrowseFolder
            // 
            this.dlg_BrowseFolder.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.dlg_BrowseFolder.ShowNewFolderButton = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageDrives);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(588, 383);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageDrives
            // 
            this.tabPageDrives.Controls.Add(this.label4);
            this.tabPageDrives.Controls.Add(this.MainDriveListView);
            this.tabPageDrives.Location = new System.Drawing.Point(4, 22);
            this.tabPageDrives.Name = "tabPageDrives";
            this.tabPageDrives.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageDrives.Size = new System.Drawing.Size(580, 357);
            this.tabPageDrives.TabIndex = 0;
            this.tabPageDrives.Text = "Drive resources";
            this.tabPageDrives.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Local/Network drives detected are listed below:";
            // 
            // MainDriveListView
            // 
            this.MainDriveListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.MainDriveListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHeaderDrive,
            this.colHeaderType,
            this.colHeaderTotal,
            this.colHeaderFreeUsed});
            this.MainDriveListView.ContextMenuStrip = this.contextMenuDrives;
            this.MainDriveListView.HideSelection = false;
            this.MainDriveListView.HotTracking = true;
            this.MainDriveListView.HoverSelection = true;
            this.MainDriveListView.Location = new System.Drawing.Point(6, 42);
            this.MainDriveListView.MultiSelect = false;
            this.MainDriveListView.Name = "MainDriveListView";
            this.MainDriveListView.Size = new System.Drawing.Size(567, 310);
            this.MainDriveListView.TabIndex = 15;
            this.MainDriveListView.UseCompatibleStateImageBehavior = false;
            this.MainDriveListView.View = System.Windows.Forms.View.Details;
            this.MainDriveListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainDriveListView_MouseClick);
            // 
            // colHeaderDrive
            // 
            this.colHeaderDrive.Text = "Drive";
            this.colHeaderDrive.Width = 135;
            // 
            // colHeaderType
            // 
            this.colHeaderType.Text = "Type";
            this.colHeaderType.Width = 120;
            // 
            // colHeaderTotal
            // 
            this.colHeaderTotal.Text = "Total";
            this.colHeaderTotal.Width = 125;
            // 
            // colHeaderFreeUsed
            // 
            this.colHeaderFreeUsed.Text = "Used / Free";
            this.colHeaderFreeUsed.Width = 180;
            // 
            // contextMenuDrives
            // 
            this.contextMenuDrives.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuDrives.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goHereToolStripMenuItem,
            this.exportThisDrivesInfoToolStripMenuItem,
            this.autoCleanToolStripMenuItem});
            this.contextMenuDrives.Name = "contextMenuDrives";
            this.contextMenuDrives.Size = new System.Drawing.Size(195, 70);
            this.contextMenuDrives.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuDrives_Closed);
            this.contextMenuDrives.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuDrives_Opening);
            // 
            // goHereToolStripMenuItem
            // 
            this.goHereToolStripMenuItem.Name = "goHereToolStripMenuItem";
            this.goHereToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.goHereToolStripMenuItem.Text = "Go here...";
            this.goHereToolStripMenuItem.Click += new System.EventHandler(this.goHereToolStripMenuItem_Click);
            // 
            // exportThisDrivesInfoToolStripMenuItem
            // 
            this.exportThisDrivesInfoToolStripMenuItem.Name = "exportThisDrivesInfoToolStripMenuItem";
            this.exportThisDrivesInfoToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.exportThisDrivesInfoToolStripMenuItem.Text = "Export drive info to file";
            this.exportThisDrivesInfoToolStripMenuItem.Click += new System.EventHandler(this.exportThisDrivesInfoToolStripMenuItem_Click);
            // 
            // autoCleanToolStripMenuItem
            // 
            this.autoCleanToolStripMenuItem.Name = "autoCleanToolStripMenuItem";
            this.autoCleanToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.autoCleanToolStripMenuItem.Text = "AutoClean";
            this.autoCleanToolStripMenuItem.Visible = false;
            this.autoCleanToolStripMenuItem.Click += new System.EventHandler(this.autoCleanToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(580, 357);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "File/Folder Maintenance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBoxSearchStat);
            this.groupBox1.Controls.Add(this.btnCancelSearch);
            this.groupBox1.Controls.Add(this.lbHoursLeft);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnClearFilesFound);
            this.groupBox1.Controls.Add(this.lbIWIllCleanUpText);
            this.groupBox1.Controls.Add(this.txtFilePattern);
            this.groupBox1.Controls.Add(this.lbFileAmountFound);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbDirAmountFound);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lbFilesProcessed);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btAddDirs);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUserDirEntry);
            this.groupBox1.Controls.Add(this.btnRemoveItemFromDirEntry);
            this.groupBox1.Controls.Add(this.btnAddItemFromDirEntry);
            this.groupBox1.Controls.Add(this.lstUserDirectoryOptions);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 348);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Remove files/folders based on age";
            // 
            // pictureBoxSearchStat
            // 
            this.pictureBoxSearchStat.BackColor = System.Drawing.Color.LightGreen;
            this.pictureBoxSearchStat.Location = new System.Drawing.Point(459, 336);
            this.pictureBoxSearchStat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxSearchStat.Name = "pictureBoxSearchStat";
            this.pictureBoxSearchStat.Size = new System.Drawing.Size(8, 8);
            this.pictureBoxSearchStat.TabIndex = 24;
            this.pictureBoxSearchStat.TabStop = false;
            // 
            // btnCancelSearch
            // 
            this.btnCancelSearch.Location = new System.Drawing.Point(472, 323);
            this.btnCancelSearch.Name = "btnCancelSearch";
            this.btnCancelSearch.Size = new System.Drawing.Size(64, 20);
            this.btnCancelSearch.TabIndex = 18;
            this.btnCancelSearch.Text = "Cancel";
            this.btnCancelSearch.UseVisualStyleBackColor = true;
            this.btnCancelSearch.Click += new System.EventHandler(this.btnCancelSearch_Click);
            // 
            // lbHoursLeft
            // 
            this.lbHoursLeft.AutoSize = true;
            this.lbHoursLeft.Location = new System.Drawing.Point(232, 330);
            this.lbHoursLeft.Name = "lbHoursLeft";
            this.lbHoursLeft.Size = new System.Drawing.Size(31, 13);
            this.lbHoursLeft.TabIndex = 23;
            this.lbHoursLeft.Text = "????";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Pattern";
            this.ToolTipOnComponents.SetToolTip(this.label7, "you can enter filename patterns here, i.e. *.txt");
            // 
            // btnClearFilesFound
            // 
            this.btnClearFilesFound.Location = new System.Drawing.Point(542, 323);
            this.btnClearFilesFound.Name = "btnClearFilesFound";
            this.btnClearFilesFound.Size = new System.Drawing.Size(22, 20);
            this.btnClearFilesFound.TabIndex = 17;
            this.btnClearFilesFound.Text = "X";
            this.ToolTipOnComponents.SetToolTip(this.btnClearFilesFound, "Clear list");
            this.btnClearFilesFound.UseVisualStyleBackColor = true;
            this.btnClearFilesFound.Click += new System.EventHandler(this.btnClearFilesFound_Click);
            // 
            // lbIWIllCleanUpText
            // 
            this.lbIWIllCleanUpText.AutoSize = true;
            this.lbIWIllCleanUpText.Location = new System.Drawing.Point(196, 330);
            this.lbIWIllCleanUpText.Name = "lbIWIllCleanUpText";
            this.lbIWIllCleanUpText.Size = new System.Drawing.Size(40, 13);
            this.lbIWIllCleanUpText.TabIndex = 19;
            this.lbIWIllCleanUpText.Text = "Status:";
            // 
            // txtFilePattern
            // 
            this.txtFilePattern.Location = new System.Drawing.Point(43, 66);
            this.txtFilePattern.Name = "txtFilePattern";
            this.txtFilePattern.Size = new System.Drawing.Size(101, 20);
            this.txtFilePattern.TabIndex = 16;
            this.txtFilePattern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFilePattern_KeyPress);
            // 
            // lbFileAmountFound
            // 
            this.lbFileAmountFound.AutoSize = true;
            this.lbFileAmountFound.Location = new System.Drawing.Point(29, 330);
            this.lbFileAmountFound.Name = "lbFileAmountFound";
            this.lbFileAmountFound.Size = new System.Drawing.Size(13, 13);
            this.lbFileAmountFound.TabIndex = 14;
            this.lbFileAmountFound.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 330);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Files:";
            // 
            // lbDirAmountFound
            // 
            this.lbDirAmountFound.AutoSize = true;
            this.lbDirAmountFound.Location = new System.Drawing.Point(133, 330);
            this.lbDirAmountFound.Name = "lbDirAmountFound";
            this.lbDirAmountFound.Size = new System.Drawing.Size(13, 13);
            this.lbDirAmountFound.TabIndex = 12;
            this.lbDirAmountFound.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 330);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Folders:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbHushOutput);
            this.groupBox2.Controls.Add(this.checkBoxDontProcessParentFolderFiles);
            this.groupBox2.Controls.Add(this.lbDaysOld);
            this.groupBox2.Controls.Add(this.cbLastAccessedCheck);
            this.groupBox2.Controls.Add(this.cbClearUserTemp);
            this.groupBox2.Controls.Add(this.cbLastWriteCheck);
            this.groupBox2.Controls.Add(this.cbDestructive);
            this.groupBox2.Controls.Add(this.lblDaysToRemove);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.trackbarDaysToOperate);
            this.groupBox2.Location = new System.Drawing.Point(286, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 154);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // cbHushOutput
            // 
            this.cbHushOutput.AutoSize = true;
            this.cbHushOutput.Location = new System.Drawing.Point(125, 61);
            this.cbHushOutput.Name = "cbHushOutput";
            this.cbHushOutput.Size = new System.Drawing.Size(123, 17);
            this.cbHushOutput.TabIndex = 26;
            this.cbHushOutput.Text = "Hush ouput, log only";
            this.ToolTipOnComponents.SetToolTip(this.cbHushOutput, "Check when the file was last accessed");
            this.cbHushOutput.UseVisualStyleBackColor = true;
            this.cbHushOutput.CheckedChanged += new System.EventHandler(this.cbHushOutput_CheckedChanged);
            // 
            // checkBoxDontProcessParentFolderFiles
            // 
            this.checkBoxDontProcessParentFolderFiles.AutoSize = true;
            this.checkBoxDontProcessParentFolderFiles.Location = new System.Drawing.Point(9, 61);
            this.checkBoxDontProcessParentFolderFiles.Name = "checkBoxDontProcessParentFolderFiles";
            this.checkBoxDontProcessParentFolderFiles.Size = new System.Drawing.Size(115, 17);
            this.checkBoxDontProcessParentFolderFiles.TabIndex = 25;
            this.checkBoxDontProcessParentFolderFiles.Text = "Dismiss parent files";
            this.ToolTipOnComponents.SetToolTip(this.checkBoxDontProcessParentFolderFiles, "Don\'t process files within the original parent folder. Only process sub-folders a" +
        "nd the files within them.");
            this.checkBoxDontProcessParentFolderFiles.UseVisualStyleBackColor = true;
            this.checkBoxDontProcessParentFolderFiles.CheckedChanged += new System.EventHandler(this.CheckBoxDontProcessParentFolderFiles_CheckedChanged);
            // 
            // lbDaysOld
            // 
            this.lbDaysOld.AutoSize = true;
            this.lbDaysOld.Location = new System.Drawing.Point(226, 136);
            this.lbDaysOld.Name = "lbDaysOld";
            this.lbDaysOld.Size = new System.Drawing.Size(46, 13);
            this.lbDaysOld.TabIndex = 24;
            this.lbDaysOld.Text = "days old";
            // 
            // cbLastAccessedCheck
            // 
            this.cbLastAccessedCheck.AutoSize = true;
            this.cbLastAccessedCheck.Location = new System.Drawing.Point(125, 40);
            this.cbLastAccessedCheck.Name = "cbLastAccessedCheck";
            this.cbLastAccessedCheck.Size = new System.Drawing.Size(96, 17);
            this.cbLastAccessedCheck.TabIndex = 17;
            this.cbLastAccessedCheck.Text = "Last Accessed";
            this.ToolTipOnComponents.SetToolTip(this.cbLastAccessedCheck, "Check when the file was last accessed");
            this.cbLastAccessedCheck.UseVisualStyleBackColor = true;
            this.cbLastAccessedCheck.CheckedChanged += new System.EventHandler(this.cbLastAccessedCheck_CheckedChanged);
            // 
            // cbClearUserTemp
            // 
            this.cbClearUserTemp.AutoSize = true;
            this.cbClearUserTemp.Location = new System.Drawing.Point(125, 19);
            this.cbClearUserTemp.Name = "cbClearUserTemp";
            this.cbClearUserTemp.Size = new System.Drawing.Size(105, 17);
            this.cbClearUserTemp.TabIndex = 16;
            this.cbClearUserTemp.Text = "Clear User Temp";
            this.ToolTipOnComponents.SetToolTip(this.cbClearUserTemp, "Clear user temporary files");
            this.cbClearUserTemp.UseVisualStyleBackColor = true;
            this.cbClearUserTemp.CheckedChanged += new System.EventHandler(this.cbClearUserTemp_CheckedChanged);
            // 
            // cbLastWriteCheck
            // 
            this.cbLastWriteCheck.AutoSize = true;
            this.cbLastWriteCheck.Location = new System.Drawing.Point(9, 40);
            this.cbLastWriteCheck.Name = "cbLastWriteCheck";
            this.cbLastWriteCheck.Size = new System.Drawing.Size(89, 17);
            this.cbLastWriteCheck.TabIndex = 15;
            this.cbLastWriteCheck.Text = "Last Modified";
            this.ToolTipOnComponents.SetToolTip(this.cbLastWriteCheck, "Check last modified time");
            this.cbLastWriteCheck.UseVisualStyleBackColor = true;
            this.cbLastWriteCheck.CheckedChanged += new System.EventHandler(this.cbActionAfterSearch_CheckedChanged);
            // 
            // cbDestructive
            // 
            this.cbDestructive.AutoSize = true;
            this.cbDestructive.Location = new System.Drawing.Point(9, 19);
            this.cbDestructive.Name = "cbDestructive";
            this.cbDestructive.Size = new System.Drawing.Size(80, 17);
            this.cbDestructive.TabIndex = 14;
            this.cbDestructive.Text = "Destructive";
            this.ToolTipOnComponents.SetToolTip(this.cbDestructive, "When searching, DELETE the files and directories instead of displaying them");
            this.cbDestructive.UseVisualStyleBackColor = true;
            this.cbDestructive.CheckedChanged += new System.EventHandler(this.cbDestructive_CheckedChanged);
            // 
            // lblDaysToRemove
            // 
            this.lblDaysToRemove.AutoSize = true;
            this.lblDaysToRemove.Location = new System.Drawing.Point(196, 136);
            this.lblDaysToRemove.Name = "lblDaysToRemove";
            this.lblDaysToRemove.Size = new System.Drawing.Size(33, 13);
            this.lblDaysToRemove.TabIndex = 13;
            this.lblDaysToRemove.Text = "5 1/2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Remove files";
            // 
            // trackbarDaysToOperate
            // 
            this.trackbarDaysToOperate.AutoSize = false;
            this.trackbarDaysToOperate.LargeChange = 60;
            this.trackbarDaysToOperate.Location = new System.Drawing.Point(5, 101);
            this.trackbarDaysToOperate.Maximum = 1826;
            this.trackbarDaysToOperate.Name = "trackbarDaysToOperate";
            this.trackbarDaysToOperate.Size = new System.Drawing.Size(268, 31);
            this.trackbarDaysToOperate.TabIndex = 1;
            this.trackbarDaysToOperate.TickFrequency = 182;
            this.trackbarDaysToOperate.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackbarDaysToOperate.Scroll += new System.EventHandler(this.trackbarDaysToOperate_Scroll);
            // 
            // lbFilesProcessed
            // 
            this.lbFilesProcessed.FormattingEnabled = true;
            this.lbFilesProcessed.HorizontalScrollbar = true;
            this.lbFilesProcessed.Location = new System.Drawing.Point(4, 199);
            this.lbFilesProcessed.Name = "lbFilesProcessed";
            this.lbFilesProcessed.Size = new System.Drawing.Size(561, 121);
            this.lbFilesProcessed.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(394, 323);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 20);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btAddDirs
            // 
            this.btAddDirs.Location = new System.Drawing.Point(217, 39);
            this.btAddDirs.Name = "btAddDirs";
            this.btAddDirs.Size = new System.Drawing.Size(63, 20);
            this.btAddDirs.TabIndex = 4;
            this.btAddDirs.Text = "&Browse";
            this.btAddDirs.UseVisualStyleBackColor = true;
            this.btAddDirs.Click += new System.EventHandler(this.btAddDirs_Click_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(81, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(442, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Choose directories/folders and choose options to process. Then, press Search to p" +
    "rocess.";
            // 
            // txtUserDirEntry
            // 
            this.txtUserDirEntry.Location = new System.Drawing.Point(3, 43);
            this.txtUserDirEntry.Name = "txtUserDirEntry";
            this.txtUserDirEntry.Size = new System.Drawing.Size(209, 20);
            this.txtUserDirEntry.TabIndex = 1;
            this.txtUserDirEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserDirEntry_KeyDown);
            // 
            // btnRemoveItemFromDirEntry
            // 
            this.btnRemoveItemFromDirEntry.Location = new System.Drawing.Point(222, 66);
            this.btnRemoveItemFromDirEntry.Name = "btnRemoveItemFromDirEntry";
            this.btnRemoveItemFromDirEntry.Size = new System.Drawing.Size(58, 20);
            this.btnRemoveItemFromDirEntry.TabIndex = 3;
            this.btnRemoveItemFromDirEntry.Text = "Remove";
            this.btnRemoveItemFromDirEntry.UseVisualStyleBackColor = true;
            this.btnRemoveItemFromDirEntry.Click += new System.EventHandler(this.BtnRemoveItemFromDirEntry_Click);
            // 
            // btnAddItemFromDirEntry
            // 
            this.btnAddItemFromDirEntry.Location = new System.Drawing.Point(164, 66);
            this.btnAddItemFromDirEntry.Name = "btnAddItemFromDirEntry";
            this.btnAddItemFromDirEntry.Size = new System.Drawing.Size(58, 20);
            this.btnAddItemFromDirEntry.TabIndex = 2;
            this.btnAddItemFromDirEntry.Text = "Add";
            this.btnAddItemFromDirEntry.UseVisualStyleBackColor = true;
            this.btnAddItemFromDirEntry.Click += new System.EventHandler(this.BtnAddItemFromDirEntry_Click);
            // 
            // lstUserDirectoryOptions
            // 
            this.lstUserDirectoryOptions.ContextMenuStrip = this.contextMenuEnableDisableDirSearch;
            this.lstUserDirectoryOptions.FormattingEnabled = true;
            this.lstUserDirectoryOptions.HorizontalScrollbar = true;
            this.lstUserDirectoryOptions.IntegralHeight = false;
            this.lstUserDirectoryOptions.Location = new System.Drawing.Point(4, 90);
            this.lstUserDirectoryOptions.Name = "lstUserDirectoryOptions";
            this.lstUserDirectoryOptions.Size = new System.Drawing.Size(277, 76);
            this.lstUserDirectoryOptions.TabIndex = 1;
            this.lstUserDirectoryOptions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstFilesFound_KeyDown);
            this.lstUserDirectoryOptions.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstFilesFound_MouseDoubleClick);
            // 
            // contextMenuEnableDisableDirSearch
            // 
            this.contextMenuEnableDisableDirSearch.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuEnableDisableDirSearch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DisableDirOptionToolStripMenuItem,
            this.EnableDirOptionToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItemRemoveDir});
            this.contextMenuEnableDisableDirSearch.Name = "contextMenuEnableDisableDirSearch";
            this.contextMenuEnableDisableDirSearch.Size = new System.Drawing.Size(163, 76);
            this.contextMenuEnableDisableDirSearch.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuEnableDisableDirSearch_Opening);
            this.contextMenuEnableDisableDirSearch.Click += new System.EventHandler(this.contextMenuEnableDisableDirSearch_Click);
            // 
            // DisableDirOptionToolStripMenuItem
            // 
            this.DisableDirOptionToolStripMenuItem.Name = "DisableDirOptionToolStripMenuItem";
            this.DisableDirOptionToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.DisableDirOptionToolStripMenuItem.Text = "Disable in search";
            this.DisableDirOptionToolStripMenuItem.Click += new System.EventHandler(this.DisableDirOptionToolStripMenuItem_Click);
            // 
            // EnableDirOptionToolStripMenuItem
            // 
            this.EnableDirOptionToolStripMenuItem.Name = "EnableDirOptionToolStripMenuItem";
            this.EnableDirOptionToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.EnableDirOptionToolStripMenuItem.Text = "Enable in search";
            this.EnableDirOptionToolStripMenuItem.Click += new System.EventHandler(this.EnableDirOptionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(159, 6);
            // 
            // toolStripMenuItemRemoveDir
            // 
            this.toolStripMenuItemRemoveDir.Name = "toolStripMenuItemRemoveDir";
            this.toolStripMenuItemRemoveDir.Size = new System.Drawing.Size(162, 22);
            this.toolStripMenuItemRemoveDir.Text = "Remove";
            this.toolStripMenuItemRemoveDir.Click += new System.EventHandler(this.ToolStripMenuItemRemoveDir_Click);
            // 
            // DialogFolderBrowser
            // 
            this.DialogFolderBrowser.Description = "Browse folders to add for file-folder maint";
            this.DialogFolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // TNANotify1
            // 
            this.TNANotify1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TNANotify1.BalloonTipTitle = "SMITTy";
            this.TNANotify1.ContextMenuStrip = this.contextMenuTNA;
            this.TNANotify1.Icon = ((System.Drawing.Icon)(resources.GetObject("TNANotify1.Icon")));
            this.TNANotify1.Text = "SMITTy";
            this.TNANotify1.Visible = true;
            this.TNANotify1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuTNA
            // 
            this.contextMenuTNA.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuTNA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdatesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.aBoutToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.contextMenuTNA.Name = "contextMenuTNA";
            this.contextMenuTNA.Size = new System.Drawing.Size(171, 82);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for updates";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(167, 6);
            // 
            // aBoutToolStripMenuItem
            // 
            this.aBoutToolStripMenuItem.Name = "aBoutToolStripMenuItem";
            this.aBoutToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.aBoutToolStripMenuItem.Text = "A&bout";
            this.aBoutToolStripMenuItem.Click += new System.EventHandler(this.aBoutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(167, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // TimerTicker_01
            // 
            this.TimerTicker_01.Interval = 1000;
            this.TimerTicker_01.Tick += new System.EventHandler(this.TimerTicker_01_Tick);
            // 
            // TimerTicker_02
            // 
            this.TimerTicker_02.Tick += new System.EventHandler(this.TimerTicker_02_Tick);
            // 
            // TimerTicker_03_STATDrives
            // 
            this.TimerTicker_03_STATDrives.Interval = 10000;
            this.TimerTicker_03_STATDrives.Tick += new System.EventHandler(this.TimerTicker_03_STATDrives_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 431);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMITTy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPageDrives.ResumeLayout(false);
            this.tabPageDrives.PerformLayout();
            this.contextMenuDrives.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearchStat)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackbarDaysToOperate)).EndInit();
            this.contextMenuEnableDisableDirSearch.ResumeLayout(false);
            this.contextMenuTNA.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog dlg_BrowseFolder;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDrives;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FolderBrowserDialog DialogFolderBrowser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btAddDirs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserDirEntry;
        private System.Windows.Forms.Button btnRemoveItemFromDirEntry;
        private System.Windows.Forms.Button btnAddItemFromDirEntry;
        private System.Windows.Forms.ListBox lstUserDirectoryOptions;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lbFilesProcessed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDaysToRemove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackbarDaysToOperate;
        private System.Windows.Forms.ListView MainDriveListView;
        private System.Windows.Forms.ColumnHeader colHeaderDrive;
        private System.Windows.Forms.ColumnHeader colHeaderType;
        private System.Windows.Forms.ColumnHeader colHeaderTotal;
        private System.Windows.Forms.ColumnHeader colHeaderFreeUsed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbDestructive;
        private System.Windows.Forms.CheckBox cbLastWriteCheck;
        private System.Windows.Forms.ToolTip ToolTipOnComponents;
        private System.Windows.Forms.Label lbFileAmountFound;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbDirAmountFound;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFilePattern;
        private System.Windows.Forms.Button btnClearFilesFound;
        private System.Windows.Forms.ContextMenuStrip contextMenuDrives;
        private System.Windows.Forms.ToolStripMenuItem exportThisDrivesInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goHereToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon TNANotify1;
        private System.Windows.Forms.ContextMenuStrip contextMenuTNA;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aBoutToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbClearUserTemp;
        private System.Windows.Forms.ToolStripMenuItem autoCleanToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbLastAccessedCheck;
        private System.Windows.Forms.Button btnCancelSearch;
        private System.Windows.Forms.Timer TimerTicker_01;
        private System.Windows.Forms.Timer TimerTicker_02;
        private System.Windows.Forms.Label lbIWIllCleanUpText;
        private System.Windows.Forms.Label lbHoursLeft;
        private System.Windows.Forms.Label lbDaysOld;
        private System.Windows.Forms.ContextMenuStrip contextMenuEnableDisableDirSearch;
        private System.Windows.Forms.ToolStripMenuItem DisableDirOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EnableDirOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveDir;
        private System.Windows.Forms.CheckBox checkBoxDontProcessParentFolderFiles;
        private About wAboutDialog;
        private System.Windows.Forms.Timer TimerTicker_03_STATDrives;
        private System.Windows.Forms.PictureBox pictureBoxSearchStat;
        private System.Windows.Forms.CheckBox cbHushOutput;
    }
}

// ListBox.IntegralHeight - When this property is set to true, the control automatically resizes to ensure that an item is not partially displayed. If you want to maintain the original size of the ListBox based on the space requirements of your form, set this property to false. 




/* 
 
    
FileInfo fileInfo = new FileInfo(@"c:\file.txt");

// local times
DateTime creationTime = fileInfo.CreationTime;
DateTime lastWriteTime = fileInfo.LastWriteTime;





 */
