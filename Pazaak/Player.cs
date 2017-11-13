using System;
using System.Collections.Generic;
<<<<<<< Updated upstream
using System.ComponentModel;
=======
>>>>>>> Stashed changes
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak
{
<<<<<<< Updated upstream
    class Player : INotifyPropertyChanged
    {
        //Methods

        /// <summary>
        /// Notifies all bindings that a property has changed
        /// </summary>
        /// <param name="field"> Name of property changed </param>
        protected void FieldChanged(string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }

        private bool isActive;
        private int wins;
        private string name;
        /*
        private Deck sideDeck;
        private Hand hand;
        private Board board;
        */

        public bool IsActive { get => isActive; set { isActive = value; FieldChanged("IsActive"); } }
        public int Wins { get => wins; set { wins = value; FieldChanged("Wins"); } }
        public string Name { get => name; set { Name = value; FieldChanged("Name"); } }
        /*
        public Deck SideDeck { get => sideDeck; set { sideDeck = value; FieldChanged("SideDeck"); } }
        public Hand Hand { get => hand; set { hand = value; FieldChanged("Hand"); } }
        public Board Board { get => board; set { board = value; FieldChanged("Board"); } }
        */
        public event PropertyChangedEventHandler PropertyChanged;
=======
    class Player
    {
        public bool isActive;
        public int wins;
        public string name;
        Deck sideDeck;
        Hand hand;
        Board board;
>>>>>>> Stashed changes
    }
}
