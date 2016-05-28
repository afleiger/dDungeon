using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
    class MonsterTile : A_Tile
    {
        public MonsterTile()
        {
            this.ch = 'M';
        }

        public override int occur()
        {
            Dungeon._infoString = "You Defeated the Terrible Monster!";

            return 3;
        }
    }
}
