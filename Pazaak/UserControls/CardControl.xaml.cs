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

        bool hasWidthChanged = false;
        bool hasHeightChanged = false;
        private void CardControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Height != 0 && e.NewSize.Width != 0 && !Double.IsNaN(e.NewSize.Height) && !Double.IsNaN(e.NewSize.Width))
            {
                if (e.HeightChanged && !hasHeightChanged)
                {
                    hasWidthChanged = true;
                    Width = Math.Max(e.NewSize.Height / 3 * 2, MinWidth);
                }
                else if (e.WidthChanged && !hasWidthChanged)
                {
                    hasHeightChanged = true;
                    Height = Math.Max(e.NewSize.Width / 2 * 3, MinHeight);
                }
                if (Width > 0) { labelDisplay.FontSize = Width / 2; }
            } else
            {
                hasWidthChanged = true;
                hasHeightChanged = true;
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
