using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using Telerik.WinControls.UI;

namespace DnaTreeBuilder.Instance
{
    class Repository
    {
        public static readonly List<Personv2> People = new List<Personv2>();
        public static readonly List<Match> MatchList = new List<Match>();
        public const string Copyright = "Dna Family Tree Builder  (c) 2014 Lassesen Consulting, LLC, http://www.lassesen.com";
        public const string AppName = "DNA Family Tree Maker for 23andMe.com and FamilyTreeDna, Beta 2.5";
        public static void Clear()
        {
            People.Clear();
            MatchList.Clear();
        }
        public static Guid Id { get; set; }
        public static string TreeName { get; set; }
        public static string Email { get; set; }
        public static string Telephone { get; set; }
        public static IEnumerable<FamilyMatch> FamilyData = null;
        public static void BuildFamilyData()
        {
            FamilyData = from p in MatchList
                         where p.GeneticDistance > 0
                         group p by p.Key into g
                         select new FamilyMatch { Key = g.Key, GeneticDistance = g.Sum(p => p.GeneticDistance) };
        }
        public static String GetPersonName(Guid id)
        {
            var found = GetPerson(id);
            if (found != null) return found.Name;
                return "Unknown Person";
        }
                public static Personv2 GetPerson(Guid id)
        {
            foreach (Personv2 personv2 in People)
            {
                if (personv2.Id == id) return personv2;
            }
            return null;
        }

        public static IEnumerable<Personv2> DnaPeople
        {
            get
            {
                return
                    from person in People
                    where !String.IsNullOrWhiteSpace(person.MeId)
                    orderby person.Name
                    select person;
            }
        }
        public static IEnumerable<Personv2> People23AndMe
        {
            get
            {
                return
                    from person in People
                    where !String.IsNullOrWhiteSpace(person.MeId)
                    orderby person.Name
                    select person;
            }
        }
        public static IEnumerable<Personv2> PeopleFamilyTreeInternal
        {
            get
            {
                return
                    from person in People
                    where !String.IsNullOrWhiteSpace(person.FamilyTreeInternalId)
                    orderby person.Name
                    select person;
            }
        }

        public static IEnumerable<Personv2> PeopleFamilyTreeDna
        {
            get
            {
                return
                    from person in People
                    where !String.IsNullOrWhiteSpace(person.FamilyTreeId)
                    orderby person.Name
                    select person;
            }
        }
        private static XmlDocument GetDom(IEnumerable<Match> matches)
        {
            var dom = new XmlDocument();
            dom.LoadXml("<dnafamilytree/>");
            var attr = dom.CreateAttribute("Shared");
            attr.Value = DateTime.Now.ToString();
            dom.DocumentElement.Attributes.SetNamedItem(attr);
            dom.DocumentElement.Attributes.SetNamedItem(attr = dom.CreateAttribute("id"));
            attr.Value = Id.ToString();
            dom.DocumentElement.Attributes.SetNamedItem(attr = dom.CreateAttribute("treename"));
            attr.Value = TreeName;
            dom.DocumentElement.Attributes.SetNamedItem(attr = dom.CreateAttribute("telephone"));
            attr.Value = Telephone;
            dom.DocumentElement.Attributes.SetNamedItem(attr = dom.CreateAttribute("email"));
            attr.Value = Email;
            foreach (Personv2 personv2 in People)
            {
                personv2.ToXmlNode(dom.DocumentElement);
            }
            foreach (Match match in matches)
            {
                match.ToXmlNode(dom.DocumentElement);
            }
            return dom;
        }
        public static string SharingXml
        {
            get
            {
                var dom = GetDom(PositiveMatchList());
                return dom.OuterXml;
            }
        }
        public static IEnumerable<Personv2> PeopleInNameOrder
        {
            get
            {
                return
                    from person in People
                    orderby person.Name
                    select person;
            }
        }


        public static IEnumerable<Match> PositiveMatchList()
        {
            return from match in MatchList
                   where match.GeneticDistance > 0
                   && match.Id0 != match.Id1
                   && match.Chromosome >= 0
                   select match;
        }

        public static IEnumerable<Match> GetChromosomes(Guid id0, Guid id1)
        {
            return from match in MatchList
                   where ((match.Id0 == id0 && match.Id1 == id1)
                   || (match.Id0 == id1 && match.Id1 == id0))
                   && match.GeneticDistance > 0
                   && match.Id0 != match.Id1
                   select match;
        }
        public static IEnumerable<Match> GetChromosomes(Guid id0)
        {
            return from match in MatchList
                   where (match.Id0 == id0
                   || match.Id1 == id0)
                   && match.Id0 != match.Id1
                   && match.GeneticDistance > 0
                   select match;
        }
        public static IEnumerable<Match> GetChromosomes()
        {
            return from match in MatchList
                   where match.Id0 != match.Id1
                   && match.GeneticDistance > 0
                   select match;
        }
        public static IEnumerable<Match> GetActualChromosomes()
        {
            return from match in MatchList
                   where match.Id0 != match.Id1
                   && match.GeneticDistance > 0
                   && match.Chromosome > 0
                   select match;
        }
        public static IEnumerable<Personv2> NotMatched23AndMePeople(Personv2 p0)
        {
            return
                   from person in People
                   where person.Is23AndMe
                   && !Match23AndMe(p0, person)
                   select person;
        }
        public static IEnumerable<Match> DnaMatch
        {
            get
            {
                return
                    from match in MatchList
                    where match.MeAnd23
                    select match;
            }
        }

        /// <summary>
        /// Returns true if match has been done.
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static bool Match23AndMe(Personv2 p0, Personv2 p1)
        {
            var result = from match in MatchList
                         where match.MeAnd23
                         && match.Id0 == p0.Id
                         && match.Id1 == p1.Id
                         select match;
            return result.Any();
        }
        public static int Count { get { return People.Count + MatchList.Count; } }
        /// <summary>
        /// If we don't have a GUID, we search by keys and last by name.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Personv2 FindOrCreatePerson(string id = null, string name = null)
        {

            if (String.IsNullOrWhiteSpace(id) && String.IsNullOrWhiteSpace(name))
                return null;
            if (String.IsNullOrWhiteSpace(name))
                name = Personv2.NormName(name);
            if (!String.IsNullOrWhiteSpace(id))
            {
                id = Personv2.NormName(id);
                foreach (var person in PeopleInNameOrder)
                {
                    if (!String.IsNullOrWhiteSpace(person.MeId) &&
                        person.MeId.Equals(id, StringComparison.CurrentCultureIgnoreCase))
                        return person;
                    if (!String.IsNullOrWhiteSpace(person.FamilyTreeId) &&
                        person.FamilyTreeId.Equals(id, StringComparison.CurrentCultureIgnoreCase))
                        return person;
                }
                if (!String.IsNullOrWhiteSpace(name))
                {
                    name = id.Trim().Replace("  ", " ");
                    foreach (var person in PeopleInNameOrder)
                        if (!String.IsNullOrWhiteSpace(person.Name) &&
                        person.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                            return person;
                }
            }
            var resultNew = new Personv2 { Name = name };
            return resultNew;
        }
        public static Personv2 FindPerson(string meId = null, string name = null)
        {
            return FindPerson(Guid.Empty, meId, Personv2.NormName(name));
        }
        public static Match FindOrCreateMatch(Guid id0, Guid id1, int chromosome = 0, int startPoint = 0, int snps = 0)
        {
            foreach (Match match in MatchList)
            {
                if (match.Id0 == id0 && match.Id1 == id1 && match.Chromosome == chromosome
                    && match.StartPoint == startPoint && match.SNPs == snps
                    )
                    return match;

            }
            return new Match { Id0 = id0, Id1 = id1 };
        }

        public static Match FindOrCreateMatch(Guid id0, Guid id1, float geneticDistance = 0)
        {
            foreach (Match match in MatchList)
            {
                if (match.Id0 == id0 && match.Id1 == id1 && match.GeneticDistance == geneticDistance && match.Chromosome == 0)
                    return match;
            }
            return new Match { Id0 = id0, Id1 = id1, GeneticDistance = geneticDistance, Chromosome = 0 };
        }

        public static string DataFolder { get; set; }
        public static string DataFileName { get; set; }
        public Repository()
        {

            TreeName = string.Empty;
            Email = string.Empty;
            Telephone = string.Empty;
            Id = Guid.NewGuid();
            DataFileName = "dnafamilytree.dft";

            DataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                                      "DnaTreeBuilder");
            try
            {
                if (!Directory.Exists(DataFolder))
                {
                    Directory.CreateDirectory(DataFolder);
                }
                DataFileName = Path.Combine(DataFolder, DataFileName);
                Load(DataFileName);
            }
            catch (Exception exc)
            {
                MessageBox.Show("File permissions issues - you may need to run as an Administrator\r\n" + exc.Message,
                                "Unexpected Problem");
            }
        }


        public static void Load(string dataFileName)
        {
            if (File.Exists(dataFileName))
                try
                {
                    var dom = new XmlDocument();
                    dom.Load(dataFileName);
                    People.Clear();
                    if (dom.DocumentElement.Attributes["treename"] != null)
                        TreeName = dom.DocumentElement.Attributes["treename"].Value;
                    if (dom.DocumentElement.Attributes["telephone"] != null)
                        Telephone = dom.DocumentElement.Attributes["telephone"].Value;
                    if (dom.DocumentElement.Attributes["email"] != null)
                        Email = dom.DocumentElement.Attributes["email"].Value;
                    if (dom.DocumentElement.Attributes["id"] != null)
                        Id = Guid.Parse(dom.DocumentElement.Attributes["id"].Value);

                    var people = dom.SelectNodes("//personv2");
                    foreach (XmlNode node in people)
                    {
                        People.Add(new Personv2(node));
                    }
                    MatchList.Clear();

                    var matched = dom.SelectNodes("//matchv2");
                    foreach (XmlNode node in matched)
                    {
                        MatchList.Add(new Match(node));
                    }
                    DataFileName = dataFileName;
                    MessageBox.Show(Summary, "Loaded " + dataFileName);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Unable to load");
                }
        }
        /// <summary>
        /// Write data to file
        /// </summary>
        public static void Write(string fileName = null)
        {
            try
            {
                var dom = GetDom(MatchList);
                try
                {
                    if (fileName == null)
                    {
                        dom.Save(DataFileName);
                    }
                    else
                    {
                        dom.Save(fileName);
                        DataFileName = fileName;
                    }
                }
                catch (Exception exc)
                {
                    var errorFile = fileName ?? DataFileName;
                    MessageBox.Show(exc.Message, "Problem saving to " + errorFile);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Unexpected Error");
            }
        }
        public static string Summary
        {
            get
            {
                var active = from match in MatchList
                             where match.GeneticDistance > 0.0
                             select match;
                return People.Count + " persons, " + MatchList.Count + " Dna Comparisons, " + active.Count() + " postive chromosome matches";
            }
        }
        public static Personv2 FindPerson(Guid guid, string meId = null, string name = null)
        {
            if (guid != Guid.Empty)
            {
                Personv2 result =
                    (from person in People
                     where person.Id == guid
                     select person).FirstOrDefault();
                if (result != null)
                    return result;
                foreach (var person in People)
                {
                    if (person.Id == guid) return person;
                }
            }
            if (!String.IsNullOrWhiteSpace(meId))
            {
                Personv2 result =
                    (from person in People
                     where person.MeId == meId
                     select person).FirstOrDefault();
                if (result != null)
                    return result;
            }

            if (!String.IsNullOrWhiteSpace(name))
            {
                Personv2 result =
                    (from person in People
                     where person.Name == name
                     select person).FirstOrDefault();
                if (result != null)
                    return result;
            }
            return null;
        }
        public static void FillComboBox(ComboBox ctl)
        {
            ctl.Items.Clear();
            ctl.Sorted = true;
            foreach (var person in DnaPeople)
            {
                ctl.Items.Add(person);
            }
            if (ctl.Items.Count > 0)
                ctl.SelectedIndex = 0;
        }
        public static void FillTreeView(RadTreeNode rootNode)
        {
            if (rootNode == null) return;
            rootNode.Nodes.Clear();
            foreach (Personv2 person in PeopleInNameOrder)
            {
                var node = person.TreeNode;
                node.ToolTipText = "Double Click to see details on this person";
                rootNode.Nodes.Add(node);
            }
           
        }
        public static string ToCsv(CsvExport signficant = CsvExport.All)
        {
            var result = new StringBuilder();
            result.AppendLine(Match.ToCsvHeader());
            switch (signficant)
            {
                case CsvExport.All:
                    foreach (var match in MatchList)
                    {
                        result.AppendLine(match.ToCsv());
                    }
                    break;
                case CsvExport.Significant:
                    foreach (var match in GetChromosomes())
                    {
                        result.AppendLine(match.ToCsv());
                    }

                    break;
                case CsvExport.Chromosomes:
                    foreach (var match in GetActualChromosomes())
                    {
                        result.AppendLine(match.ToCsv());
                    }
                    break;

            }
            result.AppendLine(Copyright);
            return result.ToString();
        }
        public static string GetMatrix(ToolStripProgressBar toolStripProgressBar1)
        {
            var result = new StringBuilder();
            int idx = 1;
            foreach (var p in Repository.People)
                p.IndexNo = idx++;
            var data = new String[idx,idx];
            foreach (var p in Repository.People)
            {
                toolStripProgressBar1.Value = p.IndexNo;
                data[p.IndexNo, 0] = p.ToString();
                foreach (var q in Repository.People)
                {
                    Application.DoEvents();
                      var txt = "?";
                    data[0,q.IndexNo] = q.ToString();
                    var matches = from m in Repository.MatchList
                                  where m.Id0 == p.Id
                                        && m.Id1 == q.Id
                                  select m;
                    if (matches.Any())
                    {
                        var degree = (from m in matches
                                      group m by m.Key
                                      into g
                                      select g.Sum(g1 => g1.GeneticDistance)).Max();
                        if (degree > 0 && degree <= 1)
                            txt = "X";
                        else if (degree == 0)
                            txt = "-none-";
                        else
                            txt = degree.ToString();
                    }
                    else
                    {
                        txt = "no info";
                    }
                    data[p.IndexNo, q.IndexNo] = txt;
                }
            }
            for (var i = 0; i < idx;i++ )
            {
                for (var j = 0; j < idx; j++)
                {
                    result.Append(data[i, j]);
                    result.Append(",");
                }
                result.AppendLine("");
            }
            toolStripProgressBar1.Visible = false;
            return result.ToString();
        }
    }
}
