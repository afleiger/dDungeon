using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Imp : A_Monster
    {

        public Imp()
            : base("Imp", 25, 15, 5, 14, "A fiendish, flying demon.", 1)
        {
            AddAbility(new ClawAttack());
            AddAbility(new TridentPoke());
        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();

            int rand = Dungeon.gRandom.Next(0, 2);
            if (rand == 1)
            {
                targs.Add(heroP.RandomTarget);
                return AbilityList[1].use(this, targs);
            }

            targs.Add(heroP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }
    }
}

