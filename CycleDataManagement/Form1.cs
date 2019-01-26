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
    public partial class Form1 : Form
    {
        public Dictionary<string, List<string>> Data = new Dictionary<string, List<string>>();
        private Dictionary<string, string> parameter = new Dictionary<string, string>();
        public string[] device = new string[] { };
        public int[] arrayTime = { };
        public List<string> paraArrays = new List<string>();
        public List<string> speed = new List<string>();
        public List<string> speed_miles = new List<string>();
        public List<string> cadence = new List<string>();
        public List<string> altitude = new List<string>();
        public List<string> power = new List<string>();
        public List<string> heartRate = new List<string>();
        public List<string> powerBalancePedalling = new List<string>();
        public List<string> intvTime = new List<string>();
        public List<string[]> OriginalData = new List<string[]>();


        public List<string> chunkHeart = new List<string>();
        public List<string> chunkSpeed = new List<string>();
        public List<string> chunkSpeed_miles = new List<string>();
        public List<string> chunkCadence = new List<string>();
        public List<string> chunkAltitude = new List<string>();
        public List<string> chunkPower = new List<string>();
        public List<string> chunkPowerBalancePedalling = new List<string>();
        string time;
        int counter = 0;
        int interval = 0;
        DateTime dt = new DateTime();
        char[] findOf = { '\t', ' ', '=' };
        int cad, hr, pwr, al;
        double sp;
        int sHeart = 0;
        int sSpeed = 0;
        int sCadence = 0;
        int sAltitude = 0;
        int sPower = 0;
        int rowCount = 0;
        int chk_num = 0;
        string smode = "";
        string chunkedData = "";


        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            cmbunit.SelectedIndex = 0; //default speed unit
        }

        /// <summary>
        /// specifying column headers
        /// </summary>
        private void InitializeGrid()
        {
            dataGrid.ColumnCount = 7;
            dataGrid.Columns[0].Name = "Time (HH:MM:SS)";
            dataGrid.Columns[1].Name = "Heart Rate (BPM)";
            dataGrid.Columns[2].Name = "Speed (KM/H)";
            dataGrid.Columns[3].Name = "Speed (MPH)";
            dataGrid.Columns[4].Name = "Cadence (RPM)";
            dataGrid.Columns[5].Name = "Altitude (M/FT)";
            dataGrid.Columns[6].Name = "Power (WATTS)";
        }

        private void Open_Click(object sender, EventArgs e)
        {
            dataGrid.DataSource = null;
            dataGrid.Rows.Clear();
            ReadSource();
            ViewData();
            Calc();
            calculateAdvancedMetrics();
        }

        /// <summary>
        ///read and display the data from  file
        /// </summary>
        public void ReadSource()
        {
            string line = "";
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "HRM|*.hrm|Text Document|*.txt";
            op.Title = "Open File";
            // Display the file select dialog box.  
            if (op.ShowDialog() == DialogResult.OK)   //if users selects a file and opens it
            {
                FileStream fs = (FileStream)op.OpenFile();
                StreamReader sr = new StreamReader(fs);

                while (!(line = sr.ReadLine()).Contains("[Note]"))

                {
                    counter++;

                    string newline = string.Join(" ", line.Split(findOf, StringSplitOptions.RemoveEmptyEntries));
                    List<string> val = newline.Split(' ').ToList();

                    for (int i = 0; i < val.Count(); i++)
                    {
                        paraArrays.Add(val[i]);
                    }

                }
                for (int i = 1; i < paraArrays.Count(); i += 2)
                {
                    parameter.Add(paraArrays[i], paraArrays[1 + i]);
                    if (paraArrays.Any())
                    {
                        paraArrays.RemoveAt(paraArrays.Count - 1);
                    }
                }

                smode = parameter["SMode"];
                SMODE(smode);

                while (!sr.EndOfStream)
                {
                    if ((line = sr.ReadLine()).Contains("[HRData]"))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            //add specific type data to array 
                            sortDataToArray(line);
                        }
                    }
                }

                //adding data to dictionary for eas of access
                DataDictionary();


                if (parameter.ContainsKey("Date"))
                {
                    string dateTime = parameter["Date"];
                    DateTime date = DateTime.ParseExact(dateTime, "yyyyMMdd", CultureInfo.InvariantCulture);
                    lbldate.Text = date.ToString("dddd, MMMM dd yyyy");
                }
                lbldevice.Text = deviceName(parameter["Monitor"]);

                if (parameter.ContainsKey("StartTime"))
                {
                    string time = parameter["StartTime"];
                    lblStartTime.Text = time;
                }
                if (parameter.ContainsKey("Interval"))
                {
                    string intval = parameter["Interval"];
                    lblinterval.Text = intval;
                }

            }
        }
        /// <summary>
        /// array for devices
        /// </summary>
        public string deviceName(string val)
        {
            string[] device = {
                "Polar Sport Tester / Vantage XL",
                "Polar Vantage NV(VNV)",         "Polar Accurex Plus",         "Polar XTrainer Plus",                "N/A",                "Polar S520",                "Polar Coach",
                "Polar S210",
                "Polar S410",
                "Polar S510",
                "Polar S610 / S610i",
                "Polar S710 / S710i / S720i",
                "Polar S810 / S810i",
                "N/A",
                "Polar E600",
                "N/A", "N/A", "N/A", "N/A",
                "Polar AXN500",
                "Polar AXN700",
                "Polar S625X / S725X",
                "Polar S725",
                "N/A","N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A", "N/A",
                "Polar CS400",
                "Polar CS600X",
                "Polar CS600",
                "Polar RS400",
                "Polar RS800",
                "Polar RS800X"
        };
            string dev = device[Convert.ToInt16(val)];
            return dev;
        }
        /// <summary>
        ///split data and adding into list array
        /// </summary>
        public void sortDataToArray(string line)
        {
            try
            {

                string newline = string.Join(" ", line.Split(findOf, StringSplitOptions.RemoveEmptyEntries));
                List<string> val = newline.Split(' ').ToList();
                OriginalData.Add(newline.Split());
                if (sHeart == 1)
                {
                    hr = int.Parse(val[0]);
                }
                if (sSpeed == 1)
                {
                    sp = int.Parse(val[1]);
                }
                if (sCadence == 1)
                {
                    cad = int.Parse(val[2]);
                }
                if (sPower == 1)
                {
                    pwr = int.Parse(val[4]);

                }
                if (sAltitude == 1)
                {
                    al = int.Parse(val[3]);
                }
                heartRate.Add(hr.ToString());
                speed.Add((sp * 0.1).ToString());
                speed_miles.Add((sp * 0.1 * 0.621371).ToString());
                cadence.Add(cad.ToString());
                altitude.Add(al.ToString());
                power.Add(pwr.ToString());
                powerBalancePedalling.Add(val[5]);
                val = null;

            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SMODE(string mode)
        {
            sHeart = int.Parse(mode.Substring(0, 1));
            sSpeed = int.Parse(mode.Substring(1, 1));
            sCadence = int.Parse(mode.Substring(2, 1));
            sAltitude = int.Parse(mode.Substring(3, 1));
            sPower = int.Parse(mode.Substring(4, 1));
        }

        /// <summary>
        /// fetch the en-GB culture for time to be displayed in British format
        /// </summary>
        public string CalcTime(string time)
        {
            CultureInfo ci = new CultureInfo("en-GB");
            dt = DateTime.ParseExact(time, "HH:mm:ss.f", ci.DateTimeFormat);
            string result = dt.AddSeconds(interval).ToString("HH:mm:ss.f");
            return result;
        }

        /// <summary>
        ///displayed list data to grid view table
        /// </summary>
        public void ViewData()
        {
            if (cmbunit.SelectedIndex == 0)
            {
                int counter = 0;
                foreach (var value in speed)
                {
                    dataGrid.Rows.Add(CalcTime(parameter["StartTime"])
                        , heartRate[counter]
                        , speed[counter]
                        , speed_miles[counter]
                        , cadence[counter]
                        , altitude[counter]
                        , power[counter]
                        );
                    counter++;
                    interval = interval + 1;
                }
            }
}

        /// <summary>
        ///adding data to dictionary
        /// </summary>
        private void DataDictionary()
        {
            Data.Add("heartRate", heartRate);
            Data.Add("speed", speed);
            Data.Add("speed_miles", speed_miles);
            Data.Add("cadence", cadence);
            Data.Add("altitude", altitude);
            Data.Add("power", power);
        }


        /// <summary>
        /// calculation
        /// </summary>
        private void Calc()
        {
            var maxSpeed = Calculate.Max(Data["speed"]);
            var totalDistanceCovered = Calculate.Sum(Data["speed"]);
            double averageSpeed = Calculate.Average(Data["speed"]);
            double avSpeed = Calculate.Average(Data["speed"]);
            var averageHeartRate = Calculate.Average(Data["heartRate"]);
            var maximumHeartRate = Calculate.Max(Data["heartRate"]);
            var minimumHeartRate = Calculate.Min(Data["heartRate"]);

            var totalDistance = Calculate.Total(avSpeed, dataGrid.RowCount, Int32.Parse(parameter["Interval"]));


            var averagePower = Calculate.Average(Data["power"]);
            var maximumPower = Calculate.Max(Data["power"]);

            var averageAltitude = Calculate.Average(Data["altitude"]);
            var maximumAltitude = Calculate.Max(Data["altitude"]);

            //summary of data to be displayed
            lbltotal.Text = RoundOff(totalDistance) + " km";
            lblavspeed.Text = RoundOff(averageSpeed) + " km/h";
            lblmaxspeed.Text = RoundOff(maxSpeed) + " km/h";
            lblavhrate.Text = RoundOff(averageHeartRate) + "  BPM";
            lblmaxhrate.Text = RoundOff(maximumHeartRate) + "  BPM";
            lblavhrate.Text = RoundOff(minimumHeartRate) + "  BPM";
            lblavpwr.Text = RoundOff(averagePower) + "  watt";
            lblmaxpwr.Text = RoundOff(maximumPower) + "  watt";
            lblavalt.Text = RoundOff(averageAltitude) + " m/ft";
        }

        /// <summary>
        ///combobox to select speed unit
        /// </summary>
        private void Cmbunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbunit.SelectedIndex == 0)
            {
                dataGrid.Columns[2].Visible = true;
                dataGrid.Columns[3].Visible = false;
                return;
            }
            dataGrid.Columns[3].Visible = true;
            dataGrid.Columns[2].Visible = false;
        }

        /// <summary>
        /// function to select two rows and to show their data value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnview_Click(object sender, EventArgs e)
        {
            if (dataGrid.SelectedRows.Count < 1 && dataGrid.SelectedColumns.Count < 6)
            {
                MessageBox.Show("Please select at least two rows");
            }
            else
            {
                refresh();
                foreach (DataGridViewRow row in dataGrid.SelectedRows)
                {
                    string[] line = row.Cells[0].Value.ToString().Split(' ');
                    intvTime.Add(line[0]);

                    string[] line1 = row.Cells[1].Value.ToString().Split(' ');
                    heartRate.Add(line1[0]);

                    string[] line2 = row.Cells[2].Value.ToString().Split(' ');
                    speed.Add(line2[0]);

                    string[] spm = row.Cells[3].Value.ToString().Split(' ');
                    speed_miles.Add(spm[0]);

                    string[] line3 = row.Cells[4].Value.ToString().Split(' ');
                    cadence.Add(line3[0]);

                    string[] line4 = row.Cells[5].Value.ToString().Split(' ');
                    altitude.Add(line4[0]);

                    string[] line5 = row.Cells[6].Value.ToString().Split(' ');
                    power.Add(line5[0]);
                    powerBalancePedalling.Add(0.ToString());
                }
                dataGrid.Rows.Clear();
                dataGrid.Refresh();
                ViewData();
                Dictionary<string, List<string>> hrData = new Dictionary<string, List<string>>();
                DataDictionary();
                Calc();
            }
        }
        /// <summary>
        /// refresh values
        /// </summary>
        public void refresh()
        {
            counter = 0;
            interval = 0;
            heartRate = new List<string>();
            speed = new List<string>();
            speed_miles = new List<string>();
            cadence = new List<string>();
            altitude = new List<string>();
            power = new List<string>(); ;
            powerBalancePedalling = new List<string>();
            intvTime = new List<string>();
            Data = new Dictionary<string, List<string>>();
            sHeart = 0;
            sSpeed = 0;
            sCadence = 0;
            sAltitude = 0;
            sPower = 0;

        }

        public int dataCount()
        {
            rowCount = dataGrid.RowCount;
            return rowCount;
        }

        private static double RoundOff(double val)
        {
            double data = Math.Round(val, 2, MidpointRounding.AwayFromZero);
            return data;
        }
        /// <summary>
        /// action when prepare chunk button is pressed for chunking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataCount() >= 4 && !string.IsNullOrEmpty(cmbChunk.Text))
            {
                int chunk_number = 0;
                string[] heart = heartRate.ToArray();
                int num = heart.Length;
                chunk_number = int.Parse(cmbChunk.Text);
                chk_num = int.Parse((num / chunk_number).ToString());

                if (chunk_number == 1)
                {
                    MessageBox.Show("First level chunking is already done. Please select more than 1 chunk");
                }
                else if (chunk_number == 2)
                {
                    btnchunk1.Enabled = true;
                    btnchunk2.Enabled = true;
                    btnchunk3.Enabled = false;
                    btnchunk4.Enabled = false;
                }
                else if (chunk_number == 3)
                {
                    btnchunk1.Enabled = true;
                    btnchunk2.Enabled = true;
                    btnchunk3.Enabled = true;
                    btnchunk4.Enabled = false;

                }
                else if (chunk_number == 4)
                {
                    btnchunk1.Enabled = true;
                    btnchunk2.Enabled = true;
                    btnchunk3.Enabled = true;
                    btnchunk4.Enabled = true;
                }
                Array();
                MessageBox.Show("Chunk Prepared");
            }
            else
            {
                MessageBox.Show("Four Rows would have been Selected At least.");
            }
        }
        /// <summary>
        /// array of data for chunking
        /// </summary>
        public void Array()
        {
            foreach (string var in heartRate)
            {
                chunkHeart.Add(var);
            }
            foreach (string var in speed)
            {
                chunkSpeed.Add(var);
            }
            foreach (string var in speed_miles)
            {
                chunkSpeed_miles.Add(var);
            }
            foreach (string var in cadence)
            {
                chunkCadence.Add(var);
            }
            foreach (string var in altitude)
            {
                chunkAltitude.Add(var);
            }
            foreach (string var in power)
            {
                chunkPower.Add(var);
            }
            foreach (string var in powerBalancePedalling)
            {
                chunkPowerBalancePedalling.Add(var);
            }
        }
        /// <summary>
        /// buttons for various levels of chunking
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnchunk1_Click(object sender, EventArgs e)
        {
            if (chk_num > 1)
            {
                string[] heart_array = chunkHeart.ToArray();
                string[] speed_array = chunkSpeed.ToArray();
                string[] speed_mile_array = chunkSpeed_miles.ToArray();
                string[] cadence_array = chunkCadence.ToArray();
                string[] altitude_array = chunkAltitude.ToArray();
                string[] power_array = chunkPower.ToArray();
                string[] pow_bal_array = chunkPowerBalancePedalling.ToArray();

                refresh();
                for (int ctr1 = 0; ctr1 < chk_num; ctr1++)
                {
                    heartRate.Add(heart_array[ctr1]);
                    speed.Add(speed_array[ctr1]);
                    speed_miles.Add(speed_mile_array[ctr1]);
                    cadence.Add(cadence_array[ctr1]);
                    altitude.Add(altitude_array[ctr1]);
                    power.Add(power_array[ctr1]);
                    powerBalancePedalling.Add(pow_bal_array[ctr1]);
                }
                dataGrid.Rows.Clear();
                dataGrid.Refresh();
                ViewData();
                Dictionary<string, List<string>> hrData = new Dictionary<string, List<string>>();
                DataDictionary();
                Calc();
            }
            else
            {
                MessageBox.Show("Please select chunk level");
            }
        }

        private void btnchunk2_Click(object sender, EventArgs e)
        {
            if (chk_num > 1)
            {
                string[] heart_array = chunkHeart.ToArray();
                string[] speed_array = chunkSpeed.ToArray();
                string[] speed_mile_array = chunkSpeed_miles.ToArray();
                string[] cadence_array = chunkCadence.ToArray();
                string[] altitude_array = chunkAltitude.ToArray();
                string[] power_array = chunkPower.ToArray();
                string[] pow_bal_array = chunkPowerBalancePedalling.ToArray();

                refresh();
                int chunk2 = chk_num * 2;
                for (int ctr1 = chk_num; ctr1 < chunk2; ctr1++)
                {
                    heartRate.Add(heart_array[ctr1]);
                    speed.Add(speed_array[ctr1]);
                    speed_miles.Add(speed_mile_array[ctr1]);
                    cadence.Add(cadence_array[ctr1]);
                    altitude.Add(altitude_array[ctr1]);
                    power.Add(power_array[ctr1]);
                    powerBalancePedalling.Add(pow_bal_array[ctr1]);
                }
                dataGrid.Rows.Clear();
                dataGrid.Refresh();
                ViewData();
                Dictionary<string, List<string>> hrData = new Dictionary<string, List<string>>();
                DataDictionary();
                Calc();
            }
            else
            {
                MessageBox.Show("Please select chunk level");
            }

        }

        private void btnchunk3_Click(object sender, EventArgs e)
        {
            if (chk_num > 1)
            {
                string[] heart_array = chunkHeart.ToArray();
                string[] speed_array = chunkSpeed.ToArray();
                string[] speed_mile_array = chunkSpeed_miles.ToArray();
                string[] cadence_array = chunkCadence.ToArray();
                string[] altitude_array = chunkAltitude.ToArray();
                string[] power_array = chunkPower.ToArray();
                string[] pow_bal_array = chunkPowerBalancePedalling.ToArray();

                refresh();
                int chunk3 = chk_num * 3;
                for (int ctr1 = chk_num * 2; ctr1 < chunk3; ctr1++)
                {
                    heartRate.Add(heart_array[ctr1]);
                    speed.Add(speed_array[ctr1]);
                    speed_miles.Add(speed_mile_array[ctr1]);
                    cadence.Add(cadence_array[ctr1]);
                    altitude.Add(altitude_array[ctr1]);
                    power.Add(power_array[ctr1]);
                    powerBalancePedalling.Add(pow_bal_array[ctr1]);
                }
                dataGrid.Rows.Clear();
                dataGrid.Refresh();
                ViewData();
                Dictionary<string, List<string>> hrData = new Dictionary<string, List<string>>();
                DataDictionary();
                Calc();
            }
            else
            {
                MessageBox.Show("Please select chunk level");
            }
        }

        private void btnchunk4_Click(object sender, EventArgs e)
        {
            if (chk_num > 1)
            {
                string[] heart_array = chunkHeart.ToArray();
                string[] speed_array = chunkSpeed.ToArray();
                string[] speed_mile_array = chunkSpeed_miles.ToArray();
                string[] cadence_array = chunkCadence.ToArray();
                string[] altitude_array = chunkAltitude.ToArray();
                string[] power_array = chunkPower.ToArray();
                string[] pow_bal_array = chunkPowerBalancePedalling.ToArray();

                refresh();
                int chunk4 = chk_num * 4;
                for (int ctr1 = chk_num * 3; ctr1 < chunk4; ctr1++)
                {
                    heartRate.Add(heart_array[ctr1]);
                    speed.Add(speed_array[ctr1]);
                    speed_miles.Add(speed_mile_array[ctr1]);
                    cadence.Add(cadence_array[ctr1]);
                    altitude.Add(altitude_array[ctr1]);
                    power.Add(power_array[ctr1]);
                    powerBalancePedalling.Add(pow_bal_array[ctr1]);
                }
                dataGrid.Rows.Clear();
                dataGrid.Refresh();
                ViewData();
                Dictionary<string, List<string>> hrData = new Dictionary<string, List<string>>();
                DataDictionary();
                Calc();
            }
            else
            {
                MessageBox.Show("Please select chunk level");
            }
        }
        /// <summary>
        /// action for redirecting to compare graph form when the menu tool strip is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void compareFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compare c = new Compare();
            c.Show();
        }

        /// <summary>
        /// submenustrip for individual graph
        /// </summary>
        private void IndividualGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Individual i = new Individual(heartRate, speed, cadence, altitude, power);
            i.Show();
        }

        /// <summary>
        /// menu for main graph
        /// </summary>
        private void MainGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graph g = new Graph(heartRate, speed, cadence, altitude, power);
            g.Show();
        }

        /// <summary>
        /// function for calculation of advanced metrics
        /// </summary>
        public void calculateAdvancedMetrics()
        {
            Calculate c = new Calculate(heartRate, speed, speed_miles, cadence, altitude, power, time);
            string FTP = c.CalculateFTP();
            string NP = c.CalculateNP();
            double PB = c.CalculatePB();
            string IF = c.CalculateIF();
            string TSS = c.CalculateTSS();

            lblftp.Text = FTP + " watts";
            lbltss.Text = TSS + "";
            lblif.Text = IF + "";
            lblpb.Text = RoundOff(PB).ToString();
            lblnp.Text = NP + " watts";
        }


        /// <summary>
        /// Calculates and retruns the average of the chunked data.
        /// </summary>
        /// <param name="totalData">the chunk of data whose averages should be calculated.</param>
        /// <returns></returns>
        private string CalculateAverageOfChunks(List<List<string[]>> totalData)
        {
            string result = "";
            int chunkCounter = 1;
            int totalChunks = totalData.Count;

            foreach (List<string[]> strList in totalData)
            {
                result += ("Average For Chunk #" + chunkCounter + "\n");
                // heart rate, speed, cadence, altitude, power
                double heartRate = 0;
                double speed = 0;
                double cadence = 0;
                double altitude = 0;
                double power = 0;

                // calculating average now
                heartRate = Calculate.GetAverage(strList, 0);
                speed = Calculate.GetAverage(strList, 1);
                cadence = Calculate.GetAverage(strList, 2);
                altitude = Calculate.GetAverage(strList, 3);
                power = Calculate.GetAverage(strList, 4);

                result += "Average Heart Rate : " + heartRate + "\n";
                result += "Average Speed : " + speed + "\n";
                result += "Average Cadence : " + cadence + "\n";
                result += "Average Altitude : " + altitude + "\n";
                result += "Average Power : " + power + "\n\n\n";

                // next chunk
                chunkCounter++;
            }

            return result;
        }

        /// <summary>
        /// Break the passed data into specified number of chunks and return it as list of chunks.
        /// </summary>
        /// <param name="numberOfChunks">expected number of chunks for the data</param>
        /// <param name="data">the actual data which requires chunking</param>
        /// <returns></returns>
        private List<List<string[]>> BreakDataIntoChunks(int numberOfChunks, List<string[]> data)
        {
            int sizeOfData = data.Count;
            // this number of items will be placed in a chunk
            int splitAtEvery = sizeOfData / numberOfChunks;

            List<List<string[]>> comparisonData = new List<List<string[]>>();

            int endAt = 0;

            // iterate over number of times
            for (int i = 0; i < numberOfChunks; i++)
            {
                List<string[]> temp = new List<string[]>();

                // increase the amount of data to be retrieved from chunk
                endAt = endAt + splitAtEvery;

                for (int j = 0; j < endAt; j++)
                {
                    // get the values upto the specified index
                    temp.Add(data[j]);
                }

                // add the value to the file
                comparisonData.Add(temp);
            }

            return comparisonData;
        }

        private void btninterval_Click(object sender, EventArgs e)
        {
            if (dataCount() == 0)
            {
                txtinterval.Text = "To detect interval you must load a file first.";
                return;
            }

            int intervals = Calculate.DetectClearInterval(speed);

            List<List<string[]>> totalData = BreakDataIntoChunks(intervals, OriginalData);

            string average = CalculateAverageOfChunks(totalData);
            chunkedData = average;

            IntervalDetection id = new IntervalDetection(chunkedData);
            id.Show();


            txtinterval.Text = "There were " + Convert.ToString(intervals) + " intervals during the period of cycling.";

        }



    }
}
 