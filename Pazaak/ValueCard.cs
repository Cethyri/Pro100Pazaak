using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak
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

        private int value;
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
                Display = value > 0 ? ("+" + value): ("" + value);
                FieldChanged("Value");
            }
        }

        public string Display
        {
            get
            {
                return display;
            }
            protected set
            {
                this.display = value;
                FieldChanged("Display");
            }
        }

        public ValueCard(int value)
        {
            Value = value;
        }

        public void DoCardEffect(Board board) { }
    }
}
