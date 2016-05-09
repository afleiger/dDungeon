package DankestDungeon;
public class Tile
{
   private A_Event event;
   
   public Tile()
   {
      event = new EmptyEvent();
   }
   public Tile(String type)
   {
      if(type.equals("w"))
      {
         event = new WallEvent();
      }
      if(type.equals("d"))
      {
         event = new DoorEvent();
      }
      if(type.equals("p"))
      {
         event = new PlayerEvent();
      }
   }
   
   public int occur()
   {
      return this.event.occur();
   }
   
   public String toString()
   {
      return event.toString();
   }
}