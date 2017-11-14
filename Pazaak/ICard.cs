using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak
{
    interface ICard: INotifyPropertyChanged
    {
        string Display { get; }
        int GetValue(Board board);
    }
}
