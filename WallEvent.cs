using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
   public class WallEvent : A_Event
   { 
      public WallEvent()
      {
          this.ch = '#';
      }
   
      public override int occur()
      {
         return 0;
      }
   }
}
