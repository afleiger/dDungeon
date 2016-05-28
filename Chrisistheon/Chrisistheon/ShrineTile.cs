using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrisistheon
{
    class ShrineTile : A_Tile
    {
        public ShrineTile()
        {
            this.ch = 'S';
        }

        public override int occur()
        {
            Dungeon._infoString = "You recieve a blessing from the Shrine!";
            return 3;
        }
    }
}
