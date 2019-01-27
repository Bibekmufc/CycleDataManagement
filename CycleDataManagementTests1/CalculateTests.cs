using Microsoft.VisualStudio.TestTools.UnitTesting;
using CycleDataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleDataManagement.Tests
{
    [TestClass()]
    public class CalculateTests
    {
        [TestMethod()]
        public void AverageTest()
        {
            //Assemble
            List<double> hrt = new List<double>()
            {
             59.43, 72.65, 88.12
            };
            double expectedResult = 73.4;

            //Act
            double actualResult = Calculate.Average(hrt);

            //Assert
            Assert.AreEqual(expectedResult, Math.Round(actualResult, 2, MidpointRounding.AwayFromZero));
        }

        [TestMethod()]
        public void SumTest()
        {
            //Assemble
            List<string> power = new List<string>()
            {
             "59.43", "72.65", "88.12"
            };
            double expectedResult = 220.2;

            //Act
            double actualResult = Calculate.Sum(power);

            //Assert
            Assert.AreEqual(expectedResult, Calculate.RoundOff(actualResult));
        }

        [TestMethod()]
        public void MaxTest()
        {
            //Assemble
            List<string> speedKMHR = new List<string>()
            {
             "70.25", "90.12", "30.81"
            };
            double expectedResult = 90.12;

            //Act
            double actualResult = Calculate.Max(speedKMHR);

            //Assert
            Assert.AreEqual(expectedResult, Calculate.RoundOff(actualResult));
        }

        [TestMethod()]
        public void MinTest()
        {
            //Assemble
            List<string> speedKMHR = new List<string>()
            {
             "70", "90", "30"
            };
            int expectedResult = 30;

            //Act
            int actualResult = Calculate.Min(speedKMHR);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void CalculateTSSTest()
        {
            //Assemble
            List<string> hrt = new List<string>()
            {
             "122.33", "91.55", "94.11"
            };
            double NP = 400.11;
            double IF = 198.22;
            double FTP = 191.2;
            string expectedResult = "34.57";

            //Act
            string[] heart1 = hrt.ToArray();
            int sec = heart1.Length;

            double TSS1 = (sec * NP * IF) / (FTP * 3600) * 100;
            double TSS = Math.Round(TSS1, 2);

            //Assert
            Assert.AreEqual(expectedResult, TSS.ToString());
        }

        [TestMethod()]
        public void GetAverageTest()
        {
            //Assemble
            List<string[]> inputData = new List<string[]>();
            double expectedResult = 49.5;

            //Act
            for (int i = 0; i < 100; i++)
            {
                inputData.Add(new string[] { Convert.ToString(i), Convert.ToString(i), Convert.ToString(i), Convert.ToString(i), Convert.ToString(i) });
            }

            double actualResult = Calculate.GetAverage(inputData, 1);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void TotalTest()
        {
            //Assemble
            double average = 100;
            int count = 3000;
            int interval = 1;
            double expectedResult = 83.33;

            //Act
            double actualResult = Calculate.Total(average, count, interval);

            //Assert
            Assert.AreEqual(expectedResult, Calculate.RoundOff(actualResult));
        }

        [TestMethod()]
        public void DetectClearIntervalTest()
        {
            //Assemble
            List<string> speedKMHR = new List<string>()
            {
             "20.12", "0", "0", "70.53", "44.41", "0", "0", "44.44", "67.1"
            };
            int expectedResult = 2;

            //Act
            int actualResult = Calculate.DetectClearInterval(speedKMHR);

            //Assert
            Assert.AreEqual(expectedResult, Calculate.RoundOff(actualResult));
        }

        [TestMethod()]
        public void RoundOffTest()
        {
            //Assemble
            double var = 62.435345342347887;
            double expectedResult = 62.44;

            //Act
            double actualResult = Calculate.RoundOff(var);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}