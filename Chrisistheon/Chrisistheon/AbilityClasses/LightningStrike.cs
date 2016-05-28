using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class LightningStrike : A_Ability
    {
        public LightningStrike()
            : base("Lightning Strike", "Call for a thunderous discharge from the heavens. It has a chance of striking multiple times. Uses 1 Spell Slot.", 1, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            ((A_Hero)self).spellSlots -= 1;

            int strikeCount = 1;
            double dam = 0;

            int attackRoll = Dungeon.gRandom.Next(1, 101);
            int toHit = 85 + (int)(self.speed - targets[0].speed);
            if (attackRoll > toHit)
            {
                return "\n-MISS-" + self.charString + " attempts to cast Lightning Strike, but it failed.";
            }

            while(attackRoll < 60)
            {
                strikeCount ++;
                dam += (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction) + 5;
                attackRoll = Dungeon.gRandom.Next(1, 101);
            }

            dam += (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction) + 5;
            targets[0].Damage(dam);
            return "\n-HIT-" + self.charString + " casts Lightning Strike on " + targets[0].charString + " striking " + strikeCount + " times, dealing " + ((int)dam) + " damage.";
        }
    }
}