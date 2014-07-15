namespace DnaTreeBuilder
{
    partial class FormFamilyDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFamilyDisplay));
            this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
            this.radToggleButton2 = new Telerik.WinControls.UI.RadToggleButton();
            this.radToggleButton1 = new Telerik.WinControls.UI.RadToggleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveTreeToCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
            this.radTreeView1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radToggleButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToggleButton1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radTreeView1
            // 
            this.radTreeView1.Controls.Add(this.radToggleButton2);
            this.radTreeView1.Controls.Add(this.radToggleButton1);
            this.radTreeView1.Location = new System.Drawing.Point(0, 33);
            this.radTreeView1.Name = "radTreeView1";
            this.radTreeView1.Size = new System.Drawing.Size(696, 704);
            this.radTreeView1.SpacingBetweenNodes = -1;
            this.radTreeView1.TabIndex = 1;
            this.radTreeView1.Text = "radTreeView1";
            this.radTreeView1.SelectedNodeChanged += new Telerik.WinControls.UI.RadTreeView.RadTreeViewEventHandler(this.radTreeView1_SelectedNodeChanged);
            // 
            // radToggleButton2
            // 
            this.radToggleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radToggleButton2.Enabled = false;
            this.radToggleButton2.Location = new System.Drawing.Point(518, 33);
            this.radToggleButton2.Name = "radToggleButton2";
            this.radToggleButton2.Size = new System.Drawing.Size(178, 24);
            this.radToggleButton2.TabIndex = 1;
            this.radToggleButton2.Text = "Genetic Distance";
            this.radToggleButton2.Visible = false;
            this.radToggleButton2.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radToggleButton2_ToggleStateChanged);
            // 
            // radToggleButton1
            // 
            this.radToggleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radToggleButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radToggleButton1.Enabled = false;
            this.radToggleButton1.Location = new System.Drawing.Point(518, 3);
            this.radToggleButton1.Name = "radToggleButton1";
            this.radToggleButton1.Size = new System.Drawing.Size(175, 24);
            this.radToggleButton1.TabIndex = 0;
            this.radToggleButton1.Text = "Related (FTDNA Matrix)";
            this.radToggleButton1.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.radToggleButton1.Visible = false;
            this.radToggleButton1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radToggleButton1_ToggleStateChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 2;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 712);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(696, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(63, 20);
            this.toolStripStatusLabel1.Text = "Running";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(696, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTreeToCSVToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveTreeToCSVToolStripMenuItem
            // 
            this.saveTreeToCSVToolStripMenuItem.Name = "saveTreeToCSVToolStripMenuItem";
            this.saveTreeToCSVToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.saveTreeToCSVToolStripMenuItem.Text = "&Save Tree to CSV";
            this.saveTreeToCSVToolStripMenuItem.Click += new System.EventHandler(this.saveTreeToCSVToolStripMenuItem_Click);
            // 
            // FormFamilyDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 737);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.radTreeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormFamilyDisplay";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FormFamilyDisplay";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.FormFamilyDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
            this.radTreeView1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radToggleButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToggleButton1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView radTreeView1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private Telerik.WinControls.UI.RadToggleButton radToggleButton1;
        private Telerik.WinControls.UI.RadToggleButton radToggleButton2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveTreeToCSVToolStripMenuItem;
    }
}
