using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Hide : A_Ability
    {
        public Hide()
            : base("Hide", "Blend into the shadows.", 0, 0)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int rand = Dungeon.gRandom.Next(1, 101);
            if (rand <= (50 + self.speed ))
            {
                self.Status = "Stealthing";
                return "\n-SUCCESS-" + self.charString + " successfully hides, gaining Stealth.";
            }
            return "\n-FAILURE-" + self.charString + " tries to hide, but they failed.";
        }
    }
}