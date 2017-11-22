using Pazaak.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pazaak
{
    public class Deck
    {
		//Remember, this is an instanced class.

		private List<ICard> cards;
		private List<ICard> removedCards;

		public List<ICard> RemovedCards { get => removedCards; set => removedCards = value; }

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
			//First, replace the cards in removedCards back into cards
			foreach (ICard x in removedCards)
			{
				cards.Add(x);
			}
			removedCards.Clear();

			//
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
		/// <returns>ICard</returns>
		public ICard DrawNextCard()
		{
			ICard returned = cards.First();
			removedCards.Add(returned);
			cards.RemoveAt(0);
			return returned;
		}

		/// <summary>
		/// Adds a new card to this deck
		/// </summary>
		/// <param name="addedCard">Self-explanatory</param>
		public void AddCard(ICard addedCard)
		{
			cards.Add(addedCard);
		}
	}
}
