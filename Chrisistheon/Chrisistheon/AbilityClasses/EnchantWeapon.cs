using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class EnchantWeapon : A_Ability
    {
        public EnchantWeapon()
            : base("Enchant Weapon", "Magically strengthen target's weapon with a random effect. Granting them power till end of combat.", 0, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int rand = Dungeon.gRandom.Next(0, 3);
            if(rand == 0)
            {
                targets[0].power += 6;
                return "\n-" + self.charString + " enchants " + targets[0].charString + "'s weapon with fire granting great power.";
            }
            if (rand == 1)
            {
                targets[0].power += 3;
                return "\n-" + self.charString + " enchants " + targets[0].charString + "'s weapon with ice granting moderate power.";
            }

            targets[0].power += 10;
            return "\n-" + self.charString + " enchants " + targets[0].charString + "'s weapon with lightning granting astonishing power.";
        }
    }
}
