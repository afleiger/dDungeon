using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class LayOnHands : A_Ability
    {
        public LayOnHands()
            : base("Lay On Hands", "Heal a single target for a great amount.", 1, 1)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            double heal;
            ((A_Hero) self).spellSlots -= 1;
            heal = targets[0].maxHealth;
            targets[0].Heal(heal);
            return "\n-" + self.charString + " lays hands on " + targets[0].charString + " restoring " + ((int)heal) + " health.";
        }
    }
}