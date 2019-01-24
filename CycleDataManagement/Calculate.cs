using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleDataManagement
{
    class Calculate
    {
        List<string> heartRate = new List<string>();
        List<string> speed = new List<string>();
        List<string> speed_mile = new List<string>();
        List<string> cadence = new List<string>();
        List<string> altitude = new List<string>();
        List<string> power = new List<string>();
        List<string> powerbalance = new List<string>();
        string time = "";
        double FTP = 0, NP = 0, PB = 12, IF = 0;

        public Calculate(List<string> heartRate, List<string> speed, List<string> speed_mile, List<string> cadence, List<string> altitude, List<string> power, string time)
        {
            this.heartRate = heartRate;
            this.speed = speed;
            this.speed_mile = speed_mile;
            this.cadence = cadence;
            this.altitude = altitude;
            this.power = power;
            this.time = time;


        }

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

        public static double Sum(List<string> value)
        {
            double sum = 0;

            foreach (var val in value)
            {
                sum = sum + Double.Parse(val);
            }

            return sum;
        }
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

        public static double Total(double average, int count, int interval)
        {
            var time = TimeSpan.FromSeconds(count * interval);
            double total1 = average * time.TotalHours;
            return total1;
        }

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

        public string CalculateIF()
        {
            double IF1 = NP / FTP;
            IF = Math.Round(IF1, 2);

            return IF.ToString();
        }

        public string CalculateTrainingStressScore()
        {
            string[] heart1 = heartRate.ToArray();
            int sec = heart1.Length;

            double TSS1 = (sec * NP * IF) / (FTP * 3600) * 100;
            double TSS = Math.Round(TSS1, 2);

            return TSS.ToString();
        }

        private double Average(List<double> power2)
        {
            throw new NotImplementedException();
        }

    }
}
