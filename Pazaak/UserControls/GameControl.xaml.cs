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

            BeginRound();
        }

        void BeginMatch()
        {
            MainDeck = new Deck();
            MainDeck.InitializeAsMainDeck();

            ObservableCollection<ICard> sideDeck = new ObservableCollection<ICard>{
                new SignCard(1),
                new SignCard(2),
                new SignCard(3),
                new SignCard(4),
                new MultiValueSignCard(new int[]{1, 2 }),
                new MultiValueSignCard(new int[]{3, 4 }),
                new ValueCard(5),
                new ValueCard(6),
                new ValueCard(-5),
                new ValueCard(-6),
            };

            playerOne = new Player("Player One", sideDeck);
            playerTwo = new Player("Player Two", sideDeck);

            playerOne.Initialize(playerTwo, MainDeck, TurnTransition);
            playerTwo.Initialize(playerOne, MainDeck, TurnTransition);
        }

        void BeginRound()
        {
            MainDeck.Shuffle();
            playerOne.SideDeck.Shuffle();
            playerTwo.SideDeck.Shuffle();

            playerOne.BeginTurn();
        }

        void TurnTransition(NextPlayerBeginTurnDelegate NextTurn)
        {
            bool hasWon = false;
            if (playerOne.HasStood && playerTwo.HasStood || playerOne.Board.Sum > 20 || playerTwo.Board.Sum > 20 || playerOne.Board.Cards.Count >= 9 || playerTwo.Board.Cards.Count >= 9)
            {
                hasWon = Winchecks();

            }
            if (hasWon)
            {
                //NextRound
            }
            else
            {
                NextTurn();
            }
        }

        private bool Winchecks()
        {
            bool won = false;
            if (playerOne.Board.Sum == 20 && playerTwo.Board.Sum != 20)
            {
                playerOne.Wins++;
                won = true;
            }
            else if (playerTwo.Board.Sum == 20 && playerOne.Board.Sum != 20)
            {
                playerTwo.Wins++;
                won = true;
            }
            else if (playerOne.Board.Sum <= 19 && playerTwo.Board.Sum < playerOne.Board.Sum)
            {
                playerOne.Wins++;
                 won = true;
            }
            else if (playerTwo.Board.Sum <= 19 && playerOne.Board.Sum < playerTwo.Board.Sum)
            {
                playerTwo.Wins++;
                 won = true;
            }
            else if (playerOne.Board.Sum <= 19 && playerTwo.Board.Sum > 20)
            {
                playerOne.Wins++;
                 won = true;
            }
            else if (playerTwo.Board.Sum <= 19 && playerOne.Board.Sum > 20)
            {
                playerTwo.Wins++;
                 won = true;
            }
            else if (playerOne.Board.Cards.Count >= 9 && playerOne.Board.Sum <= 20)
            {
                playerOne.Wins++;
                 won = true;
            }
            else if (playerTwo.Board.Cards.Count >= 9 && playerTwo.Board.Sum <= 20)
            {
                playerTwo.Wins++;
                 won = true;
            }
            else if (playerOne.Board.Sum == playerTwo.Board.Sum)
            {
                if (playerOne.Board.getTotalTieBreakerCards() > playerTwo.Board.getTotalTieBreakerCards())
                {
                    playerOne.Wins++;
                     won = true;
                }
                else if (playerTwo.Board.getTotalTieBreakerCards() > playerOne.Board.getTotalTieBreakerCards())
                {
                    playerTwo.Wins++;
                     won = true;
                }
                else
                {
                    won = true;
                }
            }
            return won;
        }
    }
}
