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

        private void FlipCard_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as SignCard)?.FlipSign();
        }

        private void ChangeValue_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MultiValueSignCard)?.CycleValue();
        }
    }
}
