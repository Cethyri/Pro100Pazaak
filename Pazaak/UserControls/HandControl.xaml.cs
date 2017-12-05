using Pazaak.Cards;
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
    public partial class HandControl : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies all bindings that a property has changed
        /// </summary>
        /// <param name="field"> Name of property changed </param>
        protected void FieldChanged(string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }

        private bool isPlayCardAllowed = true;

        public bool IsPlayCardAllowed
        {
            get
            {
                return isPlayCardAllowed;
            }
            set
            {
                isPlayCardAllowed = value;
                FieldChanged("IsPlayCardAllowed");
            }

        }

        public HandControl()
        {
            InitializeComponent();
        }

        private void CardControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsPlayCardAllowed)
            {
                Player thisPlayer = (Player)this.DataContext;
                ICard thisCard = (ICard)((FrameworkElement)sender).DataContext;

                thisPlayer.Board.AddCard(thisCard);
                thisPlayer.Hand.Cards.Remove(thisCard);

                IsPlayCardAllowed = false;
            }
        }

        private void GridCardHolder_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!((bool)e.OldValue) && (bool)e.NewValue)
            {
                IsPlayCardAllowed = true;
            }
        }
    }
}
