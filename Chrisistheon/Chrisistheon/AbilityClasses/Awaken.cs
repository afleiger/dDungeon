using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Awaken : A_Ability
    {
        public Awaken()
            : base("Awaken", "Send a wave of fel energy to all enemies.", 1, -1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {

            int attackRoll = Dungeon.gRandom.Next(1, 101);
            double toHit = 70 + self.speed;
            if (attackRoll > toHit)
            {
                return "\n-MISS-" + self.charString + " attempts to cast Awaken, but it failed.";
            }

            double dam = (self.power + self.ModifyDie) + 5;
            foreach (A_Entity tar in targets)
            {
                tar.Damage(dam);
            }
            return "\n-HIT-" + self.charString + " casts Awaken, a wave of fel energy rips through your party dealing " + ((int)dam) + " damage.";
        }
    }
}
