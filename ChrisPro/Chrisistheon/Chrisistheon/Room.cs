using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
    public class Room
    {
        private A_Tile[,] tiles;
        private String type;
        private bool isSet;
        private int pX;
        private int pY;
        private string roomGreeting;
        
        public Room()
        {
            //this.tiles = new Tile[20][40];
            this.isSet = false;
            this.type = "    ";
            this.pX = -1;
            this.pY = -1;
            this.roomGreeting = RoomFactory.randomRoomString();
        }

        public string roomString
        {
            get { return roomGreeting; }
            set { roomGreeting = value; }
        }

        public bool isSetUp()
        {
            return this.isSet;
        }

        public void setUpRoom(String type)
        {
            this.tiles = RoomFactory.genTiles(type);
        }

        public void setUpStart()
        {
            this.tiles = RoomFactory.genStart();
        }

        public String getType()
        {
            return type;
        }

        public void setRoom()
        {
            this.type = "room";
            this.isSet = true;
        }

        public void setStart()
        {
            this.type = "strt";
            this.isSet = true;
            pX = 10;
            pY = 10;
        }

        public void setFinish()
        {
            this.type = "fini";
            this.isSet = true;
            this.roomString = "You have found the exit. Congratulations!!!";
        }

        public void printRoom()
      {
         Console.Write(" {"+type+"} ");
      }

        public string GetTileString()
      {
          string ret = "";
         for(int i = 4; i < 17; i++)
         {
            for(int j = 4; j < 17; j++)
            {
               ret += tiles[i, j].ToString();
            }
            ret += "\n";
         }
         return ret;
      }

        public int move(char dir)
        {
            int nX = pX;
            int nY = pY;
            switch (dir)
            {
                case 'u':
                    nX = pX - 1;
                    break;
                case 'd':
                    nX = pX + 1;
                    break;
                case 'r':
                    nY = pY + 1;
                    break;
                case 'l':
                    nY = pY - 1;
                    break;
            }
            int spaceCode = tiles[nX, nY].occur();
            if (spaceCode == 1 || spaceCode == 3)
            {
                tiles[pX, pY] = new EmptyTile();
                tiles[nX, nY] = new PlayerTile();
                pX = nX;
                pY = nY;
            }
            if (spaceCode == 2)
            {
                tiles[pX, pY] = new EmptyTile();
                pX = -1;
                pY = -1;
            }
            return spaceCode;
        }

        public void setPlayer(int x, int y)
        {
            this.pX = x;
            this.pY = y;
            tiles[x, y] = new PlayerTile();
        }
    }
}
