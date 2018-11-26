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
        }
        private PointPairList buildPointPairList(int[] value)
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
            List<int> c2 = _speed.Select(s => Convert.ToInt32(s)).ToList();
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
    }
}
