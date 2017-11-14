using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak
{
    public class Deck
    {
        private List<ICard> cards;

		public List<ICard> Cards { get => cards; set => cards = value; }
	}
}
