using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chrisistheon;

namespace Chrisistheon
{
    public class Tester
    {
      static void Main()
      {
          //Console.ReadLine();
         Dungeon dung = new Dungeon();
         //dung.printRoute();
      
         string userIn = "f";
         while(userIn != "q")
         {
            Console.Write(dung.GetRoomString());
            userIn = Console.ReadLine();
            switch(userIn)
            {
               case "w":
                  dung.moveUp();
                  break;
               case "a":
                  dung.moveLeft();
                  break;
               case "s":
                  dung.moveDown();
                  break;
               case "d":
                  dung.moveRight();
                  break;
            }
         }
      }

    }
}
