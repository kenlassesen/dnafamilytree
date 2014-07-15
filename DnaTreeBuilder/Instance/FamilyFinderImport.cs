using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DnaTreeBuilder.Instance
{
    internal class FamilyFinderImport
    {
        private const string AdvanceMatching =
            "\"Last Name\",\"First Name\",\"Middle Name\",\"Email Address\",\"YDNA Haplogroup\",\"mtDNA Haplogroup\",\"Family Finder\""
                             ;

        private const string ChromosomeBrowser =
            "NAME,MATCHNAME,CHROMOSOME,START LOCATION,END LOCATION,CENTIMORGANS,MATCHING SNPS";

        private const string FamilyFinderMatches =
            "\"Full Name\",\"Match Date\",\"Relationship Range\",\"Suggested Relationship\",\"Shared cM\",\"Longest Block\",\"Known Relationship\",\"E-mail\",\"Ancestral Surnames\",\"Y-DNA Haplogroup\",\"mtDNA Haplogroup\",\"Notes\"";

        private string[] data;

        public FamilyFinderImport(string filePath)
        {
            data = File.ReadAllLines(filePath);
            if (data == null || data.Length < 2)
            {
                StatusMessage = "Empty File: " + filePath;
                return;
            }
            if (data[0].Equals(FamilyFinderMatches))
            {
                ProcessFamilyFinderMatches();
            }
            else if (data[0].Equals(ChromosomeBrowser))
            {
                ProcessChromosomeBrowser();
            }
            else if (data[0].Equals(AdvanceMatching))
            {
                ProcessAdvanceMatching();

            }
            else
            {
                StatusMessage = "Not Supported Format - See help page for what to down load";
            }
        }
        public string StatusMessage { get; private set; }
        void ProcessFamilyFinderMatches()
        {
            string[] commaSep = { "," };
            for (var i = 1; i < data.Length; i++)
            {
                try
                {
                    var cols = data[i].Split(commaSep, StringSplitOptions.None);
                    var name = cols[0].Replace("\"", "").Trim();
                    var email = cols[7].Replace("\"", "");
                    var surNames = cols[8].Replace("\"", "");
                    var mtDna = cols[10].Replace("\"", "");
                    var yDna = cols[9].Replace("\"", "");
                    var person = Repository.FindOrCreatePerson(name, name);
                    if (string.IsNullOrWhiteSpace(person.FamilyTreeId))
                        person.FamilyTreeId = name;
                    if (String.IsNullOrWhiteSpace(person.Email))
                    {
                        person.Email = email;
                    }
                    else if (!person.Email.Contains(email))
                    {
                        person.Email = person.Email + ";" + email;
                    }
                    person.MtDna = mtDna;
                    person.YDna = yDna;
                    if (String.IsNullOrWhiteSpace(person.Surname))
                    {
                        person.Surname = surNames;
                    }
                    else if (!person.Surname.Contains(surNames))
                    {
                        person.Surname = person.Surname + "/" + surNames;
                    }

                    if (! person.IsSaved)
                        person.Save();
                }
                catch
                    (Exception
                        exc)
                {
                    MessageBox.Show(exc.Message, "Unexpected Error");
                }

            }
        }

        void ProcessChromosomeBrowser()
        {
            string[] commaSep = { "," };
            for (var i = 1; i < data.Length; i++)
            {
                try
                {
                    var cols = data[i].Split(commaSep, StringSplitOptions.None);
                    var name0 = cols[0].Replace("\"", "").Trim();
                    var name1 = cols[1].Replace("\"", "").Trim();
                    var id0 = Repository.FindOrCreatePerson(name0,name0);
                    id0.FamilyTreeId = name0;
                    if(!id0.IsSaved) id0.Save();
                    var id1 = Repository.FindOrCreatePerson(name1,name1);
                    id1.FamilyTreeId = name1;
                    if (!id1.IsSaved) id1.Save();
                    var result = new Match { Id0 = id0.Id, Id1 = id1.Id };
                    if (cols[2].Equals("X"))
                    {
                        result.Chromosome = 27;
                    }
                    else if (cols[2].Equals("Y"))
                    {
                        result.Chromosome = 28;
                    }
                    else
                    {
                        result.Chromosome = int.Parse(cols[2]);
                    }
                    result.StartPoint = int.Parse(cols[3]);
                    result.EndPoint = int.Parse(cols[4]);
                    result.GeneticDistance = float.Parse(cols[5]);
                    result.SNPs = int.Parse(cols[6]);
                    result.FamilyTreeDna = true;
                    
                    result.Save();
                }
                catch
                    (Exception
                        exc)
                {
                    MessageBox.Show(exc.Message, "Unexpected Error");
                }

            }

        }
        void ProcessAdvanceMatching()
        {
            string[] commaSep = { "," };
            for (var i = 1; i < data.Length; i++)
                try
            {
                var cols = data[i].Split(commaSep, StringSplitOptions.None);
                var name = (cols[2] + " " + cols[1] + " " + cols[0]).Replace("\"","").Replace("  "," ").Trim();
                var email = cols[3].Replace("\"", "").Trim();
                var yDna = cols[4].Replace("\"", "").Trim();
                var mtDna = cols[5].Replace("\"", "").Trim();
                var person = Repository.FindOrCreatePerson(name, name);
                person.YDna = yDna;
                person.MtDna = mtDna;
                if (string.IsNullOrWhiteSpace(person.FamilyTreeId))
                    person.FamilyTreeId = name;
                if (String.IsNullOrWhiteSpace(person.Email))
                {
                    person.Email = String.Empty;
                }
                if (!person.Email.Contains(email))
                {
                    person.Email = person.Email + ";" + email;
                }
                if(! person.IsSaved)
                    person.Save();
            }catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "Unexpected Error");
            }
        }
/*
 * POST https://my.familytreedna.com/ftdnawebservice/FFMatrix.asmx/GetMatrixData HTTP/1.1
Host: my.familytreedna.com
Connection: keep-alive
Content-Length: 73
Accept: application/json, text/javascript, 
Origin: https://my.familytreedna.com
X-Requested-With: XMLHttpRequest
User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.153 Safari/537.36
Content-Type: application/json; charset=UTF-8
Referer: https://my.familytreedna.com/family-finder/matrix.aspx
Accept-Encoding: gzip,deflate,sdch
Accept-Language: en-US,en;q=0.8
Cookie: ASP.NET_SessionId=volrt3uh5mcx1a5pj232r52h; .FTDNAAuth=B8024D46CE97565599FD9DAF05B7D72B9AD3F127DF0E5D4388F9EF73DE6EFDB860080C17AAE50CB663416B185D9FBB14461E30B91C9D014EACE572EA55C01EE209FBE5A9396FE21775E5F93B27FACF2CD65DC76D9CB738842048D0962DF20F55BBA7A6A392E7AA90A7D2D7C30C140AA6E3B4B114; __utma=100830870.1263904954.1401133313.1402886462.1403377207.7; __utmb=100830870.6.10.1403377207; __utmc=100830870; __utmz=100830870.1401133313.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none)

{'resultIds': '2241233,71214,158437,134260,83981,1661137,416247,2311258'}
        */
        public const string matrixContainer = "matrixContainer";
        public const string SelectUsers = "MainContent_lbUsers";
        public const string SelectPicks = "MainContent_lbSelected";
        public static void ProcessMatrix()
        {
            var url = "https://my.familytreedna.com/ftdnawebservice/FFMatrix.asmx/GetMatrixData";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            var json= "{'resultIds': '2241233,71214,158437,134260,83981,1661137,416247,2311258'}";
            var writer = new StreamWriter(request.GetRequestStream());
            writer.Write(json);
            writer.Close();
            var response=request.GetResponse();
            response.GetResponseStream();
        } 
    }
}
