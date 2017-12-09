using Pazaak.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public void InitializeSelectionCardsWithAll()
        {
            for (int i = 1; i <= 6; i++)
            {
                SelectionCards.Add(new ValueCard(i));
            }

            for (int i = 1; i <= 6; i++)
            {
                SelectionCards.Add(new ValueCard(-i));
            }

            for (int i = 1; i <= 6; i++)
            {
                SelectionCards.Add(new SignCard(i));
            }

            SelectionCards.Add(new SignCard(1) { IsTieBreaker = true });

            SelectionCards.Add(new MultiplyLastCard(2));

            SelectionCards.Add(new FlipValuesCard(new int[] { 2, 4 }));

            SelectionCards.Add(new FlipValuesCard(new int[] { 3, 6 }));

            SelectionCards.Add(new MultiValueSignCard(new int[] { 1, 2 }));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<ICard> SelectionCards { get; set; }

        public CardSelectorControl()
        {
            InitializeComponent();

            Closing += CardSelectorControl_Closing;
        }
    }
}
