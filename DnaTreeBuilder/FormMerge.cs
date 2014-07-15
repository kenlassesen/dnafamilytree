using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Linq;
using DnaTreeBuilder.Instance;
namespace DnaTreeBuilder
{
    public partial class FormMerge : Telerik.WinControls.UI.RadForm
    {
        public FormMerge()
        {
            InitializeComponent();
        }

        private void formMerge_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            listBox23AndMe.Items.Clear();
            listBoxFamilyTreeDna.Items.Clear();
            foreach (var person in Repository.People23AndMe)
            {
                listBox23AndMe.Items.Add(person);
            }
            foreach (var person in Repository.PeopleFamilyTreeDna)
            {
                if (String.IsNullOrWhiteSpace(person.MeId))
                    listBoxFamilyTreeDna.Items.Add(person);
            }

        }

        private void buttonMerge_Click(object sender, EventArgs e)
        {
            var p0 = (Personv2)listBox23AndMe.SelectedItem;
            var p1 = (Personv2)listBoxFamilyTreeDna.SelectedItem;
            if (p0 == null || p1 == null)
            {
                MessageBox.Show(this, "You must select one in each box", "Unable to merge without two items");
                return;
            }
            if (p0.FamilyTreeId != p1.FamilyTreeId
                && !String.IsNullOrWhiteSpace(p0.FamilyTreeId)
                && !String.IsNullOrWhiteSpace(p1.FamilyTreeId))
            {
                MessageBox.Show(this, "You cannot merge two different FamilyTree people with different FTDNA Ids", "Unable to merge without two items");
                return;
            }
            if (p0.MeId != p1.MeId
                && !String.IsNullOrWhiteSpace(p0.MeId)
                && !String.IsNullOrWhiteSpace(p1.MeId))
            {
                MessageBox.Show(this, "You cannot merge two different 23AndMe people with different FTDNA Ids", "Unable to merge without two items");
                return;
            }
            if (string.IsNullOrWhiteSpace(p0.FamilyTreeId))
                p0.FamilyTreeId = p1.FamilyTreeId;
            if (string.IsNullOrWhiteSpace(p0.FamilyTreeInternalId))
                p0.FamilyTreeInternalId = p1.FamilyTreeInternalId;
            if (string.IsNullOrWhiteSpace(p0.MeId))
                p0.MeId = p1.MeId;
            foreach (var item in p1.PersonLinkList)
                if (!p0.PersonLinkList.Contains(item))
                    p0.PersonLinkList.Add(item);

            if (String.IsNullOrWhiteSpace(p0.MtDna))
                p0.MtDna = p1.MtDna;
            else
                p0.MtDna = (p0.MtDna + " " + p1.MtDna).Trim();

            if (String.IsNullOrWhiteSpace(p0.YDna))
                p0.YDna = p1.YDna;
            else
                p0.YDna = (p0.YDna + " " + p1.YDna).Trim();

            if (String.IsNullOrWhiteSpace(p0.Email))
                p0.Email = p1.Email;
            else
                p0.Email = (p0.Email + ";" + p1.Email).Trim();

            if (String.IsNullOrWhiteSpace(p0.Telephone))
                p0.Telephone = p1.Telephone;
            else
                p0.Telephone = (p0.Telephone + ";" + p1.Telephone).Trim();

            p0.Surname = p0.Surname + "/" + p1.Surname;
            foreach (var match in GetSet0(p1.Id))
                match.Id0 = p0.Id;
            foreach (var match in GetSet1(p1.Id))
                match.Id1 = p0.Id;
            Repository.People.Remove(p1);
            LoadData();
        }
        private IEnumerable<Match> GetSet0(Guid id)
        {
            return from match in Repository.MatchList
                   where match.Id0 == id
                   select match;
        }
        private IEnumerable<Match> GetSet1(Guid id)
        {
            return from match in Repository.MatchList
                   where match.Id1 == id
                   select match;
        }

        private int leftSide = 0;
        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leftSide = 0;
            allToolStripMenuItem.Checked = true;
            andMeToolStripMenuItem.Checked = false;
            familyTreeDnaToolStripMenuItem.Checked = false;
            UpdateLeftSide();
        }

        private void andMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allToolStripMenuItem.Checked = false;
            andMeToolStripMenuItem.Checked = true;
            familyTreeDnaToolStripMenuItem.Checked = false;
            leftSide = 1;
            UpdateLeftSide();
        }

        private void familyTreeDnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allToolStripMenuItem.Checked = false;
            andMeToolStripMenuItem.Checked = false;
            familyTreeDnaToolStripMenuItem.Checked = true;

            leftSide = 2;
            UpdateLeftSide();
        }
        private void UpdateLeftSide()
        {
            listBox23AndMe.Items.Clear();
            foreach (var p in GetFilteredPeople(leftSide))
                listBox23AndMe.Items.Add(p);
        }
        private IEnumerable<Personv2> GetFilteredPeople(int filter)
        {
            switch (filter)
            {
                case 1:
                    return Repository.People23AndMe;
                    break;
                case 2:
                    return Repository.PeopleFamilyTreeDna;
                    break;
              default:
                    return Repository.People;
                    break;
             
            }
        }
        private int rightSide = 1;
        private void allToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rightSide = 0;
            allToolStripMenuItem1.Checked = true;
            andMeToolStripMenuItem1.Checked = false;
            familyTreeDnaToolStripMenuItem1.Checked = false;
            UpdateRightSide();
        }

        private void andMeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rightSide = 1;
            allToolStripMenuItem1.Checked = false;
            andMeToolStripMenuItem1.Checked = true;
            familyTreeDnaToolStripMenuItem1.Checked = false;
            UpdateRightSide();
        }

        private void familyTreeDnaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rightSide = 2;
            allToolStripMenuItem1.Checked = false;
            andMeToolStripMenuItem1.Checked = false;
            familyTreeDnaToolStripMenuItem1.Checked = true;
            UpdateRightSide();
        }
        private void UpdateRightSide()
        {

            listBoxFamilyTreeDna.Items.Clear();
            foreach (var p in GetFilteredPeople(rightSide))
                listBoxFamilyTreeDna.Items.Add(p);
        }
    }
}
