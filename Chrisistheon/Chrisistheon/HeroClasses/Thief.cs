using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Thief : A_Hero
    {
        public Thief(string name = "Velka")
            : base(name, 80, 0, 8, 8, 15, "Thief", "A Devious Skulker. Watch your pockets.", 2)
        {
            List<string> weaponList = new List<string>();
            weaponList.Add("Bandit Dagger");
            weaponList.Add("Sleek Knife*");
            weaponList.Add("ShadowBlade**");

            this.weapons = weaponList;

            List<string> armorList = new List<string>();
            armorList.Add("Thief Hood");
            armorList.Add("Darkened Hood*");
            armorList.Add("Abyssal Hood**");

            this.armors = armorList;

            AddAbility(new BasicAttack());
            AddAbility(new Hide());
            AddAbility(new BackStab());
        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();
            if(this.Status == "Stealthed")
            {
                targs.Add(monsterP.RandomTarget);
                return AbilityList[2].use(this, targs);
            }


            int rand = Dungeon.gRandom.Next(0, 2);
            if (rand == 1)
            {
                targs.Add(monsterP.RandomTarget);
                return AbilityList[1].use(this, targs);
            }

            targs.Add(monsterP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }
    }
}