using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
   public class Tile
   {
      private A_Event eve;
   
      public Tile()
      {
         eve = new EmptyEvent();
      }

      public Tile(string type)
      {
         if(type == "w")
         {
            eve = new WallEvent();
         }
         if(type == "d")
         {
            eve = new DoorEvent();
         }
         if(type == "p")
         {
            eve = new PlayerEvent();
         }
      }
   
      public int occur()
      {
         return this.eve.occur();
      }
   
      public string toString()
      {
         return eve.toString();
      }
   }
}
