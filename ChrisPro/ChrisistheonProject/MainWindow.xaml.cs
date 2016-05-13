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
using Chrisistheon;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dungeon dung;
        public MainWindow()
        {
            InitializeComponent();
            dung = new Dungeon();
            mapBox.Text = dung.GetRoomString();
            infoBox.Text = dung.infoString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dung.moveUp();
            mapBox.Text = dung.GetRoomString();
            infoBox.Text = dung.infoString;
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            dung.moveRight();
            mapBox.Text = dung.GetRoomString();
            infoBox.Text = dung.infoString;
        }

        private void downButton_Click(object sender, RoutedEventArgs e)
        {
            dung.moveDown();
            mapBox.Text = dung.GetRoomString();
            infoBox.Text = dung.infoString;
        }

        private void leftButton_Click(object sender, RoutedEventArgs e)
        {
            dung.moveLeft();
            mapBox.Text = dung.GetRoomString();
            infoBox.Text = dung.infoString;
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
    }
}
