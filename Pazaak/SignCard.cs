using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak
{
    class SignCard: ValueCard
    {
        public SignCard(int value) : base(value) { }

        public void FlipSign()
        {
            Value *= -1;
        }
    }
}
