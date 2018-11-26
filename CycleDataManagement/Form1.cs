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
        public List<string> cadence = new List<string>();
        public List<string> altitude = new List<string>();
        public List<string> power = new List<string>();
        public List<string> heartRate = new List<string>();
        public List<string> powerBalancePedalling = new List<string>();
        int counter = 0;
        int interval = 0;
        DateTime dt = new DateTime();
        char[] findOf = { '\t', ' ', '=' };


        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
        }

        //specifying column header
        private void InitializeGrid()
        {
            dataGrid.ColumnCount = 6;
            dataGrid.Columns[5].Name = "Time (HH:MM:SS)";
            dataGrid.Columns[0].Name = "Heart Rate (BPM)";
            dataGrid.Columns[1].Name = "Speed (KM/H)";
            dataGrid.Columns[2].Name = "Cadence (RPM)";
            dataGrid.Columns[3].Name = "Altitude (M/FT)";
            dataGrid.Columns[4].Name = "Power (WATTS)";
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
                heartRate.Add(val[0]);
                speed.Add(val[1]);
                cadence.Add(val[2]);
                altitude.Add(val[3]);
                power.Add(val[4]);
                powerBalancePedalling.Add(val[5]);
                val = null;

            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     /*   public string calcTime(string time)
        {
            // fetch the en-GB culture
            CultureInfo ci = new CultureInfo("en-GB");
            dt = DateTime.ParseExact(time, "HH:mm:ss", ci.DateTimeFormat);
            string result = dt.AddSeconds(interval).ToString("HH:mm:ss");
            return result;
        } */

        //displayed list data to grid view table
        public void viewData()
        {

            int counter = 0;
            foreach (var value in speed)
            {
                dataGrid.Rows.Add(/*calcTime(parameter["StartTime"])*/
                     heartRate[counter]
                    , speed[counter]
                    , cadence[counter]
                    , altitude[counter]
                    , power[counter]
                    );
                counter++;
                interval = interval + 1;
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
            lblmaxhrate.Text = maximumHeartRate.ToString();
            lblavhrate.Text = minimumHeartRate.ToString();
            lblavpwr.Text = averagePower.ToString();
            lblmaxpwr.Text = maximumPower.ToString();
            lblavalt.Text = averageAltitude.ToString();


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
 