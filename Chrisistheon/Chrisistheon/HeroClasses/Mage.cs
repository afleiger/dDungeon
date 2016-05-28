using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Mage : A_Hero
    {
        public Mage(string name = "Ryzra")
            : base(name, 70, 5, 5, 5, 10, "Mage", "A robed spellcaster that controls the power of the elements.", 3)
        {
            List<string> weaponList = new List<string>();
            weaponList.Add("Splintered Staff");
            weaponList.Add("ArchStaff*");
            weaponList.Add("Zhonya's Staff**");

            this.weapons = weaponList;

            List<string> armorList = new List<string>();
            armorList.Add("Tattered Robes");
            armorList.Add("Dignified Robes*");
            armorList.Add("Zhonya's Robes**");

            this.armors = armorList;

            AddAbility(new BasicAttack());
            AddAbility(new FlameStrike());

        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();

            int rand = Dungeon.gRandom.Next(0, 2);
            if (rand == 1 && AbilityList[1].slotsRequired <= this.spellSlots && monsterP.Size > 1)
            {
                foreach(A_Entity cur in monsterP.mList)
                {
                    targs.Add(cur);
                }
                return AbilityList[1].use(this, targs);
            }

            targs.Add(monsterP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }
    }
}