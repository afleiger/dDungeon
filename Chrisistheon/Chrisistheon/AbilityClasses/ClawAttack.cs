using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class ClawAttack : A_Ability
    {
        public ClawAttack()
            : base("Claw", "Swipe at the target with your wicked claws.", 0, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int attackRoll = Dungeon.gRandom.Next(1, 101);
            int toHit = 80 + (int)(self.speed - targets[0].speed);
            double dam;
            if (attackRoll > toHit)
            {
                return "\n-MISS-" + self.charString + " tries to claw " + targets[0].charString + " but misses.";
            }
            if(attackRoll <= 5)
            {
                dam = (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction) * 1.5;
                targets[0].Damage(dam);
                return "\n-CRITICAL-" + self.charString + " rends deeply into the virgin flesh of " + targets[0].charString + " dealing " + ((int)dam) + " damage.";
            }

            dam = (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction);
            targets[0].Damage(dam);
            return "\n-HIT-" + self.charString + " claws at " + targets[0].charString + " dealing " + ((int)dam) + " damage.";
        }
    }
}
