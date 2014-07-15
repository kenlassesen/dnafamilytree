using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Telerik.WinControls.UI;

namespace DnaTreeBuilder.Instance
{
    public class Personv2
    {
        public Personv2()
        {
            Defaults();
        }

        public int RelatedCount { get; set; }
        public static string NormName(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) return String.Empty;
            char[] commasep = { ',', ';' };
            var parts = name.Split(commasep, StringSplitOptions.RemoveEmptyEntries);
            switch (parts.Length)
            {
                case 0:
                    return string.Empty;
                case 1:
                    name = parts[0];
                    break;
                case 2:
                    name = parts[1].Trim() + " " + parts[0].Trim();
                    break;
                case 3:
                    name = parts[1].Trim() + " " + parts[2].Trim() + " " + parts[0].Trim();
                    break;
            }
            return name.Replace("  ", " ").Replace("  ", " ").Trim();
        }
        public Personv2(string html)
        {
            Defaults();
            // To fix <img tag issue
            var i = html.IndexOf("</span>");
            html = html.Substring(0, i) + "</span></li>";
            var dom = new XmlDocument();
            dom.LoadXml(html);
            // ReSharper disable PossibleNullReferenceException
            Name = dom.DocumentElement.Attributes["data-first"].Value + " " + dom.DocumentElement.Attributes["data-last"].Value;
            // ReSharper restore PossibleNullReferenceException
            var idNode = dom.SelectSingleNode("//*[@class='ps_id']");
            if (idNode != null) MeId = idNode.InnerText;
        }
        private void Defaults()
        {
            MeId = String.Empty;
            Name = String.Empty;
            YDna = String.Empty;
            MtDna = String.Empty;
            Email = String.Empty;
            Telephone = String.Empty;
            this.Surname = String.Empty;
            Id = Guid.NewGuid();

        }
        public Personv2(XmlNode node)
        {
            Defaults();
            if (node.Name.Equals("personv2"))
            {
                if (node.Attributes["id"] != null)
                {
                    Guid testId;
                    if (Guid.TryParse(node.Attributes["id"].Value, out testId))
                    {
                        Id = testId;
                    }
                }
                if (node.Attributes["email"] != null)
                {
                    Email = node.Attributes["email"].Value;
                }
                if (node.Attributes["meId"] != null)
                {
                    MeId = node.Attributes["meId"].Value;
                }
                if (node.Attributes["surname"] != null)
                {
                    Surname = node.Attributes["surname"].Value;
                }

                if (node.Attributes["ftDnaAdvance"] != null)
                {
                    try
                    {
                        FTDnaAdvance = bool.Parse(node.Attributes["ftDnaAdvance"].Value);
                    }
                    catch
                    {
                    }
                }

                if (node.Attributes["familyTreeId"] != null)
                {
                    FamilyTreeId = node.Attributes["familyTreeId"].Value;
                }
                if (node.Attributes["familyTreeInternalId"] != null)
                {
                    FamilyTreeInternalId = node.Attributes["familyTreeInternalId"].Value;
                }
                else FamilyTreeInternalId = String.Empty;
                if (node.Attributes["yDna"] != null)
                {
                    YDna = node.Attributes["yDna"].Value;
                }
                if (node.Attributes["mtDna"] != null)
                {
                    MtDna = node.Attributes["mtDna"].Value;
                }
                if (node.Attributes["name"] != null)
                {
                    Name = node.Attributes["name"].Value;
                }
                if (node.Attributes["telephone"] != null)
                {
                    Telephone = node.Attributes["telephone"].Value;
                }
                foreach (XmlNode itemNode in node.SelectNodes("personLink"))
                {
                    if (!String.IsNullOrWhiteSpace(itemNode.InnerText))
                        PersonLinkList.Add(itemNode.InnerText);
                }
                foreach (XmlNode itemNode in node.SelectNodes("dna"))
                {
                    if (!String.IsNullOrWhiteSpace(itemNode.InnerText))
                        DnaList.Add(itemNode.InnerText);
                }
                IsSaved = true;
            }
            else
            {
                MessageBox.Show("Node name is invalid" + node.Name + "\r\n" + node.InnerXml, "Bad Input Data");
            }
        }
        public IEnumerable<Match> MyMatches
        {
            get
            {
                return from match in Repository.MatchList
                       where (match.Id0 == Id || match.Id1 == Id)
                       && match.GeneticDistance > 0
                       select match;
            }
        }
        public Guid Id { private set; get; }
        /// <summary>
        /// 23 and Me ID
        /// </summary>
        public String MeId { set; get; }

        public bool FTDnaAdvance { get; set; }
        private String _familyTreeId = string.Empty;
        public String FamilyTreeId
        {
            set { _familyTreeId = NormName(value); }
            get { return _familyTreeId; }
        }
        public String FamilyTreeInternalId { set; get; }
        public String YDna { set; get; }
        public String MtDna { set; get; }
        public String Surname { set; get; }
        private String _name = string.Empty;
        public String Name
        {
            set
            {
                if (value != null)
                    _name = NormName(value);
            }
            get { return _name; }
        }
        public String Email { get; set; }
        public String Telephone { get; set; }
        public bool Is23AndMe { get { return !String.IsNullOrWhiteSpace(MeId); } }
        public readonly List<string> PersonLinkList = new List<string>();
        public readonly List<string> DnaList = new List<string>();
        public void ToXmlNode(XmlNode node)
        {
            if (node == null || node.OwnerDocument == null) return;
            var doc = node.OwnerDocument;
            XmlNode root = doc.CreateElement("personv2");
            node.AppendChild(root);
            var attr = doc.CreateAttribute("id");
            attr.Value = Id.ToString();
            root.Attributes.Append(attr);
            root.Attributes.Append(attr = doc.CreateAttribute("name"));
            attr.Value = Name ?? String.Empty;
            root.Attributes.Append(attr = doc.CreateAttribute("meId"));
            attr.Value = MeId ?? String.Empty;
            root.Attributes.Append(attr = doc.CreateAttribute("familyTreeId"));
            attr.Value = FamilyTreeId ?? String.Empty;
            root.Attributes.Append(attr = doc.CreateAttribute("email"));
            attr.Value = Email ?? String.Empty;
            root.Attributes.Append(attr = doc.CreateAttribute("telephone"));
            attr.Value = Telephone ?? String.Empty;
            root.Attributes.Append(attr = doc.CreateAttribute("surname"));
            attr.Value = Surname ?? String.Empty;
            root.Attributes.Append(attr = doc.CreateAttribute("yDna"));
            attr.Value = YDna ?? String.Empty;
            root.Attributes.Append(attr = doc.CreateAttribute("mtDna"));
            attr.Value = MtDna ?? String.Empty;
            root.Attributes.Append(attr = doc.CreateAttribute("familyTreeInternalId"));
            attr.Value = FamilyTreeInternalId ?? String.Empty;
            root.Attributes.Append(attr = doc.CreateAttribute("ftDnaAdvance"));
            attr.Value = FTDnaAdvance.ToString();
            XmlNode itemNode;
            foreach (String item in PersonLinkList)
            {
                root.AppendChild(itemNode = doc.CreateElement("personLink"));
                itemNode.InnerText = item;
            }
            foreach (String item in DnaList)
            {
                root.AppendChild(itemNode = doc.CreateElement("dna"));
                itemNode.InnerText = item;
            }
        }

        public bool FromFamilyTreeDna { get; set; }
        public void Save()
        {
            foreach (Personv2 item in Repository.People)
            {
                if (item.Id == Id
                    ||
                    (
                    item.MeId.Equals(MeId, StringComparison.InvariantCultureIgnoreCase) &&
                    !String.IsNullOrWhiteSpace(MeId)
                    )
                    || (
                    item.FamilyTreeId.Equals(FamilyTreeId, StringComparison.InvariantCultureIgnoreCase)
                    &&
                    !String.IsNullOrWhiteSpace(FamilyTreeId)
                    )
                    )
                {
                    if (item.Id != Id)
                        MessageBox.Show(this.ToString() + " found", "Duplicate Error");
                    return;
                }
            }
            if (!IsFamilyTreeDna && !Is23AndMe)
            {
                MessageBox.Show("Source was not given", "Data Error");

                return;
            }
            Repository.People.Add(this);
            IsSaved = true;
        }
        public void Delete()
        {
            if (Repository.People.Contains(this))
                Repository.People.Remove(this);
            Repository.People.Add(this);
        }

        public bool IsSaved { get; set; }
        public RadTreeNode TreeNode
        {
            get
            {
                var treeNode = new RadTreeNode { Text = ToString(), Name = Id.ToString(), Tag = this };
                var related = new List<Guid>();
                var relatedNames = new List<String>();
                related.Add(Id);
                relatedNames.Add("Self");
                var relatedPeople = (from match in Repository.MatchList
                                     where (match.Id0 == Id || match.Id1 == Id)
                                     && match.GeneticDistance > 0
                                     select match.Id0 == Id ? match.Id1 : match.Id0).Distinct();
                foreach (Guid id in relatedPeople)
                {
                    var person = Repository.GetPerson(id);

                    treeNode.Nodes.Add(new RadTreeNode { Text = person.Name, Value = Id, Tag = person });
                }
                RelatedCount=treeNode.Nodes.Count;
                return treeNode;
            }
        }
        public RadTreeNode FamilyNode
        {
            get
            {
                return new RadTreeNode {Text = ToString(), GradientPercentage = ((float)RelatedCount)/100F,Name = Id.ToString(),  Value = Id, Tag = this, BackColor = Color.Yellow, BorderColor = Color.DeepSkyBlue };
            }
        }
        public bool IsFamilyTreeDna { get { return !String.IsNullOrWhiteSpace(FamilyTreeId); } }
        public override string ToString()
        {
            var result = new StringBuilder(Name + "   [");
            if (Is23AndMe)
                result.Append("23andMe ");
            if (IsFamilyTreeDna)
                result.Append("FTDna ");
            if(RelatedCount > 0)
                result.Append("]["+RelatedCount);
            return result.ToString().Trim() + "]";
        }

        public int IndexNo { get; set; }

    }
}
