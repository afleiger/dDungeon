using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class DoubleShot : A_Ability
    {
        public DoubleShot()
            : base("Double Shot", "Loose two arrows, placed where you will.", 1, 2)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            ((A_Hero)self).spellSlots -= this.slotsRequired;
            string hits="\n-" + self.charString + " uses Double Shot.";

            


            int attackRoll = Dungeon.gRandom.Next(1, 101);
            int toHit = 90 + (int)(self.speed - targets[0].speed);
            double dam;
            if (attackRoll > toHit)
            {
                hits+= "\n-MISS-" + self.charString + " fires at " + targets[0].charString + " but misses.";
            }
            else if (attackRoll <= 5)
            {
                dam = ((self.power*.8) + self.ModifyDie) * (1 - targets[0].DamageReduction) * 1.5;
                targets[0].Damage(dam);
                hits+= "\n-CRITICAL-" + self.charString + " delivers a critical arrow, puncturing " + targets[0].charString + ". Dealing " + ((int)dam) + " damage.";
            }
            else
            {
                dam = ((self.power * .8) + self.ModifyDie) * (1 - targets[0].DamageReduction);
                targets[0].Damage(dam);
                hits += "\n-HIT-" + self.charString + " shoots " + targets[0].charString + " and deals " + ((int)dam) + " damage.";
            }
            

            attackRoll = Dungeon.gRandom.Next(1, 101);
            toHit = 90 + (int)(self.speed - targets[1].speed);
            
            if (attackRoll > toHit)
            {
                hits += "\n-MISS-" + self.charString + " fires at " + targets[1].charString + " but misses.";
            }
            else if (attackRoll <= 5)
            {
                dam = ((self.power * .8) + self.ModifyDie) * (1 - targets[1].DamageReduction) * 1.5;
                targets[1].Damage(dam);
                hits += "\n-CRITICAL-" + self.charString + " delivers a critical arrow, puncturing " + targets[1].charString + ". Dealing " + ((int)dam) + " damage.";
            }
            else
            {
                dam = ((self.power * .8) + self.ModifyDie) * (1 - targets[1].DamageReduction);
                targets[1].Damage(dam);
                hits += "\n-HIT-" + self.charString + " shoots " + targets[1].charString + " and deals " + ((int)dam) + " damage.";
            }

            return hits;
        }
    }
}