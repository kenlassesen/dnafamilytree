using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Telerik.WinControls.UI;

namespace DnaTreeBuilder.Instance
{
    public class Match
    {
        public Guid Id0 { set; get; }
        public Guid Id1 { set; get; }
        public int Chromosome { set; get; }
        public int StartPoint { set; get; }
        public int EndPoint { set; get; }
        public bool MeAnd23 { set; get; }
        public bool FamilyTreeDna { set; get; }
        public string Key
        {
            get
            {
                return Id0.ToString() + "\t" + Id1.ToString() + "\t" + (MeAnd23 ? "23" : "FT");
            }
        }
        /// <summary>
        /// CENTIMORGANS
        /// </summary>
        public float GeneticDistance { set; get; }
        public int SNPs { set; get; }
        public Match()
        {
            Id0 = Guid.Empty;
            Id1 = Guid.Empty;
        }
        /// <summary>
        /// Is there at least 1000 snps in common
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool IsOverlapped(Match m)
        {
            if (m.Chromosome != Chromosome || m.StartPoint > EndPoint
       || EndPoint < m.StartPoint)
                return false;
            var mStart = Math.Max(m.StartPoint, StartPoint);
            var mEnd = Math.Min(m.EndPoint, EndPoint);
            return mEnd >= mStart + 1000;
        }

        public void Save()
        {
            if (MeAnd23 == FamilyTreeDna)
            {
                MessageBox.Show("Match is not sourced\r\nNot saving", "Bad data");
                return;
            }
            foreach (Match match in Repository.MatchList)
            {
                if (this.Equals(match)) return;
            }
            if (!VerifyPeople())
            {
                MessageBox.Show("People not found", "Cannot save Match");
                return;
            }
            Repository.MatchList.Add(this);
        }
        public bool VerifyPeople()
        {
            if (Id0 != Id1)
            {
                var results = from person in Repository.People
                              where person.Id == Id0 || person.Id == Id1

                              select person;
                return results.Count() == 2;
            }
            else
            {
                return (from person in Repository.People
                        where person.Id == Id0

                        select person).Any();
            }
        }
        public string ChromosomeText
        {
            set
            {
                var no = 0;
                if (String.IsNullOrWhiteSpace(value))
                    Chromosome = -1;
                else if (int.TryParse(value, out no))
                    Chromosome = no;
                else if (value.Equals("X", StringComparison.InvariantCultureIgnoreCase))
                    Chromosome = 27;
                else if (value.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    Chromosome = 28;
                else
                    Chromosome = -1;
            }
            get
            {
                switch (Chromosome)
                {
                    case 0:
                        return "Overall";

                    case -1:
                        return "Other";
                    case 27:
                        return "X";
                    case 28:
                        return "Y";
                    default:
                        return Chromosome.ToString();
                }
            }
        }

        public override int GetHashCode()
        {
            int total = 0;
            foreach (var i in Id0.ToByteArray())
            {
                total += i;
            }
            foreach (var i in Id1.ToByteArray())
            {
                total += i;
            }
            total += this.SNPs;
            total += this.StartPoint;
            return total;
        }

        public Match(XmlNode node)
        {
            try
            {
                Id0 = Guid.Parse(node.Attributes["id0"].Value);
                Id1 = Guid.Parse(node.Attributes["id1"].Value);
                Chromosome = int.Parse(node.Attributes["chromosome"].Value);
                StartPoint = int.Parse(node.Attributes["startPoint"].Value);
                EndPoint = int.Parse(node.Attributes["endPoint"].Value);
                GeneticDistance = float.Parse(node.Attributes["geneticDistance"].Value);
                SNPs = int.Parse(node.Attributes["snps"].Value);
                if (node.Attributes["me"] != null)
                    MeAnd23 = bool.Parse(node.Attributes["me"].Value);
                if (node.Attributes["tree"] != null)
                    FamilyTreeDna = bool.Parse(node.Attributes["tree"].Value);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public static string ToCsvHeader()
        {
            return "Person0Name, Person0Name, Chromosome, StartPoint, EndPoint, GeneticDistance, SNPs";
        }

        private String person0Name = String.Empty;
        private String person1Name = String.Empty;
        public String Person0Name
        {
            get
            {
                if (!String.IsNullOrWhiteSpace(person0Name)) return person0Name;
                return person0Name = Repository.GetPersonName(Id0);
            }
        }
        public String Person1Name
        {

            get
            {
                if (!String.IsNullOrWhiteSpace(person1Name)) return person1Name;
                return person1Name = Repository.GetPersonName(Id1);
            }
        }
        public string ToCsv()
        {
            return String.Format("\"{0}\",\"{1}\",{2},{3},{4},{5},{6}",
                                new object[] { Person0Name, Person0Name, ChromosomeText, StartPoint, EndPoint, GeneticDistance, SNPs });
        }
        private string TreeNodeText()
        {
            return String.Format("{0} [{1}-{2}]@{3} Distance: {4}", new object[] { Chromosome, StartPoint, EndPoint, SNPs, GeneticDistance });
        }
        public void ToXmlNode(XmlNode pnode)
        {
            var dom = pnode.OwnerDocument;
            XmlElement node = dom.CreateElement("matchv2");
            XmlAttribute attr;
            node.Attributes.Append(attr = dom.CreateAttribute("id0"));
            attr.Value = Id0.ToString();
            node.Attributes.Append(attr = dom.CreateAttribute("id1"));
            attr.Value = Id1.ToString();
            node.Attributes.Append(attr = dom.CreateAttribute("chromosome"));
            attr.Value = Chromosome.ToString();
            node.Attributes.Append(attr = dom.CreateAttribute("startPoint"));
            attr.Value = StartPoint.ToString();
            node.Attributes.Append(attr = dom.CreateAttribute("endPoint"));
            attr.Value = EndPoint.ToString();
            node.Attributes.Append(attr = dom.CreateAttribute("geneticDistance"));
            attr.Value = GeneticDistance.ToString();
            node.Attributes.Append(attr = dom.CreateAttribute("snps"));
            attr.Value = SNPs.ToString();
            node.Attributes.Append(attr = dom.CreateAttribute("me"));
            attr.Value = MeAnd23.ToString();
            node.Attributes.Append(attr = dom.CreateAttribute("tree"));
            attr.Value = FamilyTreeDna.ToString();
            pnode.AppendChild(node);
        }
        public override bool Equals(object obj)
        {
            var other = (Match)obj;
            if (other == null) return false;
            if (other.MeAnd23 != MeAnd23) return false;
            if (other.FamilyTreeDna != FamilyTreeDna) return false;
            if (Chromosome != other.Chromosome
                || SNPs != other.SNPs
                || StartPoint != other.StartPoint
                || EndPoint != other.EndPoint
        )
                return false;
            if (Id0 != other.Id0 || Id1 != other.Id1)
                return false;
            return true;
        }


    }
}

