using Pazaak.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Pazaak
{
    public class Hand
    {
        private ObservableCollection<ICard> cards;

        public ObservableCollection<ICard> Cards { get => cards; set { cards = value; } }

        public Hand()
        {
            cards = new ObservableCollection<ICard>();
        }
    }
}
