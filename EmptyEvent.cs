using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
   public class EmptyEvent : A_Event
   { 
      public EmptyEvent()
      {
         this.ch =' ';
      }
   
      public override int occur()
      {
         return 1;
      }
   }
}
