using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class MonsterParty
    {
        private List<A_Monster> members;

        public MonsterParty()
        {
            members = new List<A_Monster>();
        }

        public MonsterParty(List<A_Monster> members)
        {
            this.members = members;
        }

        public int Size
        {
            get { return members.Count; }
        }

        public List<A_Monster> mList
        {
            get { return members; }
        }

        public A_Monster RandomTarget
        {
            get
            {
                int r = Dungeon.gRandom.Next(0, Size);
                while (members[r].Status == "Stealthed")
                {
                    r = Dungeon.gRandom.Next(0, Size);
                }
                return members[r]; 
            }
        }

        public A_Monster LowestHealthTarget
        {
            get
            {
                A_Monster lowest = monster1; ;
                foreach(A_Monster cur in members)
                {
                    if(cur.health < lowest.health)
                    {
                        lowest = cur;
                    }
                }
                return lowest;
            }
        }
        public A_Monster monster1
        {
            get { return members[0]; }
        }

        public A_Monster monster2
        {
            get { return members[1]; }
        }

        public A_Monster monster3
        {
            get { return members[2]; }
        }

        public double member1HealthPercent
        {
            get { return 100 * (members[0]).health / (members[0]).maxHealth; }
        }

        public double member2HealthPercent
        {
            get { return 100 * (members[1]).health / (members[1]).maxHealth; }
        }

        public double member3HealthPercent
        {
            get { return 100 * (members[2]).health / (members[2]).maxHealth; }
        }
    }
}
