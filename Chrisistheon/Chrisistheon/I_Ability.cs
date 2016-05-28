using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
    interface I_Ability
    {
        void use(A_Entity self, A_Entity[] target);
        int NumTargets();
    }
}
