using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak
{
    public class Board //: INotifyPropertyChanged
    {
		private Card[] cards = new Card[9];
		private int sum = 0;

		public Card[] Cards {
			get => cards; 
			set {
				cards = value;
			}
		}

		public int Sum
		{
			get => sum;
			set {
				sum = value;
			}
		}
    }
}
