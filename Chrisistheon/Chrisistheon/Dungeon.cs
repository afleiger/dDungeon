using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class Dungeon
    {
        public static string _infoString = "";
        public static string _encounterString = "";
        public static Random gRandom = new Random();
        

        private Room[, ] rooms;
        private Room currentRoom;
        private int cY;
        private int cX;

        public string infoString
        {
            get { return _infoString; }
            set { _infoString = value; }
        }

        public string encounterString
        {
            get { return _encounterString; }
            set { _encounterString = value; }
        }

        public Dungeon()
        {
         this.rooms = new Room[21, 21];
         for(int i = 0; i < 21; i++)
         {
            for(int j = 0; j < 21; j++)
            {
               rooms[i, j] = new Room();
            }
         }
      
         rooms[10, 10].setStart();
         createRoute(rooms, 10, 11);
         substantiateRooms();
         currentRoom = rooms[10, 10];
         cX = 10;
         cY = 10;
      
      }

        public void printRoute()
      {
         for(int i = 0; i < 21; i++)
         {
            for(int j = 0; j < 21; j++)
            {
               rooms[i, j].printRoom();
            }
            Console.Write("\n");
         }
      }

        private void createRoute(Room[,] rooms, int row, int col)
        {
            if (row == 2 || row == 18 || col == 2 || col == 18)//reaches edge
            {
                rooms[row, col].setFinish();
                return;
            }

            rooms[row, col].setRoom();
            int loop = 0;

            while (loop < 10)
            {
                double rand = Dungeon.gRandom.Next(0, 101);
                if (rand < 25 && (!rooms[row + 1, col].isSetUp()))
                {
                    createRoute(rooms, row + 1, col);
                    return;
                }
                if (rand >= 25 && rand < 50 && (!rooms[row, col - 1].isSetUp()))
                {
                    createRoute(rooms, row, col - 1);
                    return;
                }
                if (rand >= 50 && rand < 75 && (!rooms[row - 1, col].isSetUp()))
                {
                    createRoute(rooms, row - 1, col);
                    return;
                }
                if (rand >= 75 && (!rooms[row, col + 1].isSetUp()))
                {
                    createRoute(rooms, row, col + 1);
                    return;
                }
                loop++;
            }
            rooms[row, col].setFinish();
        }

        private void substantiateRooms()
        {
            for (int i = 2; i < 19; i++)
            {
                for (int j = 2; j < 19; j++)
                {
                    rooms[i, j].setUpRoom(getLayoutCode(i, j));
                }
            }
        }

        public string GetRoomString()
        {
            return currentRoom.GetTileString();
        }

        private String getLayoutCode(int i, int j)
        {
            String ret = "";
            if (!rooms[i, j].isSetUp())
            {
                return ret;
            }
            if (rooms[i, j].getType() == "strt")
            {
                return "s";
            }
            if (rooms[i, j].getType() == "fini")
            {
                return "f";
            }
            if (rooms[i - 1, j].isSetUp() && !(rooms[i - 1, j].getType() == "strt"))
            {
                ret = "u";
            }
            if (rooms[i + 1, j].isSetUp() && !(rooms[i + 1, j].getType() == "strt"))
            {
                ret = ret + "d";
            }
            if (rooms[i, j + 1].isSetUp() && !(rooms[i, j + 1].getType() == "strt"))
            {
                ret = ret + "r";
            }
            if (rooms[i, j - 1].isSetUp() && !(rooms[i, j - 1].getType() == "strt"))
            {
                ret = ret + "l";
            }
            return ret;
        }

        public void moveUp()
        {
            if (currentRoom.move('u') == 2)
            {
                currentRoom = rooms[cX - 1, cY];
                currentRoom.setPlayer(15, 10);
                this.cX--;
                infoString = currentRoom.roomString;
            }
        }

        public void moveDown()
        {
            if (currentRoom.move('d') == 2)
            {
                currentRoom = rooms[cX + 1, cY];
                currentRoom.setPlayer(5, 10);
                this.cX++;
                infoString = currentRoom.roomString;
            }
        }

        public void moveRight()
        {
            if (currentRoom.move('r') == 2)
            {
                currentRoom = rooms[cX, cY + 1];
                currentRoom.setPlayer(10, 5);
                this.cY++;
                infoString = currentRoom.roomString;
            }
        }

        public void moveLeft()
        {
            if (currentRoom.move('l') == 2)
            {
                currentRoom = rooms[cX, cY - 1];
                currentRoom.setPlayer(10, 15);
                this.cY--;
                infoString = currentRoom.roomString;
            }
        }
    }
}
