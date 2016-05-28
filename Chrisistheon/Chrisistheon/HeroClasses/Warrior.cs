using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Warrior : A_Hero
    {
        public Warrior(string name = "Torgar")
            : base(name, 100, 0, 11, 15, 6, "Warrior", "A robust fighter who uses sword and shield.", 1)
        {
            List<string> weaponList = new List<string>();
            weaponList.Add("Bronze Sword");
            weaponList.Add("Steel Sword*");
            weaponList.Add("Master Sword**");

            this.weapons = weaponList;

            List<string> armorList = new List<string>();
            armorList.Add("Bronze Shield");
            armorList.Add("Steel Shield*");
            armorList.Add("Great Iron Bulwark**");

            this.armors = armorList;

            AddAbility(new BasicAttack());

        }
    }
}
