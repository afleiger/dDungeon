using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
   public class DoorTile : A_Tile
   { 
      public DoorTile()
      {
          this.ch = ' ';
      }
   
      public override int occur()
      {
         return 2;
      }
   }
}
