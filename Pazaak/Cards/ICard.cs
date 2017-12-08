using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak.Cards
{
    public interface ICard : INotifyPropertyChanged
    {
        ICard MakeCopy();

        /// <summary>
        /// Method to be called when a card is played. Allows card to affect the board.
        /// </summary>
        /// <param name="board"></param>
        void DoCardEffect(Board board);

        int Value { get; set; }

        string Display { get; }

        bool IsTieBreaker { get; set; }
    }
}
