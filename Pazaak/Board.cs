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
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies all bindings that a property has changed
        /// </summary>
        /// <param name="field"> Name of property changed </param>
        protected void FieldChanged(string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }

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
            set => lastCard = value;
        }

        public Board()
        {
            Cards = new ObservableCollection<ICard>();

            Sum = 0;
        }
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

        public void AddCard(ICard card)
        {
            card.DoCardEffect(this);
            Cards.Add(card);
            UpdateSum();
        }
        public int GetTotalTieBreakerCards()
        {
            int TieBreakerCards = 0;
            for (int i = 0; i < Cards.Count; i++)
            {
                if(Cards[i].IsTieBreaker)
                {
                    TieBreakerCards++;
                }
            }
            return TieBreakerCards;
        }
    }
}
