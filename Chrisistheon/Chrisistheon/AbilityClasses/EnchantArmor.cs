using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class EnchantArmor : A_Ability
    {
        public EnchantArmor()
            : base("Enchant Armor", "Magically strengthen target's armor with a random effect. Granting them defense till end of combat.", 0, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int rand = Dungeon.gRandom.Next(0, 3);
            if (rand == 0)
            {
                targets[0].defense += 6;
                return "\n-" + self.charString + " enchants " + targets[0].charString + "'s armor with fire granting great defense.";
            }
            if (rand == 1)
            {
                targets[0].defense += 3;
                return "\n-" + self.charString + " enchants " + targets[0].charString + "'s armor with ice granting moderate defense.";
            }

            targets[0].defense += 10;
            return "\n-" + self.charString + " enchants " + targets[0].charString + "'s armor with lightning granting astonishing defense.";
        }
    }
}
