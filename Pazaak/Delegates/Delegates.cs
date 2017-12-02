using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak.Delegates
{
    public delegate void NextPlayerBeginTurnDelegate();

    public delegate void WinChecksDelegate(NextPlayerBeginTurnDelegate NextTurn);
}
