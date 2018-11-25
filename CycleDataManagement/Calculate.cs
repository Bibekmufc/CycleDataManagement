using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleDataManagement
{
    class Calculate
    {
        public static decimal Average(List<string> value)
        {
            var sum = 0;

            foreach (var val in value)
            {
                sum = sum + Int32.Parse(val);
            }

            decimal result = (sum / value.Count);
            return result;
        }

        public static double Sum(List<string> value)
        {
            double sum = 0;

            foreach (var val in value)
            {
                sum = sum + Double.Parse(val);
            }

            return sum;
        }
        public static int Max(List<string> value)
        {
            int maxVal = 0;

            for (int i = 0; i < value.Count; i++)
            {
                if (maxVal < Int32.Parse(value.ElementAt(i)))
                {
                    maxVal = Int32.Parse(value.ElementAt(i));
                }
            }

            return maxVal;
        }

        public static int Min(List<string> value)
        {
            int minVal = Int32.Parse(value.ElementAt(0));

            for (int i = 0; i < value.Count; i++)
            {
                if (minVal > Int32.Parse(value.ElementAt(i)))
                {
                    minVal = Int32.Parse(value.ElementAt(i));
                }
            }

            return minVal;
        }

    }
}
