using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak
{
    public class Deck
    {
		//Remember, this is an instanced class.

		private List<ICard> cards;
		

		public void InitializeAsMainDeck()
		{
			for(int i = 0; i < 4; i++)
			{
				for (int ii = 0; ii < 10; ii++)
				{
					cards.Add(new ValueCard(ii + 1));
				}
			}
		}

		public void InitializeAsSideDeck(List<ICard> personalDeck)
		{
			cards = personalDeck;
		}

		public void Shuffle()
		{
			List<ICard> shuffled = new List<ICard>();
			Random rand = new Random();
			int n = 0;
			bool[] hasBeenShuffledBackIn = new bool[cards.Count];

			while (n < this.cards.Count)
			{
				int k = rand.Next(cards.Count);
				if (hasBeenShuffledBackIn[k])
				{
					shuffled.Add(cards.ElementAt(k));
					n++;
				}
			}

			cards = shuffled;
		}

		public ICard DrawNextCard()
		{
			ICard returned = cards.First();
			cards.RemoveAt(0);
			return returned;
		}

		public void AddCard(ICard addedCard)
		{
			cards.Add(addedCard);
		}
	}
}
