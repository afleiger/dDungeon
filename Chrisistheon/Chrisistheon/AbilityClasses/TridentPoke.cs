using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class TridentPoke : A_Ability
    {
        public TridentPoke()
            : base("TridentPoke", "Attack with trident.", 0, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int attackRoll = Dungeon.gRandom.Next(1, 101);
            int toHit = 85 + (int)(self.speed - targets[0].speed);
            double dam;
            if (attackRoll > toHit)
            {
                return "\n-MISS-" + self.charString + " misses " + targets[0].charString + " with its trident stab.";
            }
            if (attackRoll <= 15)
            {
                dam = (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction) * 2;
                targets[0].Damage(dam);
                return "\n-CRIT-" + self.charString + " brutally stabs " + targets[0].charString + " with its trident, dealing " + ((int)dam) + " damage.";
            }

            dam = (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction) *.9;
            targets[0].Damage(dam);
            return "\n-HIT-" + self.charString + " scewers " + targets[0].charString + " with its trident, dealing " + ((int)dam) + " damage.";
        }
    }
}
