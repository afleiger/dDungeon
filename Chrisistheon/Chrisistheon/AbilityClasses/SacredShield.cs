using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class SacredShield : A_Ability
    {
        public SacredShield()
            : base("SacredShield", "Grant a target a sacred shield increasing defense and speed.", 0, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            targets[0].speed += 5;
            targets[0].defense += 5;
            return "\n-" + self.charString + " casts Sacred Shield on " + targets[0].charString + " increasing speed and defense.";
        }
    }
}