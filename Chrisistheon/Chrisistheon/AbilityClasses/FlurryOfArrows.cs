using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class FlurryOfArrows : A_Ability
    {
        public FlurryOfArrows()
            : base("Flurry of Arrows", "Blast the target with flurry of arrows.", 1, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            ((A_Hero)self).spellSlots -= this.slotsRequired;

            int attackRoll;
            int toHit;
            int hitCounter=0;
            double dam=0;
            for(int i=0; i<7; i++)
            {
                attackRoll = Dungeon.gRandom.Next(1, 101);
                toHit = 40 + (int)(self.speed - targets[0].speed);
                if (attackRoll > toHit)
                {
                }
                else
                {
                    hitCounter++;
                    dam += (self.power + self.ModifyDie) * (1 - targets[0].DamageReduction);
                }
                
            }

            targets[0].Damage(dam);
            return "\n" + self.charString + " pelts " + targets[0].charString + " with a relentless flurry of arrows, hitting "+hitCounter+" times, dealing " + ((int)dam) + " damage.";
        }
    }
}

