using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class IcicleShield : A_Ability
    {
        public IcicleShield()
            : base("Icicle Shield", "Summon shields of ice to protect your entire party, slightly buffing thier defenses.", 0, -2)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            int attackRoll = Dungeon.gRandom.Next(1, 101);
            double toHit = 75 + self.speed;
            if (attackRoll > toHit)
            {
                return "\n-FAIL-" + self.charString + " attempts to cast Icicle Shield, but it failed.";
            }
            foreach (A_Entity tar in targets)
            {
                tar.defense += 3;
            }
            return "\n-SUCCESS-" + self.charString + " casts Icicle Shield, thier allies defenses are bolstered.";
        }
    }
}
