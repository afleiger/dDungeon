using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Seppuku : A_Ability
    {
        public Seppuku()
            : base("Seppuku", "Sacrifice own health to massively buff own power. Uses 1 slot.", 1, 0)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            ((A_Hero)self).spellSlots -= 1;

            double dam = self.health * .5;
            self.Damage(dam);
            self.power += self.power;
            return "\n-" + self.charString + " commits Seppuku, dealing " + ((int)dam) + " damage to themselves, entering an empowered zen-state.";
        }
    }
}