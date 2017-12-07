using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazaak.Extensions
{
    public static class Extensions
    {
        public static int[] RemoveDuplicatesAndMakePositive(this int[] values)
        {
            List<int> uniqueValues = new List<int>();

            bool isUnique;

            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Math.Abs(values[i]);
            }

            for (int i = 0; i < values.Length; i++)
            {
                isUnique = true;
                for (int j = i + 1; j < values.Length; i++)
                {
                    if (values[i] == values[j])
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
    }
}
