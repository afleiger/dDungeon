using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
   public abstract class A_Tile
   {
      protected char ch;
   
      public A_Tile()
      {
         this.ch = ' ';
      }
      
      public abstract int occur();

      public override string ToString()
      {
          string ret = "" + ch;
          return ret;
      }
   }
}
