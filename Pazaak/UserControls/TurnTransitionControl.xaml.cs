using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pazaak.UserControls
{
    /// <summary>
    /// Interaction logic for TurnTransitionControl.xaml
    /// </summary>
    public partial class TurnTransitionControl : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// Notifies all bindings that a property has changed
        /// </summary>
        /// <param name="field"> Name of property changed </param>
        protected void FieldChanged(string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }

        public void StartCountDown(int seconds)
        {
            t = new Timer
            {
                Interval = 1000
            };

            SecondsLeft = seconds;

            t.Tick += DecrementSecondsLeft;

            t.Start();
        }

        public void DecrementSecondsLeft(object sender, EventArgs e)
        {
            SecondsLeft--;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        Timer t;
        private int secondsLeft;

        public int SecondsLeft
        {
            get
            {
                return secondsLeft;
            }
            set
            {
                secondsLeft = value;
                FieldChanged("SecondsLeft");

                if (secondsLeft == 0)
                {
                    this.Close();
                    t.Stop();
                }
            }
        }

        public TurnTransitionControl()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
}
