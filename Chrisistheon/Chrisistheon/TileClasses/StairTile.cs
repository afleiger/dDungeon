using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public class StairTile : A_Tile
    {
        public StairTile()
        {
            this.ch = 'B';
        }

        public override int occur()
        {
            Dungeon._encounterString = "boss";
            return 3;
        }
    }
}
