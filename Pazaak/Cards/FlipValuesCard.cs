using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak.Cards
{
    class FlipValuesCard : ICard
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
        private int[] flipValues;
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

        public int[] FlipValues
        {
            get
            {
                return flipValues;
            }
            set
            {
                this.flipValues = RemoveDuplicates(value);

                Display = CreateValuesString();
                FieldChanged("Value");
            }
        }

        private int[] RemoveDuplicates(int[] values)
        {
            List<int> uniqueValues = new List<int>();

            bool isUnique;

            for (int i = 0; i < values.Length; i++)
            {
                isUnique = true;
                for (int j = i + 1; j < values.Length; i++)
                {
                    if (uniqueValues[i] == uniqueValues[j])
                    {
                        isUnique = false;
                        break;
                    }
                    if (isUnique)
                    {
                        uniqueValues.Add(values[i]);
                    }
                }
            }

            return uniqueValues.ToArray();
        }

        private string CreateValuesString()
        {
            string allValues = "";

            for (int i = 0; i < flipValues.Length; i++)
            {
                allValues += $"{flipValues[i]}&";
            }

            return allValues.Remove(allValues.Count() - 1);
        }

        public string Display
        {
            get
            {
                return display;
            }
            set
            {
                display = value;
                FieldChanged("Display");
            }
        }

        public bool IsTieBreaker { get; set; }

        public FlipValuesCard(int[] flipValues)
        {
            Value = 0;
            FlipValues = flipValues;
        }

        public void DoCardEffect(Board board)
        {
            foreach (ValueCard card in board.Cards)
            {
                foreach (int flipVal in flipValues)
                {
                    if (card.Value == flipVal)
                    {
                        card.Value *= -1;
                    }
                }
            }
        }
    }
}
