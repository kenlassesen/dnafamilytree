namespace DnaTreeBuilder
{
    partial class FormShared
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormShared));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radTextBoxTelephone = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBoxEmail = new Telerik.WinControls.UI.RadTextBox();
            this.radTextBoxTreeName = new Telerik.WinControls.UI.RadTextBox();
            this.labelSummary = new System.Windows.Forms.Label();
            this.buttonShared = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxTelephone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxTreeName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tree Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contributor\'s Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contributor\'s Telephone";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radTextBoxTelephone);
            this.radGroupBox1.Controls.Add(this.radTextBoxEmail);
            this.radGroupBox1.Controls.Add(this.radTextBoxTreeName);
            this.radGroupBox1.Controls.Add(this.label3);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.HeaderText = "Optional (but recommended)";
            this.radGroupBox1.Location = new System.Drawing.Point(5, 5);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(522, 108);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Optional (but recommended)";
            // 
            // radTextBoxTelephone
            // 
            this.radTextBoxTelephone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBoxTelephone.Location = new System.Drawing.Point(170, 78);
            this.radTextBoxTelephone.Name = "radTextBoxTelephone";
            this.radTextBoxTelephone.NullText = "1-555-555-1212";
            this.radTextBoxTelephone.Size = new System.Drawing.Size(345, 24);
            this.radTextBoxTelephone.TabIndex = 5;
            this.radTextBoxTelephone.TabStop = false;
            // 
            // radTextBoxEmail
            // 
            this.radTextBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBoxEmail.Location = new System.Drawing.Point(141, 47);
            this.radTextBoxEmail.Name = "radTextBoxEmail";
            this.radTextBoxEmail.NullText = "JohnDoe@email.com";
            this.radTextBoxEmail.Size = new System.Drawing.Size(374, 24);
            this.radTextBoxEmail.TabIndex = 3;
            this.radTextBoxEmail.TabStop = false;
            // 
            // radTextBoxTreeName
            // 
            this.radTextBoxTreeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBoxTreeName.Location = new System.Drawing.Point(87, 18);
            this.radTextBoxTreeName.Name = "radTextBoxTreeName";
            this.radTextBoxTreeName.Size = new System.Drawing.Size(428, 24);
            this.radTextBoxTreeName.TabIndex = 1;
            this.radTextBoxTreeName.TabStop = false;
            this.radTextBoxTreeName.Text = "My Tree";
            // 
            // labelSummary
            // 
            this.labelSummary.AutoSize = true;
            this.labelSummary.Location = new System.Drawing.Point(5, 118);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(45, 19);
            this.labelSummary.TabIndex = 1;
            this.labelSummary.Text = "label4";
            // 
            // buttonShared
            // 
            this.buttonShared.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShared.Location = new System.Drawing.Point(367, 214);
            this.buttonShared.Name = "buttonShared";
            this.buttonShared.Size = new System.Drawing.Size(160, 34);
            this.buttonShared.TabIndex = 4;
            this.buttonShared.Text = "Share This Tree";
            this.buttonShared.UseVisualStyleBackColor = true;
            this.buttonShared.Click += new System.EventHandler(this.buttonShared_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(5, 214);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(231, 19);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "For Terms and Condition of Sharing ";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(367, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Retrieve New Matches";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormShared
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 253);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.buttonShared);
            this.Controls.Add(this.labelSummary);
            this.Controls.Add(this.radGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormShared";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Share via http://dnagedcom.com/";
            this.ThemeName = "ControlDefault";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmShared_FormClosing);
            this.Load += new System.EventHandler(this.frmShared_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxTelephone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxTreeName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadTextBox radTextBoxTelephone;
        private Telerik.WinControls.UI.RadTextBox radTextBoxEmail;
        private Telerik.WinControls.UI.RadTextBox radTextBoxTreeName;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.Button buttonShared;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
    }
}
