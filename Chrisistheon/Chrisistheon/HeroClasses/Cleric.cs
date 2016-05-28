using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Cleric : A_Hero
    {
        public Cleric(string name = "Pesante")
            : base(name, 90, 3, 8, 13, 7, "Cleric", "A bringer of light and healing.", 7)
        {
            List<string> weaponList = new List<string>();
            weaponList.Add("Flanged Mace");
            weaponList.Add("Heavy Mace*");
            weaponList.Add("Light's Beacon**");

            this.weapons = weaponList;

            List<string> armorList = new List<string>();
            armorList.Add("Saint's Vestments");
            armorList.Add("Holy Mail*");
            armorList.Add("Light's Fortitude**");

            this.armors = armorList;

            AddAbility(new BasicAttack());
            AddAbility(new FlashHeal());

        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();

            int rand = Dungeon.gRandom.Next(0, 2);
            if (rand == 1 && heroP.LowestHealthTarget.health - heroP.LowestHealthTarget.maxHealth < -20)
            {
                targs.Add(heroP.LowestHealthTarget);
                return AbilityList[1].use(this, targs);
            }

            targs.Add(monsterP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }

    }
}
