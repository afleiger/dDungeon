using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Paladin : A_Hero
    {
        public Paladin(string name = "Halnoth")
            : base(name, 200, 1, 5, 20, 3, "Paladin", "A holy warrior clad in plate-mail with lots of health.", 9)
        {
            List<string> weaponList = new List<string>();
            weaponList.Add("BroadSword");
            weaponList.Add("BroaderSword*");
            weaponList.Add("The Broadest Sword**");

            this.weapons = weaponList;

            List<string> armorList = new List<string>();
            armorList.Add("Plate-Mail");
            armorList.Add("Heavy Plate-Mail*");
            armorList.Add("Deadric Plate-Mail**");

            this.armors = armorList;

            AddAbility(new BasicAttack());
            AddAbility(new HolyStrike());
            AddAbility(new Harden());
            AddAbility(new LayOnHands());
        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();

            int rand = Dungeon.gRandom.Next(1, 101);
            //Holy Strike
            if (rand < 16 && AbilityList[1].slotsRequired <= this.spellSlots && this.health < this.maxHealth)
            {
                targs.Add(monsterP.RandomTarget);
                return AbilityList[1].use(this, targs);
            }
            //Harden
            if (rand < 26)
            {
                return AbilityList[2].use(this, targs);
            }
            //LayOnHands
            if (rand < 46 && AbilityList[3].slotsRequired <= this.spellSlots &&
                heroP.LowestHealthTarget.health - heroP.LowestHealthTarget.maxHealth < -60)
            {
                targs.Add(heroP.LowestHealthTarget);
                return AbilityList[3].use(this, targs);
            }

            targs.Add(monsterP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }

    }
}