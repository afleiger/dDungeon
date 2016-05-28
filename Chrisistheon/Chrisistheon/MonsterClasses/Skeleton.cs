using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Skeleton : A_Monster
    {

        public Skeleton() : base("Skeleton", 50,5,10,3,"A soul-less animated undead warrior.", 0)
        {
            AddAbility(new ClawAttack());
        }
    }
}
