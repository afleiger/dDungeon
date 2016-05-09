package DankestDungeon;
public class Room
{
   private Tile[][] tiles;
   private String type;
   private boolean isSet;
   private int pX;
   private int pY;
   
   
   public Room()
   {
      //this.tiles = new Tile[20][40];
      this.isSet = false;
      this.type = "    ";
      this.pX = -1;
      this.pY = -1;
   }
   
   public boolean isSet()
   {
      return this.isSet;
   }
   
   public void setUpRoom(String type)
   {
      this.tiles = RoomFactory.genTiles(type);
   }
   
   /*public void setType(String type)
   {
      if(type.equals("")||type.equals("f")||type.equals("s"))
      {
         return;
      }
      if(type.length() == 1)
      {
         this.type = " " + type + "  ";
      }
      if(type.length() == 2)
      {
         this.type = " " + type + " ";
      }
      if(type.length() == 3)
      {
         this.type = type + " ";
      }
      if(type.length() == 4)
      {
         this.type = type;
      }
   }*/
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
   }
   
   public void printRoom()
   {
      System.out.print(" {"+type+"} ");
   }
   
   public void printTiles()
   {
      for(int i = 4; i < 17; i++)
      {
         for(int j = 4; j < 17; j++)
         {
            System.out.print(tiles[i][j]);
         }
         System.out.print("\n");
      }
   }
   
   public int move(char dir)
   {
      int nX = pX;
      int nY = pY;
      switch(dir)
      {
         case 'u':
            nX = pX -1;
            break;
         case 'd':
            nX = pX +1;
            break;
         case 'r':
            nY = pY +1;
            break;
         case 'l':
            nY = pY -1;
            break;
      }
      int spaceCode = tiles[nX][nY].occur();
      if(spaceCode == 1)
      {
         tiles[pX][pY] = new Tile();
         tiles[nX][nY] = new Tile("p");
         pX = nX;
         pY = nY;
      }
      if(spaceCode == 2)
      {
         tiles[pX][pY] = new Tile();
         pX = -1;
         pY = -1;
      }  
      return spaceCode;
   }
   
   public void setPlayer(int x, int y)
   {
      this.pX = x;
      this.pY = y;
      tiles[x][y] = new Tile("p");
   }
}