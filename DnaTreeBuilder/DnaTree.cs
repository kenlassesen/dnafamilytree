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
    public partial class DnaTree : Form
    {
        private TreeNode _root = new TreeNode("Ancestor");
        private readonly List<string> processed = new List<string>();

        public DnaTree()
        {
            InitializeComponent();
            treeView1.Nodes.Add(_root);
        }

        private void FillPeople()
        {
            var set = Repro.PeopleList.OrderBy(x => x.Name).ToList();
            foreach (OldPerson p in set)
            {
                comboBox1.Items.Add(p);
            }
            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        public RepositoryOld Repro { get; set; }
        public OldPerson RootPerson { get; set; }

        private void DnaTree_Load(object sender, EventArgs e)
        {
            FillPeople();
        }

        private bool InitialPopulate()
        {
            string nextId;
            var a = GetNextPerson(out nextId);
            TreeNode root = Reset(a); 
            var result = false;
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(root = new TreeNode("Ancestor"))
                ;
            TreeNode nextA = root;
            TreeNode nextAt;
            var b = Repro.FindPersonById(nextId);
            var msteps = Repro.StepsBetween(a, b);
            var siblings = Repro.AreSiblings(a, b);
            if (siblings)
            {
                root.Nodes.Add(nextAt = new TreeNode {Text = a.Name, Name = a.Id,BackColor = colorList[0]});
                root.Nodes.Add(new TreeNode { Text = b.Name, Name = b.Id, BackColor = colorList[0] });
                result = true;
            }
            else if (msteps == 1)
            {
                var direction = OldPerson.GenerationEqual(a, b);
                if (direction > 0)
                {
                    root.Nodes.Add(nextAt = new TreeNode { Text = a.Name, Name = a.Id, BackColor = colorList[0] });
                    nextAt.Nodes.Add(new TreeNode { Text = b.Name, Name = b.Id, BackColor = colorList[0] });
                }
                else
                {
                    root.Nodes.Add(nextAt = new TreeNode { Text = b.Name, Name = b.Id, BackColor = colorList[0] });
                    nextAt.Nodes.Add(new TreeNode { Text = a.Name, Name = a.Id, BackColor = colorList[0] });
                }
                result = true;
            }
            else if (msteps == 2)
            {
                var direction = OldPerson.GenerationEqual(a, b);
                if (Math.Abs(direction) < 0.2D)
                {
                    root.Nodes.Add(nextAt = new TreeNode { Text = "Unknown", Name = a.Id + "_" + b.Id, BackColor = colorList[0] });

                    nextAt.Nodes.Add(new TreeNode { Text = a.Name, Name = a.Id, BackColor = colorList[0] });
                    nextAt.Nodes.Add(new TreeNode { Text = b.Name, Name = b.Id, BackColor = colorList[0] });
                }
                if (direction > 0)
                {
                    nextA.Nodes.Add(nextAt = new TreeNode { Text = a.Name, Name = a.Id, BackColor = colorList[0] });
                    nextAt.Nodes.Add(nextAt = new TreeNode { Text = "Unknown", Name = a.Id + "/" + b.Id, BackColor = colorList[0] });
                    nextAt.Nodes.Add(new TreeNode { Text = b.Name, Name = b.Id, BackColor = colorList[0] });
                }
                else
                {
                    nextA.Nodes.Add(nextAt = new TreeNode { Text = b.Name, Name = b.Id, BackColor = colorList[0] });
                    nextAt.Nodes.Add(nextAt = new TreeNode { Text = "Unknown", Name = b.Id + "/" + a.Id, BackColor = colorList[0] });
                    nextAt.Nodes.Add(new TreeNode { Text = a.Name, Name = a.Id, BackColor = colorList[0] });
                }
                result = true;
            }
            if (result)
            {
                processed.Add(a.Id);
                processed.Add(b.Id);

                treeView1.ExpandAll();
            }
            return false;
        }

        /// <summary>
        /// Get the person next closest to the existing persons
        /// </summary>
        /// <returns></returns>
        private string NextPersonId()
        {
            var nextId = String.Empty;
            var nextCm = 0F;
            foreach (var pid in processed)
            {
                var testId = String.Empty;
                var testCm = 0F;
                var inTree = Repro.FindPersonById(pid);
                testCm = inTree.ClosestMatch(processed, out testId);
                if (testCm > nextCm)
                {
                    nextCm = testCm;
                    nextId = testId;
                }
            }
            return nextId;
        }

        private void nextImpliedFamilyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitialPopulate();
        }

        private void DoTenMore()
        {
            int loops = 9;
            var nextPerson = NextPersonId();
            if (nextPerson != null)
            {
                loops--;
                var matrix = GetMatrix(nextPerson);
                var list = matrix.OrderByDescending(kp => kp.Value)
                    .Select(kp => kp.Key)
                    .ToList();
                var added = false;

                foreach (var inTree in list)
                {
                    TreeNode[] sNode = treeView1.Nodes.Find(inTree, true);
                    if (sNode.Length == 0) return;
                    TreeNode myNode = sNode[0];

                    TreeNode aNode = myNode;
                    var steps = Repro.StepsBetween(inTree, nextPerson);
                    if (steps > 14) return;
                    if (!added)
                    {
                        int cnt = 0;
                        int anc = steps/2;
                        while (anc > 0 && aNode.Parent != null)
                        {
                            aNode = aNode.Parent;
                            anc--;
                            cnt++;
                        }
                        while (anc > 0)
                        {
                            var newNode = new TreeNode("X" + cnt++);
                            treeView1.Nodes.Remove(aNode);
                            treeView1.Nodes.Add(newNode);
                            newNode.Nodes.Add(aNode);
                            aNode = newNode;
                            anc--;
                        }
                        int dwn = steps - steps/2;
                        while (dwn > 0)
                        {
                            var cNode = new TreeNode("X" + cnt++);
                            aNode.Nodes.Add(cNode);
                            aNode = cNode;
                            dwn--;
                        }
                        var lP = Repro.FindPersonById(nextPerson);
                        aNode.Text = lP.Name;
                        aNode.Name = lP.Id;
                        aNode.EnsureVisible();
                        processed.Add(nextPerson);
                        added = true;
                    }
                    Application.DoEvents();
                    break;

                }
                nextPerson = NextPersonId();
            }
        }


        private Dictionary<string, float> GetMatrix(string personid)
        {
            var result = new Dictionary<string, float>();

            var p = Repro.FindPersonById(personid);
            if (p == null)
                return result;
            foreach (string id in processed)
            {
               // if (p.MyMatches == null)
                    return result;
                foreach (Match m in Repository.MatchList)
                {
                    if (m.GeneticDistance > 0F )//&& !result.ContainsKey(m.Id)
                   
                    {
                        result.Add(id, m.GeneticDistance);
                    }
                }
            }
            return result;
        }

        private OldPerson GetNextPerson(out string bestid)
        {
            OldPerson best = null;
            var bestCm = 0F;
            bestid = string.Empty;
            foreach (var p in Repro.PeopleList)
            {
                if (!processed.Contains(p.Id))
                {
                    if (best == null)
                    {
                        best = p;
                        bestCm = best.ClosestMatch(processed, out bestid);
                    }
                    else
                    {
                        string testid = string.Empty;
                        var testDist = 0F;
                        if (bestCm < (testDist = p.ClosestMatch(processed, out testid)))
                        {
                            best = p;
                            bestCm = testDist;
                            bestid = testid;
                        }
                    }
                }
            }
            return best;
        }

        private void doTenMoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoTenMore();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void startWithSelectedPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed.Clear();
            var p = (OldPerson) comboBox1.SelectedItem;
            if (p == null) return;
            Reset(p);
            treeView1.Nodes.Add(new TreeNode {Text = p.Name, Name = p.Id});
            processed.Add(p.Id);
            DoTenMore();
        }

        private Color[] colorList =
                                                  new Color[] {
                                                                  Color.LightGoldenrodYellow,
                                                                  Color.LightPink,
                                                                  Color.LightSteelBlue,
                                                                  Color.LightSeaGreen,
                                                                  Color.LightGray,
                                                                  Color.LightGray,
                                                                  Color.LightSalmon}
                                               ;
        /// <summary>
        /// Reset the trees for the next analysis
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private TreeNode Reset(OldPerson a)
        {
            var result = new TreeNode {Text = "Ancestor", Name = "Parent_" + a.Id, BackColor = colorList[0]};
            
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(result);
             treeViewFamilies.Nodes.Clear();
            var item = new TreeNode {Text = a.Name + " Family Tree", Tag = a, 
                BackColor = colorList[0]};
             treeViewFamilies.Nodes.Add(item);
            return result;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            var node = (TreeNode)sender;
            var person = (Personv2)node.Tag;
            if (person != null)
            {
                var personForm = new FormPerson(person);
                personForm.Show(this);
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var node = (TreeNode)sender;
            var person = (Personv2)node.Tag;
            if (person != null)
            {
                var personForm = new FormPerson(person);
                personForm.Show(this);
            }
        }
    }
}
