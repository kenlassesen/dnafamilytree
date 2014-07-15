namespace DnaTreeBuilder
{
    partial class FormDna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDna));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataToDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSavedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getSharedDNAIdsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processSharedIdsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareDNAForSelectedPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.familyFinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.familyFinderMatchesURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chromosomeBroswerUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advanceMatchesUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.familyFinderMatrixExtractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browserProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.familyFinderFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dNAFamilyTreeVersion1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeAnotherDNAFamilyFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allMatchToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.significantMatchesToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chromosomeMatchesToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeViewToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrixToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineSharingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadCurrentTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCurrentTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeTwoPeopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFamilyTreeDNAMatrixDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.familiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.constructFamiliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.naiveAlgorithmALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.saveFileDialogCsv = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogRepro = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogAsRepro = new System.Windows.Forms.SaveFileDialog();
            this.comboBoxPersons = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.office2010SilverTheme1 = new Telerik.WinControls.Themes.Office2010SilverTheme();
            this.treeView1 = new Telerik.WinControls.UI.RadTreeView();
            this.timerMatrix = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(0, 63);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(909, 689);
            this.webBrowser1.TabIndex = 4;
            this.webBrowser1.FileDownload += new System.EventHandler(this.webBrowser1_FileDownload);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.familyFinderToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.importExportToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.familiesToolStripMenuItem,
            this.donateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(909, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveDataToDateToolStripMenuItem,
            this.saveDataAsToolStripMenuItem,
            this.loadSavedFileToolStripMenuItem,
            this.newToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveDataToDateToolStripMenuItem
            // 
            this.saveDataToDateToolStripMenuItem.Name = "saveDataToDateToolStripMenuItem";
            this.saveDataToDateToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.saveDataToDateToolStripMenuItem.Text = "&Save DnaFamilyTree";
            this.saveDataToDateToolStripMenuItem.Click += new System.EventHandler(this.saveDataToDateToolStripMenuItem_Click);
            // 
            // saveDataAsToolStripMenuItem
            // 
            this.saveDataAsToolStripMenuItem.Name = "saveDataAsToolStripMenuItem";
            this.saveDataAsToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.saveDataAsToolStripMenuItem.Text = "Save As..";
            this.saveDataAsToolStripMenuItem.Click += new System.EventHandler(this.saveDataAsToolStripMenuItem_Click);
            // 
            // loadSavedFileToolStripMenuItem
            // 
            this.loadSavedFileToolStripMenuItem.Name = "loadSavedFileToolStripMenuItem";
            this.loadSavedFileToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.loadSavedFileToolStripMenuItem.Text = "Load File...";
            this.loadSavedFileToolStripMenuItem.Click += new System.EventHandler(this.loadSavedFileToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.newToolStripMenuItem.Text = "New ...";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.getSharedDNAIdsToolStripMenuItem,
            this.processSharedIdsToolStripMenuItem,
            this.compareDNAForSelectedPersonToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.actionsToolStripMenuItem.Text = "23 And Me";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(300, 24);
            this.loginToolStripMenuItem.Text = "&Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // getSharedDNAIdsToolStripMenuItem
            // 
            this.getSharedDNAIdsToolStripMenuItem.Name = "getSharedDNAIdsToolStripMenuItem";
            this.getSharedDNAIdsToolStripMenuItem.Size = new System.Drawing.Size(300, 24);
            this.getSharedDNAIdsToolStripMenuItem.Text = "&Retrieve List of People";
            this.getSharedDNAIdsToolStripMenuItem.Click += new System.EventHandler(this.getSharedDNAIdsToolStripMenuItem_Click);
            // 
            // processSharedIdsToolStripMenuItem
            // 
            this.processSharedIdsToolStripMenuItem.Name = "processSharedIdsToolStripMenuItem";
            this.processSharedIdsToolStripMenuItem.Size = new System.Drawing.Size(300, 24);
            this.processSharedIdsToolStripMenuItem.Text = "Retrieve DNA for all people";
            this.processSharedIdsToolStripMenuItem.Click += new System.EventHandler(this.processSharedIdsToolStripMenuItem_Click);
            // 
            // compareDNAForSelectedPersonToolStripMenuItem
            // 
            this.compareDNAForSelectedPersonToolStripMenuItem.Name = "compareDNAForSelectedPersonToolStripMenuItem";
            this.compareDNAForSelectedPersonToolStripMenuItem.Size = new System.Drawing.Size(300, 24);
            this.compareDNAForSelectedPersonToolStripMenuItem.Text = "Retrieve DNA for Selected Person";
            this.compareDNAForSelectedPersonToolStripMenuItem.Click += new System.EventHandler(this.compareDNAForSelectedPersonToolStripMenuItem_Click);
            // 
            // familyFinderToolStripMenuItem
            // 
            this.familyFinderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem1,
            this.familyFinderMatchesURLToolStripMenuItem,
            this.chromosomeBroswerUrlToolStripMenuItem,
            this.advanceMatchesUrlToolStripMenuItem,
            this.familyFinderMatrixExtractToolStripMenuItem});
            this.familyFinderToolStripMenuItem.Name = "familyFinderToolStripMenuItem";
            this.familyFinderToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.familyFinderToolStripMenuItem.Text = "Family Finder";
            // 
            // loginToolStripMenuItem1
            // 
            this.loginToolStripMenuItem1.Name = "loginToolStripMenuItem1";
            this.loginToolStripMenuItem1.Size = new System.Drawing.Size(261, 24);
            this.loginToolStripMenuItem1.Text = "Login";
            this.loginToolStripMenuItem1.Click += new System.EventHandler(this.loginToolStripMenuItem1_Click);
            // 
            // familyFinderMatchesURLToolStripMenuItem
            // 
            this.familyFinderMatchesURLToolStripMenuItem.Name = "familyFinderMatchesURLToolStripMenuItem";
            this.familyFinderMatchesURLToolStripMenuItem.Size = new System.Drawing.Size(261, 24);
            this.familyFinderMatchesURLToolStripMenuItem.Text = "Family Finder Matches Url";
            this.familyFinderMatchesURLToolStripMenuItem.Click += new System.EventHandler(this.familyFinderMatchesURLToolStripMenuItem_Click);
            // 
            // chromosomeBroswerUrlToolStripMenuItem
            // 
            this.chromosomeBroswerUrlToolStripMenuItem.Name = "chromosomeBroswerUrlToolStripMenuItem";
            this.chromosomeBroswerUrlToolStripMenuItem.Size = new System.Drawing.Size(261, 24);
            this.chromosomeBroswerUrlToolStripMenuItem.Text = "Chromosome Broswer Url";
            this.chromosomeBroswerUrlToolStripMenuItem.Click += new System.EventHandler(this.chromosomeBroswerUrlToolStripMenuItem_Click);
            // 
            // advanceMatchesUrlToolStripMenuItem
            // 
            this.advanceMatchesUrlToolStripMenuItem.Enabled = false;
            this.advanceMatchesUrlToolStripMenuItem.Name = "advanceMatchesUrlToolStripMenuItem";
            this.advanceMatchesUrlToolStripMenuItem.Size = new System.Drawing.Size(261, 24);
            this.advanceMatchesUrlToolStripMenuItem.Text = "Advance Matches Url";
            this.advanceMatchesUrlToolStripMenuItem.Click += new System.EventHandler(this.advanceMatchesUrlToolStripMenuItem_Click);
            // 
            // familyFinderMatrixExtractToolStripMenuItem
            // 
            this.familyFinderMatrixExtractToolStripMenuItem.Name = "familyFinderMatrixExtractToolStripMenuItem";
            this.familyFinderMatrixExtractToolStripMenuItem.Size = new System.Drawing.Size(261, 24);
            this.familyFinderMatrixExtractToolStripMenuItem.Text = "Family Finder Matrix Extract";
            this.familyFinderMatrixExtractToolStripMenuItem.Click += new System.EventHandler(this.familyFinderMatrixExtractToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browserProcessingToolStripMenuItem,
            this.peopleTreeToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // browserProcessingToolStripMenuItem
            // 
            this.browserProcessingToolStripMenuItem.Name = "browserProcessingToolStripMenuItem";
            this.browserProcessingToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.browserProcessingToolStripMenuItem.Text = "Browser Processing";
            this.browserProcessingToolStripMenuItem.Click += new System.EventHandler(this.browserProcessingToolStripMenuItem_Click);
            // 
            // peopleTreeToolStripMenuItem
            // 
            this.peopleTreeToolStripMenuItem.Name = "peopleTreeToolStripMenuItem";
            this.peopleTreeToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.peopleTreeToolStripMenuItem.Text = "People Tree";
            this.peopleTreeToolStripMenuItem.Click += new System.EventHandler(this.peopleTreeToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // importExportToolStripMenuItem
            // 
            this.importExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem1,
            this.exportToolStripMenuItem1});
            this.importExportToolStripMenuItem.Name = "importExportToolStripMenuItem";
            this.importExportToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.importExportToolStripMenuItem.Text = "Import/Export";
            // 
            // importToolStripMenuItem1
            // 
            this.importToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.familyFinderFilesToolStripMenuItem,
            this.dNAFamilyTreeVersion1ToolStripMenuItem,
            this.mergeAnotherDNAFamilyFileToolStripMenuItem});
            this.importToolStripMenuItem1.Name = "importToolStripMenuItem1";
            this.importToolStripMenuItem1.Size = new System.Drawing.Size(123, 24);
            this.importToolStripMenuItem1.Text = "Import";
            // 
            // familyFinderFilesToolStripMenuItem
            // 
            this.familyFinderFilesToolStripMenuItem.Name = "familyFinderFilesToolStripMenuItem";
            this.familyFinderFilesToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.familyFinderFilesToolStripMenuItem.Text = "Family Finder Files";
            this.familyFinderFilesToolStripMenuItem.Click += new System.EventHandler(this.familyFinderFilesToolStripMenuItem_Click);
            // 
            // dNAFamilyTreeVersion1ToolStripMenuItem
            // 
            this.dNAFamilyTreeVersion1ToolStripMenuItem.Name = "dNAFamilyTreeVersion1ToolStripMenuItem";
            this.dNAFamilyTreeVersion1ToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.dNAFamilyTreeVersion1ToolStripMenuItem.Text = "DNA Family Tree Version 1";
            this.dNAFamilyTreeVersion1ToolStripMenuItem.Click += new System.EventHandler(this.dNAFamilyTreeVersion1ToolStripMenuItem_Click);
            // 
            // mergeAnotherDNAFamilyFileToolStripMenuItem
            // 
            this.mergeAnotherDNAFamilyFileToolStripMenuItem.Name = "mergeAnotherDNAFamilyFileToolStripMenuItem";
            this.mergeAnotherDNAFamilyFileToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
            this.mergeAnotherDNAFamilyFileToolStripMenuItem.Text = "Merge Another DNA Family File";
            this.mergeAnotherDNAFamilyFileToolStripMenuItem.Visible = false;
            this.mergeAnotherDNAFamilyFileToolStripMenuItem.Click += new System.EventHandler(this.mergeAnotherDNAFamilyFileToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allMatchToCSVToolStripMenuItem,
            this.significantMatchesToCSVToolStripMenuItem,
            this.chromosomeMatchesToCSVToolStripMenuItem,
            this.treeViewToCSVToolStripMenuItem,
            this.matrixToCSVToolStripMenuItem});
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(123, 24);
            this.exportToolStripMenuItem1.Text = "Export";
            // 
            // allMatchToCSVToolStripMenuItem
            // 
            this.allMatchToCSVToolStripMenuItem.Name = "allMatchToCSVToolStripMenuItem";
            this.allMatchToCSVToolStripMenuItem.Size = new System.Drawing.Size(274, 24);
            this.allMatchToCSVToolStripMenuItem.Text = "All Match to CSV";
            this.allMatchToCSVToolStripMenuItem.Click += new System.EventHandler(this.allMatchToCSVToolStripMenuItem_Click);
            // 
            // significantMatchesToCSVToolStripMenuItem
            // 
            this.significantMatchesToCSVToolStripMenuItem.Name = "significantMatchesToCSVToolStripMenuItem";
            this.significantMatchesToCSVToolStripMenuItem.Size = new System.Drawing.Size(274, 24);
            this.significantMatchesToCSVToolStripMenuItem.Text = "Significant Matches to CSV";
            this.significantMatchesToCSVToolStripMenuItem.Click += new System.EventHandler(this.significantMatchesToCSVToolStripMenuItem_Click);
            // 
            // chromosomeMatchesToCSVToolStripMenuItem
            // 
            this.chromosomeMatchesToCSVToolStripMenuItem.Name = "chromosomeMatchesToCSVToolStripMenuItem";
            this.chromosomeMatchesToCSVToolStripMenuItem.Size = new System.Drawing.Size(274, 24);
            this.chromosomeMatchesToCSVToolStripMenuItem.Text = "Chromosome Matches to CSV";
            this.chromosomeMatchesToCSVToolStripMenuItem.Click += new System.EventHandler(this.chromosomeMatchesToCSVToolStripMenuItem_Click);
            // 
            // treeViewToCSVToolStripMenuItem
            // 
            this.treeViewToCSVToolStripMenuItem.Name = "treeViewToCSVToolStripMenuItem";
            this.treeViewToCSVToolStripMenuItem.Size = new System.Drawing.Size(274, 24);
            this.treeViewToCSVToolStripMenuItem.Text = "TreeView to CSV";
            this.treeViewToCSVToolStripMenuItem.Click += new System.EventHandler(this.treeViewToCSVToolStripMenuItem_Click);
            // 
            // matrixToCSVToolStripMenuItem
            // 
            this.matrixToCSVToolStripMenuItem.Name = "matrixToCSVToolStripMenuItem";
            this.matrixToCSVToolStripMenuItem.Size = new System.Drawing.Size(274, 24);
            this.matrixToCSVToolStripMenuItem.Text = "Matrix to CSV";
            this.matrixToCSVToolStripMenuItem.Click += new System.EventHandler(this.matrixToCSVToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlineSharingToolStripMenuItem,
            this.mergeTwoPeopleToolStripMenuItem,
            this.clearFamilyTreeDNAMatrixDataToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // onlineSharingToolStripMenuItem
            // 
            this.onlineSharingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadCurrentTreeToolStripMenuItem,
            this.removeCurrentTreeToolStripMenuItem});
            this.onlineSharingToolStripMenuItem.Name = "onlineSharingToolStripMenuItem";
            this.onlineSharingToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.onlineSharingToolStripMenuItem.Text = "Online Sharing";
            // 
            // uploadCurrentTreeToolStripMenuItem
            // 
            this.uploadCurrentTreeToolStripMenuItem.Name = "uploadCurrentTreeToolStripMenuItem";
            this.uploadCurrentTreeToolStripMenuItem.Size = new System.Drawing.Size(270, 24);
            this.uploadCurrentTreeToolStripMenuItem.Text = "Upload Current Tree";
            this.uploadCurrentTreeToolStripMenuItem.Click += new System.EventHandler(this.uploadCurrentTreeToolStripMenuItem_Click);
            // 
            // removeCurrentTreeToolStripMenuItem
            // 
            this.removeCurrentTreeToolStripMenuItem.Name = "removeCurrentTreeToolStripMenuItem";
            this.removeCurrentTreeToolStripMenuItem.Size = new System.Drawing.Size(270, 24);
            this.removeCurrentTreeToolStripMenuItem.Text = "Download Matching Records";
            // 
            // mergeTwoPeopleToolStripMenuItem
            // 
            this.mergeTwoPeopleToolStripMenuItem.Name = "mergeTwoPeopleToolStripMenuItem";
            this.mergeTwoPeopleToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.mergeTwoPeopleToolStripMenuItem.Text = "Merge Two People";
            this.mergeTwoPeopleToolStripMenuItem.Click += new System.EventHandler(this.mergeTwoPeopleToolStripMenuItem_Click);
            // 
            // clearFamilyTreeDNAMatrixDataToolStripMenuItem
            // 
            this.clearFamilyTreeDNAMatrixDataToolStripMenuItem.Name = "clearFamilyTreeDNAMatrixDataToolStripMenuItem";
            this.clearFamilyTreeDNAMatrixDataToolStripMenuItem.Size = new System.Drawing.Size(306, 24);
            this.clearFamilyTreeDNAMatrixDataToolStripMenuItem.Text = "Clear FamilyTree DNA Matrix Data";
            this.clearFamilyTreeDNAMatrixDataToolStripMenuItem.Click += new System.EventHandler(this.clearFamilyTreeDNAMatrixDataToolStripMenuItem_Click);
            // 
            // familiesToolStripMenuItem
            // 
            this.familiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.constructFamiliesToolStripMenuItem,
            this.naiveAlgorithmALLToolStripMenuItem});
            this.familiesToolStripMenuItem.Name = "familiesToolStripMenuItem";
            this.familiesToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.familiesToolStripMenuItem.Text = "Families";
            // 
            // constructFamiliesToolStripMenuItem
            // 
            this.constructFamiliesToolStripMenuItem.Name = "constructFamiliesToolStripMenuItem";
            this.constructFamiliesToolStripMenuItem.Size = new System.Drawing.Size(266, 24);
            this.constructFamiliesToolStripMenuItem.Text = "Naive Algorithm - Individual";
            this.constructFamiliesToolStripMenuItem.Click += new System.EventHandler(this.constructFamiliesToolStripMenuItem_Click);
            // 
            // naiveAlgorithmALLToolStripMenuItem
            // 
            this.naiveAlgorithmALLToolStripMenuItem.Name = "naiveAlgorithmALLToolStripMenuItem";
            this.naiveAlgorithmALLToolStripMenuItem.Size = new System.Drawing.Size(266, 24);
            this.naiveAlgorithmALLToolStripMenuItem.Text = "Naive Algorithm -ALL";
            this.naiveAlgorithmALLToolStripMenuItem.Click += new System.EventHandler(this.naiveAlgorithmALLToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.donateToolStripMenuItem.Text = "Donate!";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 692);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(909, 25);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 19);
            this.toolStripProgressBar1.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(765, 694);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Stop And Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialogRepro
            // 
            this.openFileDialogRepro.FileName = "openFileDialog1";
            // 
            // comboBoxPersons
            // 
            this.comboBoxPersons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPersons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPersons.FormattingEnabled = true;
            this.comboBoxPersons.Location = new System.Drawing.Point(5, 33);
            this.comboBoxPersons.Name = "comboBoxPersons";
            this.comboBoxPersons.Size = new System.Drawing.Size(707, 24);
            this.comboBoxPersons.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(718, 31);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(186, 26);
            this.button2.TabIndex = 2;
            this.button2.Text = "Fetch 23AndMe Person";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // treeView1
            // 
            this.treeView1.AllowPlusMinusAnimation = true;
            this.treeView1.AllowShowFocusCues = true;
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(5, 62);
            this.treeView1.Name = "treeView1";
            this.treeView1.ShowLines = true;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(880, 626);
            this.treeView1.SpacingBetweenNodes = -1;
            this.treeView1.TabIndex = 3;
            this.treeView1.Text = "radTreeView1";
            this.treeView1.NodeMouseDoubleClick += new Telerik.WinControls.UI.RadTreeView.TreeViewEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // timerMatrix
            // 
            this.timerMatrix.Tick += new System.EventHandler(this.timerMatrix_Tick);
            // 
            // FormDna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 717);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBoxPersons);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormDna";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "DNA Family Tree Maker for 23andMe.com";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataToDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getSharedDNAIdsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processSharedIdsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem loadSavedFileToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SaveFileDialog saveFileDialogCsv;
        private System.Windows.Forms.OpenFileDialog openFileDialogRepro;
        private System.Windows.Forms.ToolStripMenuItem saveDataAsToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialogAsRepro;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browserProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem familiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem constructFamiliesToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBoxPersons;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem compareDNAForSelectedPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineSharingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadCurrentTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCurrentTreeToolStripMenuItem;
        private System.Windows.Forms.Timer timerRefresh;
        private Telerik.WinControls.Themes.Office2010SilverTheme office2010SilverTheme1;
        private Telerik.WinControls.UI.RadTreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem importExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem familyFinderFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dNAFamilyTreeVersion1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allMatchToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem significantMatchesToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chromosomeMatchesToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem familyFinderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem familyFinderMatchesURLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chromosomeBroswerUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advanceMatchesUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem familyFinderMatrixExtractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeTwoPeopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearFamilyTreeDNAMatrixDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem naiveAlgorithmALLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem treeViewToCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrixToCSVToolStripMenuItem;
        private System.Windows.Forms.Timer timerMatrix;
        private System.Windows.Forms.ToolStripMenuItem mergeAnotherDNAFamilyFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
    }
}

