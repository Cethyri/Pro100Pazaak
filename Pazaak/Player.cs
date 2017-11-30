using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak
{
    public delegate void NextPlayerBeginTurn();

    class Player : INotifyPropertyChanged
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

        /// <summary>
        /// Starts turn by adding a card from the main deck to the player's board.
        /// also sets IsActive to true
        /// </summary>
        public void BeginTurn()
        {
            IsActive = true;

            Cards.ICard newCard = /*random card from main deck*/ new Cards.ValueCard(0);
            //remove newCard from main deck
            Board.AddCard(newCard);
        }

        /// <summary>
        /// Ends the turn by turning IsActive to false 
        /// and calling the BeginTurn method for the next player
        /// </summary>
        public void EndTurn()
        {
            IsActive = false;

            nextPlayerBeginTurn();
        }

        /// <summary>
        /// Add's the nextPlayer's begin turn method to the delegate called in EndTurn()
        /// </summary>
        /// <param name="nextPlayer"> the next player in turn order </param>
        public void RegisterNextPlayer(Player nextPlayer)
        {
            nextPlayerBeginTurn += nextPlayer.BeginTurn;
        }

        private bool isActive;
        private int wins;
        private string name;
        private Deck sideDeck;
        private Hand hand;
        private Board board;
        private NextPlayerBeginTurn nextPlayerBeginTurn;

        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                FieldChanged("IsActive");
            }
        }
        public int Wins
        {
            get => wins;
            set
            {
                wins = value;
                FieldChanged("Wins");
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                FieldChanged("Name");
            }
        }
        public Deck SideDeck
        {
            get => sideDeck;
            set
            {
                sideDeck = value;
                FieldChanged("SideDeck");
            }
        }
        public Hand Hand
        {
            get => hand;
            set
            {
                hand = value;
                FieldChanged("Hand");
            }
        }
        public Board Board
        {
            get => board;
            set
            {
                board = value;
                FieldChanged("Board");
            }
        }

        public Player()
        {
            sideDeck = new Deck();
            hand = new Hand();
            board = new Board();
        }
    }
}
