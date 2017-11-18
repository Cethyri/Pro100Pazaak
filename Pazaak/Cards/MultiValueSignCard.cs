using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak.Cards
{
    public class MultiValueSignCard : SignCard
    {
        private int[] possibleValues;
        private int count;
        private int current;

        public MultiValueSignCard(int[] possibleValues) : base(0)
        {
            if (possibleValues.Count() == 0)
            {
                throw new ArgumentNullException("possibleValues can't be empty");
            }

            PossibleValues = possibleValues;
        }

        public int[] PossibleValues
        {
            get
            {
                return possibleValues;
            }
            set
            {
                possibleValues = value;
                count = value.Count();
                current = 0;
                Value = value[current];
                FieldChanged("PossibleValues");
            }
        }

        public void CycleValue()
        {
            current++;
            current %= count;
            Value = possibleValues[current];
        }
    }
}
