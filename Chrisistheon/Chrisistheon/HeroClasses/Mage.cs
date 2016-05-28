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
            : base(name, 70, 5, 8, 5, 10, "Mage", "A robed spellcaster that controls the power of the elements.", 3)
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
            AddAbility(new LightningStrike());
            AddAbility(new IcicleShield());

        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();

            int rand = Dungeon.gRandom.Next(1, 101);
            if (rand < 25 && AbilityList[1].slotsRequired <= this.spellSlots && monsterP.Size > 1)//Flame Strike
            {
                foreach(A_Entity cur in monsterP.mList)
                {
                    targs.Add(cur);
                }
                return AbilityList[1].use(this, targs);
            }
            if (rand < 50 && AbilityList[2].slotsRequired <= this.spellSlots)//Lightning Strike
            {
                targs.Add(monsterP.RandomTarget);
                return AbilityList[2].use(this, targs);
            }
            if(rand < 75)//Basic
            {
                targs.Add(monsterP.RandomTarget);
                return AbilityList[0].use(this, targs);
            }

            foreach (A_Entity cur in heroP.mList) //Icicle
            {
                targs.Add(cur);
            }
            return AbilityList[3].use(this, targs);

        }
    }
}