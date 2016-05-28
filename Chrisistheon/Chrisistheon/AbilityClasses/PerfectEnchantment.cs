using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class PerfectEnchantment : A_Ability
    {
        public PerfectEnchantment()
            : base("Perfect Enchantment", "Magically enchances a target, boosting all stats. Uses 1 Spell Slot.", 1, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            ((A_Hero)self).spellSlots -= this.slotsRequired;

            int rand = Dungeon.gRandom.Next(0, 3);
            if (rand == 0)
            {
                targets[0].power += 6;
                targets[0].defense += 6;
                targets[0].speed += 6;
                return "\n-" + self.charString + " enchants " + targets[0].charString + " with the embodiment of fire granting great stats.";
            }
            if (rand == 1)
            {
                targets[0].power += 3;
                targets[0].defense += 3;
                targets[0].speed += 3;
                return "\n-" + self.charString + " enchants " + targets[0].charString + " with the embodiment of ice granting moderate stats.";
            }

            targets[0].power += 10;
            targets[0].defense += 10;
            targets[0].speed += 10;
            return "\n-" + self.charString + " enchants " + targets[0].charString + " with the embodiment of lightning granting astonishing stats.";
        }
    }
}
