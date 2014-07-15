using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
namespace DnaTreeBuilder
{

    public class RepositoryOld
    {

        /// <summary>
        /// Person submitting
        /// </summary>
        public string OwnerEmail { get; set; }

        public Guid Id { get; private set; }
        public List<OldPerson> PeopleList = new List<OldPerson>();
        private List<string> idList = new List<string>();
        public string DataFolder { get; set; }
        public RepositoryOld()
        {
            Id = Guid.NewGuid();
            DataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "DnaTreeBuilder");
            try
            {
                if (!Directory.Exists(DataFolder))
                {
                    Directory.CreateDirectory(DataFolder);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("File permissions issues - you may need to run as an Administrator.\r\n"+exc.Message,
                                "Unexpected Problem");
            }
            dom.LoadXml("<dnaTreeMaker/>");
            FilePath = System.IO.Path.Combine(DataFolder, "DnaTreeMaker.dtb");
            if (File.Exists((FilePath)))
            {
                LoadFile(FilePath);

            }
        }
        public bool AreSiblings(OldPerson a, OldPerson b)
        {
            var cms= a.GetCm(b.Id);
            return cms > 1800 && cms < 3700;
        }
        public int StepsBetween(OldPerson a, OldPerson b)
        {
            if (a == null || b == null)
                return 0;
            return StepsBetween(a.Id, b.Id);
        }
        public int StepsBetween(string a, string b)
        {
            if (a == null || b == null)
                return 0;
            return FindPersonById(a).GetSteps(b);
        }
        public int StepsBetween(OldPerson a, string b)
        {
            if (a == null || b == null)
                return 0;
            return a.GetSteps(b);
        }
     
        public void Clear()
        {
            dom.LoadXml("<dnaTreeMaker/>");
            PeopleList.Clear();
            idList.Clear();
        }
        public string ToCsv()
        {
            var result = new StringBuilder();
          
            return result.ToString();
        }
        public void ClearZeroRelatives()
        {
            foreach(var person in PeopleList)
                person.ClearZeroMatches();
        }
        public string GetName(string id)
        {
            foreach(OldPerson p in PeopleList)
            {
                if (p.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase))
                    return p.Name;
            }
            return "Unknown";
        }
        public List<string> IdList { get { return idList; } }
        public void SaveAs(string path, IWin32Window from)
        {
            FilePath = path;
            Save(from);
        }
        public string FilePath { get; set; }
        private readonly XmlDocument dom = new XmlDocument();
        private void RebuildDom()
        {
            dom.LoadXml("<dnaTreeMaker />");
            XmlAttribute attr=dom.CreateAttribute("id");
            attr.Value = Id.ToString();

            dom.DocumentElement.Attributes.Append(attr);
            if (!string.IsNullOrWhiteSpace(OwnerEmail))
            {
                attr = dom.CreateAttribute("email");
                attr.Value = OwnerEmail;
            }
            foreach (OldPerson p in PeopleList)
            {
                dom.DocumentElement.AppendChild(p.GetNode(dom));
            }
        }
        public void ResetMatches()
        {
            foreach(var p in PeopleList)
            {
               
            }
        }
        public void SaveAs(IWin32Window from, string fileName)
        {
            Id = Guid.NewGuid();
            FilePath = fileName;
            Save(from);
        }
        public void Save(IWin32Window from)
        {
            RebuildDom();
            try
            {
                dom.Save(FilePath);
            }
            catch (Exception exc)
            {
                MessageBox.Show((IWin32Window)from, exc.Message + "\r\nYou do not have permission to save to:\r\n" + FilePath,
                                "Try a different location");
            }
        }
        /// <summary>
        /// Load a data file
        /// </summary>
        /// <param name="filePath"></param>
        public void LoadFile(string filePath)
        {
            Clear();
            FilePath = filePath;
            dom.Load(filePath);
            XmlAttribute attr = dom.DocumentElement.Attributes["id"];
            if(attr !=null)try
            {
                Id = Guid.Parse(attr.Value);
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message + "\r\n" + attr.Value);
                Id = Guid.NewGuid();
            }
             attr = dom.DocumentElement.Attributes["email"];
             if (attr != null)
                 OwnerEmail = attr.Value;
           
            FillPeopleList();
        }
        public bool IsMatchDone(string a, string b)
        {
            XmlNode node = dom.SelectSingleNode("//match[@id1='" + a + "' and @id2='" + b + "']"
                );
            return (node != null);
        }
        public int MatchCount { get { return dom.SelectNodes("//match").Count; } }
        public int Count { get { return dom.SelectNodes("//person[@id]").Count; } }
        public bool AddPerson(OldPerson person)
        {
            if (null == FindPersonById(person.Id))
            {
                PeopleList.Add(person);
            }
            var node = dom.SelectSingleNode("//person[@id='" + person.Id + "']");
            if (node == null)
            {
                if (!idList.Contains(person.Id))
                {
                    idList.Add(person.Id);

                }
                dom.DocumentElement.AppendChild(person.GetNode(dom));
                return true;
            }
            return false;
        }
        public OldPerson FindPersonById(string id)
        {
            foreach (OldPerson p in PeopleList)
            {
                if (p.Id.Equals(id)) return p;
            }
            return null;
        }
        public OldPerson FindPersonByName(string name)
        {
            foreach (OldPerson p in PeopleList)
            {
                if (p.Name.Equals(name)) return p;
            }
            return null;
        }
        public void XFillPeopleList()
        {
            PeopleList.Clear();
            idList.Clear();
            var nodes = dom.SelectNodes("//person[@id]");
            if (nodes != null)
                foreach (XmlNode node in nodes)
                {
                    var p = new OldPerson(node);
                    PeopleList.Add(p);
                    idList.Add(p.Id);
                }
        }
         public static int ConvertToSteps(float cm)
        {
            if (cm >= 2800) return 1;
            if (cm >= 1400) return 2;
            if (cm >= 700) return 3;
            if (cm >= 350) return 4;
            if (cm >= 175) return 5;
            if (cm >= 87) return 6;
            if (cm >= 43) return 7;
            if (cm >= 22) return 8;
            if (cm >= 11) return 9;
            if (cm >= 5) return 10;
            if (cm > 0) return 11;
            return 100;
        }

    }
}
