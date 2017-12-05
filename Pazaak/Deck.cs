using Pazaak.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pazaak
{
    public class Deck
    {
		//Remember, this is an instanced class.

        private static Random rand = new Random();

        public ObservableCollection<ICard> RemovedCards { get; set; }
		public ObservableCollection<ICard> Cards { get; set; }

		/// <summary>
		/// Initializes this deck as the main deck.
		/// </summary>
		public void InitializeAsMainDeck()
		{
			for(int i = 0; i < 4; i++)
			{
				for (int ii = 0; ii < 10; ii++)
				{
					Cards.Add(new ValueCard(ii + 1));
				}
			}
		}

		/// <summary>
		/// Initializes this deck as a player's deck.
		/// </summary>
		/// <param name="personalDeck">List of player's cards</param>
		public void InitializeAsSideDeck(ObservableCollection<ICard> personalDeck)
		{
			Cards = personalDeck;
		}

		/// <summary>
		/// Shuffles this deck.
		/// </summary>
		public void Shuffle()
		{
			//First, replace the cards in removedCards back into cards
			foreach (ICard x in RemovedCards)
			{
				Cards.Add(x);
			}
			RemovedCards.Clear();

			//
			ObservableCollection<ICard> shuffled = new ObservableCollection<ICard>();
			int n = 0;
			bool[] hasBeenShuffledBackIn = new bool[Cards.Count];

			for (int i = 0; i < hasBeenShuffledBackIn.Length; i++)
			{
				hasBeenShuffledBackIn[i] = false;
			}

			while (n < this.Cards.Count)
			{
				int k = rand.Next(Cards.Count);
				if (!hasBeenShuffledBackIn[k])
				{
					hasBeenShuffledBackIn[k] = true;
					shuffled.Add(Cards.ElementAt(k));
					n++;
				}
			}

			Cards = shuffled;
		}

		/// <summary>
		/// Draws next card while also removing it from this deck.
		/// </summary>
		/// <returns>ICard</returns>
		public ICard DrawNextCard()
		{
			ICard returned = Cards.First();
			RemovedCards.Add(returned);
			Cards.RemoveAt(0);
			return returned;
		}

		/// <summary>
		/// Adds a new card to this deck
		/// </summary>
		/// <param name="addedCard">Self-explanatory</param>
		public void AddCard(ICard addedCard)
		{
			Cards.Add(addedCard);
		}

        public Deck()
        {
            Cards = new ObservableCollection<ICard>();
            RemovedCards = new ObservableCollection<ICard>();
        }
	}
}
