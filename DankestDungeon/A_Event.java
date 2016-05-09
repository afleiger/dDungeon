package DankestDungeon;
public abstract class A_Event
{
   private char c;
   
   public A_Event(char c)
   {
      this.c = c;
   }

   public abstract int occur();//returns: 0 -> indicates wall/cannot move
                               //returns: 1 -> can move
                               //returns: 2 -> indicates door
   
   public String toString()
   {
      String ret = "" + c;
      return ret;
   }
}