using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public abstract class A_Entity : IComparable<A_Entity>
    {
        private List<A_Ability> abs;

        private double maxHp;
        private double currentHp;
        private double pow;
        private double currentPow;
        private double def;
        private double currentDef;
        private double spd;
        private double currentSpd;
        private string name;
        private string stat;

        private bool _hasDied;

        private bool _isPlayer;
        private int weaponDie;

        public A_Entity(string charName, double maxHp, double pow, double def, double spd, int weaponDie)
        {
            this.maxHp = maxHp;
            this.pow = pow;
            this.def = def;
            this.spd = spd;
            this.name = charName;
            this.weaponDie = weaponDie;
            
            abs = new List<A_Ability>();
            currentHp = maxHp;
            currentDef = def;
            currentPow = pow;
            currentSpd = spd;

            _hasDied = false;

            stat = "Normal";
        }

        public List<A_Ability> AbilityList
        {
            get { return abs; }
        }

        public bool IsPlayer
        {
            get { return _isPlayer; }
            set { _isPlayer = value; }
        }

        public bool IsDead
        {
            get {return currentHp == 0;}
        }

        public bool HasDied
        {
            get { return _hasDied; }
            set { _hasDied = value; }
        }

        public string Status
        {
            get { return stat; }
            set { stat = value; }
        }

        public double power
        {
            get { return currentPow; }
            set { currentPow = value;
            if (currentPow > (maxPower * 2))
            {
                currentPow = maxPower * 2;
            }
            }
        }

        public double maxPower
        {
            get { return pow; }
            set { pow = value;
            currentPow = value;
                if(pow < 0)
                {
                    maxPower = 0;
                }
            }
        }

        public double defense
        {
            get { return currentDef; }
            set { currentDef = value;
            if (currentDef > maxDefense * 2)
            {
                currentDef = maxDefense * 2;
            }
            }
        }

        public double maxDefense
        {
            get { return def; }
            set { def = value;
            currentDef = value; }
        }

        public double speed
        {
            get { return currentSpd; }
            set { currentSpd = value;
            if (currentSpd > maxSpeed * 2)
            {
                currentSpd = maxSpeed * 2;
            }
            }
        }

        public double maxSpeed
        {
            get { return spd; }
            set { spd = value;
            currentSpd = value;
            }
        }

        public double health
        {
            get { return currentHp; }
            set { currentHp = value; }
        }

        public double maxHealth
        {
            get { return maxHp; }
            set { maxHp = value;
            currentHp = value;
            }
        }

        public string charString
        {
            get { return name; }
            set { name = value; }
        }

        public int ModifyDie
        {
            get { return Dungeon.gRandom.Next(0, weaponDie); }
            set { weaponDie = weaponDie + value; }
        }

        public double DamageReduction
        {
            get { return this.currentDef * .01; }
        }

        public void Damage(double dmg)
        {
            this.currentHp -= dmg;
            if(currentHp <= 0)
            {
                currentHp = 0;
            }
        }

        public void Heal(double heal)
        {
            this.currentHp += heal;
            if(currentHp > maxHp)
            {
                currentHp = maxHp;
            }
        }

        public void ResetStats()
        {
            this.currentSpd = spd;
            this.currentDef = def;
            this.currentPow = pow;
        }

        public abstract string TakeTurn(Party heroP, MonsterParty monsterP);

        protected void AddAbility(A_Ability addMe)
        {
            abs.Add(addMe);
        }

        public int NumberOfAbilities
        {
            get { return abs.Count; }
        }

        public int CompareTo(A_Entity other)
        {
            return (int)(other.spd - this.spd) ;
        }

        int IComparable<A_Entity>.CompareTo(A_Entity other)
        {
            return (int)(other.spd - this.spd);
        }
    }
}
