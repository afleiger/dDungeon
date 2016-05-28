using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class DivineGrace : A_Ability
    {
        public DivineGrace()
            : base("Divine Grace", "Beseech Iorr to grant you increased speed.", 0, 0)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int rand = Dungeon.gRandom.Next(1, 101);
            if (rand <= (85))
            {
                self.speed += 5;
                return "\n-SUCCESS-Iorr grants " + self.charString + " divine grace.";
            }
            return "\n-FAILURE-Iorr turns away from " + self.charString + "'s request of divine grace.";
        }
    }
}