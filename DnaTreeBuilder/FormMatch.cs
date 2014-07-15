using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using DnaTreeBuilder.Instance;
namespace DnaTreeBuilder
{
    public partial class FormMatch : Telerik.WinControls.UI.RadForm
    {
        private Guid id0;
        private Guid id1;
        public FormMatch(Personv2 p0, Personv2 p1)
        {
            InitializeComponent();
            id0 = p0.Id;
            id1 = p1.Id;
            Text = p0.Name + " to " + p1.Name;
        }
        private void formMatch_Load(object sender, EventArgs e)
        {
            var data = new DataTable();
            data.Columns.Add("Chromosome");
            data.Columns.Add("Start Point");
            data.Columns.Add("End Point");
            data.Columns.Add("SNPs");
            data.Columns.Add("centiMorgans");
            data.Columns.Add("Source");
            foreach (Match match in Repository.GetChromosomes(id0, id1))
            {
                var row = data.NewRow();
                row["Chromosome"] = match.ChromosomeText;
                row["Start Point"] = match.StartPoint;
                row["End Point"] = match.EndPoint;
                row["SNPs"] = match.SNPs;
                row["centiMorgans"] = match.GeneticDistance;

                row["Source"] = match.FamilyTreeDna ? "Family Tree" : match.MeAnd23 ? "23AndMe" : "";
                data.Rows.Add(row);
            }
            var view = new DataView(data);
            DataTable distinctValues = view.ToTable(true, "Chromosome", "Start Point", "End Point", "SNPs", "centiMorgans", "Source");
            radGridView1.DataSource = distinctValues;
        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }
    }
}
