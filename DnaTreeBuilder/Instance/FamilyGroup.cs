using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DnaTreeBuilder
{
    public class FamilyGroup : List<OldPerson>
    {
        private string title;
        public FamilyGroup(OldPerson a)
        {
            this.Add(a);
            title = a.Name + " tree";
        }
        public bool TestPerson(OldPerson a)
        {
            foreach (OldPerson item in this)
            {
                if (item.CmDistance(a) == 0)
                    return false;
            }
            this.Add(a);
            return true;
        }
    }
}
