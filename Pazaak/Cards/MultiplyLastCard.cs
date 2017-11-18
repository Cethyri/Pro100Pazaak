using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak.Cards
{
    public class MultiplyLastCard : ICard
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies all bindings that a property has changed
        /// </summary>
        /// <param name="field"> Name of property changed </param>
        protected void FieldChanged(string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }

        private int value;
        private int multValue;
        private string display;

        public int Value
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

        public string Display
        {
            get
            {
                return display;
            }
            set
            {
                display = $"Mult ({value})";
                FieldChanged("Display");
            }
        }

        public bool IsTieBreaker { get; set; }

        public MultiplyLastCard(int multValue)
        {
            Value = 0;
            MultValue = multValue;
        }

        public void DoCardEffect(Board board)
        {
            board.LastCard.Value *= multValue;
        }
    }
}
