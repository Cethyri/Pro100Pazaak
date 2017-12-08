using Pazaak.Cards;
using Pazaak.Delegates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pazaak
{
    class Player : INotifyPropertyChanged
    {
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
        /// If the player has stood, instead they skip they're turn
        /// also sets IsActive to true
        /// </summary>
        public void BeginTurn()
        {
            if (HasStood)
            {
                EndTurn();
            }
            else
            {
                IsActive = true;

                MessageBox.Show("Click OK when you are ready to start your turn", "Next Turn", MessageBoxButton.OK);
                Board.AddCard(MainDeck.DrawNextCard());

                if(Board.Sum == 20)
                {
                    HasStood = true;
                    EndTurn();
                }
            }
        }

        /// <summary>
        /// Ends the turn by turning IsActive to false 
        /// and calling the BeginTurn method for the next player
        /// </summary>
        public void EndTurn()
        {
            IsActive = false;

            checksDelegate(nextPlayerBeginTurn);
        }

        /// <summary>
        /// Add's the nextPlayer's begin turn method to the delegate called in EndTurn()
        /// </summary>
        /// <param name="nextPlayer"> the next player in turn order </param>
        /// <param name="mainDeck"> a reference to the main deck to draw cards from </param>
        public void Initialize(Player nextPlayer, Deck mainDeck, TurnTransitionDelegate checksDelegate)
        {
            MainDeck = mainDeck;

            this.checksDelegate += checksDelegate;
            nextPlayerBeginTurn += nextPlayer.BeginTurn;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool isActive;
        private bool hasStood;
        private int wins;
        private string name;
        private Deck sideDeck;
        private Deck mainDeck;
        private Hand hand;
        private Board board;
        private NextPlayerBeginTurnDelegate nextPlayerBeginTurn;
        private TurnTransitionDelegate checksDelegate;

        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                FieldChanged("IsActive");
            }
        }

        public bool HasStood
        {
            get => hasStood;
            set
            {
                hasStood = value;
                FieldChanged("HasStood");
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

        public Deck MainDeck
        {
            get => mainDeck;
            set
            {
                mainDeck = value;
                FieldChanged("MainDeck");
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

        /// <summary>
        /// Constructor for player
        /// </summary>
        /// <param name="name"> player's name </param>
        /// <param name="sideDeck"> whatever deck the player's hand will be drawn from </param>
        public Player(string name, ObservableCollection<ICard> sideDeck)
        {
            Name = name;
            Wins = 0;
            SideDeck = new Deck();
            Hand = new Hand();
            Board = new Board();

            SideDeck.InitializeAsSideDeck(sideDeck);
            SideDeck.Shuffle();
        }
    }
}
