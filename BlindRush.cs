using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class BlindRush : A_Ability
    {
        public BlindRush() : base("Blind Rush", "Blindly rushes the opponet, if misses takes health damage", 0, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            ((A_Hero)self).spellSlots -= this.slotsRequired;

            int attackRoll = Dungeon.gRandom.Next(1, 101);
            int toHit = 90 + (int)(self.speed - targets[0].speed);
            double dam;
            if (attackRoll > toHit)
            {
                self.Damage(3.0);
                return "\n-MISS-" + self.charString + " blindly rushes " + targets[0].charString + ", but misses and takes 3 health damage.";
            }
            

            dam = (self.power*1.2 + self.ModifyDie) * (1 - targets[0].DamageReduction);
            targets[0].Damage(dam);
            return "\n-HIT-" + self.charString + " blindly rushes  " + targets[0].charString + " and tramples them dealing " + ((int)dam) + " damage.";
        }
    }
}
