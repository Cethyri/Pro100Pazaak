using Pazaak.Cards;
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
using Pazaak.Delegates;

namespace Pazaak.UserControls
{
    /// <summary>
    /// Interaction logic for GameControl.xaml
    /// </summary>
    public partial class GameControl : UserControl
    {
        Player playerOne;
        Player playerTwo;
        private Deck mainDeck;
        public Deck MainDeck
        {
            get => mainDeck;
            set
            {
                mainDeck = value;
            }
        }

        public GameControl()
        {
            InitializeComponent();

            BeginMatch();

            pctrlPlayerOne.DataContext = playerOne;
            pctrlPlayerTwo.DataContext = playerTwo;

            while (playerOne.Wins < 3 && playerTwo.Wins < 3)
            {
                BeginRound();
            }
        }

        void BeginMatch()
        {
            MainDeck = new Deck();
            MainDeck.InitializeAsMainDeck();

            ObservableCollection<ICard> sideDeck = new ObservableCollection<ICard>{
                new ValueCard(1),
                new ValueCard(2),
                new ValueCard(3),
                new ValueCard(4),
                new ValueCard(5),
                new ValueCard(-1),
                new ValueCard(-2),
                new ValueCard(-3),
                new ValueCard(-4),
                new ValueCard(-5)
            };

            playerOne = new Player("Player One", sideDeck);
            playerTwo = new Player("Player Two", sideDeck);

            playerOne.Initialize(playerTwo, MainDeck, WinChecks);
            playerTwo.Initialize(playerOne, MainDeck, WinChecks);
        }

        void BeginRound()
        {
            MainDeck.Shuffle();
            playerOne.SideDeck.Shuffle();
            playerTwo.SideDeck.Shuffle();

            playerOne.BeginTurn();
        }

        void WinChecks(NextPlayerBeginTurnDelegate NextTurn)
        {
            if (playerOne.Board.Sum == 20 && playerTwo.Board.Sum != 20)
            {
                playerOne.Wins++;
            }
            else if (playerTwo.Board.Sum == 20 && playerOne.Board.Sum != 20)
            {
                playerTwo.Wins++;
            }
            else if (playerOne.Board.Sum <= 19 && playerTwo.Board.Sum < playerOne.Board.Sum)
            {
                playerOne.Wins++;
            }
            else if (playerTwo.Board.Sum <= 19 && playerOne.Board.Sum < playerTwo.Board.Sum)
            {
                playerTwo.Wins++;
            }
            else if (playerOne.Board.Sum <= 19 && playerTwo.Board.Sum > 20)
            {
                playerOne.Wins++;
            }
            else if (playerTwo.Board.Sum <= 19 && playerOne.Board.Sum > 20)
            {
                playerTwo.Wins++;
            }
            else if (playerOne.Board.Cards.Count >= 9 && playerOne.Board.Sum < 20)
            {
                playerOne.Wins++;
            }
            else if (playerTwo.Board.Cards.Count >= 9 && playerTwo.Board.Sum < 20)
            {
                playerTwo.Wins++;
            }

            NextTurn();
        }
    }
}
