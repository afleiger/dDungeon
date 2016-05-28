using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class FallenWarrior : A_Hero
    {
        public FallenWarrior(string name = "The Forgotten")
            : base(name, 40, 0, 8, 10, 8, "FallenWarrior", "A Warrior who has long since been forgoten.", 11)
        {
            List<string> weaponList = new List<string>();
            weaponList.Add("Fallens Fist");
            weaponList.Add("Rusted Gauntlet*");
            weaponList.Add("Tatterd Blade**");

            this.weapons = weaponList;

            List<string> armorList = new List<string>();
            armorList.Add("Tattered Clothing");
            armorList.Add("Tattered Armor*");
            armorList.Add("Ancient Armor**");

            this.armors = armorList;

            AddAbility(new BasicAttack());
            AddAbility(new BlindRush());

        }

        public new void Damage(double dmg)
        {
            this.health -= dmg;
            if (this.health <= 0)
            {
                Random rand = new Random();
                int rng = rand.Next(0, 101);
                if (rng < 90)
                    this.health = this.maxHealth;
                else
                    this.health = 0;
            }
        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();
            int rand = Dungeon.gRandom.Next(1, 101);
            if (rand < 50)
            {
                return AbilityList[1].use(this, targs);
            }

            targs.Add(monsterP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }
    }

    
}
