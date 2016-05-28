using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public abstract class A_Monster : A_Entity
    {
        private int mid;
        private string monsterToolTip;

        public A_Monster(string name, double maxHp, double pow, double def, double spd, string tt, int monsterID, int weaponDie = 6)
            : base(name, maxHp, pow, def, spd, weaponDie)
        {
            this.monsterToolTip = tt;
            this.mid = monsterID;
        }

        public string toolTip
        {
            get { return monsterToolTip; }
        }

        public int monsterID
        {
            get { return mid; }
        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();
            targs.Add(heroP.RandomTarget);
            return this.AbilityList[0].use(this, targs);
        }
    }
}
