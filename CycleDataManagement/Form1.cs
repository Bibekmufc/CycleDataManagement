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
        string smode = "";


        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            cmbunit.SelectedIndex = 0;
        }

        //specifying column header
        private void InitializeGrid()
        {
            dataGrid.ColumnCount = 6;
            dataGrid.Columns[0].Name = "Time (HH:MM:SS)";
            dataGrid.Columns[1].Name = "Heart Rate (BPM)";
            dataGrid.Columns[2].Name = "Speed (KM/H)";
            dataGrid.Columns[3].Name = "Cadence (RPM)";
            dataGrid.Columns[4].Name = "Altitude (M/FT)";
            dataGrid.Columns[5].Name = "Power (WATTS)";
        }

        private void Open_Click(object sender, EventArgs e)
        {
            dataGrid.DataSource = null;
            dataGrid.Rows.Clear();
            ReadSource();
            viewData();
            Calc();
        }

        //read and display the data from  file
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

                //adding hr data to dictionary for easy access
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
        private string deviceName(string val)
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
        //split data and adding into list array
        public void sortDataToArray(string line)
        {
            try
            {

                string newline = string.Join(" ", line.Split(findOf, StringSplitOptions.RemoveEmptyEntries));
                List<string> val = newline.Split(' ').ToList();
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


        public string calcTime(string time)
        {
            // fetch the en-GB culture
            CultureInfo ci = new CultureInfo("en-GB");
            dt = DateTime.ParseExact(time, "HH:mm:ss.f", ci.DateTimeFormat);
            string result = dt.AddSeconds(interval).ToString("HH:mm:ss.f");
            return result;
        }

        //displayed list data to grid view table
        public void viewData()
        {

            int counter = 0;
            foreach (var value in speed)
            {
                dataGrid.Rows.Add(calcTime(parameter["StartTime"])
                    , heartRate[counter]
                    , speed[counter]
                    , cadence[counter]
                    , altitude[counter]
                    , power[counter]
                    );
                counter++;
                interval = interval + 1;
    }
}

        private void CalculateSpeed(string type)
        {
            if (Data.Count > 0)
            {
                List<string> data = new List<string>();
                if (type == "Miles")
                {
                    dataGrid.Columns[2].Name = "Speed(Mile/hr)";

                    data.Clear();
                    for (int i = 0; i < Data.Count; i++)
                    {
                        string temp = (Convert.ToDouble(Data["speed"][i]) / 100).ToString();
                        data.Add(temp);
                    }

                    Data["speed"].Clear();
                    Data["speed"] = data;

                    //dataGridView1.SelectedCells[0].Value = 10.ToString();
                    //dataGridView1.SelectedCells[1].Value = 10.ToString();

                    //dataGrid.Update();
                    //dataGrid.Refresh();
                }
                else
                {
                    dataGrid.Columns[2].Name = "Speed(km/hr)";

                    data.Clear();
                    for (int i = 0; i < Data.Count; i++)
                    {
                        string temp = (Convert.ToDouble(Data["speed"][i]) / 1.5).ToString();
                        data.Add(temp);
                    }

                    Data["speed"].Clear();
                    Data["speed"] = data;

                    dataGrid.Update();
                    dataGrid.Refresh();
                }
            }
        }


        //adding HRdata to dictionary 
        private void DataDictionary()
        {
            Data.Add("heartRate", heartRate);
            Data.Add("speed", speed);
            Data.Add("cadence", cadence);
            Data.Add("altitude", altitude);
            Data.Add("power", power);
        }


        //summary calculation
        private void Calc()
        {
            var maxSpeed = Calculate.Max(Data["speed"]);
            var totalDistanceCovered = Calculate.Sum(Data["speed"]);
            var averageSpeed = Calculate.Average(Data["speed"]);
            var averageHeartRate = Calculate.Average(Data["heartRate"]);
            var maximumHeartRate = Calculate.Max(Data["heartRate"]);
            var minimumHeartRate = Calculate.Min(Data["heartRate"]);

            var averagePower = Calculate.Average(Data["power"]);
            var maximumPower = Calculate.Max(Data["power"]);

            var averageAltitude = Calculate.Average(Data["altitude"]);
            var maximumAltitude = Calculate.Max(Data["altitude"]);

            //summary of data 
            lbltotal.Text = totalDistanceCovered.ToString();
            lblavspeed.Text = averageSpeed.ToString();
            lblmaxspeed.Text = maxSpeed.ToString();
            lblavhrate.Text = averageHeartRate.ToString();
            lblmaxhrate.Text = maximumHeartRate.ToString() + "" + "BPM";
            lblavhrate.Text = minimumHeartRate.ToString();
            lblavpwr.Text = averagePower.ToString();
            lblmaxpwr.Text = maximumPower.ToString();
            lblavalt.Text = averageAltitude.ToString();


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateSpeed("KM");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateSpeed("Miles");
        }

        private void arrayNuller()
        {
            Data = new Dictionary<string, List<string>>();
            parameter = new Dictionary<string, string>();
            paraArrays = new List<string>();
            arrayTime = new int[] { };
            heartRate = new List<string>();
            speed = new List<string>();
            cadence = new List<string>();
            altitude = new List<string>();
            power = new List<string>();
            powerBalancePedalling = new List<string>();
            device = new string[] { };
            counter = 0;
            interval = 0;
            findOf = new char[] { };
            dataGrid.DataSource = null;
            dataGrid.Rows.Clear();

            lbltotal.Text = "";
            lblavspeed.Text = "";
            lblmaxspeed.Text = "";
            lblavhrate.Text = "";
            lblmaxhrate.Text = "";
            lblavpwr.Text = "";
            lblmaxpwr.Text = "";
            lblavalt.Text = "";
            lbldevice.Text = "";
            lblStartTime.Text = "";
            lblinterval.Text = "";
        }

        private void IndividualGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Individual i = new Individual(heartRate, speed, cadence, altitude, power);
            i.Show();
        }

        private void MainGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Graph g = new Graph(heartRate, speed, cadence, altitude, power);
            g.Show();
        }
    }
}
 