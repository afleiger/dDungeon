﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
   public class WallTile : A_Tile
   { 
      public WallTile()
      {
          this.ch = '#';
      }
   
      public override int occur()
      {
         return 0;
      }
   }
}
