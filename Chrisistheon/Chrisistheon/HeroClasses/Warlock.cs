using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Warlock : A_Hero
    {
        public Warlock(string name = "Klingst")
            : base(name, 100, 4, 5, 5, 9, "Warlock", "A master of the demonic arts.", 5)
        {
            List<string> weaponList = new List<string>();
            weaponList.Add("Sacrificial Dagger");
            weaponList.Add("Ceremonial Scimitar*");
            weaponList.Add("Demonic Nail**");

            this.weapons = weaponList;

            List<string> armorList = new List<string>();
            armorList.Add("Warlock Robes");
            armorList.Add("Ceremonial Clothes*");
            armorList.Add("Demonic Embrace**");

            this.armors = armorList;

            AddAbility(new BasicAttack());

        }
    }
}