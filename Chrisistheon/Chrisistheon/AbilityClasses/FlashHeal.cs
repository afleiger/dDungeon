using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class FlashHeal : A_Ability
    {
        public FlashHeal()
            : base("Flash Heal", "Heal a single target for a small amount.", 0, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            double heal;

            heal = (self.power + self.ModifyDie) + 5;
            targets[0].Heal(heal);
            return "\n-" + self.charString + " casts Flash Heal on " + targets[0].charString + " restoring " + ((int)heal) + " health.";
        }
    }
}