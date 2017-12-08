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
	/// Interaction logic for BoardControl.xaml
	/// </summary>
	public partial class BoardControl : UserControl
    { 
        bool hasWidthChanged = false;
        bool hasHeightChanged = false;

        /// <summary>
        /// Logic for when the UniformGrid is changed
        /// </summary>
        /// <param name="sender"> sender </param>
        /// <param name="e"> event arguments </param>
        private void UniformGrid_SizeChanged(object sender, SizeChangedEventArgs e)
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
            }
            else
            {
                hasWidthChanged = false;
                hasHeightChanged = false;
            }
        }

        public BoardControl()
        {
            InitializeComponent();
        }
    }
}
