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
        /// <summary>
        /// Whenever the CardControl Size Changes, the ratio is enforced again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!Double.IsNaN(e.NewSize.Height) && !Double.IsNaN(e.NewSize.Width))
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
            } else
            {
                hasWidthChanged = false;
                hasHeightChanged = false;
            }
            if (Width > 0) { labelDisplay.FontSize = Width / 3; }
            else if (Height > 0) { labelDisplay.FontSize = Height / 4.5; }
        }

        bool hasWidthChanged = false;
        bool hasHeightChanged = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public CardControl()
        {
            InitializeComponent();
            SizeChanged += CardControl_SizeChanged;
        }
    }
}
