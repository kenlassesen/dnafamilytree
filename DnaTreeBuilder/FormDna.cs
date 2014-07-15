using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DnaTreeBuilder.Instance;
using mshtml;
using Telerik.WinControls.UI;

namespace DnaTreeBuilder
{
    public partial class FormDna : Telerik.WinControls.UI.RadForm
    {
        private bool inLoad = true;
        private RadTreeNode _peopleroot;
        public FormDna()
        {
            InitializeComponent();
            Login();
            treeView1.Nodes.Add(_peopleroot = new RadTreeNode("People"));
            webBrowser1.DocumentCompleted += Wb_DocumentCompleted;
            toolStripStatusLabel1.Text = "Please login your account";
            timerRefresh.Enabled = true;
            ShowWb();
            if (DateTime.Now.Year > 2014)
            {
                MessageBox.Show(this, "This Beta Version has expired.\r\n", "Please Download a newer version");
            }
            toolStripStatusLabel1.Text = Repository.Summary;
        }
        private void RefreshDisplay()
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(_peopleroot = new RadTreeNode("People"));

            Repository.FillTreeView(_peopleroot);
            _peopleroot.Expanded = true;
            Repository.FillComboBox(comboBoxPersons);
            treeView1.Visible = true;
        }
        private bool _browserDone = true;
        void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            _browserDone = true;
            if (e.Url.AbsolutePath.ToLower().Equals("you"))
            {
                toolStripStatusLabel1.Text = "Select your next action on the 23AndMe menu.";
                getSharedDNAIdsToolStripMenuItem.Enabled = true;
                processSharedIdsToolStripMenuItem.Enabled = true;
            }
            else if (e.Url.AbsolutePath.ToLower().Contains("/user/login"))
            {
                toolStripStatusLabel1.Text = "Login to 23AndMe.";

            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isRunning = true;
            Login();
            ShowWb();
        }
        private void Login()
        {
            var url = "https://www.23andme.com/user/signin/";
            GoToUrl(url);
        }
        private void GoToUrl(string url)
        {
            if (inLoad) return;
            ShowWb();
            webBrowser1.Stop();
            _browserDone = false;
            webBrowser1.Navigate(url);
            // Allows us to abort
            isRunning = true;
            var loops = 0;
            while (webBrowser1.IsBusy || loops < 5)
            {
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
                if (webBrowser1.IsBusy)
                {
                    loops = 0;
                }
                else
                {
                    loops++;
                }
                if (String.IsNullOrEmpty(webBrowser1.Url.AbsoluteUri))
                    loops = 0;
                else if (!url.Equals(webBrowser1.Url.AbsoluteUri, StringComparison.InvariantCultureIgnoreCase))
                {
                    loops = 0;
                }

                if (!isRunning) return;
            }
            Console.WriteLine("Ready");
        }
        private void getSharedDNAIdsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWb();
            Get23AndMePeople();
        }
        private void Get23AndMePeople()
        {
            ShowWb();
            isRunning = true;
            webBrowser1.Stop();
            Application.DoEvents();
            toolStripStatusLabel1.Text = "Starting  Data Capture";
            Application.DoEvents();
            _browserDone = false;
            var url = "https://www.23andme.com/you/labs/multi_ibd/";
            GoToUrl(url);
            var preCount = Repository.Count;
            if (webBrowser1.Document == null)
            {
                MessageBox.Show(this, "Please check your connection and try again",
                                "Error: Internet Connection Failed");
                return;
            }
            try
            {
                if (!isRunning) return;
                var dom = webBrowser1.Document.DomDocument as IHTMLDocument2;

                List<mshtml.IHTMLLIElement> allLi = dom
                    .all.OfType<mshtml.IHTMLLIElement>()
                    .ToList();

                foreach (IHTMLLIElement li in allLi)
                {
                    var el = (IHTMLElement)li;
                    if (el.outerHTML.Contains("data-first"))
                    {
                        var person = new Personv2(el.outerHTML);
                        var checkPerson = Repository.FindPerson(person.MeId);
                        if (checkPerson == null)
                            person.Save();
                    }
                }
                for (var i = 0; i < 100000; i++)
                {
                    Application.DoEvents();
                    if (!isRunning) return;
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Unexpected Error");
            }
            var delta = Repository.Count - preCount;
            if (delta > 0)
            {
                Repository.Write();
                timerRefresh.Enabled = true;
                MessageBox.Show(this, Repository.Summary, delta + " people added");
            }
            ShowPeople();
        }
        private string metaUrl = "https://www.23andme.com/you/labs/multi_ibd/table/?default_id_1={0}&default_id_2={1}&default_id_3={2}&default_id_4={3}&default_id_5={4}&default_id_6={5}";


        public void Single23andMeNode(Personv2 p0)
        {
            var data = new String[6];
            data[0] = p0.MeId;
            for (var p = 1; p < data.Length; p++)
            {
                data[p] = "";
            }
            var i = 1;
            foreach (Personv2 p1 in Repository.NotMatched23AndMePeople(p0))
            {

                if (!Repository.Match23AndMe(p0, p1))
                {
                    data[i++] = p1.MeId;
                }
                if (i > 5)
                {
                    GetNumbers(p0, String.Format(metaUrl, data), data);
                    toolStripStatusLabel1.Text = Repository.Summary;
                    for (var p = 1; p < data.Length; p++)
                    {
                        data[p] = "";
                    }
                    i = 1;
                }
                if (!isRunning) return;
            }
            var lasti = i;
            while (i < 6)
            {
                data[i++] = "";
            }
            if (lasti > 1)
            {
                GetNumbers(p0, String.Format(metaUrl, data), data);
                toolStripStatusLabel1.Text = Repository.Summary;
            }

        }
        private void GetNumbers(Personv2 p0, string url, string[] idList)
        {
            try
            {
                Console.WriteLine(url);
                webBrowser1.Stop();
                _browserDone = false;
                webBrowser1.AllowNavigation = true;
                webBrowser1.Navigate(url);
                while (webBrowser1.IsBusy || !_browserDone)
                {
                    System.Threading.Thread.Sleep(100);
                    Application.DoEvents();
                    if (!isRunning) return;
                }
                var waiting = true;
                while (waiting)
                {
                    var dom = webBrowser1.Document.DomDocument as IHTMLDocument2;
                    if (!isRunning) return;
                    List<mshtml.IHTMLTable> allLi = dom
                        .all.OfType<mshtml.IHTMLTable>()
                        .ToList();
                    if (allLi.Count > 0)
                    {
                        foreach (IHTMLTable li in allLi)
                        {
                            var el = (IHTMLElement)li;
                            ParseTable(p0, el.outerHTML);
                        }
                        waiting = false;
                    }
                    else
                    {
                        for (var i = 0; i < 100000; i++)
                        {
                            Application.DoEvents();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Unexpected Error");
            }
            // For items with no data, create a NoMatch Record
            foreach (string meId in idList)
            {
                if (!string.IsNullOrWhiteSpace(meId))
                {
                    var p1 = Repository.FindPerson(meId);
                    if (p1 != null)
                    {
                        if (!Repository.Match23AndMe(p0, p1))
                        {
                            var dummy = new Match { Id0 = p0.Id, Id1 = p1.Id, Chromosome = -1, GeneticDistance = 0, MeAnd23 = true };
                            dummy.Save();
                        }
                    }
                }
            }
        }

        private void ParseTable(Personv2 p0, string table)
        {
            if (!table.Contains("Chromosome") || !table.Contains("Genetic distance"))
                return;
            string[] nameSep = { " vs. " };
            string[] cmSep = { " cM" };
            table = table.Replace("&nbsp;", "");
            var dom = new System.Xml.XmlDocument();
            try
            {
                dom.LoadXml(table);
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message + "\r\n" + table, "Parsing HTML error");
            }
            var rows = dom.SelectNodes("//tr");
            if (rows != null)
                foreach (XmlNode row in rows)
                {

                    if (row.ChildNodes.Count == 6 && !String.IsNullOrWhiteSpace(row.ChildNodes[0].InnerText))
                    {
                        var names = row.ChildNodes[0].InnerText.Split(nameSep, StringSplitOptions.RemoveEmptyEntries);
                        if (names.Length > 1)
                            try
                            {
                                var name = names[1].Trim();
                                var p1 = Repository.FindOrCreatePerson(name, name);
                                if (p1 == null)
                                {
                                    MessageBox.Show(this, name + " was not found -- please refetch you people",
                                                    "23AndMe.com updated sharing");
                                }
                                var chrom = row.ChildNodes[1].InnerText;
                                var startAt = int.Parse(row.ChildNodes[2].InnerText);
                                var endAt = int.Parse(row.ChildNodes[3].InnerText);
                                var cM =
                                    float.Parse(
                                        row.ChildNodes[4].InnerText.Split(cmSep, StringSplitOptions.RemoveEmptyEntries)[0]);
                                var snps = int.Parse(row.ChildNodes[5].InnerText);
                                var match = new Match
                                                {
                                                    ChromosomeText = chrom,
                                                    EndPoint = endAt,
                                                    StartPoint = startAt,
                                                    GeneticDistance = cM,
                                                    Id1 = p1.Id,
                                                    Id0 = p0.Id,
                                                    SNPs = snps,
                                                    MeAnd23 = true
                                                };

                                match.Save();
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show(this, exc.Message, "Unexpected Error");
                            }
                    }
                }
            Repository.Write();

        }
        private void processSharedIdsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isRunning = true;
            var start = Repository.Count;
            foreach (Personv2 person in Repository.DnaPeople)
            {
                ShowWb();
                Single23andMeNode(person);
            }
            var diff = Repository.Count - start;
            if (diff > 0)
            {
                timerRefresh.Enabled = true;
                MessageBox.Show(this, Repository.Summary, diff + " matches added");
            }
        }

        private void browserProcessingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWb();
        }
        void ShowWb()
        {
            webBrowser1.Visible = true;
            treeView1.Visible = false;

        }

        private void peopleTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerRefresh.Enabled = true;
            ShowPeople();
        }

        void ShowPeople()
        {
            webBrowser1.Visible = false;
            treeView1.Visible = true;
        }

        private void ancestorTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowAncestors();
        }
        void ShowAncestors()
        {

            webBrowser1.Visible = false;
            treeView1.Visible = true;
        }

        private bool isRunning = true;
        private void button1_Click(object sender, EventArgs e)
        {
            isRunning = false;
            toolStripStatusLabel1.Text = "Stopping";
            Repository.Write();
            toolStripStatusLabel1.Text = "Stopped. " + Repository.Summary;
        }

        private void saveDataToDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Repository.Write();
                MessageBox.Show(this, "Data saved to: " + Repository.DataFileName, "Successful Save");
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Unexpected Error");
            }
        }

        private void peopleToCSVExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogCsv.Title = "Save data to CSV file";
            saveFileDialogCsv.Filter = "CSV or Excel(*.csv)|*.csv";
            saveFileDialogCsv.CheckPathExists = true;
            saveFileDialogCsv.DefaultExt = "csv";
            saveFileDialogCsv.AddExtension = true;
            saveFileDialogCsv.OverwritePrompt = true;
            saveFileDialogCsv.InitialDirectory = DataFolder;
            if (saveFileDialogCsv.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(saveFileDialogCsv.FileName, Repository.ToCsv(),Encoding.UTF8);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, exc.Message, "Unexpected Error");
                }
            }
        }

        private void loadSavedFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogRepro.Title = "Load a DNA Family Tree Builder File";
            openFileDialogRepro.Filter = "DNA Family Tree Builder File v2|*.dft";
            openFileDialogRepro.FileName = "*.dft";
            openFileDialogRepro.InitialDirectory = DataFolder;
            openFileDialogRepro.CheckFileExists = true;
            openFileDialogRepro.InitialDirectory = DataFolder;
            if (openFileDialogRepro.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                try
                {
                    Repository.Write();
                    Repository.Load(openFileDialogRepro.FileName);
                    timerRefresh.Enabled = true;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, exc.Message, "Load Failed");
                }
        }

        private void saveDataAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveFileDialogAsRepro.Title = "Save a DNA Family Tree Builder File";
            saveFileDialogAsRepro.Filter = "DNA Family Tree Builder File (*.dft)|*.dft";
            saveFileDialogAsRepro.FileName = "*.dft";
            saveFileDialogAsRepro.CheckFileExists = false;
            saveFileDialogAsRepro.OverwritePrompt = true;
            saveFileDialogAsRepro.InitialDirectory = DataFolder;
            if (saveFileDialogAsRepro.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                try
                {
                    Repository.Write(saveFileDialogAsRepro.FileName);
                    MessageBox.Show(this, Repository.Summary, "Save Successful");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, exc.Message, "Save Failed");
                }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveFileDialogAsRepro.Title = "Create a DNA Family Tree Builder File";
            saveFileDialogAsRepro.Filter = "DNA Family Tree Builder File(*.dft)|*.dft";
            saveFileDialogAsRepro.FileName = "*.dft";

            saveFileDialogAsRepro.CheckFileExists = false;
            saveFileDialogAsRepro.OverwritePrompt = true;
            saveFileDialogAsRepro.InitialDirectory = DataFolder;
            if (saveFileDialogAsRepro.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                try
                {
                    Repository.Write();
                    Repository.Clear();
                    Repository.DataFileName = saveFileDialogAsRepro.FileName;
                    Repository.Write();
                    _peopleroot.Nodes.Clear();
                    comboBoxPersons.Items.Clear();
                    timerRefresh.Enabled = true;
                    MessageBox.Show(this, Repository.Summary, "Save Successful");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, exc.Message, "Save Failed");
                }
        }

        private string DataFolder { get { return Repository.DataFolder; } }
        private void Form1_Load(object sender, EventArgs e)
        {
            // make sure everything is initialized
            var init = new Repository();
            if (Repository.Count > 0)
            {
                ShowPeople();
                treeView1.ExpandAll();
            }
            inLoad = false;
            Text = Repository.AppName;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ab = new AboutBox1();
            ab.ShowDialog(this);

        }

        private void treeViewToCSVExcelSignificantDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogCsv.Title = "Save data to CSV file";
            saveFileDialogCsv.Filter = "CSV or Excel|*.csv";
            saveFileDialogCsv.CheckPathExists = true;
            saveFileDialogCsv.DefaultExt = "csv";
            saveFileDialogCsv.AddExtension = true;
            saveFileDialogCsv.OverwritePrompt = true;
            saveFileDialogCsv.InitialDirectory = DataFolder;
            if (saveFileDialogCsv.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(saveFileDialogCsv.FileName, Repository.ToCsv(CsvExport.Significant),Encoding.UTF8);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, exc.Message, "Unexpected Error");
                }
            }
        }

        private void constructFamiliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var builderForm = new FormFamilyBuilder(_peopleroot.Nodes);
            builderForm.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Do23AndMePerson();
            ShowAncestors();
        }
        private void Do23AndMePerson()
        {

            if (comboBoxPersons.SelectedIndex > -1)
            {
                var person = (Personv2)comboBoxPersons.SelectedItem;
                Single23andMeNode(person);
            }
        }

        private void compareDNAForSelectedPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWb();
            Do23AndMePerson();
            timerRefresh.Enabled = true;
            ShowAncestors();
        }

        private void compareDifferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] sep = { '@' };
            var result = new StringBuilder();
            var cnt = 0;
            foreach (RadTreeNode p in _peopleroot.Nodes)
            {
                foreach (RadTreeNode matchPerson in p.Nodes)
                {
                    var parts = matchPerson.Name.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > 1)
                    {
                        var matchkey = parts[1] + "@" + parts[0];
                        var matches = treeView1.FindNodes(matchkey);
                        if (matches.Length == 1)
                        {
                            cnt++;

                            var match1 = (float)(matchPerson.Tag ?? 0F);
                            var match2 = (float)(matches[0].Tag ?? 0F);
                            if (match1 != match2)
                                result.AppendLine(p.Text + " to " + matchPerson.Text + " differs: " + match1 + " <> " + match2);
                        }
                        else if (matches.Length > 1)
                        {

                        }
                    }
                }

            }
            if (result.Length == 0)
            {
                cnt = cnt / 2;
                MessageBox.Show(this, "No differences Detected", cnt + " comparisons done");
            }
            else
            {
                var reportFile = Path.Combine(Repository.DataFolder,
                                              "Differences.txt");
                File.WriteAllText(reportFile, result.ToString(),Encoding.UTF8);
                string targetDir = string.Format(Repository.DataFolder);
                var p = new Process();
                p.StartInfo.WorkingDirectory = targetDir;
                p.StartInfo.FileName = "Notepad";

                p.StartInfo.Arguments = reportFile;
                p.StartInfo.CreateNoWindow = false;
                p.Start();

            }

        }

        private void Import_HelpRequest(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start("http://dnafamilytree.wordpress.com/software-dna-family-tree-builder/alpha-release-2/importing-family-tree-dna-files/");
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = Repository.Summary;
            timerRefresh.Enabled = false;
            RefreshDisplay();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, RadTreeViewEventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node != null && node.Tag != null)
            {
                var personTest = node.Tag as Personv2;
                if (personTest != null)
                {
                    var frm = new FormPerson(personTest);
                    frm.Show();
                }
                else
                {
                    var guidTest = (System.Guid)node.Tag;
                    var p0 = (Personv2)node.Parent.Tag;
                    var p1 = Repository.FindPerson(guidTest);
                    var frm = new FormMatch(p0, p1);
                    frm.Show();
                }
            }
        }

        private void allMatchToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogCsv.Title = "Save data to CSV file";
            saveFileDialogCsv.Filter = "CSV or Excel|*.csv";
            saveFileDialogCsv.CheckPathExists = true;
            saveFileDialogCsv.DefaultExt = "csv";
            saveFileDialogCsv.AddExtension = true;
            saveFileDialogCsv.OverwritePrompt = true;
            saveFileDialogCsv.InitialDirectory = DataFolder;
            saveFileDialogCsv.FileName = "AllMatchData.csv";
            if (saveFileDialogCsv.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(saveFileDialogCsv.FileName, Repository.ToCsv(CsvExport.All),Encoding.UTF8);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, exc.Message, "Unexpected Error");
                }
            }

        }

        private void familyFinderFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogRepro.Title = "Import a Family Finder (FamilyTreeDna) File";
            openFileDialogRepro.Filter = "Family Finder Files |*_*.csv|Family Finder Matches Export|*_Family_Finder_Matches_*.csv|Chromosome Browser Export|_chromosome_browser_results*.csv|Advanced Matching|*-advanced-matching_*.csv";
            openFileDialogRepro.FileName = String.Empty;
            openFileDialogRepro.InitialDirectory = DataFolder;
            openFileDialogRepro.ShowHelp = true;
            openFileDialogRepro.HelpRequest += Import_HelpRequest;
            openFileDialogRepro.CheckFileExists = true;
            openFileDialogRepro.InitialDirectory = DataFolder;
            if (openFileDialogRepro.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                try
                {
                    var cnt = Repository.Count;
                    var import = new FamilyFinderImport(openFileDialogRepro.FileName);
                    Repository.Write();
                    var diff = Repository.Count - cnt;
                    timerRefresh.Enabled = true;
                    MessageBox.Show(this, diff + " new records added", "Import Completed");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, exc.Message, "Load Failed");
                }

        }

        private void dNAFamilyTreeVersion1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogRepro.Title = "Import Version 1 Dna Family Tree File";
            openFileDialogRepro.Filter = "Dna Family Tree Database v1|*.dtb";
            openFileDialogRepro.FileName = String.Empty;
            openFileDialogRepro.InitialDirectory = DataFolder;
            openFileDialogRepro.ShowHelp = false;
            openFileDialogRepro.CheckFileExists = true;
            openFileDialogRepro.InitialDirectory = DataFolder;
            if (openFileDialogRepro.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                try
                {
                    var cnt = Repository.Count;
                    var import = new Version1Import(openFileDialogRepro.FileName);
                    var diff = Repository.Count - cnt;
                    timerRefresh.Enabled = true;
                    Repository.Write();
                    MessageBox.Show(this, diff + " new records added", "Import Completed");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, exc.Message, "Load Failed");
                }
        }

        private void chromosomeMatchesToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogCsv.Title = "Save data to CSV file";
            saveFileDialogCsv.Filter = "CSV or Excel|*.csv";
            saveFileDialogCsv.CheckPathExists = true;
            saveFileDialogCsv.DefaultExt = "csv";
            saveFileDialogCsv.AddExtension = true;
            saveFileDialogCsv.OverwritePrompt = true;
            saveFileDialogCsv.InitialDirectory = DataFolder;
            saveFileDialogCsv.FileName = "Chromosomes.csv";
            if (saveFileDialogCsv.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(saveFileDialogCsv.FileName, Repository.ToCsv(CsvExport.Chromosomes),Encoding.UTF8);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, exc.Message, "Unexpected Error");
                }
            }
        }

        private void significantMatchesToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogCsv.Title = "Save data to CSV file";
            saveFileDialogCsv.Filter = "CSV or Excel|*.csv";
            saveFileDialogCsv.CheckPathExists = true;
            saveFileDialogCsv.DefaultExt = "csv";
            saveFileDialogCsv.AddExtension = true;
            saveFileDialogCsv.OverwritePrompt = true;
            saveFileDialogCsv.InitialDirectory = DataFolder;
            saveFileDialogCsv.FileName = "Significant.csv";
            if (saveFileDialogCsv.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    System.IO.File.WriteAllText(saveFileDialogCsv.FileName, Repository.ToCsv(CsvExport.Significant),Encoding.UTF8);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(this, exc.Message, "Unexpected Error");
                }
            }
        }

        private void familyFinderMatchesURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var url = "https://my.familytreedna.com/family-finder/matches.aspx";
            GoToUrl(url);
            MessageBox.Show(this, "Click [CSV]\r\nThen Import", "Instructions");
        }

        private void chromosomeBroswerUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var url = "https://my.familytreedna.com/family-finder/chromosome-browser.aspx";
            GoToUrl(url);
            MessageBox.Show(this, "Click Dowload All\r\nThen Import", "Instructions");
        }

        private void advanceMatchesUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var url = "https://my.familytreedna.com/advanced-matches.aspx";
            GoToUrl(url);
            MessageBox.Show(this, "Click Run Report\r\nAt bottom of page, click [CSV]\r\nThen Import", "Instructions");
        }

        private void loginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var url = "https://my.familytreedna.com/login.aspx";
            GoToUrl(url);

            MessageBox.Show(this, "Login and then select the page to down", "Instructions");
        }

        private void webBrowser1_FileDownload(object sender, EventArgs e)
        {
            Console.WriteLine(sender);
        }

        private void familyFinderMatrixExtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWb();
            isRunning = true;
            var url = "https://my.familytreedna.com/family-finder/matrix.aspx";
            GoToUrl(url);
            var cnt = Repository.Count;
            GetInternalId();
            ProcessMatrix();
            var diff = Repository.Count - cnt;
            timerRefresh.Enabled = true;
            MessageBox.Show(this, diff + " records added", "Matrix Processing Finished");
        }
        private readonly List<string> _familyTreeMatrix = new List<string>();
        /// <summary>
        /// Pulls the internal Id
        /// </summary>
        private void GetInternalId()
        {
            _familyTreeMatrix.Clear();
            var selectAll = webBrowser1.Document.GetElementById("MainContent_lbUsers");
            while (selectAll == null || selectAll.GetElementsByTagName("option").Count == 0)
            {
                LongEvents();
                selectAll = webBrowser1.Document.GetElementById("MainContent_lbUsers");
                if (!isRunning) return;
            }
            try
            {
                // We are now ready

                for (var i = 0; i < selectAll.GetElementsByTagName("option").Count; i++)
                {

                    var val = selectAll.GetElementsByTagName("option")[i].GetAttribute("value");
                    var name = selectAll.GetElementsByTagName("option")[i].GetAttribute("text");
                    var person = Repository.FindOrCreatePerson(name, name);
                    person.FamilyTreeId = name;
                    person.FamilyTreeInternalId = val;
                    if (!person.IsSaved) person.Save();
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Unexpected Error");
                return;
            }
        }

        private void LongEvents()
        {
            for (var i = 0; i < 40; i++)
            {
                System.Threading.Thread.Sleep(10);
                Application.DoEvents();
                if (!isRunning) return;
            }

        }
        private void ProcessMatrix()
        {
            // Find the key elements
            while (webBrowser1.Document == null)
                Application.DoEvents();
            try
            {
                LongEvents();
                var selected = "selected";
                var selectAll = webBrowser1.Document.GetElementById("MainContent_lbUsers");
                var selectPicked = webBrowser1.Document.GetElementById("MainContent_lbSelected");
                var buttonAdd = webBrowser1.Document.GetElementById("MainContent_btnAdd");
                var buttonRemove = webBrowser1.Document.GetElementById("MainContent_btnRemove");
                var content = webBrowser1.Document.GetElementById("matrixContainer");
                while (selectAll == null || selectPicked == null || buttonAdd == null || buttonRemove == null
                || content == null || selectAll.GetElementsByTagName("option").Count == 0
                )
                {
                    LongEvents();
                    selectAll = webBrowser1.Document.GetElementById("MainContent_lbUsers");
                    selectPicked = webBrowser1.Document.GetElementById("MainContent_lbSelected");
                    buttonAdd = webBrowser1.Document.GetElementById("MainContent_btnAdd");
                    buttonRemove = webBrowser1.Document.GetElementById("MainContent_btnRemove");
                    content = webBrowser1.Document.GetElementById("matrixContainer");
                    if (!isRunning) return;

                }
                // We are now ready
                var first = 0;
                var match = 1;
                var maxCount = selectAll.GetElementsByTagName("option").Count;

                while (first < maxCount)
                {
                    if (!isRunning) return;
                    while (selectPicked.GetElementsByTagName("option").Count > 0)
                    {
                        if (!isRunning) return;
                        var remove = false;
                        for (var i = 0; i < selectPicked.GetElementsByTagName("option").Count; i++)
                        {
                            remove = true;
                            selectPicked.GetElementsByTagName("option")[i].SetAttribute(selected, selected);
                        }
                        if (remove)
                        {
                            buttonRemove.InvokeMember("click");
                        }
                        while (selectPicked.GetElementsByTagName("option").Count > 0)
                            LongEvents();
                    }
                    LongEvents();
                    for (var i = 0; i < selectAll.GetElementsByTagName("option").Count; i++)
                    {
                        selectAll.GetElementsByTagName("option")[i].SetAttribute(selected, String.Empty);
                        Application.DoEvents();
                    }
                    LongEvents();


                    selectAll.GetElementsByTagName("option")[first].SetAttribute(selected, selected);
                    var selectCnt = 0;
                    for (var ids = 0; ids < 9; ids++)
                    {
                        if (!isRunning) return;
                        try
                        {
                            if (match < selectAll.GetElementsByTagName("option").Count)
                            {
                                selectCnt++;
                                selectAll.GetElementsByTagName("option")[match++].SetAttribute(selected, selected);
                            }
                            else
                            {
                                first++;
                                match = first + 1;
                                break;
                            }
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show(this, exc.Message, "Unexpected Error");
                        }
                    }
                    if (first > maxCount - 1)
                        return;
                    // If we end up with just one
                    if (selectCnt > 0)
                    {
                        content.InnerHtml = String.Empty;
                        buttonAdd.InvokeMember("click");
                        while (content == null || String.IsNullOrWhiteSpace(content.InnerText))
                        {
                            LongEvents();
                            content = webBrowser1.Document.GetElementById("matrixContainer");
                        }
                        while (content.InnerHtml.Length < 100)
                        {
                            while (webBrowser1.IsBusy)
                            {
                                for (var i = 0; i < 100000; i++)
                                    Application.DoEvents();
                            }
                        }
                        if (!isRunning) return;
                        ParseMatrix(content.InnerHtml);
                        toolStripStatusLabel1.Text = Repository.Summary;
                    }
                    Repository.Write();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Unexpected Error - try again");
            }
        }
        private void ParseMatrix(string html)
        {
            html = html.Replace("class=matrix cellSpacing=0 cellPadding=0 border=0", String.Empty)
                    .Replace("class=header2", string.Empty)
                .Replace("class=header", string.Empty)

                .Replace("&nbsp;", String.Empty)
                .Replace("class=emptyData", string.Empty)
                 .Replace("class=data", string.Empty)
                 .Replace("class=tableTitle", string.Empty)
                 .Replace("<IMG alt=Match src=\"https://my.familytreedna.com/family-finder/img/white_fa_ch_circle.png\">", "XXX")
                ;
            var colspan = html.IndexOf("colSpan");
            var end = html.IndexOf(">", colspan);
            html = html.Substring(0, colspan - 1) + html.Substring(end);
            var list = new List<string>();
            var dom = new XmlDocument();
            dom.LoadXml(html);
            var lines = dom.DocumentElement.SelectNodes("//TR");
            var names = lines[1];
            var ncells = names.SelectNodes("TD");
            list.Add("");
            for (var i = 1; i < ncells.Count; i++)
                list.Add(ncells[i].InnerText.Trim());
            for (var r = 2; r < lines.Count; r++)
            {
                if (!isRunning) return;
                var line = lines[r];
                var cells = line.SelectNodes("TD");
                for (var i = 1; i < cells.Count; i++)
                {
                    Match match = null;
                    if (i != r)
                    {
                        var p0 = Repository.FindOrCreatePerson(list[r - 1]);
                        var p1 = Repository.FindOrCreatePerson(list[i]);
                        if (String.IsNullOrWhiteSpace(p0.FamilyTreeId))
                            p0.FamilyTreeId = list[r - 1];
                        if (!p0.IsSaved) p0.Save();
                        if (String.IsNullOrWhiteSpace(p1.FamilyTreeId))
                            p1.FamilyTreeId = list[i];
                        if (!p1.IsSaved) p1.Save();
                        if (cells[i].InnerText.Trim().Length > 1)
                        {
                            match = Repository.FindOrCreateMatch(p0.Id, p1.Id, 0.1F);
                        }
                        else
                        {
                            match = Repository.FindOrCreateMatch(p0.Id, p1.Id, 0.0F);
                        }
                        match.Chromosome = -1;
                        match.FamilyTreeDna = true;
                        match.Save();

                    }
                }
            }
        }

        private void mergeTwoPeopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormMerge();
            frm.ShowDialog(this);
            timerRefresh.Enabled = true;
        }

        private void uploadCurrentTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormShared();
            frm.ShowDialog(this);
        }

        private void clearFamilyTreeDNAMatrixDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var matches = (from match in Repository.MatchList
                           where match.GeneticDistance < 1 && match.FamilyTreeDna
                           select match).ToArray();
            for (var i = 0; i < matches.Length; i++)
                Repository.MatchList.Remove(matches[i]);
            Repository.Write();
            timerRefresh.Enabled = true;
        }

        private void naiveAlgorithmALLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FormFamilyBuilderAll(_peopleroot.Nodes);
            frm.Show(this);
        }

        private void treeViewToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveUtility.SaveRadTree(treeView1);
        }

        private void matrixToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerMatrix.Enabled = true;
            MessageBox.Show(this, "Depending on the size of your tree and computer speed\r\nThis may take a few minutes. It is running in background and will appear when ready", "This may take a few minutes");
        }

        private void timerMatrix_Tick(object sender, EventArgs e)
        {
            timerMatrix.Enabled = false;
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Maximum = Repository.People.Count;
            SaveUtility.SaveString(Repository.GetMatrix(toolStripProgressBar1), this, "Matrix.csv");
        }

        private void mergeAnotherDNAFamilyFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK ==
            MessageBox.Show(this,
                            "This allows multiple files to be merged into one\r\nUsually it is wise to keep unmerge copies around for backup\r\nYou may need to merge people after the import",
                            "Are you using a copy or the original(not recommended)", MessageBoxButtons.OKCancel))
            {

            }
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Process.Start("http://www.lassesen.com/donate.html");
        }
    }
}
