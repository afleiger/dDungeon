using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Enrage : A_Ability
    {
        public Enrage()
            : base("Enrage", "Enrage yourself boosting your stats.", 1, 0)
        {

        }

        public override string use(A_Entity self, List<A_Entity> targets)
        {
            ((A_Hero)self).spellSlots -= this.slotsRequired;
            int rand = Dungeon.gRandom.Next(1, 101);
            if (rand <= 80)
            {
                self.defense -= 5;
                self.power += 5;
                self.speed += 5;
                return "\n-SUCCESS-" + self.charString + " successfully Enrages.";
            }
            return "\n-FAILURE-" + self.charString + "'s fails to enrage.";
        }
    }
}