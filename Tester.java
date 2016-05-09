import java.util.*;
import DankestDungeon.*;
public class Tester
{
   public static void main(String[] args)
   {
   
      Dungeon dung = new Dungeon();
      dung.printRoute();
      
      Scanner kb = new Scanner(System.in);
      String userIn = "f";
      while(!userIn.equals("q"))
      {
         dung.printCurrentRoom();
         userIn = kb.nextLine();
         switch(userIn)
         {
            case "w":
               dung.moveUp();
               break;
            case "a":
               dung.moveLeft();
               break;
            case "s":
               dung.moveDown();
               break;
            case "d":
               dung.moveRight();
               break;
         }
      }
   }
}