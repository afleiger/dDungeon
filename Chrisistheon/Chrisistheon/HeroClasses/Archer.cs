using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Archer : A_Hero
    {
        public Archer(string name = "Ralph")
            : base(name, 85, 3, 13, 9, 8, "Archer", "A charming archer, who dispatches their foes from afar.", 10)
        {
            List<string> weaponList = new List<string>();
            weaponList.Add("Wooden Longbow");
            weaponList.Add("Bronze Longbow*");
            weaponList.Add("Steel Longbow**");

            this.weapons = weaponList;

            List<string> armorList = new List<string>();
            armorList.Add("Potato Sack");
            armorList.Add("Clothing*");
            armorList.Add("Leather Armor**");

            this.armors = armorList;

            AddAbility(new BasicAttack());
            AddAbility(new SureShot());
            AddAbility(new FlurryOfArrows());
            AddAbility(new DoubleShot());
        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();

            int rand = Dungeon.gRandom.Next(1, 101);
            //DoubleShot
            if (rand < 20 && AbilityList[3].slotsRequired <= this.spellSlots)
            {
                targs.Add(monsterP.RandomTarget);
                targs.Add(monsterP.RandomTarget);
                return AbilityList[3].use(this, targs);
            }
            //FlurryOfArrows
            if (rand < 30 && AbilityList[2].slotsRequired <= this.spellSlots)
            {
                targs.Add(monsterP.RandomTarget);
                return AbilityList[2].use(this, targs);
            }
            //SureShot
            if (rand < 35)
            {
                targs.Add(monsterP.RandomTarget);
                return AbilityList[1].use(this, targs);
            }

            targs.Add(monsterP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }

    }
}
