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

        private ICard[] cards;
        private int sum;

        public ICard[] Cards
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

        public Board()
        {
            Cards = new ICard[9];
            Sum = 0;
        }
        public void UpdateSum()
        {

            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] != null)
                {
                    sum = sum + cards[i].Value;
                }
                else
                {
                    break;
                }
            }

        }
    }
}
