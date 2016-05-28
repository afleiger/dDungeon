using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public abstract class A_Ability
    {
        private String abilityName;
        private int numberOfTargets;
        private string desc;
        private int slotsUsed;

        public A_Ability(string name, string desc, int slotsUsed = 0, int tar = 1)
        {
            this.abilityName = name;
            this.desc = desc;
            this.numberOfTargets = tar;
            this.slotsUsed = slotsUsed;
        }

        public string Description
        {
            get { return desc; }
        }

        public string Name
        {
            get { return abilityName; }
        }

        public int Targets
        {
            get { return numberOfTargets; }
        }

        public int slotsRequired
        {
            get { return slotsUsed; }
        }

        public abstract string use(A_Entity self, List<A_Entity> targets);
    }
}
