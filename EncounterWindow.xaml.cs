using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChrisistheonGUI
{
    /// <summary>
    /// Interaction logic for EncounterWindow.xaml
    /// </summary>
    public partial class EncounterWindow : Window
    {
        private MainWindow mainWin;

        //Chest Rates
        private static int armorChance = 50;
        private static int weaponChance = 50;

        //Misc Rates
        private static int bookShelfChance = 50;
        private static int pitTrapChance = 50;

        private bool isMonster;
        private bool isBoss;
        private bool isBattleRunning;

        public EncounterWindow(string type, MainWindow mainWin)
        {
            InitializeComponent();
            this.mainWin = mainWin;
            isMonster = false;
            isBoss = false;
            isBattleRunning = false;

            if(type == "chest")
            {
                chestEncounter();
            }
            if(type == "shrine")
            {
                shrineEncounter();
            }
            if (type == "monster")
            {
                isMonster = true;
                monsterEncounter();
            }
            if(type == "misc")
            {
                miscEncounter();
            }
            if(type == "boss")
            {
                isMonster = true;
                isBoss = true;
                bossEncounter();
            }
        }

        private void monsterEncounter()
        {
            encPicture.Source = new BitmapImage(new Uri(@"/Images/exc.ico", UriKind.Relative));
            encBlock.Text = "You are ambushed by enemies! Prepare yourselves!";
        }
        private void bossEncounter()
        {
            encPicture.Source = new BitmapImage(new Uri(@"/Images/demon.ico", UriKind.Relative));
            encBlock.Text = "You approach a lord of the tower! Prepare yourselves for a difficult fight!";
        }

        private void miscEncounter()
        {
            int rand = Dungeon.gRandom.Next(1, 101);

            if(rand <= bookShelfChance)
            {
                encPicture.Source = new BitmapImage(new Uri(@"/Images/books.ico", UriKind.Relative));
                encBlock.Text = "You found a collection of books detailing how to defend against the denizens of the tower.\nAll party members gain a boost to Defense.";
                player1.maxDefense += 4;
                player2.maxDefense += 4;
                player3.maxDefense += 4;
            }
            else if(rand <=pitTrapChance + bookShelfChance)
            {
                encPicture.Source = new BitmapImage(new Uri(@"/Images/pitTrap.ico", UriKind.Relative));
                A_Hero cur = selectRandomPartyTarget();
                double dam = (1 - cur.DamageReduction) * 25;
                encBlock.Text = cur.charString + " has stumbled into a pit trap! They take " + ((int)dam) + " damage!";
                cur.Damage(dam);
            }
        }


        private void chestEncounter()
        {
            encPicture.Source = new BitmapImage(new Uri(@"/Images/chest.ico", UriKind.Relative));
            encBlock.Text = "You found a treasure chest!";
            A_Hero cur = selectRandomPartyTarget();
            int rand = Dungeon.gRandom.Next(1, 101);
            if(rand <= armorChance)
            {
                cur.upgradeArmor();
                encBlock.Text += "\nYou gained " + cur.currentArmor + ".\n" + cur.charString + " equips the armor.";
            }
            else if (rand <= armorChance + weaponChance)
            {
                cur.upgradeWeapon();
                encBlock.Text += "\nYou gained " + cur.currentWeapon + ".\n" + cur.charString + " equips the weapon.";
            }
        }

        private void shrineEncounter()
        {
            encBlock.Text = "You found a shrine of ";
            A_Hero cur = selectRandomPartyTarget();

            int rand = Dungeon.gRandom.Next(1, 12);
            switch(rand)
            {
                case 1:
                    encPicture.Source = new BitmapImage(new Uri(@"/Images/Iorr.ico", UriKind.Relative));
                    encBlock.Text += "Iorr, God of Wind.\n" + cur.charString + " is blessed with increased Speed!";
                    cur.maxSpeed += 4;
                    break;
                case 2:
                    encPicture.Source = new BitmapImage(new Uri(@"/Images/Tymera.ico", UriKind.Relative));
                    encBlock.Text += "Tymera, Goddess of Music.\n" + cur.charString + " is blessed with increased SpellSlots!";
                    cur.maxSlots += 1;
                    break;
                case 3: 
                    encPicture.Source = new BitmapImage(new Uri(@"/Images/Cynos.ico", UriKind.Relative));
                    encBlock.Text += "Cynos, God of the Hunt.\n" + cur.charString + " is blessed with increased Power!";
                    cur.maxPower += 5;
                    break;
                case 4:
                    encPicture.Source = new BitmapImage(new Uri(@"/Images/Agborh.ico", UriKind.Relative));
                    encBlock.Text += "Agborh, Demon of Sorrow.\n" + cur.charString + " is cursed with lowered Defense!";
                    cur.maxDefense -= 8;
                    break;
                case 5:
                    encPicture.Source = new BitmapImage(new Uri(@"/Images/Haara.ico", UriKind.Relative));
                    encBlock.Text += "Haara, Goddess of the Dawn.\nYour party is granted an extra rest!";
                    mainWin.playerParty.potions++;
                    break;
                case 6:
                    encPicture.Source = new BitmapImage(new Uri(@"/Images/Oaldir.ico", UriKind.Relative));
                    encBlock.Text += "Oaldir, Demon of Miasma.\n" + cur.charString + " is cursed with lowered Power!";
                    cur.maxPower -= 5;
                    break;
                case 7:
                    encPicture.Source = new BitmapImage(new Uri(@"/Images/Melzoth.ico", UriKind.Relative));
                    encBlock.Text += "Melzoth, Demon of War.\n" + cur.charString + " is struck by an unseen blow! They take 25 damage.";
                    cur.Damage(25);
                    break;
                case 8:
                    encPicture.Source = new BitmapImage(new Uri(@"/Images/Vona.ico", UriKind.Relative));
                    encBlock.Text += "Vona, Goddess of Rebirth.\nYour party is fully restored!";
                    mainWin.playerParty.restorePartyMembers();

                    break;
                case 9:
                    encPicture.Source = new BitmapImage(new Uri(@"/Images/Oxtarr.ico", UriKind.Relative));
                    encBlock.Text += "Oxtarr, God of Wisdom.\n" + cur.charString + " is blessed with increased Defense!";
                    cur.maxDefense += 8;
                    break;
                case 10:
                    encPicture.Source = new BitmapImage(new Uri(@"/Images/Sila.ico", UriKind.Relative));
                    encBlock.Text += "Sila, Goddess of Light.\n" + cur.charString + " is blessed with increased Health!";
                    cur.maxHealth += 20;
                    break;
                case 11:
                    encPicture.Source = new BitmapImage(new Uri(@"/Images/Jibum.ico", UriKind.Relative));
                    encBlock.Text += "Jibum, God of Glory.\n" + cur.charString + " is blessed! They now feel a little bit stronger in every way.";
                    cur.maxPower += 3;
                    cur.maxDefense += 5;
                    cur.maxSpeed += 2;
                    cur.maxHealth += 5;
                    break;
            }
            
        }

        private A_Hero selectRandomPartyTarget()
        {
            A_Hero cur = null;
            int rand = Dungeon.gRandom.Next(1, 4);
            switch (rand)
            {
                case 1:
                    cur = mainWin.playerParty.player1;
                    break;
                case 2:
                    cur = mainWin.playerParty.player2;
                    break;
                case 3:
                    cur = mainWin.playerParty.player3;
                    break;
            }
            return cur;
        }

        private A_Hero player1
        {
            get { return mainWin.playerParty.player1; }
        }
        private A_Hero player2
        {
            get { return mainWin.playerParty.player2; }
        }
        private A_Hero player3
        {
            get { return mainWin.playerParty.player3; }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (isMonster)
            {
                new BattleWindow(mainWin, isBoss).Show();
                this.isBattleRunning = true;
            }
            else
            {
                this.mainWin.IsEnabled = true;
                this.mainWin.Focus();
            }
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (!isBattleRunning && isMonster)
            {
                new BattleWindow(mainWin, isBoss).Show();
            }
            else if(!isMonster)
            {
                this.mainWin.IsEnabled = true;
                this.mainWin.Focus();
            }
        }
    }
}
