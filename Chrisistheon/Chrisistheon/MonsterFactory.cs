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
            ret.Add(new Skeleton());
            ret.Add(new Skeleton());
            ret.Add(new Imp());


            return ret;
        }
    }
}
