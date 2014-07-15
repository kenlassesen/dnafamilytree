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
    public partial class FormFamilyDisplayGenetic : Telerik.WinControls.UI.RadForm
    {

        private readonly List<Personv2> terminateList;
        private readonly List<Personv2> starterList;
        public FormFamilyDisplayGenetic(List<Personv2> terminate, List<Personv2> starterList)
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
                radTreeView1.Nodes.Add(adam);
                var starter=starterList[0];
                adam.Nodes.Add(starter.FamilyNode);
                starterList.RemoveAt(0);
                timer1.Enabled = true;    
            }
            else
            {
                timer2.Enabled = true;
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            GeneticLayout();
        }
        private void GeneticLayout()
        {
                      var toDoList = (from node in radTreeView1.Nodes
                       where ! node.Checked
                       orderby node.Nodes.Count
                       select node);
            
            if(! toDoList.Any())
            {
                toolStripStatusLabel1.Text = "Done Genetic Trees";
                return;
            }
            var anode = toDoList.FirstOrDefault();
            switch (anode.Nodes.Count)
            {
                case 0:
                case 1:
                    anode.Checked = true;
                    anode.ToolTipText = "No DNA relatives to show";
                    break;
                case 2:
                    genetic2(anode);
                    break;
                default:
                    genetic2(anode);
                    break;
            }
            anode.Checked = true;
            timer2.Enabled = true;
        }
        private void genetic2(RadTreeNode node)
        {
            var list = GetMatchSet(node);
            var link=list[0];
            var rel = GeneticDistance.ConvertToSteps(link, list);
            node.ToolTipText = rel.ToString();
            node.Checked = true;
        }

        private List<Guid> activeTree;
        private List<Match> GetMatchSet(RadTreeNode node)
        {
            activeTree = new List<Guid>();
            foreach(var n in node.Nodes)
                activeTree.Add((Guid) (n.Value));
            var matches=from m in Repository.MatchList
                        where m.GeneticDistance > 0
                        && activeTree.Contains(m.Id0)
                        && activeTree.Contains(m.Id1)
                        group m by m.Key into g
                        select new Match {Id0=g.Min(p=>p.Id0),Id1=g.Min(p=>p.Id1),GeneticDistance = g.Sum(p => p.GeneticDistance) };
            return (from m in matches
                    orderby m.GeneticDistance descending
                    select m).ToList();
        }
    }
}
