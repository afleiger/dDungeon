using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class DemonLord : A_Monster
    {

        public DemonLord()
            : base("Demon Lord", 500, 0, 20, 11, "An ancient demonic lord.", 0, 12)
        {
            AddAbility(new ClawAttack());
            AddAbility(new DemonRage());
            AddAbility(new Awaken());
        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();

            int rand = Dungeon.gRandom.Next(1, 101);

            if (rand < 33.3 && this.power > 6.66)//Awaken
            {
                foreach (A_Entity cur in heroP.mList)
                {
                    targs.Add(cur);
                }
                return AbilityList[2].use(this, targs);
            }
            if (rand < 66.6)//DemonRage
            {
                targs.Add(heroP.RandomTarget);
                return AbilityList[1].use(this, targs);
            }

            targs.Add(heroP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }
    }
}