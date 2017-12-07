using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak.Cards
{
    public class ValueCard : ICard
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

        protected int value;
        protected string display;

        virtual public int Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                Display = value > 0 ? ("+" + value): ("" + value);
                FieldChanged("Value");
            }
        }

        virtual public string Display
        {
            get
            {
                return display;
            }
            set
            {
                this.display = value;
                FieldChanged("Display");
            }
        }

        virtual public bool IsTieBreaker { get; }

        public ValueCard(int value)
        {
            Value = value;
        }

        virtual public void DoCardEffect(Board board) { }
    }
}
