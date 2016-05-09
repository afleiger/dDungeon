package DankestDungeon;
public class EmptyEvent extends A_Event
{ 
   public EmptyEvent()
   {
      super(' ');
   }

   public int occur()
   {
      return 1;
   }
}