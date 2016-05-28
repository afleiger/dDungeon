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
    /// Interaction logic for Tavern.xaml
    /// </summary>
    public partial class Tavern : Window
    {
        MainWindow mainW;
        int step;
        A_Hero hero1;
        A_Hero hero2;
        A_Hero hero3;

        HeroFactory heroFactory;

        public Tavern(MainWindow mainWin)
        {
            InitializeComponent();
            step = 0;
            mainW = mainWin;
            heroFactory = new HeroFactory();
        }

        private void continueButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.step == 0)
            {
                this.step = 1;
                continueButton.IsEnabled = false;
                tavText.Text = "The old, disgruntled bar tender asks, \"Who the hell are you?\"...";

                nameBox.Text = "Enter Your Name";
                nameBox.IsEnabled = true;
                characterCreation();
                nameBox.Focus();
                nameBox.SelectAll();
            }

            if(this.step == 2)
            {
                tavText.Text = "You look around the tavern for able-bodied men and women. Three individuals catch your eye. Pick one...";
                tavButton1.IsEnabled = true;
                tavButton2.IsEnabled = true;
                tavButton3.IsEnabled = true;
                continueButton.IsEnabled = false;
                allyCreation();
            }

            if(this.step == 3)
            {
                tavText.Text = "After acquainting yourself with your new ally, you decide to find another among the patrons of the tavern. Pick one...";
                tavButton1.IsEnabled = true;
                tavButton2.IsEnabled = true;
                tavButton3.IsEnabled = true;
                continueButton.IsEnabled = false;
                allyCreation();
            }

            if(this.step == 4)
            {
                tavText.Text = "Your party is assembled. You plunge yourselves into fate's cruel hands and head towards the tower of Chrisistheon...";
                mainW.playerParty.player1.IsPlayer = true;
                step++;
            }
            else if(this.step == 5)
            {
                mainW.PopulatePartyInfo();
                mainW.Show();
                this.Hide();
            }
        }

        private void tavButton1_Click(object sender, RoutedEventArgs e)
        {
            if (this.step == 1)
            {
                hero1.charString = nameBox.Text;
                mainW.playerParty.addMember(hero1);
                nameBox.IsEnabled = false;
                continueButton.IsEnabled = true;
                tavText.Text = "The bar keep laughs heartily, \"So " + hero1.charString + ", I imagine you're here to brave the dread tower of Chrisistheon. You'll need allies for such an endeavor.";
                tavButton1.IsEnabled = false;
                tavButton2.IsEnabled = false;
                tavButton3.IsEnabled = false;
                resetButtons();

                heroFactory.addPick(hero1.classID);
            }

            if (this.step == 2)
            {
                tavButton1.IsEnabled = false;
                tavButton2.IsEnabled = false;
                tavButton3.IsEnabled = false;
                resetButtons();
                continueButton.IsEnabled = true;

                mainW.playerParty.addMember(hero1);
                tavText.Text = hero1.charString + " sits down at your table, giving you a confident nod of approval.";

                heroFactory.addPick(hero1.classID);
            }

            if(this.step == 3)
            {
                tavButton1.IsEnabled = false;
                tavButton2.IsEnabled = false;
                tavButton3.IsEnabled = false;
                resetButtons();
                continueButton.IsEnabled = true;

                mainW.playerParty.addMember(hero1);
                tavText.Text = hero1.charString + " joins the party, looking eager for the battles to come.";
            }
                step++;
                
            
        }

        private void tavButton2_Click(object sender, RoutedEventArgs e)
        {
            if (this.step == 1)
            {
                hero2.charString = nameBox.Text;
                mainW.playerParty.addMember(hero2);
                nameBox.IsEnabled = false;
                continueButton.IsEnabled = true;
                tavText.Text = "The bar keep laughs heartily, \"So "+ hero2.charString +", I imagine you're here to brave the dread tower of Chrisistheon. You'll need allies for such an endeavor.";
                tavButton1.IsEnabled = false;
                tavButton2.IsEnabled = false;
                tavButton3.IsEnabled = false;
                resetButtons();

                heroFactory.addPick(hero2.classID);
            }

            if (this.step == 2)
            {
                tavButton1.IsEnabled = false;
                tavButton2.IsEnabled = false;
                tavButton3.IsEnabled = false;
                resetButtons();
                continueButton.IsEnabled = true;

                mainW.playerParty.addMember(hero2);
                tavText.Text = hero2.charString + " sits down at your table, giving you a confident nod of approval.";

                heroFactory.addPick(hero2.classID);
            }

            if (this.step == 3)
            {
                tavButton1.IsEnabled = false;
                tavButton2.IsEnabled = false;
                tavButton3.IsEnabled = false;
                resetButtons();
                continueButton.IsEnabled = true;

                mainW.playerParty.addMember(hero2);
                tavText.Text = hero2.charString + " joins the party, looking eager for the battles to come.";
            }
            step++;

        }

        private void tavButton3_Click(object sender, RoutedEventArgs e)
        {
            if (this.step == 1)
            {
                hero3.charString = nameBox.Text;
                mainW.playerParty.addMember(hero3);
                nameBox.IsEnabled = false;
                continueButton.IsEnabled = true;
                tavText.Text = "The bar keep laughs heartily, \"So " + hero3.charString + ", I imagine you're here to brave the dread tower of Chrisistheon. You'll need allies for such an endeavor.\"";
                tavButton1.IsEnabled = false;
                tavButton2.IsEnabled = false;
                tavButton3.IsEnabled = false;
                resetButtons();

                heroFactory.addPick(hero3.classID);
            }

            if(this.step == 2)
            {
                tavButton1.IsEnabled = false;
                tavButton2.IsEnabled = false;
                tavButton3.IsEnabled = false;
                resetButtons();
                continueButton.IsEnabled = true;

                mainW.playerParty.addMember(hero3);
                tavText.Text = hero3.charString + " sits down at your table, giving you a confident nod of approval.";
                heroFactory.addPick(hero3.classID);
            }

            if (this.step == 3)
            {
                tavButton1.IsEnabled = false;
                tavButton2.IsEnabled = false;
                tavButton3.IsEnabled = false;
                resetButtons();
                continueButton.IsEnabled = true;

                mainW.playerParty.addMember(hero3);
                tavText.Text = hero3.charString + " joins the party, looking eager for the battles to come.";
            }
            step++;
        }

        private void nameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(nameBox.Text != "" && nameBox.Text.Length < 16)
            {
                tavButton1.IsEnabled = true;
                tavButton2.IsEnabled = true;
                tavButton3.IsEnabled = true;
            }
            else
            {
                tavButton1.IsEnabled = false;
                tavButton2.IsEnabled = false;
                tavButton3.IsEnabled = false;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        private void characterCreation()
        {
            A_Hero[] heroes = heroFactory.RandomHeroes();
            tavButton1.Content = "_1: " + heroes[0].classString;
            tavButton1.ToolTip = heroes[0].toolTip;
            hero1 = heroes[0];

            tavButton2.Content =  "_2: " + heroes[1].classString;
            tavButton2.ToolTip = heroes[1].toolTip;
            hero2 = heroes[1];

            tavButton3.Content =  "_3: " + heroes[2].classString;
            tavButton3.ToolTip = heroes[2].toolTip;
            hero3 = heroes[2];
        }

        private void allyCreation()
        {
            A_Hero[] heroes = heroFactory.RandomHeroes();
            tavButton1.Content = "_1: " + heroes[0].charString + " - " + heroes[0].classString;
            tavButton1.ToolTip = heroes[0].toolTip;
            hero1 = heroes[0];

            tavButton2.Content = "_2: " + heroes[1].charString + " - " + heroes[1].classString;
            tavButton2.ToolTip = heroes[1].toolTip;
            hero2 = heroes[1];


            tavButton3.Content = "_3: " + heroes[2].charString + " - " + heroes[2].classString;
            tavButton3.ToolTip = heroes[2].toolTip;
            hero3 = heroes[2];
        }

        private void resetButtons()
        {
            tavButton1.Content = "--";
            tavButton2.Content = "--";
            tavButton3.Content = "--";

            tavButton1.ToolTip = "";
            tavButton2.ToolTip = "";
            tavButton3.ToolTip = "";
        }
    }
}
