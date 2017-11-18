using System;
using System.Collections.Generic;
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

        private ValueCard[] cards;
        private int sum;
        private Value lastCard;

        public ValueCard[] Cards
        {
            get => cards;
            set
            {
                cards = value;
                FieldChanged("Cards");
            }
        }

        public int Sum
        {
            get => sum;
            set
            {
                sum = value;
                FieldChanged("Sum");
            }
        }

        public ValueCard LastCard
        {
            get
            {
                for (int i = 8; i >= 0; i--)
                {
                    if (cards[i] != null)
                    {
                        return cards[i];
                    }
                }
                return null;
            }
            set => lastCard = value;
        }

        public Board()
        {
            Cards = new ValueCard[9];

            Sum = 0;
        }
    }
}
