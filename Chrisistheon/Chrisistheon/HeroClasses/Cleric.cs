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
            : base(name, 90, 2, 5, 13, 5, "Cleric", "A bringer of light and healing.", 7)
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
            AddAbility(new SacredShield());
            AddAbility(new UnleashHeaven());

        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();

            if (heroP.LowestHealthTarget.health < 20 && this.spellSlots >= AbilityList[3].slotsRequired) // Unleash Heaven
            {
                foreach (A_Entity cur in heroP.mList)
                {
                    targs.Add(cur);
                }
                return AbilityList[3].use(this, targs);
            }

            int rand = Dungeon.gRandom.Next(1, 101);
            if (rand < 50 && heroP.LowestHealthTarget.health - heroP.LowestHealthTarget.maxHealth < -20) //Flash Heal
            {
                targs.Add(heroP.LowestHealthTarget);
                return AbilityList[1].use(this, targs);
            }
            if(rand < 75) //Sacred Shield
            {
                targs.Add(heroP.LowestHealthTarget);
                return AbilityList[2].use(this, targs);
            }
            targs.Add(monsterP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }

    }
}
