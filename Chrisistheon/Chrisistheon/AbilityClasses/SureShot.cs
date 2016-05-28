using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class SureShot : A_Ability
    {
        public SureShot()
            : base("Sure Shot", "Always hits its target.", 0, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int attackRoll = Dungeon.gRandom.Next(1, 101);
            
            double dam;
            
            if (attackRoll <= 5)
            {
                dam = ((self.power*.75) + self.ModifyDie) * (1 - targets[0].DamageReduction) * 1.5;
                targets[0].Damage(dam);
                return "\n-CRITICAL-" + self.charString + " delivers a critical strike, with Sure Shot from afar to " + targets[0].charString + ". Dealing " + ((int)dam) + " damage.";
            }

            dam = ((self.power * .75) + self.ModifyDie) * (1 - targets[0].DamageReduction);
            targets[0].Damage(dam);
            return "\n-HIT-" + self.charString + " strikes the " + targets[0].charString + " with Sure Shot from afar and deals " + ((int)dam) + " damage.";
        }
    }
}
