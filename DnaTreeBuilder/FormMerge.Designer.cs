namespace DnaTreeBuilder
{
    partial class FormMerge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMerge));
            this.listBox23AndMe = new System.Windows.Forms.ListBox();
            this.listBoxFamilyTreeDna = new System.Windows.Forms.ListBox();
            this.buttonMerge = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.leftSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.andMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.familyTreeDnaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.andMeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.familyTreeDnaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox23AndMe
            // 
            this.listBox23AndMe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox23AndMe.FormattingEnabled = true;
            this.listBox23AndMe.ItemHeight = 16;
            this.listBox23AndMe.Location = new System.Drawing.Point(4, 37);
            this.listBox23AndMe.Name = "listBox23AndMe";
            this.listBox23AndMe.Size = new System.Drawing.Size(218, 484);
            this.listBox23AndMe.Sorted = true;
            this.listBox23AndMe.TabIndex = 1;
            // 
            // listBoxFamilyTreeDna
            // 
            this.listBoxFamilyTreeDna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxFamilyTreeDna.FormattingEnabled = true;
            this.listBoxFamilyTreeDna.ItemHeight = 16;
            this.listBoxFamilyTreeDna.Location = new System.Drawing.Point(228, 37);
            this.listBoxFamilyTreeDna.Name = "listBoxFamilyTreeDna";
            this.listBoxFamilyTreeDna.Size = new System.Drawing.Size(251, 484);
            this.listBoxFamilyTreeDna.Sorted = true;
            this.listBoxFamilyTreeDna.TabIndex = 2;
            // 
            // buttonMerge
            // 
            this.buttonMerge.Location = new System.Drawing.Point(485, 108);
            this.buttonMerge.Name = "buttonMerge";
            this.buttonMerge.Size = new System.Drawing.Size(132, 44);
            this.buttonMerge.TabIndex = 4;
            this.buttonMerge.Text = "Merge Into One";
            this.buttonMerge.UseVisualStyleBackColor = true;
            this.buttonMerge.Click += new System.EventHandler(this.buttonMerge_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftSideToolStripMenuItem,
            this.rightSideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // leftSideToolStripMenuItem
            // 
            this.leftSideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.andMeToolStripMenuItem,
            this.familyTreeDnaToolStripMenuItem});
            this.leftSideToolStripMenuItem.Name = "leftSideToolStripMenuItem";
            this.leftSideToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.leftSideToolStripMenuItem.Text = "Left Side";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // andMeToolStripMenuItem
            // 
            this.andMeToolStripMenuItem.Checked = true;
            this.andMeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.andMeToolStripMenuItem.Name = "andMeToolStripMenuItem";
            this.andMeToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.andMeToolStripMenuItem.Text = "23AndMe";
            this.andMeToolStripMenuItem.Click += new System.EventHandler(this.andMeToolStripMenuItem_Click);
            // 
            // familyTreeDnaToolStripMenuItem
            // 
            this.familyTreeDnaToolStripMenuItem.Name = "familyTreeDnaToolStripMenuItem";
            this.familyTreeDnaToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.familyTreeDnaToolStripMenuItem.Text = "FamilyTreeDna";
            this.familyTreeDnaToolStripMenuItem.Click += new System.EventHandler(this.familyTreeDnaToolStripMenuItem_Click);
            // 
            // rightSideToolStripMenuItem
            // 
            this.rightSideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem1,
            this.andMeToolStripMenuItem1,
            this.familyTreeDnaToolStripMenuItem1});
            this.rightSideToolStripMenuItem.Name = "rightSideToolStripMenuItem";
            this.rightSideToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.rightSideToolStripMenuItem.Text = "Right Side";
            // 
            // allToolStripMenuItem1
            // 
            this.allToolStripMenuItem1.Name = "allToolStripMenuItem1";
            this.allToolStripMenuItem1.Size = new System.Drawing.Size(177, 24);
            this.allToolStripMenuItem1.Text = "All";
            this.allToolStripMenuItem1.Click += new System.EventHandler(this.allToolStripMenuItem1_Click);
            // 
            // andMeToolStripMenuItem1
            // 
            this.andMeToolStripMenuItem1.Name = "andMeToolStripMenuItem1";
            this.andMeToolStripMenuItem1.Size = new System.Drawing.Size(177, 24);
            this.andMeToolStripMenuItem1.Text = "23AndMe";
            this.andMeToolStripMenuItem1.Click += new System.EventHandler(this.andMeToolStripMenuItem1_Click);
            // 
            // familyTreeDnaToolStripMenuItem1
            // 
            this.familyTreeDnaToolStripMenuItem1.Checked = true;
            this.familyTreeDnaToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.familyTreeDnaToolStripMenuItem1.Name = "familyTreeDnaToolStripMenuItem1";
            this.familyTreeDnaToolStripMenuItem1.Size = new System.Drawing.Size(177, 24);
            this.familyTreeDnaToolStripMenuItem1.Text = "FamilyTreeDna";
            this.familyTreeDnaToolStripMenuItem1.Click += new System.EventHandler(this.familyTreeDnaToolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(484, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 68);
            this.label1.TabIndex = 3;
            this.label1.Text = "Right Person will be merged into Left Person";
            // 
            // FormMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 518);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMerge);
            this.Controls.Add(this.listBoxFamilyTreeDna);
            this.Controls.Add(this.listBox23AndMe);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMerge";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Merge Individuals";
            this.ThemeName = "ControlDefault";
            this.Load += new System.EventHandler(this.formMerge_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox23AndMe;
        private System.Windows.Forms.ListBox listBoxFamilyTreeDna;
        private System.Windows.Forms.Button buttonMerge;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem leftSideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem andMeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem familyTreeDnaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightSideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem andMeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem familyTreeDnaToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
    }
}
