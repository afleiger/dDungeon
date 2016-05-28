using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class UnleashHeaven : A_Ability
    {
        public UnleashHeaven()
            : base("Unleash Heaven", "Heal all allies for large amount.", 1, -2)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            ((A_Hero)self).spellSlots -= 1;


            int attackRoll = Dungeon.gRandom.Next(1, 101);
            double toHit = 88 + self.speed - 2;
            if (attackRoll > toHit)
            {
                return "\n-FAIL-" + self.charString + " fails to Unleash Heaven. GG.";
            }

            double heal = (self.power + self.ModifyDie) * 3.5;
            foreach (A_Entity tar in targets)
            {
                tar.Heal(heal);
            }
            return "\n-SUCCESS-" + self.charString + " Unleashes Heaven. Pristine angels descend and restore " + ((int)heal) + " health to all allies.";
        }
    }
}
