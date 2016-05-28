using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Cleave : A_Ability
    {
        public Cleave()
            : base("Cleave", "Cleave the target, damage is based on missing health.", 1, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int attackRoll = Dungeon.gRandom.Next(1, 101);
            A_Hero Self = ((A_Hero)self);

            Self.spellSlots -= this.slotsRequired;
            double missingHP = (Self.maxHealth - Self.health) / 10.0;

            int toHit = 90 + (int)(self.speed - targets[0].speed);
            double dam;
            if (attackRoll > toHit)
            {
                return "\n-MISS-" + self.charString + " attmpets to cleave"  + targets[0].charString + " but misses.";
            }
            if (attackRoll <= 5)
            {
                dam = ((self.power * .80) + self.ModifyDie) * (1 - targets[0].DamageReduction) * 1.5;
                targets[0].Damage(dam);
                return "\n-CRITICAL-" + self.charString + " delivers a critical strike, with Sure Shot from afar to " + targets[0].charString + ". Dealing " + ((int)(dam+missingHP)) + " damage.";
            }

            dam = ((self.power * .80) + self.ModifyDie) * (1 - targets[0].DamageReduction);
            targets[0].Damage(dam);
            return "\n-HIT-" + self.charString + " strikes the " + targets[0].charString + " with Sure Shot from afar and deals " + ((int)(dam + missingHP)) + " damage.";
        }
    }
}
