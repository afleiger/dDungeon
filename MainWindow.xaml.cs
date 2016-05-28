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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChrisistheonGUI;

namespace ChrisistheonGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dungeon dung;
        public Party playerParty;
        Tavern tav;
        EncounterWindow currentEncounter;
        StartScreen startup;

        public MainWindow()
        {
            InitializeComponent();

            tav = new Tavern(this);
            playerParty = new Party();

            startup = new StartScreen(tav);
            startup.Show();
            this.Hide();

            dung = new Dungeon();
            mapBox.Text = dung.GetRoomString();
        }

        public void PopulatePartyInfo()
        {
            player1Box.Header = playerParty.playerName + " - " + playerParty.playerClass;
            player2Box.Header = playerParty.member1Name + " - " + playerParty.member1Class;
            player3Box.Header = playerParty.member2Name + " - " + playerParty.member2Class;

            UpdateInfo();
        }

        public void UpdateInfo()
        {
            player1Slots.Content = "SpellSlots: " + playerParty.player1.spellSlots;
            player2Slots.Content = "SpellSlots: " + playerParty.player2.spellSlots;
            player3Slots.Content = "SpellSlots: " + playerParty.player3.spellSlots;

            barCharacter1.Value = playerParty.playerHealthPercent;
            barCharacter2.Value = playerParty.member1HealthPercent;
            barCharacter3.Value = playerParty.member2HealthPercent;

            player1HealthNums.Content = ((int)playerParty.player1.health) + "/" + playerParty.player1.maxHealth;
            player2HealthNums.Content = ((int)playerParty.player2.health) + "/" + playerParty.player2.maxHealth;
            player3HealthNums.Content = ((int)playerParty.player3.health) + "/" + playerParty.player3.maxHealth;

            restButton.Content = "Rest: " + playerParty.potions;
            if(playerParty.potions == 0)
            {
                restButton.IsEnabled = false;
            }
            else
            {
                restButton.IsEnabled = true;
            }

            if(playerParty.player1.IsDead)
            {
                GameOver();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dung.moveUp();
            mapBox.Text = dung.GetRoomString();
            infoBox.Text = dung.infoString;
            CheckEncounter();
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            dung.moveRight();
            mapBox.Text = dung.GetRoomString();
            infoBox.Text = dung.infoString;;
            CheckEncounter();
        }

        private void downButton_Click(object sender, RoutedEventArgs e)
        {
            dung.moveDown();
            mapBox.Text = dung.GetRoomString();
            infoBox.Text = dung.infoString;
            CheckEncounter();
        }

        private void leftButton_Click(object sender, RoutedEventArgs e)
        {
            dung.moveLeft();
            mapBox.Text = dung.GetRoomString();
            infoBox.Text = dung.infoString;
            CheckEncounter();
        }

        private void CheckEncounter()
        {
            string enc = dung.encounterString;
            if(enc != "")
            {
                currentEncounter = new EncounterWindow(enc, this);
                currentEncounter.Show();
                currentEncounter.Focus();
                this.IsEnabled = false;
            }
            dung.encounterString = "";
            UpdateInfo();
        }

        private void theBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AboutItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("P -> Your Party\n# -> Wall", "About");
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        private void playerStats1_Click(object sender, RoutedEventArgs e)
        {
            new StatWindow(playerParty.player1, this).Show();
            this.IsEnabled = false;
        }

        private void playerStats2_Click(object sender, RoutedEventArgs e)
        {
            new StatWindow(playerParty.player2, this).Show();
            this.IsEnabled = false;
        }

        private void playerStats3_Click(object sender, RoutedEventArgs e)
        {
            new StatWindow(playerParty.player3, this).Show();
            this.IsEnabled = false;
        }

        public void GameOver()
        {
            MessageBox.Show("You have died. The tower claims yet another soul.", "Game Over");
            Application.Current.Shutdown();
        }

        private void restButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You set up camp and rest, restoring the party health and spell slots.", "Camp");
            playerParty.restorePartyMembers();
            playerParty.potions--;
            UpdateInfo();
        }
    }
}
