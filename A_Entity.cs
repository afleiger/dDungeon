using System;

namespace Chrisistheon
{
    public abstract class A_Entity
    {
        protected internal string className;
        protected internal int maxHP;
        protected int curHP;
        protected internal int pwr;
        protected internal int def;
        protected internal int spd;
        protected internal int comPwr;
        protected internal int comDef;
        protected internal int comSpd;

        public A_Entity(string className, int hp, int pwr, int def, int spd)
        {
            this.className = className;
            this.maxHP = hp;
            this.curHP = hp;
            this.pwr = pwr;
            this.def = def;
            this.spd = spd;
            this.comPwr = 0;
            this.comDef = 0;
            this.comSpd = 0;
        }

        public virtual string ClassName
        {
            get
            {
                return className;
            }
        }
        public virtual int curHp
        {
            get
            {
                return curHP;
            }
        }
        public virtual int Pwr
        {
            get
            {
                return pwr;
            }
        }
        public virtual int Def
        {
            get
            {
                return def;
            }
        }
        public virtual int Spd
        {
            get
            {
                return spd;
            }
        }

        public virtual int manipulateHealth(int hpChange)
        {
            curHP += hpChange;
            if (curHP > maxHP)
            {
                curHP = maxHP;
            }
            if (curHP < 0)
            {
                curHP = 0;
            }
            return curHP;
        }
        public abstract int Attack();

        public override String ToString()
        {
            return className + ": " + maxHP + ", " + pwr + ", " + def + ", " + spd;
        }


    }
}