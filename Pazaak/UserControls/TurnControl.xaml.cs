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
    /// Interaction logic for TurnControl.xaml
    /// </summary>
    public partial class TurnControl : UserControl
    {
        public TurnControl()
        {
            InitializeComponent();
        }

        private void ButtonEndTurn_Click(object sender, RoutedEventArgs e)
        {
            ((Player)DataContext).EndTurn();
        }

        private void ButtonStand_Click(object sender, RoutedEventArgs e)
        {
            ((Player)DataContext).EndTurn();
            //does not stand. needs to have additional code that ends the game after getting to this player's next turn
            //add an if statement to this player's BeginTurn()?
        }
    }
}
