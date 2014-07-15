using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DnaTreeBuilder.Instance;
using Telerik.WinControls;

namespace DnaTreeBuilder
{
    public partial class FormShared : Telerik.WinControls.UI.RadForm
    {
     
        public FormShared()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://dnagedcom.com/DnaSharingTerms");
        }

        private void frmShared_Load(object sender, EventArgs e)
        {
            Repository.Write();
            radTextBoxEmail.Text=Repository.Email ;
            radTextBoxTelephone.Text=Repository.Telephone;
            radTextBoxTreeName.Text=Repository.TreeName ;

            
            labelSummary.Text = "This will share the contents of this tree with others.\r\nYou may wish to review the data before uploading.";
        }

        private void buttonShared_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Repository.Email= radTextBoxEmail.Text;
            Repository.Telephone = radTextBoxTelephone.Text;
            Repository.TreeName = radTextBoxTreeName.Text;
            Repository.Write();
            var xml = Repository.SharingXml;
            Text = "Uploading -- please wait";
            Application.DoEvents();
            try
            {
                var conn = new SqlConnection("Redacted");
                conn.Open();
                var cmd = new SqlCommand
                              {CommandText = "Upload", CommandType = CommandType.StoredProcedure, Connection = conn};
                cmd.Parameters.AddWithValue("Data", xml);
                cmd.ExecuteNonQuery();
                MessageBox.Show(this, "Thank you for sharing!", "Upload successful" );
                Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Unable to upload");
            }
            this.Enabled = true;
        }

        private void frmShared_FormClosing(object sender, FormClosingEventArgs e)
        {
            Repository.Email = radTextBoxEmail.Text;
            Repository.Telephone = radTextBoxTelephone.Text;
            Repository.TreeName = radTextBoxTreeName.Text;
            Repository.Write();
        }
    }
}
