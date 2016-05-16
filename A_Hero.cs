using System;

namespace Chrisistheon
{
    public class A_Hero : A_Entity
    {
        public A_Hero(string name, int hp, int pwr, int def, int spd) : base(name, hp, pwr, def, spd)
        {
        }

        public override int Attack()
        {
            int damage = 0;
            return damage;
        }

    }
}