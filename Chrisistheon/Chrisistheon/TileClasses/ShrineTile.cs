using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    class ShrineTile : A_Tile
    {
        public ShrineTile()
        {
            this.ch = 'S';
        }

        public override int occur()
        {
            Dungeon._encounterString = "shrine";
            return 3;
        }
    }
}
