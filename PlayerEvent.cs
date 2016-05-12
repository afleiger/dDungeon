using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
   public class PlayerEvent : A_Event
   {
      public PlayerEvent()
      {
          this.ch = 'P';
      }
   
      public override int occur()
      {
         return 0;
      }
   }
}
