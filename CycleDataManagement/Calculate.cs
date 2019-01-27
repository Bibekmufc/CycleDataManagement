using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleDataManagement
{
    /// <summary>
    /// this class does the calculation and mathematics part like sum, average, etc.
    /// </summary>
    public class Calculate
    {
        public static List<string> heartRate = new List<string>();
        public static List<string> speed = new List<string>();
        public static List<string> speed_mile = new List<string>();
        public static List<string> cadence = new List<string>();
        public static List<string> altitude = new List<string>();
        public static List<string> power = new List<string>();
        public static List<string> powerbalance = new List<string>();
        string time = "";
        public static double FTP = 0, NP = 0, PB = 12, IF = 0;

        /// <summary>
        /// constructor of this class
        /// </summary>
        /// <param name="heartRate"></param>
        /// <param name="speed"></param>
        /// <param name="speed_mile"></param>
        /// <param name="cadence"></param>
        /// <param name="altitude"></param>
        /// <param name="power"></param>
        /// <param name="time"></param>
        public Calculate(List<string> heartRate, List<string> speed, List<string> speed_mile, List<string> cadence, List<string> altitude, List<string> power, string time)
        {
            Calculate.heartRate = heartRate;
            Calculate.speed = speed;
            Calculate.speed_mile = speed_mile;
            Calculate.cadence = cadence;
            Calculate.altitude = altitude;
            Calculate.power = power;
            this.time = time;


        }

        /// <summary>
        /// average calculation with string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Average(List<string> value)
        {
            double sum = 0;

            foreach (var val in value)
            {
                sum = sum + double.Parse(val);
            }

            double result = (sum / value.Count);
            return result;
        }

        /// <summary>
        /// average calculation with double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Average(List<double> value)
        {
            double sum = 0;

            foreach (var val in value)
            {
                sum = sum + val;
            }

            double result = (sum / value.Count);
            return result;
        }
        
        /// <summary>
        /// average calculation with int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Average(List<int> value)
        {
            double sum = 0;

            foreach (var val in value)
            {
                sum = sum + val;
            }

            double result = (sum / value.Count);
            return result;
        }

        /// <summary>
        /// sum calculation with string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Sum(List<string> value)
        {
            double sum = 0;

            foreach (var val in value)
            {
                sum = sum + Double.Parse(val);
            }

            return sum;
        }

        /// <summary>
        /// max calculation with string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Max(List<string> value)
        {
            double maxVal = 0;

            for (int i = 0; i < value.Count; i++)
            {
                if (maxVal < double.Parse(value.ElementAt(i)))
                {
                    maxVal = double.Parse(value.ElementAt(i));
                }
            }

            return maxVal;
        }
        /// <summary>
        /// max calculation with int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Max(List<int> value)
        {
            double maxVal = 0;

            for (int i = 0; i < value.Count; i++)
            {
                if (maxVal < (value.ElementAt(i)))
                {
                    maxVal = (value.ElementAt(i));
                }
            }

            return maxVal;
        }
        /// <summary>
        /// max calculation with double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double Max(List<double> value)
        {
            double maxVal = 0;

            for (int i = 0; i < value.Count; i++)
            {
                if (maxVal < (value.ElementAt(i)))
                {
                    maxVal = (value.ElementAt(i));
                }
            }

            return maxVal;
        }

        /// <summary>
        /// min calculation with string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
        /// <summary>
        /// min calculation with int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Min(List<int> value)
        {
            int minVal = (value.ElementAt(0));

            for (int i = 0; i < value.Count; i++)
            {
                if (minVal > (value.ElementAt(i)))
                {
                    minVal = (value.ElementAt(i));
                }
            }

            return minVal;
        }

        /// <summary>
        /// calculation of total distance
        /// </summary>
        /// <param name="average"></param>
        /// <param name="count"></param>
        /// <param name="interval"></param>
        /// <returns></returns>
        public static double Total(double average, int count, int interval)
        {
            var time = TimeSpan.FromSeconds(count * interval);
            double total1 = average * time.TotalHours;
            return total1;
        }

        /// <summary>
        /// calculation of functional threshold power
        /// </summary>
        /// <returns></returns>
        public string CalculateFTP()
        {
            double num = 0;
            List<double> power2 = new List<double>();
            string[] arrpower = power.ToArray();
            for (int counter = 0; counter <= 1200; counter++)
            {
                num = Double.Parse(arrpower[counter]);
                power2.Add(num);
            }
            double avg_power = Average(power2);
            double FTP1 = avg_power * 0.95;
            FTP = Math.Round(FTP1, 2);
            return FTP.ToString();
        }

        /// <summary>
        /// calculation of normal power
        /// </summary>
        /// <returns></returns>
        public string CalculateNP()
        {
            List<double> power1 = new List<double>();
            List<double> power2 = new List<double>();
            List<double> power3 = new List<double>();
            double num = 0;
            string[] arrpower = power.ToArray();
            for (int counter = 0; counter <= 600; counter++)
            {
                num = Double.Parse(arrpower[counter]);
                power1.Add(num);
            }
            for (int counter = 601; counter <= 1200; counter++)
            {
                num = Double.Parse(arrpower[counter]);
                power2.Add(num);
            }

            for (int counter = 1201; counter <= 1800; counter++)
            {
                num = Double.Parse(arrpower[counter]);
                power3.Add(num);

            }
            double avg_power1 = Average(power1);
            double avg_power2 = Average(power2);
            double avg_power3 = Average(power3);

            double in4 = Math.Pow(avg_power1, 4);
            double in5 = Math.Pow(avg_power2, 4);
            double in6 = Math.Pow(avg_power3, 4);

            double calc1 = in4 * 10;
            double calc2 = in5 * 10;
            double calc3 = in6 * 10;

            double np1 = Math.Sqrt(Math.Sqrt(calc1));
            double np2 = Math.Sqrt(Math.Sqrt(calc2));
            double np3 = Math.Sqrt(Math.Sqrt(calc3));

            double NP1 = (np1 + np2 + np3) / 3;
            NP = Math.Round(NP1, 2);
            return NP.ToString();

        }

        /// <summary>
        /// calculation of intensity factor
        /// </summary>
        /// <returns></returns>
        public string CalculateIF()
        {
            double IF1 = NP / FTP;
            IF = Math.Round(IF1, 2);

            return IF.ToString();
        }

        /// <summary>
        /// calculation of training stress score
        /// </summary>
        /// <returns></returns>
        public string CalculateTSS(List<string> heartRate)
        {
            string[] heart1 = heartRate.ToArray();
            int sec = heart1.Length;

            double TSS1 = (sec * NP * IF) / (FTP * 3600) * 100;
            double TSS = Math.Round(TSS1, 2);

            return TSS.ToString();
        }
        /// <summary>
        /// generates the power balance value
        /// </summary>
        /// <returns>the average power balance value</returns>
        public double CalculatePB()
        {
            List<string> pwr = new List<string>();
            string[] power1 = power.ToArray();
            double result = 0.0;

            double temp = 0.0;
            foreach(string arStr in power1)
            {
                double.TryParse(arStr, out temp);
                result += temp;
            }
            return result / power1.Length;
        }

        /// <summary>
        /// Get the average from the provided list of the strings.
        /// </summary>
        /// <param name="psdData">the list of the data read from the file</param>
        /// <param name="index">the default index of the number to be read</param>
        /// <returns>the aerage value of number at the given index</returns>
        public static double GetAverage(List<string[]> psdData, int index)
        {
            double total = 0;
            foreach (var items in psdData)
            {
                string str = items[index];

                if (str.Length > 1)
                {
                    str = str.Insert(str.Length - 1, "");
                }

                total += double.Parse(str);
            }

            total = total / psdData.Count;

            return total;
        }
        public static string AverageID(List<string> value)
        {
            double sum = 0;

            foreach (var val in value)
            {
                sum = sum + double.Parse(val);
            }

            double result = (sum / value.Count);
            return result.ToString();
        }

        public static List<int> intervalIndexes;

        /// <summary>
        /// The method which calculates the power balance for the given data dump.
        /// </summary>
        /// <param name="dataSet">the set of data extracted from the source hrm files</param>
        /// <returns>the calculated power balance value</returns>
        public static int DetectClearInterval(List<string> dataSet)
        {
            int result = 0;
            List<int> indexes = new List<int>();

            bool countIt = true;
            for (int i = 0; i < dataSet.Count; i++)
            {
                if (i + 1 > dataSet.Count - 1) break;

                if (dataSet[i].Equals("0"))
                {
                    // set last index of zero
                    if (countIt)
                    {
                        result++;
                        countIt = false;
                        indexes.Add(i);
                    }
                }
                else
                {
                    countIt = true;
                }
            }

            Calculate.intervalIndexes = indexes;
            return result;
        }
    }
}
