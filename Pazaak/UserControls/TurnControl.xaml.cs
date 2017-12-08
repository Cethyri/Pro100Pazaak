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

        /// <summary>
        /// Logic for when buttonEndTurn is clicked
        /// </summary>
        /// <param name="sender"> presumably buttonEndTurn </param>
        /// <param name="e"> pertinent event arguments </param>
        private void ButtonEndTurn_Click(object sender, RoutedEventArgs e)
        {
            ((Player)DataContext).EndTurn();
        }

        /// <summary>
        /// Logic for when buttonStand is clicked
        /// </summary>
        /// <param name="sender"> presumably buttonStand </param>
        /// <param name="e"> pertinent event arguments </param>
        private void ButtonStand_Click(object sender, RoutedEventArgs e)
        {
            ((Player)DataContext).HasStood = true;
            ((Player)DataContext).EndTurn();
        }
    }
}
