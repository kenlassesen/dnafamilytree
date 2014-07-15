using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DnaTreeBuilder.Instance;
using Telerik.WinControls;
using System.Linq;
using Telerik.WinControls.UI;
namespace DnaTreeBuilder
{
    public partial class FormFamilyBuilderAll : Telerik.WinControls.UI.RadForm
    {
        private RadTreeNodeCollection nodes;
        public FormFamilyBuilderAll(RadTreeNodeCollection dna)
        {
            InitializeComponent();
            nodes = dna;
        }
        private void frmFamilyBuilder_Load(object sender, EventArgs e)
        {
 var choices = new List<int>();
            foreach (RadTreeNode node in nodes)
            {
                if (!choices.Contains(node.Nodes.Count))
                    choices.Add(node.Nodes.Count);
            }
            if (comboBox1.Items.Count > 0) return;
            foreach (var choice in choices)
                comboBox1.Items.Add(String.Format("{0,6}", choice));
            switch (comboBox1.Items.Count)
            {
                case 0:
                    MessageBox.Show(this, "No data", "Aborting");
                    Close();
                    return;
                case 1:
                    comboBox1.SelectedIndex = 0;
                    break;
                case 2:
                    comboBox1.SelectedIndex = 1;
                    break;
                default:
                    comboBox1.SelectedIndex = comboBox1.Items.Count - 2;
                    break;
            }
        }

        private void buttonEstimate_Click(object sender, EventArgs e)
        {
            var terms = new List<Personv2>();
            var people = new List<Personv2>();
            foreach(var item in checkedListBoxTerminating.CheckedItems)
            {
                terms.Add((Personv2)item);
            }
            foreach(var item in comboBoxStarter.Items)
            {
                people.Add((Personv2)item);
            }
            var frm = new FormFamilyDisplayAll(terms, people);
            frm.Show(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       if(comboBox1.Items.Count==0) 
                frmFamilyBuilder_Load(sender, e);
            int threshold = int.Parse(comboBox1.SelectedItem.ToString());
            //Update with out changing prior choice much
            foreach (RadTreeNode node in nodes)
            {
                if (node.Nodes.Count >= threshold)
                {
                    if (!checkedListBoxTerminating.Items.Contains(node.Tag))
                    {
                        var i = checkedListBoxTerminating.Items.Add(node.Tag);
                        checkedListBoxTerminating.SetItemChecked(i, true);
                    }
                    if (comboBoxStarter.Items.Contains(node.Tag))
                        comboBoxStarter.Items.Remove(node.Tag);
                }
                else
                {
                    if (!comboBoxStarter.Items.Contains(node.Tag))
                        comboBoxStarter.Items.Add((node.Tag));

                    if (checkedListBoxTerminating.Items.Contains(node.Tag))
                        checkedListBoxTerminating.Items.Remove(node.Tag);

                }
            }
            if (comboBoxStarter.SelectedIndex < 0 && comboBoxStarter.Items.Count > 0)
                comboBoxStarter.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
  var terms = new List<Personv2>();
            var people = new List<Personv2>();
            foreach(var item in checkedListBoxTerminating.CheckedItems)
            {
                terms.Add((Personv2)item);
            }
            foreach(var item in comboBoxStarter.Items)
            {
                people.Add((Personv2)item);
            }
            var frm = new FormFamilyDisplayGenetic(terms, people);
            frm.Show(this);
        }
    }
}
