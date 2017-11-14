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
        public string Display => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        public int GetValue(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
