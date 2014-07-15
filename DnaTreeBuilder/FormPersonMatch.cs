using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DnaTreeBuilder.Instance;
namespace DnaTreeBuilder
{
    public partial class FormPersonMatch : Form
    {
        private Personv2 person;
        public FormPersonMatch(Personv2 person)
        {
            this.person = person;
            InitializeComponent();
            Text = person.Name + " Chromosome Matches";
        }

        private void formMatch_Load(object sender, EventArgs e)
        {
            var data = new DataTable();
            data.Columns.Add("Person");
            data.Columns.Add("Chromosome");
            data.Columns.Add("Start Point");
            data.Columns.Add("End Point");
            data.Columns.Add("SNPs");
            data.Columns.Add("centiMorgans");
            data.Columns.Add("Source");
            var lastId = Guid.Empty;
            var lastName = String.Empty;
            Personv2 matchPerson;
            foreach (Match match in Repository.GetChromosomes(person.Id))
            {
                var row = data.NewRow();
                row["Chromosome"] = match.ChromosomeText;
                row["Start Point"] = match.StartPoint;
                row["End Point"] = match.EndPoint;
                row["SNPs"] = match.SNPs;
                row["centiMorgans"] = match.GeneticDistance;
                row["Source"] = match.FamilyTreeDna ? "Family Tree" : match.MeAnd23 ? "23AndMe" : "";
                if (person.Id == match.Id0)
                    matchPerson = Repository.FindPerson(match.Id1);
                else
                    matchPerson = Repository.FindPerson(match.Id0);
                row["Person"] = matchPerson.Name;
                data.Rows.Add(row);
            }
            var view = new DataView(data);
            DataTable distinctValues = view.ToTable(true, "Chromosome", "Start Point", "End Point", "SNPs", "centiMorgans","Person","Source");
            radGridView1.DataSource = distinctValues;
        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }
    }
}
