using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak.Cards
{
    public class MultiplyLastCard : ValueCard
    {
        public override void DoCardEffect(Board board)
        {
            board.LastCard.Value *= multValue;
        }

        protected int multValue;

        public override int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                FieldChanged("Value");
            }
        }

        public override string Display
        {
            get
            {
                return display;
            }
            set
            {
                display = $"x{value}";
                FieldChanged("Display");
            }
        }

        public int MultValue
        {
            get
            {
                return multValue;
            }
            set
            {
                this.multValue = value;
                Display = $"{multValue}";
                FieldChanged("Value");
            }
        }

        public MultiplyLastCard(int multValue) : base(0)
        {
            MultValue = multValue;
        }
    }
}
