using Pazaak.Cards;
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

namespace Pazaak.UserControls
{
    /// <summary>
    /// Interaction logic for GameControl.xaml
    /// </summary>
    public partial class GameControl : UserControl
    {
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

            Player playerOne = new Player
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
            };
            Player playerTwo = new Player
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
                    Cards = new ValueCard[9]
                    {
                        new ValueCard(0),
                        new ValueCard(1),
                        new ValueCard(2),
                        new ValueCard(3),
                        null,
                        null,
                        null,
                        null,
                        null
                    },
                }
            };
             

            playerOne.Initialize(playerTwo, MainDeck);
            playerTwo.Initialize(playerOne, MainDeck);

            pctrlPlayerOne.DataContext = playerOne;
            pctrlPlayerTwo.DataContext = playerTwo;

            playerOne.BeginTurn();
        }
        bool WinChecks(int sum1, int sum2)
        {
            bool won = false;
            if (sum1 == 20 && sum2 == 20)
            {
                won = false;

            }
            else if (sum1 == 20 || sum2 == 20)
            {
                won = true;
            }
            return won;

        }
    }
}
