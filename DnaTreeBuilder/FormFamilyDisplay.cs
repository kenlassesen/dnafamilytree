using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DnaTreeBuilder.Instance;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace DnaTreeBuilder
{
    public partial class FormFamilyDisplay : Telerik.WinControls.UI.RadForm
    {

        private List<Personv2> terminateList;
        private Personv2 starterPerson;
        public FormFamilyDisplay(List<Personv2> terminate, Personv2 starter)
        {
            InitializeComponent();
            terminateList = terminate;
            starterPerson = starter;
            if(starter==null)
            {
                Close();
            }
            else
            Text = "Family Tree for:" + starterPerson.Name;
        }

        private void radTreeView1_SelectedNodeChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {

        }

        private RadTreeNode adam;
        private void FormFamilyDisplay_Load(object sender, EventArgs e)
        {
            adam=new RadTreeNode("Common Ancestor");
            radTreeView1.Nodes.Add(adam);
            adam.Nodes.Add(starterPerson.FamilyNode);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if(radToggleButton1.ToggleState== ToggleState.On)
            {
                AddRelatedPeopleSimple();
            }
        }

        private void radToggleButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

        }

        private void radToggleButton2_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

        }
        private void AddRelatedPeopleSimple()
        {
            var toDoList = (from node in adam.Nodes
                       where node.BackColor == Color.Yellow
                       select node);
            
            if(! toDoList.Any())
            {
                toolStripStatusLabel1.Text = "Done";
                return;
            }
            var toDo=toDoList.FirstOrDefault();
            var person =(Personv2) toDo.Tag;
            if( (from p in terminateList
                     where p.Id ==person.Id
                     select p).Any())
            {
                toDo.BorderColor = Color.Red;
                toDo.BackColor = Color.LightPink;
            }
            else
            {
                var matches = from match in Repository.MatchList
                              where (match.Id0 == person.Id || match.Id1 == person.Id)
                                    && match.GeneticDistance > 0
                              select match;
                foreach(var match in matches)
                {
                    Guid id = match.Id0;
                    if(!(from node in adam.Nodes where id==(Guid) node.Value select node).Any())
                    {
                        var addP = Repository.GetPerson(match.Id0);
                        adam.Nodes.Add(addP.FamilyNode);
                    }
                   id = match.Id1;
                   if(!(from node in adam.Nodes where id==(Guid) node.Value select node).Any())
                     {
                        var addP = Repository.GetPerson(match.Id1);
                        adam.Nodes.Add(addP.FamilyNode);
                    }
                }
                toDo.BorderColor = Color.FloralWhite;
                toDo.BackColor = Color.FloralWhite;
            }
            timer1.Enabled = true;
        }

        private void saveTreeToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveUtility.SaveRadTree(radTreeView1);
        }
    }
}
