using System;

namespace Chrisistheon
{
    public class A_Monster : A_Entity
    {
        public A_Monster(string name, int hp, int pwr, int def, int spd) : base(name, hp, pwr, def, spd)
        {
        }

        public override int Attack()
        {
            int damage = 0;
            return damage;
        }
    }
}