import javax. swing.*;
import java.awt.event.ActionListener;
import java.awt.event.*;
public class GraphicalUserInterface extends JFrame implements ActionListener, KeyListener {

   private JLabel mapLabel;
   private JTextArea mapTextBox;
   private JLabel textLabel;
   private JTextArea TextBox;
   private JButton button1;
   private JButton button2;
   private JButton button3;
   private JButton potionButton;
   private JButton upArrow;
   private JButton downArrow;
   private JButton leftArrow;
   private JButton rightArrow;
   private ActionEvent event;
   private KeyEvent key;
	
   public GraphicalUserInterface(){
	  super();
      this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
      this.pack();
      this.setSize(700,700);
   	//Map Label Settings
      mapLabel= new JLabel("Map");
      mapLabel.setBounds(10, 0, 25, 25);
   	
   	//mapTextBox Settings
      mapTextBox= new JTextArea();
      mapTextBox.setBounds(10, 25, 665, 200);
      mapTextBox.setEditable(false);

   	//TextLabel
      textLabel= new JLabel("Interaction");
      textLabel.setBounds(10, 215, 100, 50);
   	
   	//TextBox
      TextBox= new JTextArea();
      TextBox.setBounds(10, 250, 665, 200);
      TextBox.setEditable(false);
   	
   	//button1
      button1= addButton("1",10,460,50,40);
   	
   	//button2
      button2 = addButton("2",65, 460, 50, 40); 
   	
   	//button3
      button3= addButton("3",120, 460, 50, 40); 
   	
   	//potionButton
      potionButton = addButton("Potion", 175, 460, 70, 40);
      
   	//upArrow
      upArrow = addButton("\u2191",498, 505, 50, 40); 
   	
   	//downArrow
      downArrow = addButton("\u2193", 498, 595, 50, 40);
   	
   	//leftArrow
      leftArrow = addButton("\u2190", 470, 550, 50, 40);
   	
   	//rightArrow
      rightArrow = addButton("\u2192", 525, 550, 50, 40);
   	
      JLabel empty = new JLabel("");
      
      JTextField keyListener = new JTextField();
      keyListener.addKeyListener(this);
      
      this.add(mapLabel);
      this.add(mapTextBox);
      this.add(textLabel);
      this.add(TextBox);		
      this.add(button1);
      this.add(button2);
      this.add(button3);
      this.add(potionButton);
      this.add(leftArrow);
      this.add(rightArrow);
      this.add(upArrow);
      this.add(downArrow);
      
      this.add(keyListener);
      this.add(empty);
      this.setVisible(true);
   }
   
   private JButton addButton(String name, int one, int two, int three, int four){
      JButton button = new JButton(name);
      button.addActionListener(this);
      button.setVisible(true);
      button.setBounds(one, two, three, four);
      return button;
      
   }
	
   public void actionPerformed(ActionEvent e){
       //this.mapTextBox.setText(MockMapReturn.updateMap());
	   //this.notify();
	   event=e;
	  
   }
   
   public ActionEvent getEvent(){
	   return this.event;
   }
   
   public KeyEvent getKey(){
	   return this.key;
   }
   
   //the key event
   public void keyTyped(KeyEvent e) {
      //this.TextBox.setText(e.getKeyChar()+"");
   }

   //the key event
   public void keyPressed(KeyEvent e) {
	   this.key = e;
   }

   //the key event
   public void keyReleased(KeyEvent e) {
	   //this.TextBox.setText(e.getKeyChar()+"");
   }
   
   public void appendTextBox(String newText){
	   this.TextBox.setText(this.TextBox.getText()+"\n"+newText);
   }
   
   public void writeMapTextBox(String text){
	   this.mapTextBox.setText(text);
   }
   
   public void writeText(String text){
	  this.TextBox.setText(text); 
   }
   
   public void resetKey(){
	   this.key=null;
   }
   /*public static void main(String[] args){
      GraphicalUserInterface gui = new GraphicalUserInterface();
   }*/
}
