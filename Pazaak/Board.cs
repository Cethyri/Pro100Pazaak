using Pazaak.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak
{


    public class Board : INotifyPropertyChanged
    {
        /// <summary>
        /// Notifies all bindings that a property has changed
        /// </summary>
        /// <param name="field"> Name of property changed </param>
        protected void FieldChanged(string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }

        /// <summary>
        /// Updates the sum of all Cards stored in Cards
        /// </summary>
        public void UpdateSum()
        {
            Sum = 0;
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i] != null)
                {
                    Sum += Cards[i].Value;
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Adds a card to Cards
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(ICard card)
        {
            card.DoCardEffect(this);
            Cards.Add(card.Copy());
            UpdateSum();
        }

        /// <summary>
        /// Counts every card with IsTieBreaker being true
        /// </summary>
        /// <returns></returns>
        public int GetTotalTieBreakerCards()
        {
            int TieBreakerCards = 0;
            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].IsTieBreaker)
                {
                    TieBreakerCards++;
                }
            }
            return TieBreakerCards;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private int sum;
        private ICard lastCard;

        public ObservableCollection<ICard> Cards { get; set; }

        public int Sum
        {
            get => sum;
            set
            {
                sum = value;
                FieldChanged("Sum");
            }
        }

        public ICard LastCard
        {
            get
            {
                if(Cards.Count > 0)
                {
                    return Cards.Last();
                }
                return null;
            }
        }

        /// <summary>
        /// Constructor for board
        /// Initializes variables so they aren't null
        /// </summary>
        public Board()
        {
            Cards = new ObservableCollection<ICard>();

            Sum = 0;
        }
    }
}
