using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public abstract class A_Hero : A_Entity
    {
        private string classToolTip;
        private int slots;
        private int curSlots;
        private List<string> weaps;
        private List<string> arms;
        private int cid;
        private int curWeaponLvl;
        private int curArmorLvl;
        private string _className;

        public A_Hero(string charName, double maxHp, int maxSlots, double pow, double def, double spd, string className, string tt, int classID, int weaponDie = 6)
            : base(charName, maxHp, pow, def, spd, weaponDie)
        {
            this.slots = maxSlots;
            this.curSlots = maxSlots;
            this.classToolTip = tt;
            this.cid = classID;
            this.curWeaponLvl = 0;
            this.curArmorLvl = 0;
            this._className = className;
        }

        public List<string> weapons
        {
            get { return weaps; }
            set { weaps = value; }
        }

        public List<string> armors
        {
            get { return arms; }
            set { arms = value; }
        }

        public int classID
        {
            get { return cid; }
        }

        public int maxSlots
        {
            get { return slots; }
            set { slots = value;
            curSlots = value;
            }
        }

        public int spellSlots
        {
            get { return curSlots; }
            set { curSlots = value;
            if (curSlots > slots)
            {
                curSlots = slots;
            }
            }
        }

        public string toolTip
        {
            get { return classToolTip; }
            set { classToolTip = value; }
        }

        public string classString
        {
            get { return _className; }
            set { _className = value; }
        }

        public string currentWeapon
        {
            get { return weaps[curWeaponLvl]; }
        }

        public string currentArmor
        {
            get { return arms[curArmorLvl]; }
        }

        public void restoreAll()
        {
            if (health < maxHealth)
            {
                health = maxHealth;
            }
            if (spellSlots < maxSlots)
            {
                spellSlots = maxSlots;
            }
        }

        public void upgradeWeapon()
        {
            this.curWeaponLvl++;
            if(curWeaponLvl > 2)
            {
                curWeaponLvl = 2;
            }
            else
            {
                maxPower += 5;
            }
        }

        public void upgradeArmor()
        {
            this.curArmorLvl++;
            if (curArmorLvl > 2)
            {
                curArmorLvl = 2;
            }
            else
            {
                maxDefense += 5;
            }
        }

        public override string TakeTurn(Party heroP, MonsterParty monsterP)
        {
            List<A_Entity> targs = new List<A_Entity>();
            targs.Add(monsterP.RandomTarget);
            return AbilityList[0].use(this, targs);
        }
        
    }
}
