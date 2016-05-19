using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            Boolean createDatabase = true;
            Database db = new Database();

            if (createDatabase)
            {
                db.connect();

                db.addHeroTouple("Warrior", 110, 11, 43, 6);
                db.addHeroTouple("Rogue", 85, 13, 21, 8);
                db.addHeroTouple("Cleric", 70, 5, 15, 5);
                db.addHeroTouple("Archer", 85, 13, 19, 6);
                db.addHeroTouple("Mage", 65, 15, 10, 6);
                db.addHeroTouple("Paladin", 200, 4, 98, 2);
                db.addHeroTouple("Sanik", 90, 8, 18, 11);
                db.addHeroTouple("Elementalist", 95, 9, 16, 4);
                db.addHeroTouple("Pikachu", 85, 9, 16, 10);
                db.addHeroTouple("Barbarian", 130, 12, 38, 5);
                db.addHeroTouple("Guardian", 120, 10, 46, 5);
                db.addHeroTouple("Assassin", 70, 11, 16, 4);
                db.addHeroTouple("Glass Cannon", 90, 35, 0, 5);
                db.addHeroTouple("Zombie", 60, 8, 33, 2);
                db.addHeroTouple("The Rock", 300, 3, 0, 5);
                db.addHeroTouple("Simba", 100, 12, 52, 4);

                db.addMonsterTouple("Small rat", 51, 5, 40, 3);
                db.addMonsterTouple("Wild dog", 60, 6, 50, 5);
                db.addMonsterTouple("Large Rat", 75, 11, 56, 5);
                db.addMonsterTouple("Zubat", 60, 8, 40, 7);

                db.addMonsterTouple("Goblin", 70, 6, 40, 6);
                db.addMonsterTouple("Rock", 10, 0, 190, 1);
                db.addMonsterTouple("Orc", 90, 7, 50, 4);
                db.addMonsterTouple("Fire Elemntal", 70, 11, 30, 7);
                db.addMonsterTouple("Ogre", 120, 8, 100, 5);

                db.addMonsterTouple("Skeleton", 100, 10, 40, 5);
                db.addMonsterTouple("Face Sucker", 69, 14, 34, 3);
                db.addMonsterTouple("Draugers", 120, 11, 46, 5);
                db.addMonsterTouple("Rabid Stalker", 110, 10, 50, 8);
                db.addMonsterTouple("Uruk-hai", 150, 13, 46, 6);
                db.addMonsterTouple("Wyven", 200, 18, 70, 7);

                db.addMonsterTouple("Dragon", 500, 25, 50, 20);

                db.addMonsterTouple("Chest Mimic lv 1", 90, 9, 40, 5);
                db.addMonsterTouple("Chest Mimic lv 2", 110, 10, 45, 5);
                db.addMonsterTouple("Chest Mimic lv 3", 130, 11, 50, 5);
                
                db.addRoomTouple("You enter a glorious, open hallway.");
                db.addRoomTouple("You enter a mundane kitchen.");
                db.addRoomTouple("You walk into a heavily used torture chamber...");
                db.addRoomTouple("The air stinks of rot. The corners are cesspools of garbage.");
                db.addRoomTouple("This room has mystical lights bouncing from the walls. It is quite magical.");
                db.addRoomTouple("You enter what appears to be an old classroom.");
                db.addRoomTouple("You enter a very, very dark room...");
                db.addRoomTouple("You enter a corroded bedroom. The bed seems to be only lightly used.");
                db.addRoomTouple("A magnificient library is laid out before you. One could spend years in here.");
                db.addRoomTouple("Blood is warm on the floor in this room...");
                db.addRoomTouple("You can hear bone-chilling screams rising from under the floor.");
                db.addRoomTouple("You can feel eyes on you in this room...");
                db.addRoomTouple("Your stomach churns as you enter a decrepid bathroom.");
                db.addRoomTouple("This room seems to have been used to throw festive dance parties.");
                db.addRoomTouple("You enter a seemingly mundane room.");
                db.addRoomTouple("You enter an armory, though it seems most of the blades are rusted and dull.");
                db.addRoomTouple("This room has many fantastic portraits hanging on the walls");
                db.addRoomTouple("You are struck with a miasma of dust as you enter this old room.");
                db.addRoomTouple("A fully-stocked bar is featured in this room. Perhaps drinking is not the greatest idea right now.");
                db.addRoomTouple("Small rats infest this room, sifting quickly through piles of unidentifiable refuse.");
                db.addRoomTouple("The darkness shifts as if toying with you.");
                db.addRoomTouple("This room appears to be filled with miniature tables and chairs.");
                db.addRoomTouple("You enter an old concert hall, the various instruments abandoned on stage have long been silent.");
                db.addRoomTouple("Official documents are scattered across the floor in this room.");
                db.addRoomTouple("You stumble over the large boulders and strange potholes which make up the floor of this battered passageway.");
                db.addRoomTouple("Trickling water runs delicately over the rocky walls of this room.");
                db.addRoomTouple("This room smells like delicious, freshly-baked bread.");
                db.addRoomTouple("You enter a lavish tomb, where an ancient person of great reknown was laid to rest.");
                db.addRoomTouple("You enter a wine aging room, countless barrels are stacked horizontally.");
                db.addRoomTouple("This quiet room seems to have been used for pursuing creative endeavors.");
                db.addRoomTouple("You enter an old bath house.");
                db.addRoomTouple("This room is breathing... You are unsettled by this.");
                db.addRoomTouple("You enter an ancient drawing room. Though some of these drawings appear to have just been drafted.");
                db.addRoomTouple("Silent clocks ominously fill every corner of this strange room.");
                db.addRoomTouple("You enter a prayer room.");
                db.addRoomTouple("You enter a salon.");
                db.addRoomTouple("You enter a lobby.");
                db.addRoomTouple("You enter a foyer.");
                db.addRoomTouple("This room is an ancient battlefield, the bones of the fallen, still clad in rusty armor.");
                db.addRoomTouple("You enter a simple room, its hearth has been cold for ages passed.");
                db.addRoomTouple("You enter a small study.");
                db.addRoomTouple("You enter an exquisitely decorated cathedral room.");
            }
            /*
            Random r = new Random();
            List<A_Entity> list = new List<A_Entity>();

            for (int j = 0; j < 7; j++)
            {
                int i = r.Next(1, 6);
                String s = db.getHeroName(i);
                list.Add(HeroFactory.createHero(s));
                //Console.WriteLine("Index " + i + " has the name " + s);
                //int[] stats = db.getClassStats(s);
                //Console.WriteLine("Class " + s + " has hp = " + stats[0] + ", pwr = " + stats[1] + ", def = " + stats[2] + ", spd = " + stats[3]);
            }
            Battle b = new Battle(list);
            b.battle();            

            Console.ReadKey();
            */
        }
    }
}
