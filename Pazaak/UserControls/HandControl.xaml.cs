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
    /// Interaction logic for HandControl.xaml
    /// </summary>
    public partial class HandControl : UserControl
    {
        public HandControl()
        {
            InitializeComponent();

            cardControl0.DataContext = ((Hand)DataContext).Cards[0];
            cardControl1.DataContext = ((Hand)DataContext).Cards[1];
            cardControl2.DataContext = ((Hand)DataContext).Cards[2];
            cardControl3.DataContext = ((Hand)DataContext).Cards[3];
        }
    }
}
