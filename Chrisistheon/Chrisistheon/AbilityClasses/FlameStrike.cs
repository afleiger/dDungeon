using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class FlameStrike : A_Ability
    {
        public FlameStrike()
            : base("Flame Strike", "Burn all enemies with a wall of Flame.", 1, -1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            ((A_Hero)self).spellSlots -= 1;
            int attackRoll = Dungeon.gRandom.Next(1, 101);
            double toHit = 70 + self.speed;
            if (attackRoll > toHit)
            {
                return "\n-MISS-" + self.charString + " attempts to cast Flame Strike, but it failed.";
            }

            double dam = (self.power + self.ModifyDie) + 5;
            foreach(A_Entity tar in targets)
            {
                tar.Damage(dam);
            }
            return "\n-HIT-" + self.charString + " unleashes Flame Strike upon thier foes. Burning them for " + ((int)dam) + " damage.";
        }
    }
}