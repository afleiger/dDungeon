using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Barbarian : A_Hero
    {
        public Barbarian(string name = "Conan")
            : base(name, 130, 3, 12, 10, 9, "Barbarian", "Crush your enemies. See them driven before you. Hear the lamentations of their women.", 12)
        {
            List<string> weaponList = new List<string>();
            weaponList.Add("Fallens Fist");
            weaponList.Add("Rusted Gauntlet*");
            weaponList.Add("Tatterd Blade**");

            this.weapons = weaponList;

            List<string> armorList = new List<string>();
            armorList.Add("Loin Cloth");
            armorList.Add("Loin Cloth and Helm*");
            armorList.Add("Tribal Leather Armor**");

            this.armors = armorList;

            AddAbility(new BasicAttack());
            AddAbility(new Enrage());
            AddAbility(new Cleave());

        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();
            int rand = Dungeon.gRandom.Next(1, 101);
            //enrage
            if (rand < 25)
            {
                return AbilityList[1].use(this, targs);
            }
            //cleave
            if (rand < 50)
            {
                targs.Add(monsterP.RandomTarget);
                return AbilityList[2].use(this, targs);
            }
            targs.Add(monsterP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }
    }


}
