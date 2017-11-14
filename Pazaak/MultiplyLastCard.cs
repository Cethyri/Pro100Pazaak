using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak
{
    class MultiplyLastCard : ICard
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Display => throw new NotImplementedException();

        public int DoCardEffect(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
