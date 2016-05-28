using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Samurai : A_Hero
    {
        public Samurai(string name = "Nobunaga")
            : base(name, 90, 1, 25, 0, 9, "Samurai", "A fragile, yet devasting swordsman of superior skill.", 8)
        {
            List<string> weaponList = new List<string>();
            weaponList.Add("Steel Katana");
            weaponList.Add("Maramasa*");
            weaponList.Add("Chaos Blade**");

            this.weapons = weaponList;

            List<string> armorList = new List<string>();
            armorList.Add("Tattered Kimono");
            armorList.Add("Fine Kimono*");
            armorList.Add("Royal Kimono**");

            this.armors = armorList;

            AddAbility(new BasicAttack());
            AddAbility(new Seppuku());

        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();
            int rand = Dungeon.gRandom.Next(1, 101);
            if (rand < 20 && this.health < (this.maxHealth * .5) && this.power == this.maxPower && AbilityList[1].slotsRequired <= this.spellSlots)
            {
                return AbilityList[1].use(this, targs);
            }

            targs.Add(monsterP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }
    }
}
