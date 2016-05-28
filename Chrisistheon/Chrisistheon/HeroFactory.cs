using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class HeroFactory
    {
        private int[] picks;
        private static int ClassCount = 11;

        public HeroFactory()
        {
            picks = new int[2];
            picks[0] = 0;
            picks[1] = 0;
        }

        public void addPick(int cid)
        {
            if(picks[0] == 0)
            {
                picks[0] = cid;
            }
            else
            {
                picks[1] = cid;
            }
        }

        public A_Hero[] RandomHeroes()
        {
            A_Hero[] ret = new A_Hero[3];
            List<int> prev = new List<int>();

            for (int x = 0; x < 3; x++ )
            {
                int rand = Dungeon.gRandom.Next(1, ClassCount);
                while(rand == picks[0] || rand == picks[1] || prev.Contains(rand) )
                {
                    rand = Dungeon.gRandom.Next(1, ClassCount);
                }
                switch (rand)
                {
                    case 1:
                        ret[x] = new Warrior();
                        break;
                    case 2:
                        ret[x] = new Thief();
                        break;
                    case 3:
                        ret[x] = new Mage();
                        break;
                    case 4:
                        ret[x] = new Avenger();
                        break;
                    case 5:
                        ret[x] = new Warlock();
                        break;
                    case 6:
                        ret[x] = new Enchanter();
                        break;
                    case 7:
                        ret[x] = new Cleric();
                        break;
                    case 8:
                        ret[x] = new Samurai();
                        break;
                    case 9:
                        ret[x] = new Paladin();
                        break;
                    case 10:
                        ret[x] = new Archer();
                        break;
                }

                prev.Add(rand);
            }

            return ret;
        }
    }
}
