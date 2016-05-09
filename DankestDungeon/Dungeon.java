package DankestDungeon;
public class Dungeon
{
   private Room[][] rooms;
   private Room currentRoom;
   private int cY;
   private int cX;
   
   public Dungeon()
   {
      this.rooms = new Room[21][21];
      for(int i = 0; i < 21; i++)
      {
         for(int j = 0; j < 21; j++)
         {
            rooms[i][j] = new Room();
         }
      }
      
      rooms[10][10].setStart();
      createRoute(rooms, 10, 11);
      substantiateRooms();
      currentRoom = rooms[10][10];
      cX = 10;
      cY = 10;
      
   }
   
   public void printRoute()
   {
      for(int i = 0; i < 21; i++)
      {
         for(int j = 0; j < 21; j++)
         {
            rooms[i][j].printRoom();
         }
         System.out.print("\n");
      }
   }
   
   private void createRoute(Room[][] rooms, int row, int col)
   {
      if(row == 2 || row == 18 || col == 2 || col == 18)//reaches edge
      {
         rooms[row][col].setFinish();
         return;
      }
      
      rooms[row][col].setRoom();
      int loop = 0;
      
      while(loop < 10)
      {
         double rand = Math.random() * 100;
         if(rand < 25 && (!rooms[row+1][col].isSet()))
         {
            createRoute(rooms, row+1, col);
            return;
         }
         if(rand >= 25 && rand < 50 && (!rooms[row][col-1].isSet()))
         {
            createRoute(rooms, row, col-1);
            return;
         }
         if(rand >= 50 && rand < 75 && (!rooms[row-1][col].isSet()))
         {
            createRoute(rooms, row-1, col);
            return;
         }
         if(rand >= 75 && (!rooms[row][col+1].isSet()))
         {
            createRoute(rooms, row, col+1);
            return;
         }
         loop ++;
      }
      rooms[row][col].setFinish();
   }
   
   private void substantiateRooms()
   {
      for(int i = 2; i < 19; i++)
      {
         for(int j = 2; j < 19; j++)
         {
            rooms[i][j].setUpRoom(getLayoutCode(i,j));//setType for testing >> eventually should be setUpRoom();
         }
      }
   }
   
   public void printItAll()
   {
      for(int i = 2; i < 19; i++)
      {
         for(int j = 2; j < 19; j++)
         {
            if(rooms[i][j].isSet())
            {
               rooms[i][j].printTiles();
            }
         }
      }

   }
   
   public void printCurrentRoom()
   {
      currentRoom.printTiles();
   }
   
   private String getLayoutCode(int i, int j)
   {
      String ret = "";
      if(!rooms[i][j].isSet())
      {
         return ret;
      }
      if(rooms[i][j].getType().equals("strt"))
      {
         return "s";
      }
      if(rooms[i][j].getType().equals("fini"))
      {
         return "f";
      }
      if(rooms[i-1][j].isSet()&& !(rooms[i-1][j].getType().equals("strt")))
      {
         ret = "u";
      }
      if(rooms[i+1][j].isSet()&& !(rooms[i+1][j].getType().equals("strt")))
      {
         ret = ret + "d";
      }
      if(rooms[i][j+1].isSet()&& !(rooms[i][j+1].getType().equals("strt")))
      {
         ret = ret + "r";
      }
      if(rooms[i][j-1].isSet()&& !(rooms[i][j-1].getType().equals("strt")))
      {
         ret = ret + "l";
      }
      return ret;
   }
   
   public void moveUp()
   {
      if(currentRoom.move('u') == 2)
      {
         currentRoom = rooms[cX-1][cY];
         currentRoom.setPlayer(15, 10);
         this.cX--;
      }
   }
   
   public void moveDown()
   {
      if(currentRoom.move('d') == 2)
      {
         currentRoom = rooms[cX+1][cY];
         currentRoom.setPlayer(5, 10);
         this.cX++;
      }
   }
   
   public void moveRight()
   {
      if(currentRoom.move('r') == 2)
      {
         currentRoom = rooms[cX][cY+1];
         currentRoom.setPlayer(10, 5);
         this.cY++;
      }
   }
   
   public void moveLeft()
   {
      if(currentRoom.move('l') == 2)
      {
         currentRoom = rooms[cX][cY-1];
         currentRoom.setPlayer(10, 15);
         this.cY--;
      }
   }
}