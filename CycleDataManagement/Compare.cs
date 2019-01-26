using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycleDataManagement
{
    public partial class Compare : Form
    {

        List<string> parametersArray = new List<string>();
        Dictionary<string, string> parameter = new Dictionary<string, string>();
        List<int> heart = new List<int>();
        List<double> speed = new List<double>();
        List<double> speed_mile = new List<double>();
        List<int> cadence = new List<int>();
        List<int> altitude = new List<int>();
        List<int> power = new List<int>();
        List<int> powerbalance = new List<int>();
        List<DateTime> dateTime = new List<DateTime>();
        List<String> summary = new List<String>();
        Dictionary<string, List<string>> hrData = new Dictionary<string, List<string>>();



        List<string> parametersArray1 = new List<string>();
        Dictionary<string, string> parameter1 = new Dictionary<string, string>();
        List<int> heart2 = new List<int>();
        List<double> speed2 = new List<double>();
        List<double> speed_mile2 = new List<double>();
        List<int> cadence2 = new List<int>();
        List<int> altitude2 = new List<int>();
        List<int> power2 = new List<int>();
        List<int> powerbalance2 = new List<int>();
        List<DateTime> dateTime2 = new List<DateTime>();
        List<String> summary2 = new List<String>();
        Dictionary<string, List<string>> hrData1 = new Dictionary<string, List<string>>();
        int countData1 = 0, countData2 = 0;


        char[] findOf = { '\t', ' ', '=' };
        DateTime dt = new DateTime();
        int heartCheck = 0;
        int speedCheck = 0;
        int cadenceCheck = 0;
        int altitudeCheck = 0;
        int powerCheck = 0;
        int counter = 0;

        int interval = 0;

        String smode = "";
        String time = "";
        String ntime = "";
        String timee = "";

        String smode1 = "";
        String time1 = "";
        String ntime1 = "";
        String timee1 = "";
        public Compare()
        {
            InitializeComponent();
            InitGrid();
            InitGrid1();
        }

        /// <summary>
        /// button for selecting file one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnfile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "HRM|*.hrm|HRM/Text Document|*.txt";
            if (od.ShowDialog() == DialogResult.OK)
            {
                txtfile1.Text = Path.GetFullPath(od.FileName);
            }
        }

        /// <summary>
        /// button to open window for selecting file two
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnfile2_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "HRM|*.hrm|HRM/Text Document|*.txt";
            if (od.ShowDialog() == DialogResult.OK)
            {
                txtfile2.Text = Path.GetFullPath(od.FileName);
            }
        }

        /// <summary>
        /// puts the contents of the file chosen in an array
        /// </summary>
        /// <param name="filePath"></param>
        public void fileprocessing(string filePath)
        {
            try
            {
                Console.WriteLine(txtfile1.Text);

                StreamReader sr = new StreamReader(filePath);
                string line = "";
                string newLine = "";

                while (!(line = sr.ReadLine()).Contains("[Note]"))
                {

                    counter++;
                    string newline = string.Join(" ", line.Split(findOf, StringSplitOptions.RemoveEmptyEntries));
                    List<string> val = newline.Split(' ').ToList();

                    for (int i = 0; i < val.Count(); i++)
                    {
                        parametersArray.Add(val[i]);
                    }

                }

                try
                {
                    //stores header information in a dictionary with keys and values
                    for (int i = 1; i < parametersArray.Count(); i += 2)
                    {
                        parameter.Add(parametersArray[i], parametersArray[1 + i]);
                        if (parametersArray.Any()) //prevent IndexOutOfRangeException for empty list
                        {
                            parametersArray.RemoveAt(parametersArray.Count - 1);
                        }
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show(e.Message);
                }
                //calculates smode
                smode = parameter["SMode"];
                SMODE(smode);

                while (!sr.EndOfStream)
                {
                    if ((line = sr.ReadLine()).Contains("[HRData]"))
                    {


                        while ((newLine = sr.ReadLine()) != null)
                        {

                            sortDataIntoArray(newLine);
                        }
                    }
                }

            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show(exc.ToString());
            }



            catch (IOException e)
            {
                Console.WriteLine(e);
            }

            Form1 f = new Form1();
            device1.Text = f.deviceName(parameter["Monitor"]);

        }

        /// <summary>
        /// puts the contents of the file chosen in an array
        /// </summary>
        /// <param name="filePath"></param>
        public void fileprocessing1(string filePath)
        {

            try
            {
                Console.WriteLine(txtfile2.Text);

                StreamReader sr = new StreamReader(filePath);
                string line = "";
                string newLine = "";
                int counter1 = 0;

                while (!(line = sr.ReadLine()).Contains("[Note]"))
                {

                    counter1++;
                    string newline = string.Join(" ", line.Split(findOf, StringSplitOptions.RemoveEmptyEntries));
                    List<string> val = newline.Split(' ').ToList();

                    for (int i = 0; i < val.Count(); i++)
                    {
                        parametersArray1.Add(val[i]);
                    }

                }

                try
                {
                    //stores header information in a dictionary with keys and values
                    for (int i = 1; i < parametersArray1.Count(); i += 2)
                    {
                        parameter1.Add(parametersArray1[i], parametersArray1[1 + i]);
                        if (parametersArray1.Any()) //prevent IndexOutOfRangeException for empty list
                        {
                            parametersArray1.RemoveAt(parametersArray1.Count - 1);
                        }
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    MessageBox.Show(e.Message);
                }
                //calculates smode
                smode = parameter1["SMode"];
                SMODE(smode);

                while (!sr.EndOfStream)
                {
                    if ((line = sr.ReadLine()).Contains("[HRData]"))
                    {


                        while ((newLine = sr.ReadLine()) != null)
                        {

                            sortDataIntoArray1(newLine);

                        }
                    }
                }

            }
            catch (InvalidOperationException exc)
            {
                MessageBox.Show(exc.ToString());
            }

            catch (IOException e)
            {
                Console.WriteLine(e);
            }

            Form1 fm = new Form1();
            device2.Text = fm.deviceName(parameter1["Monitor"]);

        }

        /// <summary>
        /// breaks down the data from array into specific paths
        /// </summary>
        /// <param name="line"></param>
        public void sortDataIntoArray(string line)
        {
            try
            {
                int heart2 = 0;
                int speed1 = 0, cadence1 = 0, altitude1 = 0, power1 = 0, powerbal = 0;
                string newline = string.Join(" ", line.Split(findOf, StringSplitOptions.RemoveEmptyEntries));
                List<string> val = newline.Split(' ').ToList();
                if (heartCheck == 1)
                {
                    heart2 = int.Parse(val[0]);
                }
                if (speedCheck == 1)
                {
                    speed1 = int.Parse(val[1]);
                }
                if (cadenceCheck == 1)
                {
                    cadence1 = int.Parse(val[2]);
                }
                if (powerCheck == 1)
                {
                    power1 = int.Parse(val[4]);
                    powerbal = int.Parse(val[5]);

                }
                if (altitudeCheck == 1)
                {
                    altitude1 = int.Parse(val[3]);
                }

                heart.Add(heart2);
                speed.Add(speed1 * 0.1);
                speed_mile.Add(roundOff(speed1 * 0.1 * 0.621371));
                cadence.Add(cadence1);
                altitude.Add(altitude1);
                power.Add(power1);
                powerbalance.Add(powerbal);
                val = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }

        /// <summary>
        /// breaks down the data from array into specific paths
        /// </summary>
        /// <param name="line"></param>
        public void sortDataIntoArray1(string line)
        {
            try
            {
                int hrt = 0, sp = 0, cd = 0, al = 0, pw = 0, pwb = 0;
                string newline = string.Join(" ", line.Split(findOf, StringSplitOptions.RemoveEmptyEntries));
                List<string> val = newline.Split(' ').ToList();
                if (heartCheck == 1)
                {
                    hrt = int.Parse(val[0]);
                }
                if (speedCheck == 1)
                {
                    sp = int.Parse(val[1]);
                }
                if (cadenceCheck == 1)
                {
                    cd = int.Parse(val[2]);
                }
                if (powerCheck == 1)
                {
                    pw = int.Parse(val[4]);
                    pwb = int.Parse(val[5]);

                }
                if (altitudeCheck == 1)
                {
                    al = int.Parse(val[3]);
                }

                heart2.Add(hrt);
                speed2.Add(sp * 0.1);
                speed_mile2.Add(roundOff(sp * 0.1 * 0.621371));
                cadence2.Add(cd);
                altitude2.Add(al);
                power2.Add(pw);
                powerbalance2.Add(pwb);
                val = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// minimizing the decimal value to 2
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static double roundOff(double val)
        {
            double data = Math.Round(val, 2, MidpointRounding.AwayFromZero);
            return data;
        }

        /// <summary>
        /// calculating smode
        /// </summary>
        /// <param name="mode"></param>
        private void SMODE(string mode)
        {
            heartCheck = int.Parse(mode.Substring(0, 1));
            speedCheck = int.Parse(mode.Substring(1, 1));
            cadenceCheck = int.Parse(mode.Substring(2, 1));
            altitudeCheck = int.Parse(mode.Substring(3, 1));
            powerCheck = int.Parse(mode.Substring(4, 1));
        }

        /// <summary>
        /// building the time interval for each row
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public string timeBuilder(string time)
        {
            // fetch the en-GB culture
            CultureInfo ukCulture = new CultureInfo("en-GB");
            dt = DateTime.ParseExact(time, "HH:mm:ss.f", ukCulture.DateTimeFormat);
            string result = dt.AddSeconds(interval).ToString("HH:mm:ss.f");
            return result;
        }

        /// <summary>
        /// displays window of graph when the graph button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btngraph_Click(object sender, EventArgs e)
        {
            if (filedata1.RowCount > 1 && filedata2.RowCount > 1)
            {
                //instansating summarygraph variable (display in combied graph)
                CompareGraph cg = new CompareGraph(heart, speed, cadence, altitude, power, heart2, speed2, cadence2, altitude2, power2, parameter, parameter1);
                cg.Show();
            }
            else
            {
                MessageBox.Show("Please Select the File First");
            }
        }

        /// <summary>
        /// function to fill the data into a table
        /// </summary>
        public void FillTable1()
        {
            int counter = 0;
            foreach (int value in heart)
            {

                filedata1.Rows.Add(timeBuilder(parameter["StartTime"])
                    , heart[counter]
                    , speed[counter]
                    , cadence[counter]
                    , altitude[counter]
                    , power[counter]
                    , powerbalance[counter]
                    );
                counter++;
                interval++;
            }
        }

        /// <summary>
        /// function to fill the data into a table
        /// </summary>
        public void FillTable2()
        {
            int interval = 0;
            int counter1 = 0;
            foreach (int value in heart2)
            {
                filedata2.Rows.Add(timeBuilder(parameter1["StartTime"])
                 , heart2[counter1]
                 , speed2[counter1]
                 , cadence2[counter1]
                 , altitude2[counter1]
                 , power2[counter1]
                 , powerbalance2[counter1]
                 );
                counter1++;
                interval++;
            }

        }

        /// <summary>
        /// specifying the column headers
        /// </summary>
        private void InitGrid()
        {
            filedata1.ColumnCount = 7;
            filedata1.Columns[0].Name = "TimeInterval (HH:MM:SS)";
            filedata1.Columns[1].Name = "Heart Rate (bpm)";
            filedata1.Columns[2].Name = "Speed (km/h)";
            filedata1.Columns[3].Name = "Cadence (rpm)";
            filedata1.Columns[4].Name = "Altitude (m)";
            filedata1.Columns[5].Name = "Power (watts)";
            filedata1.Columns[6].Name = "Power Balance";
        }

        /// <summary>
        /// specifying the column headers
        /// </summary>
        private void InitGrid1()
        {
            filedata2.ColumnCount = 7;
            filedata2.Columns[0].Name = "TimeInterval (HH:MM:SS)";
            filedata2.Columns[1].Name = "Heart Rate (bpm)";
            filedata2.Columns[2].Name = "Speed (km/h)";
            filedata2.Columns[3].Name = "Cadence (rpm)";
            filedata2.Columns[4].Name = "Altitude (m)";
            filedata2.Columns[5].Name = "Power (watts)";
            filedata2.Columns[6].Name = "Power Balance";
        }

        /// <summary>
        /// counts the number of rows in the data grid table
        /// </summary>
        /// <returns></returns>
        public int rowCount()
        {
            int count = 0;
            count = filedata1.RowCount;
            return count;
        }

        /// <summary>
        /// counts the number of rows in the data grid table
        /// </summary>
        /// <returns></returns>
        public int rowCount1()
        {
            int count = 0;
            count = filedata2.RowCount;
            return count;
        }

        /// <summary>
        /// selects the rows to show the values in difference field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filedata1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (filedata1.SelectedRows.Count == 0 || filedata1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Select a Row");
            }
            else
            {
                String[] heart = null, speed = null, cadence = null, altitude = null, power = null, powerBalance = null;

                String[] heart1 = null, speed1 = null, cadence1 = null, altitude1 = null, power1 = null, powerBalance1 = null;

                filedata2.ClearSelection();
                filedata2.Rows[e.RowIndex].Selected = true;

                foreach (DataGridViewRow row in filedata1.SelectedRows)
                {
                    heart = row.Cells[1].Value.ToString().Split(' ');
                    speed = row.Cells[2].Value.ToString().Split(' ');
                    cadence = row.Cells[3].Value.ToString().Split(' ');
                    altitude = row.Cells[4].Value.ToString().Split(' ');
                    power = row.Cells[5].Value.ToString().Split(' ');
                    powerBalance = row.Cells[6].Value.ToString().Split(' ');
                }

                foreach (DataGridViewRow row in filedata2.SelectedRows)
                {
                    heart1 = row.Cells[1].Value.ToString().Split(' ');
                    speed1 = row.Cells[2].Value.ToString().Split(' ');
                    cadence1 = row.Cells[3].Value.ToString().Split(' ');
                    altitude1 = row.Cells[4].Value.ToString().Split(' ');
                    power1 = row.Cells[5].Value.ToString().Split(' ');
                    powerBalance1 = row.Cells[6].Value.ToString().Split(' ');
                }

                double heartNum = double.Parse(heart[0]);
                double speedNum = double.Parse(speed[0]);
                double cadenceNum = double.Parse(cadence[0]);
                double altitudeNum = double.Parse(altitude[0]);
                double powerNum = double.Parse(power[0]);
                double powerbalanceNum = double.Parse(powerBalance[0]);

                double heartNum1 = double.Parse(heart1[0]);
                double speedNum1 = double.Parse(speed1[0]);
                double cadenceNum1 = double.Parse(cadence1[0]);
                double altitudeNum1 = double.Parse(altitude1[0]);
                double powerNum1 = double.Parse(power1[0]);
                double powerbalanceNum1 = double.Parse(powerBalance1[0]);

                string env = Environment.NewLine;
                txtdifference.Text = "Difference In " + env + env +
                    "Heart Rate: " + heartNum + " - " + heartNum1 + " =  " + CalculateDifference(heartNum, heartNum1) +
                    env + "Speed: " + speedNum + " - " + speedNum1 + " =  " + CalculateDifference(speedNum, speedNum1) +
                    env + "Cadence: " + cadenceNum + " - " + cadenceNum1 + " =  " + CalculateDifference(cadenceNum, cadenceNum1) +
                    env + "Altitude: " + altitudeNum + " - " + altitudeNum1 + " =  " + CalculateDifference(altitudeNum, altitudeNum1) +
                    env + "Power: " + powerNum + " - " + powerNum1 + " =  " + CalculateDifference(powerNum, powerNum1) +
                    env + "Power Balance: " + powerbalanceNum + " - " + powerbalanceNum1 + " =  " + CalculateDifference(powerbalanceNum, powerbalanceNum1) +
                    env;

            }
        }

        /// <summary>
        /// action performed when the compare button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncompare_Click_1(object sender, EventArgs e)
        {
            fileprocessing(txtfile1.Text);
            FillTable1();

            fileprocessing1(txtfile2.Text);
            FillTable2();
        }



        /// <summary>
        /// calculates the difference of data
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public string CalculateDifference(double num1, double num2)
        {
            double rst = 0;
            rst = num1 - num2;
            return rst.ToString();
        }
    }
}
