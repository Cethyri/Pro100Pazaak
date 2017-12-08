using Pazaak.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak.Cards
{
    public class MultiValueSignCard : SignCard
    {
        public void CycleValue()
        {
            current++;
            current %= possibleValues.Length;
            Value = possibleValues[current] * ((Value < 0)? -1: 1);
        }

        protected int[] possibleValues;
        protected int current;

        public int[] PossibleValues
        {
            get
            {
                return possibleValues;
            }
            set
            {
                possibleValues = value.RemoveDuplicatesAndMakePositive();
                current = 0;
                Value = possibleValues[current];
                FieldChanged("PossibleValues");
            }
        }

        public MultiValueSignCard(int[] possibleValues) : base(0)
        {
            if (possibleValues.Count() == 0)
            {
                throw new ArgumentNullException("possibleValues can't be empty");
            }

            PossibleValues = possibleValues;
        }
    }
}
