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
    /// Interaction logic for StatWindow.xaml
    /// </summary>
    public partial class StatWindow : Window
    {
        MainWindow mainWin;
        A_Hero hero;

        public StatWindow(A_Hero hero, MainWindow mainWin)
        {
            InitializeComponent();
            this.hero = hero;
            this.mainWin = mainWin;

            PopulateStats();
        }

        private void PopulateStats()
        {
            this.Title = hero.charString + " Stats";
            Healthp.Content = ((int)hero.health) + "/" + hero.maxHealth;
            Slotsp.Content = hero.spellSlots + "/" + hero.maxSlots;
            Powerp.Content = hero.power;
            Defensep.Content = hero.defense;
            Speedp.Content = hero.speed;
            Weaponp.Content = hero.currentWeapon;
            Armorp.Content = hero.currentArmor;

            int skillCount = hero.AbilityList.Count;
            
            if(skillCount > 0)
            {
                AbilityButton1.Content = hero.AbilityList[0].Name;
                AbilityButton1.ToolTip = hero.AbilityList[0].Description;
            }
            if(skillCount > 1)
            {
                AbilityButton2.Content = hero.AbilityList[1].Name;
                AbilityButton2.ToolTip = hero.AbilityList[1].Description;
            }
            if (skillCount > 2)
            {
                AbilityButton3.Content = hero.AbilityList[2].Name;
                AbilityButton3.ToolTip = hero.AbilityList[2].Description;
            }
            if (skillCount > 3)
            {
                AbilityButton4.Content = hero.AbilityList[3].Name;
                AbilityButton4.ToolTip = hero.AbilityList[3].Description;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            this.mainWin.IsEnabled = true;
            this.mainWin.Focus();
        }
    }
}
