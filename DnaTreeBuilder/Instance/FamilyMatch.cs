using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DnaTreeBuilder
{
    public class FamilyMatch
    {
        public Guid Id0 {private  set; get; }
        public Guid Id1{ private set; get; }
        public float GeneticDistance { set; get; }
        public string Key
        {
           set { char[] sep = {'\t'};
               var parts = value.Split(sep);
               Id0 = Guid.Parse(parts[0]);
               Id1 = Guid.Parse(parts[1]);
           } 
        }
        public FamilyMatch()
        {
        }


    }

}