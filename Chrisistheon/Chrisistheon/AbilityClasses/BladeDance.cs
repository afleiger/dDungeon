using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class BladeDance : A_Ability
    {
        public BladeDance()
            : base("Blade Dance", "Dance across the battlefield. Delivering 4 attacks.", 1, 4)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            ((A_Hero)self).spellSlots -= this.slotsRequired;
            string ret = "\n-" + self.charString + " raises their "  + ((A_Hero)self).currentWeapon +  "  before using Blade Dance.";
            int attackRoll;
            int toHit;
            double dam;

            for(int x = 0; x < 4; x++)
            {
                attackRoll = Dungeon.gRandom.Next(1, 101);
                toHit = 80 + (int)(self.speed - targets[x].speed);
                if (attackRoll > toHit)
                {
                    ret += "\n-MISS-" + self.charString + " misses " + targets[x].charString + ".";
                }
                else if (attackRoll <= 10)
                {
                    dam = (self.power + self.ModifyDie) * (1 - targets[x].DamageReduction) * 2;
                    targets[x].Damage(dam);
                    ret += "\n-CRITICAL-" + self.charString + "'s blade weaves its will into " + targets[x].charString + "'s flesh, dealing " + ((int)dam) + " damage.";
                }
                else
                {
                    dam = (self.power + self.ModifyDie) * (1 - targets[x].DamageReduction);
                    targets[x].Damage(dam);
                    ret += "\n-HIT-" + self.charString + " strikes the " + targets[x].charString + " and deals " + ((int)dam) + " damage.";
                }
            }
            return ret;
        }
    }
}