using Pazaak.Cards;
using Pazaak.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            ObservableCollection<ICard> playerOneSideDeck = new ObservableCollection<ICard>()
            {
                new ValueCard(1),
                new ValueCard(1),
                new ValueCard(1),
                new ValueCard(1),
            };
            ObservableCollection<ICard> playerTwoSideDeck = new ObservableCollection<ICard>()
            {
                new ValueCard(1),
                new ValueCard(1),
                new ValueCard(1),
                new ValueCard(1),
            };
            Player playerOne = new Player("Player One", playerOneSideDeck);
            Player playerTwo = new Player("Player Two", playerTwoSideDeck);
            uniformgridMain.Children.Clear();
            uniformgridMain.Rows = 1;
            uniformgridMain.Children.Add(new GameControl(playerOne, playerTwo) { Name = "gamecontrolGame" });
        }
    }
}
