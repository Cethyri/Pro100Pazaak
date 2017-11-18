using Pazaak.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak
{
    class Hand
    {
        private ICard[] cards;

        public ICard[] Cards { get => cards; set { cards = value; } }

        /// <summary>
        /// 
        /// Calls the chosen card's DoCardEffect 
        /// then adds a value card with the chosen 
        /// card's value
        /// 
        /// </summary>
        /// <param name="cardIndex"> index of the chosen card in the member ICard array Cards </param>
        /// <param name="board"> The board that the new card will be added to </param>
        public void AddToBoard(int cardIndex, Board board)
        {
            for(int i = 0; i < board.Cards.Length; i++)
            {
                if(board.Cards[i] != null)
                {
                    Cards[cardIndex].DoCardEffect(board);
                    board.Cards[i] = new ValueCard(Cards[cardIndex].Value);
                    break;
                }
            }
        }

        public Hand()
        {
            cards = new ICard[4];
        }
    }
}
