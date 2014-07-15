using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace DnaTreeBuilder.Instance
{
    class Version1Import
    {
        private XmlDocument dom;
        public Version1Import(string fileName)
        {
            dom=new XmlDocument();
            if(File.Exists(fileName))
            {
                dom.Load(fileName);
                ImportPeople();
                ImportMatch();
            }

        }
        private void ImportPeople()
        {
            //  <person id="7e08d86d44e0e581" name="Suzanne Cox Johnson" ancestor="" />
            var people = dom.SelectNodes("//person");
            foreach(XmlNode node in people)
            {
                var id = node.Attributes["id"].Value;
                var name = node.Attributes["name"].Value;
                var person = Repository.FindOrCreatePerson(name, id);
                person.MeId = id;
                if(!person.IsSaved) person.Save();
            }
        }
        //  <match key="334452a46ee53694350e274530ae4b47" id1="334452a46ee53694" id2="350e274530ae4b47" name1="Ken Lassesen" name2="Ethelyn Hallberg" cm="26" fragments="2" />
        private void ImportMatch()
        {
            var matches = dom.SelectNodes("//match");
            foreach (XmlNode node in matches)
            {
                var id0 = node.Attributes["id1"].Value;
                var id1 = node.Attributes["id2"].Value;
                var person0 = Repository.FindPerson(id0);
                var person1 = Repository.FindPerson(id1);
                var geneticDistance = 0F;
                if(float.TryParse(node.Attributes["cm"].Value, out geneticDistance))
                {
                    var match = new Match {ChromosomeText = "0", Id0 = person0.Id, Id1=person1.Id, GeneticDistance = geneticDistance,MeAnd23 = true};
                    match.Save();
                }
            }

        }
        private void ImportMatch2()
        {
            // <person id="334452a46ee53694" name="Ken Lassesen" ancestor="">
    //<match2 id="63ae8e1e5fb70fc5" personId="" name="Kasper Bræmer-Jensen" chromosome="2" startPoint="35000000" endPoint="47000000" geneticDistance="16.2" snps="3323" />
            var people = dom.SelectNodes("//match2");
            foreach (XmlNode node in people)
            {
                var otherId = node.ParentNode.Attributes["id"].Value;
                var id = node.Attributes["id"].Value;
                var name = node.Attributes["name"].Value;
                var person = Repository.FindOrCreatePerson(name, id);
                person.MeId = id;
                if(! person.IsSaved)person.Save();
            }

        }
    }
}
