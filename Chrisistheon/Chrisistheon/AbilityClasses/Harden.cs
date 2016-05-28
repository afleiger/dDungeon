using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Harden : A_Ability
    {
        public Harden()
            : base("Harden", "Make yourself impenetrable.", 0, 0)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int rand = Dungeon.gRandom.Next(1, 101);
            if (rand <= 80)
            {
                self.defense += 5;
                return "\n-SUCCESS-" + self.charString + " successfully hardens.";
            }
            return "\n-FAILURE-" + self.charString + "'s harden spell failed.";
        }
    }
}