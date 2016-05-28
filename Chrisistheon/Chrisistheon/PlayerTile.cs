using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
   public class PlayerTile : A_Tile
   {
      public PlayerTile()
      {
          this.ch = 'P';
      }
   
      public override int occur()
      {
         return 0;
      }
   }
}
