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
        public GameControl()
        {
            InitializeComponent();

            Player playerOne = new Player
            {
                Name = "Player One",
                Wins = 0,
                Hand = new Hand
                {
                    Cards = new ICard[]
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
                    Cards = new ICard[]
                    {
                        new ValueCard(0),
                        new ValueCard(1),
                        new ValueCard(2),
                        new ValueCard(3),
                    },
                },
            };

            pctrlPlayerOne.DataContext = playerOne;
            pctrlPlayerOne.hndControl.DataContext = playerOne.Hand;

            pctrlPlayerTwo.DataContext = playerTwo;
        }
    }
}
