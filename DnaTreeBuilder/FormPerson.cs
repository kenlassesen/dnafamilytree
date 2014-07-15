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
    public partial class FormPerson : Form
    {
        private Personv2 person;
        private string title;
        public FormPerson(Personv2 person=null )
        {
            InitializeComponent();
            if(person==null)
            {
                person=new Personv2();
                title = "New Person";

            }
            else
            {
                this.person = person;
            }
        }

        private void PersonForm_Load(object sender, EventArgs e)
        {
            Text = title;
            textBoxEmail.Text = person.Email ?? String.Empty;
            textBoxName.Text = person.Name?? String.Empty;
            textBoxTelephone.Text = person.Telephone?? String.Empty;
            foreach (string item in person.PersonLinkList)
            {
                listBoxPersonLink.Items.Add(item);
            }
            label23AndMe.Text = person.Is23AndMe
                                    ? "23AndMe:" +
                                    person.MeId: String.Empty;
            labelFamilyTreeDna.Text = person.IsFamilyTreeDna
                        ? "FamilyTreeDna: " +
                        person.FamilyTreeId : String.Empty;
            if (!String.IsNullOrWhiteSpace(person.Name))
            {
                Text = person.Name;
            }
            labelmtDna.Text="mtDna: "+(person.MtDna ??"")            ;
            labelYDna.Text = "YDna: " + (person.YDna ?? "");
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
           person.Email = textBoxEmail.Text;
            textBoxName.Text = textBoxName.Text;
             person.Telephone = textBoxTelephone.Text;
            person.PersonLinkList.Clear();
            foreach (var item in listBoxPersonLink.Items)
            {
                person.PersonLinkList.Add(item.ToString());
            }
            foreach (string item in person.PersonLinkList)
            {
                listBoxPersonLink.Items.Add(item);
            }
            person.Save();
        }

        private void buttonViewChromosomes_Click(object sender, EventArgs e)
        {
            var frm = new FormPersonMatch(person);
            frm.Show(this);
        }
    }
}
