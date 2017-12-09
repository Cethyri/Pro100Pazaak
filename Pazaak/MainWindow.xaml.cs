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
            Player playerOne = new Player("Player One", new ObservableCollection<ICard>());
            Player playerTwo = new Player("Player Two", new ObservableCollection<ICard>());

            CardSelectorControl cardSelectorOne = new CardSelectorControl()
            {
                Title = "Player One Card Selection",
            };
            CardSelectorControl cardSelectorTwo = new CardSelectorControl()
            {
                Title = "Player Two Card Selection",
            };

            cardSelectorOne.DataContext = playerOne.SideDeck;
            cardSelectorTwo.DataContext = playerTwo.SideDeck;

            Hide();

            cardSelectorOne.ShowDialog();
            cardSelectorTwo.ShowDialog();

            Show();

            uniformgridMain.Children.Clear();
            uniformgridMain.Rows = 1;
            uniformgridMain.Children.Add(
                new GameControl(playerOne, playerTwo)
                {
                    Name = "gamecontrolGame"
                });
        }
    }
}
