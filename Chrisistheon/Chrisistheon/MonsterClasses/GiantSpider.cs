using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class GiantSpider : A_Monster
    {

        public GiantSpider()
            : base("Giant Spider", 70, 7, 7, 9, "A large, deadly arachnid.", 2, 10)
        {
            AddAbility(new BiteAttack());
            AddAbility(new WebShot());
        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();

            int rand = Dungeon.gRandom.Next(1, 101); //WebShot
            if (rand < 20)
            {
                targs.Add(heroP.RandomTarget);
                targs.Add(heroP.RandomTarget);
                return AbilityList[1].use(this, targs);
            }

            targs.Add(heroP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }
    }
}