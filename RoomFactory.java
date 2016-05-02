package DankestDungeon;
public class RoomFactory
{
   public static Tile[][] genTiles(String type)
   {
      if(type.equals("s"))
      {
         return genStart();
      }
      if(type.equals("f"))
      {
         return genFinish();
      }
      if(type.equals("u"))
      {
         return genU();
      }
      if(type.equals("d"))
      {
         return genD();
      }
      if(type.equals("r"))
      {
         return genR();
      }
      if(type.equals("l"))
      {
         return genL();
      }
      if(type.equals("ud"))
      {
         return genUD();
      }
      if(type.equals("ur"))
      {
         return genUR();
      }
      if(type.equals("ul"))
      {
         return genUL();
      }
      if(type.equals("dr"))
      {
         return genDR();
      }
      if(type.equals("dl"))
      {
         return genDL();
      }
      if(type.equals("rl"))
      {
         return genRL();
      }
      if(type.equals("udr"))
      {
         return genUDR();
      }
      if(type.equals("udl"))
      {
         return genUDL();
      }
      if(type.equals("url"))
      {
         return genURL();
      }
      if(type.equals("drl"))
      {
         return genDRL();
      }
      if(type.equals("udrl"))
      {
         return genUDRL();
      }
      return null;
   }
   
   private static Tile[][] genStart()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[2][4] = new Tile("d");
      ret[2][2] = new Tile("p");
      return ret;
   }
   private static Tile[][] genFinish()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      return ret;
   }
   private static Tile[][] genU()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[0][2] = new Tile("d");
      return ret;
   }
   private static Tile[][] genD()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[4][2] = new Tile("d");
      return ret;
   }
   private static Tile[][] genR()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[2][4] = new Tile("d");
      return ret;
   }
   private static Tile[][] genL()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[2][0] = new Tile("d");
      return ret;
   }
   private static Tile[][] genUD()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[0][2] = new Tile("d");
      ret[4][2] = new Tile("d");
      return ret;
   }
   private static Tile[][] genUR()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[0][2] = new Tile("d");
      ret[2][4] = new Tile("d");
      return ret;
   }
   private static Tile[][] genUL()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[0][2] = new Tile("d");
      ret[2][0] = new Tile("d");
      return ret;
   }
   private static Tile[][] genDR()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[4][2] = new Tile("d");
      ret[2][4] = new Tile("d");
      return ret;
   }
   private static Tile[][] genDL()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[4][2] = new Tile("d");
      ret[2][0] = new Tile("d");
      return ret;
   }
   private static Tile[][] genRL()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[2][4] = new Tile("d");
      ret[2][0] = new Tile("d");
      return ret;
   }
   private static Tile[][] genUDR()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[0][2] = new Tile("d");
      ret[4][2] = new Tile("d");
      ret[2][4] = new Tile("d");
      return ret;
   }
   private static Tile[][] genUDL()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[0][2] = new Tile("d");
      ret[4][2] = new Tile("d");
      ret[2][0] = new Tile("d");
      return ret;
   }
   private static Tile[][] genURL()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[0][2] = new Tile("d");
      ret[2][4] = new Tile("d");
      ret[2][0] = new Tile("d");
      return ret;
   }
   private static Tile[][] genDRL()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[4][2] = new Tile("d");
      ret[2][4] = new Tile("d");
      ret[2][0] = new Tile("d");
      return ret;
   }
   private static Tile[][] genUDRL()
   {
      Tile[][] ret = new Tile[5][5];
      initialize(ret);
      ret[0][2] = new Tile("d");
      ret[4][2] = new Tile("d");
      ret[2][4] = new Tile("d");
      ret[2][0] = new Tile("d");
      return ret;
   }
   private static void initialize(Tile[][] ret)
   {
      for(int i = 0; i < 5; i++)
      {
         for(int j = 0; j < 5; j++)
         {
            if(i == 0 || i == 4 || j == 0 || j == 4)
            {
               ret[i][j] = new Tile("w");
            }
            else
            {
               ret[i][j] = new Tile();
            }
         }
      }
   }
   
}