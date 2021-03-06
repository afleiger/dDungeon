﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class HolyStrike : A_Ability
    {
        public HolyStrike()
            : base("Holy Strike", "A blessed strike which heals the user if successful.", 0, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            ((A_Hero) self).spellSlots -= this.slotsRequired;

            int attackRoll = Dungeon.gRandom.Next(1, 101);
            int toHit = 90 + (int)(self.speed - targets[0].speed);
            if (attackRoll > toHit)
            {
                return "\n-MISS-" + self.charString + " uses Holy Strike on " + targets[0].charString + " but misses horribly.";
            }

            double dam = (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction) * .85;
            targets[0].Damage(dam);
            double heal = dam * .25;
            self.Heal(heal);
            return "\n-HIT-" + self.charString + " uses Holy Strike on " + targets[0].charString + " dealing " + ((int)dam) + " damage." + "\n-" + self.charString + " heals for " + ((int)heal);
        }
    }
}