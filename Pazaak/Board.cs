using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak
{


    public class Board : INotifyPropertyChanged
    {
        private ICard[] cards = new ICard[9];
        private int sum = 0;

        public event PropertyChangedEventHandler PropertyChanged;
        //Methods

        /// <summary>
        /// Notifies all bindings that a property has changed
        /// </summary>
        /// <param name="field"> Name of property changed </param>
        protected void FieldChanged(string field = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(field));
        }

        public ICard[] Cards
        {
            get => cards;
            set
            {
                cards = value;
            }
        }

        public int Sum
        {
            get => sum;
            set
            {
                sum = value;
            }
        }
    }
}
