using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public static class MonsterFactory
    {
        public static List<A_Monster> randomMonsters()
        {
            List<A_Monster> ret = new List<A_Monster>();
            int rand = Dungeon.gRandom.Next(1, 4);
            switch(rand)
            {
                case 1:
                    ret.Add(new Skeleton());
                    ret.Add(new Imp());
                    break;
                case 2:
                    ret.Add(new GiantSpider());
                    ret.Add(new Skeleton());
                    break;
                case 3:
                    ret.Add(new Imp());
                    ret.Add(new GiantSpider());
                    break;
                case 4:
                    ret.Add(new Skeleton());
                    ret.Add(new GiantSpider());
                    ret.Add(new Imp());
                    break;
            }
            return ret;
        }

        public static List<A_Monster> randomBoss()
        {
            List<A_Monster> ret = new List<A_Monster>();

            ret.Add(new DemonLord());

            return ret;
        }
    }
}
