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

        public MultiplyLastCard(int multValue)
        {
            value = 0;
            this.multValue = multValue;
            display = $"Mult ({multValue})";
        }

        public void DoCardEffect(Board board)
        {
            throw new NotImplementedException();
        }
    }
}
