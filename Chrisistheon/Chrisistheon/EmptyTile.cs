using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
   public class EmptyTile : A_Tile
   { 
      public EmptyTile()
      {
         this.ch =' ';
      }
   
      public override int occur()
      {
         return 1;
      }
   }
}
