using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    class ChestTile : A_Tile
    {
        public ChestTile()
        {
            this.ch = 'C';
        }

        public override int occur()
        {
            Dungeon._encounterString = "chest";
            return 3;
        }
    }
}
