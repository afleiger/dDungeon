using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
    class BasicAttack : I_Ability
    {
        public int NumTargets()
        {
            return 1;
        }

        public void use(A_Entity self, A_Entity[] target)
        {
            double damage = self.Power*(target[0].Defense*.005);
            target[0].TakeDamage(damage);
        }
    }
}
