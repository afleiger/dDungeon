using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    class MonsterTile : A_Tile
    {
        public MonsterTile()
        {
            this.ch = ' ';
        }

        public override int occur()
        {
            Dungeon._encounterString = "monster";
            return 3;
        }
    }
}
