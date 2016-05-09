package DankestDungeon;
public class RoomFactory
{
   

   public static Tile[][] genTiles(String type)
   {
      Tile[][] ret = randomLayout();
      if(type.contains("s"))
      {
         ret[10][10] = new Tile("p");
         ret[10][16] = new Tile("d");
      }
      if(type.contains("u"))
      {
         ret[4][10] = new Tile("d");
      }
      if(type.contains("d"))
      {
         ret[16][10] = new Tile("d");
      }
      if(type.contains("r"))
      {
         ret[10][16] = new Tile("d");
      }
      if(type.contains("l"))
      {
         ret[10][4] = new Tile("d");
      }
      return ret; 
   }
   
   private static Tile[][] randomLayout()
   {
      Tile[][] ret = new Tile[20][20];
      initialize(ret);
      makeA(ret);
      return ret;
   }
   
   private static void makeA(Tile[][] ara)
   {
      for(int x = 4; x < 17; x++)
      {
         for(int y = 4; y < 17; y++)
         {
            if(x == 4 || x == 16 || y == 4 || y == 16)
            {
               ara[x][y] = new Tile("w");
            }
         }
      }
      
   }
   
   private static void initialize(Tile[][] ret)
   {
      for(int i = 0; i < 20; i++)
      {
         for(int j = 0; j < 20; j++)
         {
            ret[i][j] = new Tile();
         }
      }
   }
   
}