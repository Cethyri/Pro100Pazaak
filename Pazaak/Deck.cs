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
		
		/// <summary>
		/// Initializes this deck as the main deck.
		/// </summary>
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

		/// <summary>
		/// Initializes this deck as a player's deck.
		/// </summary>
		/// <param name="personalDeck">List of player's cards</param>
		public void InitializeAsSideDeck(List<ICard> personalDeck)
		{
			cards = personalDeck;
		}

		/// <summary>
		/// Shuffles this deck.
		/// </summary>
		public void Shuffle()
		{
			List<ICard> shuffled = new List<ICard>();
			Random rand = new Random();
			int n = 0;
			bool[] hasBeenShuffledBackIn = new bool[cards.Count];

			for (int i = 0; i < hasBeenShuffledBackIn.Length; i++)
			{
				hasBeenShuffledBackIn[i] = false;
			}

			while (n < this.cards.Count)
			{
				int k = rand.Next(cards.Count);
				if (!hasBeenShuffledBackIn[k])
				{
					hasBeenShuffledBackIn[k] = true;
					shuffled.Add(cards.ElementAt(k));
					n++;
				}
			}

			cards = shuffled;
		}

		/// <summary>
		/// Draws next card while also removing it from this deck.
		/// </summary>
		/// <returns></returns>
		public ICard DrawNextCard()
		{
			ICard returned = cards.First();
			cards.RemoveAt(0);
			return returned;
		}

		/// <summary>
		/// Adds a new card to this deck
		/// </summary>
		/// <param name="addedCard">Card to be added</param>
		public void AddCard(ICard addedCard)
		{
			cards.Add(addedCard);
		}
	}
}
