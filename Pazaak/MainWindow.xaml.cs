using Pazaak.UserControls;
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

namespace Pazaak
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cardcontrolCard.DataContext = new Cards.ValueCard(7);

            Button button = new Button
            {
                Content = "Change Size",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
            };
            button.Click += Button_Click;

            gridMain.Children.Add(button);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cardcontrolCard.Height = 150;
        }
    }
}
