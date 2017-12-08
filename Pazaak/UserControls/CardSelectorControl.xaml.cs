using Pazaak.Cards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    /// Interaction logic for CardSelectorControl.xaml
    /// </summary>
    public partial class CardSelectorControl : INotifyPropertyChanged
    {
        /// <summary>
        /// Notifies all bindings that a property has changed
        /// </summary>
        /// <param name="field"> Name of property changed </param>
        protected void FieldChanged(string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }

        private void CardSelectorControl_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CardControlSelection_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CardControl card = sender as CardControl;

            Deck sideDeck = DataContext as Deck;

            sideDeck.AddCard((card.DataContext as ICard).Copy());
        }

        private void CardControlSideDeck_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CardControl card = sender as CardControl;

            Deck sideDeck = DataContext as Deck;

            sideDeck.Cards.Remove(card.DataContext as ICard);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICard[] selectionCards;

        public ICard[] SelectionCards
        {
            get
            {
                return selectionCards;
            }
            set
            {
                selectionCards = value;
                FieldChanged("SelectionCards");
            }
        }

        public CardSelectorControl()
        {
            InitializeComponent();

            Closing += CardSelectorControl_Closing;
        }
    }
}
