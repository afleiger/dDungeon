using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class DemonRage : A_Ability
    {
        public DemonRage()
            : base("Demon Rage", "Rush your target in a wild fury, gaining power.", 0, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int attackRoll = Dungeon.gRandom.Next(1, 101);
            int toHit = 70 + (int)(self.speed - targets[0].speed);
            double dam;
            if (attackRoll > toHit)
            {
                return "\n-MISS-" + self.charString + " rages onto the battlefield, but " + targets[0].charString + " swiftly dodges.";
            }
            if (attackRoll <= 6)
            {
                dam = (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction) * 1.5;
                targets[0].Damage(dam);
                self.maxPower += 10;
                return "\n-CRITICAL-" + self.charString + " enters into a demonic orgy of rage, thrashing " + targets[0].charString + " mercilously for " + ((int)dam) + " damage. His power feeds.";
            }

            dam = (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction);
            targets[0].Damage(dam);
            self.maxPower += 5;
            return "\n-HIT-" + self.charString + " goes into a demonic rage, ravaging " + targets[0].charString + " for " + ((int)dam) + " damage. His power feeds.";
        }
    }
}