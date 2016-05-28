using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class BackStab : A_Ability
    {
        public BackStab()
            : base("Back Stab", "Stab your target in the back. Deals massive damage if in stealth. Has high critical chance.", 0, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int attackRoll = Dungeon.gRandom.Next(1, 101);
            int toHit = 90 + (int)(self.speed - targets[0].speed);
            double dam;
            if (attackRoll > toHit)
            {
                return "\n-MISS-" + self.charString + " tries to backstab " + targets[0].charString + " but fumbles.";
            }
            if (attackRoll <= 10)
            {
                if(self.Status == "Stealthed")
                {
                    dam = (self.power + self.ModifyDie +2) * (1 - targets[0].DamageReduction) * 5;
                    targets[0].Damage(dam);
                    return "\n-CRITICAL-" + targets[0].charString + " is gloriously eviscerated by " + self.charString + "'s stealthed backstab! Dealing "+ ((int)dam) +" damage." ;
                }
                else
                {
                    dam = (self.power + self.ModifyDie +2) * (1 - targets[0].DamageReduction) * 1.2;
                    targets[0].Damage(dam);
                    return "\n-CRITICAL-" + targets[0].charString + " is stabbed in a vulnerable location by " + self.charString + "'s backstab. Dealing " + ((int)dam) + " damage.";
                }
            }

            if (self.Status == "Stealthed")
            {
                dam = (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction) * 3;
                targets[0].Damage(dam);
                return "\n-HIT-" + self.charString + " sneaks behind " + targets[0].charString + " and backstabs them. Dealing " + ((int)dam) + " damage.";
            }

            dam = (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction) * .7;
            targets[0].Damage(dam);
            return "\n-HIT-" + self.charString + " weakly stabs at " + targets[0].charString + " back and deals " + ((int)dam) + " damage.";
        }
    }
}