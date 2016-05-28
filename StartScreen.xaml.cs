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
    /// Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class StartScreen : Window
    {
        private Tavern tav;

        public StartScreen(Tavern tav)
        {
            InitializeComponent();
            this.tav = tav;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            tav.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
