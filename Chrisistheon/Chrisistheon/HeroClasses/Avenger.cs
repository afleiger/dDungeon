using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Avenger : A_Hero
    {
        public Avenger(string name = "Villegard")
            : base(name, 90, 2, 12, 8, 12, "Avenger", "A robed holy warrior who utilizes miracles and a giant two-handed sword.", 4)
        {
            List<string> weaponList = new List<string>();
            weaponList.Add("GreatSword");
            weaponList.Add("Holy GreatSword*");
            weaponList.Add("Angelic GreatBlade**");

            this.weapons = weaponList;

            List<string> armorList = new List<string>();
            armorList.Add("Acolyte's Robe");
            armorList.Add("Stalker's Robe*");
            armorList.Add("Inquisitor Robes**");

            this.armors = armorList;

            AddAbility(new BasicAttack());
            AddAbility(new HolyStrike());
            AddAbility(new BladeDance());
            AddAbility(new DivineGrace());
        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();

            int rand = Dungeon.gRandom.Next(1, 101);
            if (rand < 40 &&  this.health < this.maxHealth)//HolyStrike
            {
                targs.Add(monsterP.RandomTarget);
                return AbilityList[1].use(this, targs);
            }
            if(rand < 50 && this.spellSlots >= AbilityList[2].slotsRequired)//Blade Dance
            {
                targs.Add(monsterP.RandomTarget);
                targs.Add(monsterP.RandomTarget);
                targs.Add(monsterP.RandomTarget);
                targs.Add(monsterP.RandomTarget);
                return AbilityList[2].use(this, targs);
            }
            if(rand < 60 && this.speed != (this.maxSpeed *2))// Divine Grace
            {
                return AbilityList[3].use(this, targs);
            }

            targs.Add(monsterP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }

    }
}