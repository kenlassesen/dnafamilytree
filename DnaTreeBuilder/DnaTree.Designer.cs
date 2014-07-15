namespace DnaTreeBuilder
{
    partial class DnaTree
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameCurrentFamilyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentFamilyToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWithSelectedPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextImpliedFamilyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doTenMoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeViewFamilies = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.processToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(743, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameCurrentFamilyToolStripMenuItem,
            this.editNodesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Visible = false;
            // 
            // renameCurrentFamilyToolStripMenuItem
            // 
            this.renameCurrentFamilyToolStripMenuItem.Name = "renameCurrentFamilyToolStripMenuItem";
            this.renameCurrentFamilyToolStripMenuItem.Size = new System.Drawing.Size(231, 24);
            this.renameCurrentFamilyToolStripMenuItem.Text = "Rename Current Family";
            // 
            // editNodesToolStripMenuItem
            // 
            this.editNodesToolStripMenuItem.Name = "editNodesToolStripMenuItem";
            this.editNodesToolStripMenuItem.Size = new System.Drawing.Size(231, 24);
            this.editNodesToolStripMenuItem.Text = "Edit Nodes";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentFamilyToCSVToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Visible = false;
            // 
            // currentFamilyToCSVToolStripMenuItem
            // 
            this.currentFamilyToCSVToolStripMenuItem.Name = "currentFamilyToCSVToolStripMenuItem";
            this.currentFamilyToCSVToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.currentFamilyToCSVToolStripMenuItem.Text = "Current Family to CSV";
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startWithSelectedPersonToolStripMenuItem,
            this.nextImpliedFamilyToolStripMenuItem,
            this.doTenMoreToolStripMenuItem});
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.processToolStripMenuItem.Text = "Process";
            // 
            // startWithSelectedPersonToolStripMenuItem
            // 
            this.startWithSelectedPersonToolStripMenuItem.Name = "startWithSelectedPersonToolStripMenuItem";
            this.startWithSelectedPersonToolStripMenuItem.Size = new System.Drawing.Size(250, 24);
            this.startWithSelectedPersonToolStripMenuItem.Text = "Start with Selected Person";
            this.startWithSelectedPersonToolStripMenuItem.Click += new System.EventHandler(this.startWithSelectedPersonToolStripMenuItem_Click);
            // 
            // nextImpliedFamilyToolStripMenuItem
            // 
            this.nextImpliedFamilyToolStripMenuItem.Name = "nextImpliedFamilyToolStripMenuItem";
            this.nextImpliedFamilyToolStripMenuItem.Size = new System.Drawing.Size(250, 24);
            this.nextImpliedFamilyToolStripMenuItem.Text = "Next Implied &Family";
            this.nextImpliedFamilyToolStripMenuItem.Click += new System.EventHandler(this.nextImpliedFamilyToolStripMenuItem_Click);
            // 
            // doTenMoreToolStripMenuItem
            // 
            this.doTenMoreToolStripMenuItem.Name = "doTenMoreToolStripMenuItem";
            this.doTenMoreToolStripMenuItem.Size = new System.Drawing.Size(250, 24);
            this.doTenMoreToolStripMenuItem.Text = "&Next Person";
            this.doTenMoreToolStripMenuItem.Click += new System.EventHandler(this.doTenMoreToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(0, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(743, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 447);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(743, 25);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(0, 58);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(500, 386);
            this.treeView1.TabIndex = 2;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            // 
            // treeViewFamilies
            // 
            this.treeViewFamilies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewFamilies.Location = new System.Drawing.Point(505, 58);
            this.treeViewFamilies.Name = "treeViewFamilies";
            this.treeViewFamilies.Size = new System.Drawing.Size(238, 386);
            this.treeViewFamilies.TabIndex = 3;
            // 
            // DnaTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 472);
            this.Controls.Add(this.treeViewFamilies);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DnaTree";
            this.Text = "DnaTree";
            this.Load += new System.EventHandler(this.DnaTree_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameCurrentFamilyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentFamilyToCSVToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextImpliedFamilyToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem doTenMoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWithSelectedPersonToolStripMenuItem;
        private System.Windows.Forms.TreeView treeViewFamilies;

    }
}