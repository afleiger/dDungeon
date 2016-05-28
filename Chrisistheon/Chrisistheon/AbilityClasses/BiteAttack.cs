using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class BiteAttack : A_Ability
    {
        public BiteAttack()
            : base("Bite Attack", "Lunge at your foes with gnarled teeth.", 0, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int attackRoll = Dungeon.gRandom.Next(1, 101);
            int toHit = 80 + (int)(self.speed - targets[0].speed);
            double dam;
            if (attackRoll > toHit)
            {
                return "\n-MISS-" + self.charString + " tries to bite " + targets[0].charString + " but misses.";
            }
            if (attackRoll <= 5)
            {
                dam = (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction) * 1.5;
                targets[0].Damage(dam);
                return "\n-CRITICAL-" + self.charString + " sinks its fangs deep into " + targets[0].charString + " dealing " + ((int)dam) + " damage.";
            }

            dam = (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction);
            targets[0].Damage(dam);
            return "\n-HIT-" + self.charString + " bites " + targets[0].charString + " dealing " + ((int)dam) + " damage.";
        }
    }
}