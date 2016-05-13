using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
    class MiscTile : A_Tile
    {
        public MiscTile()
        {
            this.ch = '?';
        }

        public override int occur()
        {
            Dungeon._infoString = "You evade the sneaky trap!";
            return 3;
        }
    }
}
