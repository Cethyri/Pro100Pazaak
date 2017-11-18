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
		private ICard lastCard;

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

		public ICard LastCard { get => GetLastCard(); set => lastCard = value; }

		
		private ICard GetLastCard()
		{
			for (int i = 8; i >= 0; i--)
			{
				if(cards[i] != null)
				{
					return cards[i];
				}
			}
			return null;
		}
		
		public Board()
        {
            Cards = new ValueCard[9];

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
