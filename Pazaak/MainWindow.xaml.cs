using Pazaak.UserControls;
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

namespace Pazaak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonQuickPlay_Click(object sender, RoutedEventArgs e)
        {
            uniformgridMain.Children.Clear();
            uniformgridMain.Rows = 1;
            uniformgridMain.Children.Add(new GameControl { Name = "gamecontrolGame" });
        }

        private void ButtonCustomDecks_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Custom Deck option is not currently available", "WARNING");
            uniformgridMain.Children.Clear();
            uniformgridMain.Rows = 1;
            uniformgridMain.Children.Add(new GameControl { Name = "gamecontrolGame" });
        }
    }
}
