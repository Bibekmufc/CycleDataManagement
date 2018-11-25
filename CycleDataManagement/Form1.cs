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
        public List<string> paraArrays = new List<string>();
        public List<string> speed = new List<string>();
        public List<string> cadence = new List<string>();
        public List<string> altitude = new List<string>();
        public List<string> power = new List<string>();
        public List<string> heartRate = new List<string>();
        public List<string> powerBalancePedalling = new List<string>();
        int counter = 0;
        char[] findOf = { '\t', ' ', '=' };


        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
        }

        //specifying column header
        private void InitializeGrid()
        {
            dataGrid.ColumnCount = 5;
            dataGrid.Columns[0].Name = "Heart Rate (bpm)";
            dataGrid.Columns[1].Name = "Speed (km/h)";
            dataGrid.Columns[2].Name = "Cadence (rpm)";
            dataGrid.Columns[3].Name = "Altitude (m/ft)";
            dataGrid.Columns[4].Name = "Power (watts)";
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
            // If the user clicked OK in the dialog then  ,
            if (op.ShowDialog() == DialogResult.OK)
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
                try
                {
                    for (int i = 1; i < paraArrays.Count(); i += 2)
                    {
                        parameter.Add(paraArrays[i], paraArrays[0 + i]);
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message);
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
                    string date = parameter["Date"];
                    DateTime dt = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    lbldate.Text = dt.ToString("dddd, MMMM dd yyyy");
                }
                if (parameter.ContainsKey("StartTime"))
                {
                    string time = parameter["StartTime"];
                    lblstar.Text = time;
                }
                if (parameter.ContainsKey("Interval"))
                {
                    string intval = parameter["Interval"];
                    lblinterval.Text = intval;
                }


            }
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

        //displayed list data to grid view table
        public void viewData()
        {

            int counter = 0;
            foreach (var value in speed)
            {
                dataGrid.Rows.Add(heartRate[counter]
                    , speed[counter]
                    , cadence[counter]
                    , altitude[counter]
                    , power[counter]);
                counter++;
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
            //var totalDistanceCovered = Summary.Sum(hrData["cadence"]);
            var averageSpeed = Calculate.Average(Data["speed"]);
            var averageHeartRate = Calculate.Average(Data["heartRate"]);
            var maximumHeartRate = Calculate.Max(Data["heartRate"]);
            var minimumHeartRate = Calculate.Min(Data["heartRate"]);

            var averagePower = Calculate.Average(Data["power"]);
            var maximumPower = Calculate.Max(Data["power"]);

            var averageAltitude = Calculate.Average(Data["altitude"]);
            var maximumAltitude = Calculate.Max(Data["altitude"]);

            //summary of data 
            lbltotal.Text = null;
            lblavspeed.Text = averageSpeed.ToString();
            lblmaxspeed.Text = maxSpeed.ToString();
            lblavhrate.Text = averageHeartRate.ToString();
            lblmaxhrate.Text = maximumHeartRate.ToString();
            lblavhrate.Text = minimumHeartRate.ToString();
            lblavpwr.Text = averagePower.ToString();
            lblmaxpwr.Text = maximumPower.ToString();
            lblavalt.Text = averageAltitude.ToString();


        }
    }
}