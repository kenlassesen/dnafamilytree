using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DnaTreeBuilder.Instance
{
    class GeneticDistance
    {
        public static Relationship ConvertToSteps(Match match, List<Match> reference)
        {
            float cm = match.GeneticDistance;
            if (cm > 3600)
            {
                return ParentOrChild(match, reference);
            }
            if (cm >= 2800) return Relationship.Sibling;
            if (cm >= 1400)
            {
                switch(ParentOrChild(match, reference))
                {
                    case Relationship.Parent:
                        return Relationship.GrandParent;
                        case Relationship.Child:
                        return Relationship.GrandChild;
                    default:
                        return Relationship.Step2;
                }
            }
            if (cm >= 700) return Relationship.Step3;
            if (cm >= 350) return Relationship.Step4;
            if (cm >= 175) return Relationship.Step5;
            if (cm >= 87) return Relationship.Step6;
            if (cm >= 43) return Relationship.Step7;
            if (cm >= 22) return Relationship.Step8;
            if (cm >= 11) return Relationship.Step9;
            if (cm >= 5) return Relationship.Step10;
            if (cm > 0) return Relationship.Step11;
            return Relationship.Step12;
        }
        private static Relationship ParentOrChild(Match match, List<Match> reference)
        {
            var scope = new List<Guid> { match.Id0, match.Id1 };
            List<Guid> common = (from m in reference
                                 where match.Id0 == m.Id0 || match.Id0 == m.Id1
                                 select match.Id0 == m.Id0 ? m.Id1 : m.Id0).Intersect(
 (from m in reference
  where match.Id1 == m.Id0 || match.Id1 == m.Id1
  select match.Id1 == m.Id0 ? m.Id1 : m.Id0)).ToList();
            var sum0 = (from m in reference
                        where (match.Id0 == m.Id0 || match.Id0 == m.Id1)
                              && (common.Contains(m.Id0) || common.Contains(m.Id1))
                        select m.GeneticDistance).Sum();
            var sum1 = (from m in reference
                        where (match.Id1 == m.Id0 || match.Id1 == m.Id1)
                              && (common.Contains(m.Id0) || common.Contains(m.Id1))
                        select m.GeneticDistance).Sum();
            if (sum0 > sum1)
                return Relationship.Parent;
            if (sum0 < sum1)
                return Relationship.Child;
            return Relationship.Step1;
        }
    }
}
