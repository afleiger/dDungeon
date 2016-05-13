using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
    public class RoomFactory
    {
        private static int monsterRate = 25;
        private static int chestRate = 25;
        private static int shrineRate = 25;
        private static int miscRate = 25;
        //remaining chance out of 100 will result in no special tile at the spawn.

        public static string randomRoomString()
        {
            switch(Dungeon.gRandom.Next(0,42))
            {
                case 0: 
                    return "You enter a glorious, open hallway.";
                case 1:
                    return "You enter a mundane kitchen.";
                case 2:
                    return "You walk into a heavily used torture chamber...";
                case 3:
                    return "The air stinks of rot. The corners are cesspools of garbage.";
                case 4:
                    return "This room has mystical lights bouncing from the walls. It is quite magical.";
                case 5:
                    return "You enter what appears to be an old classroom.";
                case 6:
                    return "You enter a very, very dark room...";
                case 7:
                    return "You enter a corroded bedroom. The bed seems to be only lightly used.";
                case 8:
                    return "A magnificient library is laid out before you. One could spend years in here.";
                case 9:
                    return "Blood is warm on the floor in this room...";
                case 10:
                    return "You can hear bone-chilling screams rising from under the floor.";
                case 11:
                    return "You can feel eyes on you in this room...";
                case 12:
                    return "Your stomach churns as you enter a decrepid bathroom.";
                case 13:
                    return "This room seems to have been used to throw festive dance parties.";
                case 14:
                    return "You enter a seemingly mundane room.";
                case 15:
                    return "You enter an armory, though it seems most of the blades are rusted and dull.";
                case 16:
                    return "This room has many fantastic portraits hanging on the walls";
                case 17:
                    return "You are struck with a miasma of dust as you enter this old room.";
                case 18:
                    return "A fully-stocked bar is featured in this room. Perhaps drinking is not the greatest idea right now.";
                case 19:
                    return "Small rats infest this room, sifting quickly through piles of unidentifiable refuse.";
                case 20:
                    return "The darkness shifts as if toying with you.";
                case 21:
                    return "This room appears to be filled with miniature tables and chairs.";
                case 22:
                    return "You enter an old concert hall, the various instruments abandoned on stage have long been silent.";
                case 23:
                    return "Official documents are scattered across the floor in this room.";
                case 24:
                    return "You stumble over the large boulders and strange potholes which make up the floor of this battered passageway.";
                case 25:
                    return "Trickling water runs delicately over the rocky walls of this room.";
                case 26:
                    return "This room smells like delicious, freshly-baked bread.";
                case 27:
                    return "You enter a lavish tomb, where an ancient person of great reknown was laid to rest.";
                case 28:
                    return "You enter a wine aging room, countless barrels are stacked horizontally.";
                case 29:
                    return "This quiet room seems to have been used for pursuing creative endeavors.";
                case 30:
                    return "You enter an old bath house.";
                case 31:
                    return "This room is breathing... You are unsettled by this.";
                case 32:
                    return "You enter an ancient drawing room. Though some of these drawings appear to have just been drafted.";
                case 33:
                    return "Silent clocks ominously fill every corner of this strange room.";
                case 34:
                    return "You enter a prayer room.";
                case 35:
                    return "You enter a salon.";
                case 36:
                    return "You enter a lobby.";
                case 37:
                    return "You enter a foyer.";
                case 38:
                    return "This room is an ancient battlefield, the bones of the fallen, still clad in rusty armor.";
                case 39:
                    return "You enter a simple room, its hearth has been cold for ages passed.";
                case 40:
                    return "You enter a small study.";
                case 41:
                    return "You enter an exquisitely decorated cathedral room.";

            }
            return "";
        }


        public static A_Tile[,] genTiles(String type)
        {
            if(type.Contains("f"))
            {
                return genFinish();
            }
            if (type.Contains("s"))
            {
                return genStart();
            }

            A_Tile[,] ret = randomLayout();
            if (type.Contains("u"))
            {
                ret[4, 10] = new DoorTile();
            }
            if (type.Contains("d"))
            {
                ret[16, 10] = new DoorTile();
            }
            if (type.Contains("r"))
            {
                ret[10, 16] = new DoorTile();
            }
            if (type.Contains("l"))
            {
                ret[10, 4] = new DoorTile();
            }
            return ret;
        }

        public static A_Tile[,] genStart()
        {
            A_Tile[,] ret = new A_Tile[20, 20];
            initialize(ret);
            makeBase(ret);
            ret[10, 16] = new DoorTile();
            ret[10, 10] = new PlayerTile();

            return ret;
        }

        public static A_Tile[,] genFinish()
        {
            A_Tile[,] ret = new A_Tile[20, 20];
            initialize(ret);
            makeBase(ret);
            
            return ret;
        }

        private static A_Tile[,] randomLayout()
      {
         A_Tile[, ] ret = new A_Tile[20, 20];
         initialize(ret);
         makeBase(ret);
         int r = Dungeon.gRandom.Next(0, 10);

         if (r == 0)
             makeA(ret);
         else if (r == 1)
             makeB(ret);
         else if (r == 2)
             makeC(ret);
         else if (r == 3)
             makeD(ret);
         else if (r == 4)
             makeE(ret);
         else if (r == 5)
             makeF(ret);
         else if (r == 6)
             makeG(ret);
         else if (r == 7)
             makeH(ret);
         else if (r == 8)
             makeI(ret);
         else if (r == 9)
             makeJ(ret);
         return ret;
      }

        private static void makeBase(A_Tile[,] ara)
        {
            for (int x = 4; x < 17; x++)
            {
                for (int y = 4; y < 17; y++)
                {
                    if (x == 4 || x == 16 || y == 4 || y == 16)
                    {
                        ara[x, y] = new WallTile();
                    }
                }
            }
            
        }

        private static A_Tile randomSpawn()
        {
            int r = Dungeon.gRandom.Next(1, 101);
            if(r < monsterRate)
            {
                return new MonsterTile();
            }
            else if(r < chestRate + monsterRate)
            {
                return new ChestTile();
            }
            else if(r < chestRate + monsterRate + shrineRate)
            {
                return new ShrineTile();
            }
            else if(r < chestRate + monsterRate + shrineRate + miscRate)
            {
                return new MiscTile();
            }
            else
            {
                return new EmptyTile();
            }
            
        }


        private static void makeA(A_Tile[,] ara)//empty room
        {
            //Spawns
            ara[10, 10] = randomSpawn();
        }

        private static void makeB(A_Tile[,] ara)// hollow center box
        {
            ara[11, 9] = new WallTile();
            ara[9, 9] = new WallTile();
            ara[9, 11] = new WallTile();
            ara[11, 11] = new WallTile();

            //Spawns
            ara[10, 10] = randomSpawn();
        }

        private static void makeC(A_Tile[,] ara)// ladder shape
        {
            for(int i = 7; i <=13; i++)
            {
                for(int j = 7; j <=13; j++)
                {
                    if(i < j)
                        ara[i, j] = new WallTile();
                }
            }

            //Spawns
            ara[10, 10] = randomSpawn();
        }

        private static void makeD(A_Tile[,] ara)// ladder shape
        {
            for (int i = 7; i <= 13; i++)
            {
                for (int j = 7; j <= 13; j++)
                {
                    if (i > j)
                        ara[i, j] = new WallTile();
                }
            }

            //Spawns
            ara[10, 10] = randomSpawn();
        }

        private static void makeE(A_Tile[,] ara)//close 2x2 pillars
        {
            ara[14, 6] = new WallTile();
            ara[14, 7] = new WallTile();
            ara[14, 13] = new WallTile();
            ara[14, 14] = new WallTile();

            ara[13, 6] = new WallTile();
            ara[13, 7] = new WallTile();
            ara[13, 13] = new WallTile();
            ara[13, 14] = new WallTile();

            ara[6, 6] = new WallTile();
            ara[6, 7] = new WallTile();
            ara[6, 13] = new WallTile();
            ara[6, 14] = new WallTile();

            ara[7, 6] = new WallTile();
            ara[7, 7] = new WallTile();
            ara[7, 13] = new WallTile();
            ara[7, 14] = new WallTile();

            //Spawns
            ara[10, 10] = randomSpawn();
        }

        private static void makeF(A_Tile[,] ara)//far 2x2 pillars
        {
            ara[13, 7] = new WallTile();
            ara[13, 8] = new WallTile();
            ara[13, 12] = new WallTile();
            ara[13, 13] = new WallTile();

            ara[12, 7] = new WallTile();
            ara[12, 8] = new WallTile();
            ara[12, 12] = new WallTile();
            ara[12, 13] = new WallTile();

            ara[7, 7] = new WallTile();
            ara[7, 8] = new WallTile();
            ara[7, 12] = new WallTile();
            ara[7, 13] = new WallTile();

            ara[8, 7] = new WallTile();
            ara[8, 8] = new WallTile();
            ara[8, 12] = new WallTile();
            ara[8, 13] = new WallTile();

            //Spawns
            ara[10, 10] = randomSpawn();
        }

        private static void makeG(A_Tile[,] ara)//abnormal Shape
        {
            ara[8, 12] = new WallTile();
            ara[8, 13] = new WallTile();
            ara[7, 12] = new WallTile();
            ara[7, 13] = new WallTile();

            ara[11, 8] = new WallTile();
            ara[12, 8] = new WallTile();
            ara[12, 9] = new WallTile();
            ara[12, 10] = new WallTile();
            ara[12, 11] = new WallTile();
            ara[12, 12] = new WallTile();
            ara[12, 13] = new WallTile();

            //Spawns
            ara[10, 10] = randomSpawn();

        }

        private static void makeH(A_Tile[,] ara)// center pillar
        {
            for (int i = 8; i < 13; i++ )
            {
                for(int j = 8; j < 13; j++)
                {
                    ara[i, j] = new WallTile();
                }
            }

            //Spawns
            ara[6, 6] = randomSpawn();
        }

        private static void makeI(A_Tile[,] ara) //cross pattern
        {
            for (int i = 5; i <= 15; i++)
            {
                for(int j = 5; j <= 15; j++)
                {
                    if(i != 10 && j != 10 && i != 9 && i != 11 && j != 9 && j != 11)
                    {
                        ara[i, j] = new WallTile();
                    }
                }
            }

            //Spawns
            ara[10, 10] = randomSpawn();
        }

        private static void makeJ(A_Tile[,] ara)// diamond shape
        {
            ara[8, 10] = new WallTile();
            ara[12, 10] = new WallTile();

            ara[10, 8] = new WallTile();
            ara[10, 9] = new WallTile();
            ara[10, 10] = new WallTile();
            ara[10, 11] = new WallTile();
            ara[10, 12] = new WallTile();

            ara[9, 9] = new WallTile();
            ara[9, 10] = new WallTile();
            ara[9, 11] = new WallTile();

            ara[11, 9] = new WallTile();
            ara[11, 10] = new WallTile();
            ara[11, 11] = new WallTile();

            //Spawns
            ara[14, 14] = randomSpawn();
        }

        private static void initialize(A_Tile[,] ret)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    ret[i, j] = new EmptyTile();
                }
            }
        }

    }

}
