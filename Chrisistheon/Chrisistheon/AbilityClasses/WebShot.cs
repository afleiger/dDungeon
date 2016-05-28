using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class WebShot : A_Ability
    {
        public WebShot()
            : base("Web Shot", "Fire sticky webbing to damage and slow two targets.", 0, 2)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int attackRoll;
            int toHit;
            double dam;
            string ret = "\n-" + self.charString + " shoots webbing at multiple targets.";

            for(int x = 0; x < 2; x++)
            {
                attackRoll = Dungeon.gRandom.Next(1, 101);
                toHit = 80 + (int)(self.speed - targets[x].speed);
                if (attackRoll > toHit)
                {
                    ret += "\n-MISS-" + self.charString + " throws web at " + targets[x].charString + " but misses.";
                }
                else if (attackRoll <= 8)
                {
                    dam = (self.power + self.ModifyDie) * (1 - targets[x].DamageReduction);
                    targets[x].Damage(dam);
                    targets[x].speed -= 10;
                    ret += "\n-CRITICAL-" + self.charString + " bombards " + targets[x].charString + " with corrosive webbing, slowing them greatly and dealing " + ((int)dam) + " damage.";
                }
                else
                {
                    dam = (self.power + self.ModifyDie) * (1 - targets[x].DamageReduction) *.5;
                    targets[x].Damage(dam);
                    targets[x].speed -= 5;
                    ret += "\n-HIT-" + self.charString + " snags " + targets[x].charString + " in web projectiles, slowing them and dealing " + ((int)dam) + " damage.";
                }
            }
            return ret;
        }
    }
}