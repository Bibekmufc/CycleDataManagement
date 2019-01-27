using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace CycleDataManagement
{
    /// <summary>
    /// this class is used to compare the graphs of two chosen files
    /// </summary>
    public partial class CompareGraph : Form
    {
        List<int> heart = null;
        List<double> speed = null;
        List<int> cadence = null;
        List<int> altitude = null;
        List<int> power = null;

        List<int> heart2 = null;
        List<double> speed2 = null;
        List<int> cadence2 = null;
        List<int> altitude2 = null;
        List<int> power2 = null;
        Dictionary<string, string> parameter = null;
        Dictionary<string, string> parameter1 = null;

        Compare cm = new Compare();

        /// <summary>
        /// constructor of this class
        /// </summary>
        /// <param name="heart"></param>
        /// <param name="speed"></param>
        /// <param name="cadence"></param>
        /// <param name="altitude"></param>
        /// <param name="power"></param>
        /// <param name="heart2"></param>
        /// <param name="speed2"></param>
        /// <param name="cadence2"></param>
        /// <param name="altitude2"></param>
        /// <param name="power2"></param>
        /// <param name="parameter"></param>
        /// <param name="parameter1"></param>
        public CompareGraph(List<int> heart,
            List<double> speed,
            List<int> cadence,
            List<int> altitude,
            List<int> power,
            List<int> heart2,
            List<double> speed2,
            List<int> cadence2,
            List<int> altitude2,
            List<int> power2,
            Dictionary<string, string> parameter,
            Dictionary<string, string> parameter1
            )
        {
            InitializeComponent();
            this.heart = heart;
            this.speed = speed;
            this.cadence = cadence;
            this.altitude = altitude;
            this.power = power;

            this.heart2 = heart2;
            this.speed2 = speed2;
            this.cadence2 = cadence2;
            this.altitude2 = altitude2;
            this.power2 = power2;
            this.parameter = parameter;
            this.parameter1 = parameter1;
        }
        /// <summary>
        /// function to assign pointpairlist key and value
        /// </summary>
        /// <param name="data">accepts value of array of integer type</param>
        /// <returns>returns the point</returns>
        private PointPairList buildPointPairList(int[] data)
        {
            PointPairList pt = new PointPairList();

            for (int counter = 0; counter < data.Length; counter++)
            {
                pt.Add(counter, (data[counter]));
            }
            return pt;

        }
        /// <summary>
        /// function to assign pointpairlist key and value
        /// </summary>
        /// <param name="data">accepts value of array of double type</param>
        /// <returns>returns the point</returns>
        private PointPairList buildPointPairList(double[] data)
        {
            PointPairList pt = new PointPairList();

            for (int counter = 0; counter < data.Length; counter++)
            {
                pt.Add(counter, (data[counter]));
            }
            return pt;

        }

        /// <summary>
        /// function to plot points in the graph
        /// </summary>
        private void plotToGraph()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            myPane.Title = "Summary Graph of First File";
            myPane.XAxis.Title = "Time in second";
            myPane.YAxis.Title = "Parameters";
            myPane.PaneFill.Color = Color.LightGray;
            myPane.AxisFill.Color = Color.MintCream;

            GraphPane myPane1 = zedGraphControl2.GraphPane;
            myPane1.Title = "Summary Graph of Second File";
            myPane1.XAxis.Title = "Time in second";
            myPane1.YAxis.Title = "Parameters ";
            myPane1.PaneFill.Color = Color.LightGray;
            myPane1.AxisFill.Color = Color.MintCream;
            PointPairList heartPairList = new PointPairList();
            PointPairList speedPairList = new PointPairList();
            PointPairList cadencePAirList = new PointPairList();
            PointPairList powerPairList = new PointPairList();
            PointPairList altitudePairList = new PointPairList();

            PointPairList heartPairList1 = new PointPairList();
            PointPairList speedPairList1 = new PointPairList();
            PointPairList cadencePAirList1 = new PointPairList();
            PointPairList powerPairList1 = new PointPairList();
            PointPairList altitudePairList1 = new PointPairList();



            heartPairList = buildPointPairList(heart.ToArray());
            speedPairList = buildPointPairList(speed.ToArray());
            cadencePAirList = buildPointPairList(cadence.ToArray());
            powerPairList = buildPointPairList(power.ToArray());
            altitudePairList = buildPointPairList(altitude.ToArray());

            heartPairList1 = buildPointPairList(heart2.ToArray());
            speedPairList1 = buildPointPairList(speed2.ToArray());
            cadencePAirList1 = buildPointPairList(cadence2.ToArray());
            powerPairList1 = buildPointPairList(power2.ToArray());
            altitudePairList1 = buildPointPairList(altitude2.ToArray());


            LineItem teamACurve = myPane.AddCurve("Heart Rate", heartPairList, Color.Red, SymbolType.None);
            LineItem teamACurve1 = myPane.AddCurve("Speed", speedPairList, Color.Blue, SymbolType.None);
            LineItem teamACurve2 = myPane.AddCurve("Cadence", cadencePAirList, Color.Yellow, SymbolType.None);
            LineItem teamACurve3 = myPane.AddCurve("Altitude", altitudePairList, Color.Violet, SymbolType.None);
            LineItem teamACurve4 = myPane.AddCurve("Power", powerPairList, Color.DarkCyan, SymbolType.None);


            LineItem teamACurve5 = myPane1.AddCurve("Heart Rate", heartPairList1, Color.Red, SymbolType.None);
            LineItem teamACurve6 = myPane1.AddCurve("Speed", speedPairList1, Color.Blue, SymbolType.None);
            LineItem teamACurve7 = myPane1.AddCurve("Cadence", cadencePAirList1, Color.Yellow, SymbolType.None);
            LineItem teamACurve8 = myPane1.AddCurve("Altitude", altitudePairList1, Color.Violet, SymbolType.None);
            LineItem teamACurve9 = myPane1.AddCurve("Power", powerPairList1, Color.DarkCyan, SymbolType.None);

            zedGraphControl1.AxisChange();
            zedGraphControl2.AxisChange();
        }
 
        /// <summary>
        /// initialized when the form in loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompareGraph_Load(object sender, EventArgs e)
        {
            plotToGraph();
            Calc();
            Calc2();
        }


        /// <summary>
        /// calculation of data to be displayed of first graph
        /// </summary>
        private void Calc()
        {
            var maxSpeed = Calculate.Max(speed);
            var totalDistanceCovered = Calculate.Average(speed);
            double averageSpeed = Calculate.Average(speed);
            double avSpeed = Calculate.Average(speed);
            var averageHeartRate = Calculate.Average(heart);
            var maximumHeartRate = Calculate.Max(heart);
            var minimumHeartRate = Calculate.Min(heart);

            var totalDistance = Calculate.Total(avSpeed, cm.rowCount(), Int32.Parse(parameter["Interval"]));


            var averagePower = Calculate.Average(power);
            var maximumPower = Calculate.Max(power);

            var averageAltitude = Calculate.Average(altitude);
            var maximumAltitude = Calculate.Max(altitude);

            lbltotal.Text = Compare.roundOff(totalDistance) + " km";
            lblavspeed.Text = Compare.roundOff(averageSpeed) + " km/h";
            lblmaxspeed.Text = Compare.roundOff(maxSpeed) + " km/h";
            lblavhrate.Text = Compare.roundOff(averageHeartRate) + "  BPM";
            lblmaxhrate.Text = Compare.roundOff(maximumHeartRate) + "  BPM";
            lblavhrate.Text = Compare.roundOff(minimumHeartRate) + "  BPM";
            lblavpwr.Text = Compare.roundOff(averagePower) + "  watt";
            lblmaxpwr.Text = Compare.roundOff(maximumPower) + "  watt";
            lblavalt.Text = Compare.roundOff(averageAltitude) + " m/ft";

        }

        /// <summary>
        /// calculation of data for second graph
        /// </summary>
        private void Calc2()
        {
            var maxSpeed = Calculate.Max(speed2);
            var totalDistanceCovered = Calculate.Average(speed2);
            double averageSpeed = Calculate.Average(speed2);
            double avSpeed = Calculate.Average(speed2);
            var averageHeartRate = Calculate.Average(heart2);
            var maximumHeartRate = Calculate.Max(heart2);
            var minimumHeartRate = Calculate.Min(heart2);

            var totalDistance = Calculate.Total(avSpeed, cm.rowCount1(), Int32.Parse(parameter["Interval"]));


            var averagePower = Calculate.Average(power);
            var maximumPower = Calculate.Max(power);

            var averageAltitude = Calculate.Average(altitude);
            var maximumAltitude = Calculate.Max(altitude);

            lbltotal2.Text = Compare.roundOff(totalDistance) + " km";
            lblavspeed2.Text = Compare.roundOff(averageSpeed) + " km/h";
            lblmaxspeed2.Text = Compare.roundOff(maxSpeed) + " km/h";
            lblavhrate2.Text = Compare.roundOff(averageHeartRate) + "  BPM";
            lblmaxhrate2.Text = Compare.roundOff(maximumHeartRate) + "  BPM";
            lblavhrate2.Text = Compare.roundOff(minimumHeartRate) + "  BPM";
            lblavpwr2.Text = Compare.roundOff(averagePower) + "  watt";
            lblmaxpwr2.Text = Compare.roundOff(maximumPower) + "  watt";
            lblavalt2.Text = Compare.roundOff(averageAltitude) + " m/ft";
        }
    }
}
