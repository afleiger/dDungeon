using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChrisistheonGUI
{
    public abstract class A_Event
    {

        protected char ch;
        public A_Event()
        {
            this.ch = ' ';
        }
        public A_Event(char c)
        {
            this.ch = c;
        }

        public abstract int occur();//returns: 0 -> indicates wall/cannot move
        //returns: 1 -> can move
        //returns: 2 -> indicates door
        //returns: 3 -> indicates chest

        public string toString()
        {
            string ret = "" + ch;
            return ret;
        }
    }
}
