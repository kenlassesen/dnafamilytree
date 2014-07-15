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
    public partial class FormFamilyDisplayAll : Telerik.WinControls.UI.RadForm
    {

        private readonly List<Personv2> terminateList;
        private readonly List<Personv2> starterList;
        public FormFamilyDisplayAll(List<Personv2> terminate, List<Personv2> starterList)
        {
            InitializeComponent();
            terminateList = terminate;
            this.starterList = starterList;
            Text = "Family Tree for ALL Persons:";
        }

        private void radTreeView1_SelectedNodeChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {

        }

        private int familyCount = 1;
        private RadTreeNode adam;
        private void FormFamilyDisplay_Load(object sender, EventArgs e)
        {
            newFamily();
        }
        private void newFamily()
        {
            if (starterList.Count > 0)
            {
                adam = new RadTreeNode("Family Group " + familyCount++);
                adam.ForeColor = Color.Black;
                radTreeView1.Nodes.Add(adam);
                var starter=starterList[0];
                adam.Nodes.Add(starter.FamilyNode);
                starterList.RemoveAt(0);
                timer1.Enabled = true;    
            }
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
                       orderby node.GradientPercentage descending 
                       select node);
            
            if(! toDoList.Any())
            {
                toolStripStatusLabel1.Text = "Done "+adam.Text;
                newFamily();
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
                    try
                {
                    Guid id = match.Id0;
                    if(!(from node in adam.Nodes where id==(Guid) node.Value select node).Any())
                    {
                        var addP = Repository.GetPerson(match.Id0);
                        var addN = addP.FamilyNode;
                        addN.Text = addN.Text + " <= " + toDo.Text;
                        adam.Nodes.Add(addN);
                        if (starterList.Contains(addP))
                            starterList.Remove(addP);
                    }
                   id = match.Id1;
                   if(!(from node in adam.Nodes where id==(Guid) node.Value select node).Any())
                     {
                        var addP = Repository.GetPerson(match.Id1);
                        var addN = addP.FamilyNode;
                         addN.Text = addN.Text + " <= " + toDo.Text;
                        adam.Nodes.Add(addN);
                       if (starterList.Contains(addP))
                            starterList.Remove(addP);
                    }
                }
                catch(Exception exc)
                {
                    MessageBox.Show(this, exc.Message, "Unexpected Error");
                }
                toDo.BorderColor = Color.FloralWhite;
                toDo.BackColor = Color.FloralWhite;
            }
            adam.ExpandAll();
            timer1.Enabled = true;
        }

        private int filter = 0;
        private void allTreesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allTreesToolStripMenuItem.Checked = true;
        orMorePeopleToolStripMenuItem.Checked = false;
                  orMorePeopleToolStripMenuItem1.Checked = false;
            filter = 0;
            ApplyFilter();
        }

        private void orMorePeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allTreesToolStripMenuItem.Checked = false;
            orMorePeopleToolStripMenuItem.Checked = true;
                              orMorePeopleToolStripMenuItem1.Checked = false;
            filter = 3;
            ApplyFilter();
        }

        private void orMorePeopleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            allTreesToolStripMenuItem.Checked = false;
        orMorePeopleToolStripMenuItem.Checked = false;
                  orMorePeopleToolStripMenuItem1.Checked = true;
            filter = 6;
            ApplyFilter();
        }
        private void ApplyFilter()
        {
            foreach (RadTreeNode node in radTreeView1.Nodes)
                node.Visible = node.Nodes.Count() >= filter;
        }

        private void saveTreeToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveUtility.SaveRadTree(radTreeView1);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /// <summary>
        /// All of the family tree DNA detail data
        /// </summary>
        private List<Match> ftDna=null;
        private void inferDnaMatchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            MessageBox.Show(this,
                            "This looks at Terminators Family DNA (if any)\r\n And looks for seqment matches that agrees with these Family Groups\r\nThey a coin toss (literally)",
                            "Stretching the tree");
            ftDna = (from m in Repository.MatchList
                    where m.FamilyTreeDna && m.GeneticDistance > 1
                    select m).ToList();
            if (ftDna == null || !ftDna.Any())
            {
                MessageBox.Show(this,
                                "Unable to find any chromosome level data for FTDNA - have you downloaded yet?",
                                "No Family Tree DNA data");
                return;
            }
            timerFTDNa.Enabled = true;
        }

        private void timerFTDNa_Tick(object sender, EventArgs e)
        {
            timerFTDNa.Enabled = false;
              var toDoList = (from node in radTreeView1.Nodes
                       where node.ForeColor == Color.Black
                       orderby node.Nodes.Count 
                       select node);
            if(! toDoList.Any())
            {
                toolStripStatusLabel1.Text = "FTDNA inference Done "+adam.Text;
                return;
            }
            var toDo=toDoList.FirstOrDefault();
            foreach(var n in toDo.Nodes)
            {
                var p = (Personv2) n.Tag;
                var overlaps = (from m in Repository.MatchList
                               where m.GeneticDistance > 1
                                     && (m.Id0 == p.Id || m.Id1 == p.Id)
                               select m).ToList();
                foreach(var o in overlaps)
                {
                    foreach(var m in ftDna)
                    {
                        if(o.IsOverlapped(m))
                        {
                            var p0 = Repository.GetPerson(m.Id0).FamilyNode;
                            var p1 = Repository.GetPerson(m.Id1).FamilyNode;
                            var add = 0;
                            foreach(var n1 in toDo.Nodes)
                            {
                                if (p0.Value == n1.Value) add = add | 1;
                                if (p1.Value == n1.Value) add = add | 2;
                            }
                            switch(add)
                            {
                                case 0:
                                    break;
                                case 1:
                                    toDo.Nodes.Add(p1);
                                    break;
                                     case 2:
                                    toDo.Nodes.Add(p1);
                                    break;
                                    
                                default:
                                    break;
                            }
                        }
                    }
                }

            }
            toDo.ForeColor = Color.BlueViolet;
            timerFTDNa.Enabled = true;

        }
    }
}
