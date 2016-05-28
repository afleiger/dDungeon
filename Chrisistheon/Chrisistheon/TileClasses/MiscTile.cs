using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    class MiscTile : A_Tile
    {
        public MiscTile()
        {
            this.ch = '?';
        }

        public override int occur()
        {
            Dungeon._encounterString = "misc";
            return 3;
        }
    }
}
