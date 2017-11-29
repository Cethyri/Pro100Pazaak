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
		public BoardControl()
		{
			InitializeComponent();
		}

        bool hasSizeChanged = false;
        private void UniformGrid_SizeChanged(object sender, SizeChangedEventArgs e)
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
                }
            }
            else
            {
                hasSizeChanged = false;
            }
        }
    }
}
