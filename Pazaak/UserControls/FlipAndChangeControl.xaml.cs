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
    /// Interaction logic for FlipAndChangeControl.xaml
    /// </summary>
    public partial class FlipAndChangeControl : UserControl
    {
        public FlipAndChangeControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Calls FlipSign() if the sender is a SignCard
        /// </summary>
        /// <param name="sender"> sender </param>
        /// <param name="e"> event arguments </param>
        private void FlipCard_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as SignCard)?.FlipSign();
        }

        /// <summary>
        /// Calls CycleValue() if the sender is a MultiValueSignCard
        /// </summary>
        /// <param name="sender"> sender </param>
        /// <param name="e"> event arguments </param>
        private void ChangeValue_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MultiValueSignCard)?.CycleValue();
        }
    }
}
