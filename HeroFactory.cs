using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
    class HeroFactory
    {
        public static A_Hero createHero(int index)
        {
            Database db = new Database();
            String className = db.getHeroName(index);
            int[] stats = db.getClassStats(className);
            return new A_Hero(className, stats[0], stats[1], stats[2], stats[3]);
        }
        public static A_Hero createHero(String className)
        {
            Database db = new Database();
            int[] stats = db.getClassStats(className);
            return new A_Hero(className, stats[0], stats[1], stats[2], stats[3]);
        }
    }
}
