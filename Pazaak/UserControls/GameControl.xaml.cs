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
            get =>mainDeck;
            set
            {
                mainDeck = value;
            }
        }

        public GameControl()
        {
            InitializeComponent();

            MainDeck = new Deck();
            MainDeck.InitializeAsMainDeck();
            MainDeck.Shuffle();

            playerOne = new Player
            {
                Name = "Player One",
                Wins = 0,
                Hand = new Hand
                {
                    Cards = new System.Collections.ObjectModel.ObservableCollection<ICard>
                    {
                        new ValueCard(0),
                        new ValueCard(1),
                        new ValueCard(2),
                        new ValueCard(3),
                    },
                },
                Board = new Board()
            };
             playerTwo = new Player
            {
                Name = "Player Two",
                Wins = 0,
                Hand = new Hand
                {
                    Cards = new System.Collections.ObjectModel.ObservableCollection<ICard>
                    {
                        new ValueCard(0),
                        new ValueCard(1),
                        new ValueCard(2),
                        new ValueCard(3),
                    },
                },
                Board = new Board
                {
                    Cards = new ObservableCollection<ValueCard>
                    {
                        new ValueCard(0),
                        new ValueCard(1),
                        new ValueCard(2),
                        new ValueCard(3),
                    },
                }
            };
             

            playerOne.Initialize(playerTwo, MainDeck, WinChecks);
            playerTwo.Initialize(playerOne, MainDeck, WinChecks);

            pctrlPlayerOne.DataContext = playerOne;
            pctrlPlayerTwo.DataContext = playerTwo;

            playerOne.BeginTurn();
        }
        void WinChecks(NextPlayerBeginTurnDelegate NextTurn)
        {
            bool won = false;
            if (playerOne.Board.Sum == 20 && playerTwo.Board.Sum != 20)
            {
                won = true;
                playerOne.Wins++;
               
            }
            else if (playerTwo.Board.Sum == 20 && playerOne.Board.Sum != 20)
            {
                won = true;
                playerTwo.Wins++;
            }
            else if (playerOne.Board.Sum <= 19 && playerTwo.Board.Sum < playerOne.Board.Sum)
            {
                won = true;
                playerOne.Wins++;
            }
            else if (playerTwo.Board.Sum <= 19 && playerOne.Board.Sum < playerTwo.Board.Sum)
            {
                won = true;
                playerTwo.Wins++;
            }
            else if (playerOne.Board.Sum <= 19 && playerTwo.Board.Sum > 20)
            {
                won = true;
                playerOne.Wins++;
            }
            else if (playerTwo.Board.Sum <= 19 && playerOne.Board.Sum > 20)
            {
                won = true;
                playerTwo.Wins++;
            }else if (playerOne.Board.Cards.Count >= 9 && playerOne.Board.Sum < 20)
            {
                won = true;
                playerOne.Wins++;
            }
            else if (playerTwo.Board.Cards.Count >= 9 && playerTwo.Board.Sum < 20)
            {
                won = true;
                playerTwo.Wins++;
            }


        }
    }
}
