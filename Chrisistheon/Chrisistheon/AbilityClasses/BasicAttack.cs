using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class BasicAttack : A_Ability
    {
        public BasicAttack() : base("Basic Attack", "Attack a single target with your weapon.", 0, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            ((A_Hero)self).spellSlots -= this.slotsRequired;

            int attackRoll = Dungeon.gRandom.Next(1,101);
            int toHit = 90 + (int)(self.speed - targets[0].speed);
            double dam;
            if(attackRoll > toHit)
            {
                return "\n-MISS-" + self.charString + " attacks " + targets[0].charString + " but misses.";
            }
            if(attackRoll <= 5)
            {
                dam = (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction) * 1.5;
                targets[0].Damage(dam);
                return "\n-CRITICAL-" + self.charString + " delivers a critical strike, crushing " + targets[0].charString + ". Dealing " + ((int)dam) + " damage.";
            }

            dam = (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction);
            targets[0].Damage(dam);
            return "\n-HIT-" + self.charString + " attacks " + targets[0].charString + " and deals "+ ((int)dam) + " damage.";
        }
    }
}
