using System.Collections.Generic;
using System.Linq;
using System;
namespace Chrisistheon
{
    public class Battle
    {
        private List<A_Entity> combatants;

        public Battle()
        {
            combatants = new List<A_Entity>();
        }
        
        public Battle(List<A_Entity> combatants)
        {
            this.combatants = combatants;
        }

        //This method will be tied to an event handler
        public void battle()
        {
            foreach (A_Entity curEntity in combatants)
                Console.WriteLine(curEntity.ToString());

            List<A_Entity> sortedList = battleOrder();
            Console.WriteLine();
            Console.WriteLine();
            foreach (A_Entity curEntity in sortedList)
            {
                Console.WriteLine(curEntity.ToString());
                //if (curEntity.curHp > 0)
                //    curEntity.Attack();
            }
        }
        //orders the fighters in decreasing order based on speed
        private List<A_Entity> battleOrder()
        {
            List<A_Entity> sortedList = combatants;
            sortedList = sortedList.OrderByDescending(o => o.spd).ToList();
            return sortedList;
        }
    }
}