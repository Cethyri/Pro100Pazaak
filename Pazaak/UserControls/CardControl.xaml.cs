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
    /// Interaction logic for CardControl.xaml
    /// </summary>
    public partial class CardControl : UserControl
    {
        public CardControl()
        {
            InitializeComponent();
            SizeChanged += CardControl_SizeChanged;
        }

        bool hasSizeChanged = false;
        private void CardControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height != 0 && e.NewSize.Width != 0 && !Double.IsNaN(e.NewSize.Height) && !Double.IsNaN(e.NewSize.Width) && !hasSizeChanged)
            {
                hasSizeChanged = true;
                if (e.HeightChanged)
                {
                    
                    Width = Math.Max(e.NewSize.Height / 3 * 2, MinWidth);
                }
                else
                {
                    Height = Math.Max(e.NewSize.Width / 2 * 3, MinHeight);
                    //This never actually happens because the only thing that updates is Height
                }
                if (Width > 0) { labelDisplay.FontSize = Width / 2; }
            } else
            {
                hasSizeChanged = false;
            }
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Grid)sender).Background = new SolidColorBrush(Colors.LightBlue);
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Grid)sender).Background = new SolidColorBrush(Colors.White);
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //whatever happens when the card is clicked
        }
    }
}
