using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Enchanter : A_Hero
    {
        public Enchanter(string name = "Tim")
            : base(name, 100, 4, 5, 5, 9, "Enchanter", "A spellcaster who specializes in magically stengthening thier allies.", 6)
        {
            List<string> weaponList = new List<string>();
            weaponList.Add("Enchanter's Staff");
            weaponList.Add("Tribal Staff*");
            weaponList.Add("Ancient Rabbit Staff**");

            this.weapons = weaponList;

            List<string> armorList = new List<string>();
            armorList.Add("Enchanter's Garments");
            armorList.Add("Tribal Garments*");
            armorList.Add("Ancient Rabbit Garments**");

            this.armors = armorList;

            AddAbility(new BasicAttack());
            AddAbility(new EnchantWeapon());

        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();
            int rand = Dungeon.gRandom.Next(0, 2);
            if(rand == 0)
            {
                targs.Add(heroP.RandomTarget);
                return AbilityList[1].use(this, targs);
            }

            targs.Add(monsterP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }
    }
}