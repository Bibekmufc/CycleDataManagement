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
    public partial class Individual : Form
    {
        List<string> _heartRate = null;
        List<string> _speed = null;
        List<string> _cadence = null;
        List<string> _altitude = null;
        List<string> _power = null;

        public Individual(List<string> heartRate, List<string> speed, List<string> cadence, List<string> altitude, List<string> power)
        {
            _heartRate = heartRate;
            _speed = speed;
            _cadence = cadence;
            _altitude = altitude;
            _power = power;
            InitializeComponent();

            this.CenterToScreen();
            zheart.Visible = true;
            zpower.Visible = false;
            zspeed.Visible = false;
            zaltitude.Visible = false;
            zcadence.Visible = false;


            this.rdHR.Checked = true;
        }
        /// <summary>
        /// function to build points to plot in graph
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private PointPairList buildPointPairList(int[] value)
        {
            PointPairList pr = new PointPairList();
            for (int i = 0; i < value.Count(); i++)
            {
                pr.Add(i, (value[i]));
            }
            return pr;
        }
        private PointPairList buildPointPairList(double[] value)
        {
            PointPairList pr = new PointPairList();
            for (int i = 0; i < value.Count(); i++)
            {
                pr.Add(i, (value[i]));
            }
            return pr;
        }

        private void Individual_Load(object sender, EventArgs e)
        {
            MapGraph();
        }
        /// <summary>
        /// function to plot points in graph
        /// </summary>
        private void MapGraph()
        {
            GraphPane myPane = zheart.GraphPane;
            GraphPane myPane2 = zspeed.GraphPane;
            GraphPane myPane3 = zcadence.GraphPane;
            GraphPane myPane4 = zpower.GraphPane;
            GraphPane myPane5 = zaltitude.GraphPane;

            // Setting the titles
            myPane.Title = "Heartrate Analysis";
            myPane.XAxis.Title = "Time in seconds";
            myPane.YAxis.Title = "Value";

            myPane2.Title = "Speed Analysis";
            myPane2.XAxis.Title = "Time in seconds";
            myPane2.YAxis.Title = "Value";

            myPane4.Title = "Power Analysis";
            myPane4.XAxis.Title = "Time in seconds";
            myPane4.YAxis.Title = "Value";

            myPane3.Title = "Cadence Analysis";
            myPane3.XAxis.Title = "Time in seconds";
            myPane3.YAxis.Title = "Value";

            myPane5.Title = "Altitude Analysis";
            myPane5.XAxis.Title = "Time in seconds";
            myPane5.YAxis.Title = "Value";


            PointPairList heartPairList = new PointPairList();
            PointPairList speedPairList = new PointPairList();
            PointPairList cadencePairList = new PointPairList();
            PointPairList powerPairList = new PointPairList();
            PointPairList altitudePairList = new PointPairList();


            List<int> hr = _heartRate.Select(s => Convert.ToInt32(s)).ToList();
            heartPairList = buildPointPairList(hr.ToArray());
            List<double> c2 = _speed.Select(s => Convert.ToDouble(s)).ToList();
            speedPairList = buildPointPairList(c2.ToArray());
            List<int> c3 = _cadence.Select(s => Convert.ToInt32(s)).ToList();
            cadencePairList = buildPointPairList(c3.ToArray());
            List<int> c4 = _power.Select(s => Convert.ToInt32(s)).ToList();
            powerPairList = buildPointPairList(c4.ToArray());
            List<int> c5 = _altitude.Select(s => Convert.ToInt32(s)).ToList();
            altitudePairList = buildPointPairList(c5.ToArray());


            LineItem heartCurve = myPane.AddCurve("HeartRate",
            heartPairList, Color.Red, SymbolType.None);


            LineItem speedCurve = myPane2.AddCurve("Speed",
            speedPairList, Color.Black, SymbolType.None);

            LineItem cadenceCurve = myPane3.AddCurve("Cadence",
            cadencePairList, Color.DarkCyan, SymbolType.None);

            LineItem powerCurve = myPane4.AddCurve("Power",
            speedPairList, Color.Green, SymbolType.None);

            LineItem altitudeCurve = myPane5.AddCurve("Altitude",
                  altitudePairList, Color.DarkGoldenrod, SymbolType.None
                  );

            zheart.AxisChange();
            zspeed.AxisChange();
            zcadence.AxisChange();
            zpower.AxisChange();
            zaltitude.AxisChange();
        }

        private void individual_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void SetSize()
        {
            zheart.Location = new Point(0, 0);
            zheart.IsShowPointValues = true;
            zheart.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 50);

            zspeed.Location = new Point(0, 0);
            zspeed.IsShowPointValues = true;
            zspeed.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 50);

            zcadence.Location = new Point(0, 0);
            zcadence.IsShowPointValues = true;
            zcadence.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 50);

            zpower.Location = new Point(0, 0);
            zpower.IsShowPointValues = true;
            zpower.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 50);

            zaltitude.Location = new Point(0, 0);
            zaltitude.IsShowPointValues = true;
            zaltitude.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 50);
        }

        private void rdSpeed_CheckedChanged(object sender, EventArgs e)
        {
            zheart.Visible = false;
            zpower.Visible = false;
            zspeed.Visible = true;
            zaltitude.Visible = false;
            zcadence.Visible = false;
        }

        private void rdCadence_CheckedChanged(object sender, EventArgs e)
        {
            zheart.Visible = false;
            zpower.Visible = false;
            zspeed.Visible = false;
            zaltitude.Visible = false;
            zcadence.Visible = true;
        }

        private void rdPower_CheckedChanged(object sender, EventArgs e)
        {
            zheart.Visible = false;
            zpower.Visible = true;
            zspeed.Visible = false;
            zaltitude.Visible = false;
            zcadence.Visible = false;
        }

        private void rdAltitude_CheckedChanged(object sender, EventArgs e)
        {
            zheart.Visible = false;
            zpower.Visible = false;
            zspeed.Visible = false;
            zaltitude.Visible = true;
            zcadence.Visible = false;
        }

        private void rdHR_CheckedChanged(object sender, EventArgs e)
        {
            zheart.Visible = true;
            zpower.Visible = false;
            zspeed.Visible = false;
            zaltitude.Visible = false;
            zcadence.Visible = false;
        }
    }
}
