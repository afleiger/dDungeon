using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ChrisistheonGUI
{
    public class Party
    {
        private List<A_Hero> members;
        private int potionCount;
        
        public Party()
        {
            members = new List<A_Hero>();
            potionCount = 1;
        }

        public string playerName
        {
            get { return members[0].charString; }
        }

        public A_Hero RandomTarget
        {
            get
            {
                int r = 0;
                int x = 0;
                while(x < 10)
                {
                    r = Dungeon.gRandom.Next(0, members.Count);

                    if(members[r].Status != "Stealthing")
                    {
                        return members[r];
                    }
                    x++;
                }
                return members[r];
            }
        }

        public A_Hero LowestHealthTarget
        {
            get
            {
                A_Hero lowest = player1;
                foreach (A_Hero cur in members)
                {
                    if (cur.health < lowest.health)
                    {
                        lowest = cur;
                    }
                }
                return lowest;
            }
        }

        public List<A_Hero> mList
        {
            get { return members; }
        }

        public A_Hero player1
        {
            get { return members[0]; }
        }

        public A_Hero player2
        {
            get { return members[1]; }
        }

        public A_Hero player3
        {
            get { return members[2]; }
        }

        public string playerClass
        {
            get { return members[0].classString; }
        }

        public string member1Name
        {
            get { return (members[1]).charString; }
        }

        public string member2Name
        {
            get { return (members[2]).charString; }
        }

        public string member1Class
        {
            get { return (members[1]).classString; }
        }

        public string member2Class
        {
            get { return (members[2]).classString; }
        }

        public double playerHealthPercent
        {
            get { return (members[0].health / members[0].maxHealth) * 100; }
        }

        public double member1HealthPercent
        {
            get { return 100 * (members[1]).health / (members[1]).maxHealth; }
        }

        public double member2HealthPercent
        {
            get { return 100 * (members[2]).health / (members[2]).maxHealth; }
        }

        public void restorePartyMembers()
        {
            player1.restoreAll();
            player2.restoreAll();
            player3.restoreAll();
        }

        public int potions
        {
            get { return potionCount; }
            set { potionCount = value; }
        }

        public void addMember(A_Hero member)
        {
            members.Add(member);
        }

        public void setStatsToDefault()
        {
            player1.power = player1.maxPower;
            player2.power = player2.maxPower;
            player3.power = player3.maxPower;

            player1.defense = player1.maxDefense;
            player2.defense = player2.maxDefense;
            player3.defense = player3.maxDefense;

            player1.speed = player1.maxSpeed;
            player2.speed = player2.maxSpeed;
            player3.speed = player3.maxSpeed;

            player1.Status = "Normal";
            player2.Status = "Normal";
            player3.Status = "Normal";

            player2.HasDied = false;
            player3.HasDied = false;

            if(player2.IsDead)
            {
                player2.health = 1;
            }
            if (player3.IsDead)
            {
                player3.health = 1;
            }
        }
    }
}
