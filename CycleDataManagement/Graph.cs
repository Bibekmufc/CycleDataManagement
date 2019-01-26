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
    public partial class Graph : Form
    {
        List<string> _heartRate = null;
        List<string> _speed = null;
        List<string> _cadence = null;
        List<string> _altitude = null;
        List<string> _power = null;

        public Graph(List<string> heartRate, List<string> speed, List<string> cadence, List<string> altitude, List<string> power)
        {
            _heartRate = heartRate;
            _speed = speed;
            _cadence = cadence;
            _altitude = altitude;
           _power = power;
            InitializeComponent();
        }
        private void Graph_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            MapGraph();
            SetSize();
        }
        private PointPairList BuildPointPairList(int[] value)
        {
            PointPairList pr = new PointPairList();
            for (int i = 0; i < value.Count(); i++)
            {
                pr.Add(i, (value[i]));
            }
            return pr;
        }
        private PointPairList BuildPointPairList(double[] value)
        {
            PointPairList pr = new PointPairList();
            for (int i = 0; i < value.Count(); i++)
            {
                pr.Add(i, (value[i]));
            }
            return pr;
        }
        /// <summary>
        /// plots points to graph
        /// </summary>
        private void MapGraph()
        {
            GraphPane myPane = zGraph.GraphPane;
            myPane.Title = "Graph Analysis";
            myPane.XAxis.Title = "Time in seconds";
            myPane.YAxis.Title = "Value";

            PointPairList heartPairList = new PointPairList();
            PointPairList speedPairList = new PointPairList();
            PointPairList cadencePairList = new PointPairList();
            PointPairList powerPairList = new PointPairList();
            PointPairList altitudePairList = new PointPairList();

            List<int> hr = _heartRate.Select(s => Convert.ToInt32(s)).ToList();
            heartPairList = BuildPointPairList(hr.ToArray());
            List<double> c2 = _speed.Select(s => Convert.ToDouble(s)).ToList();
            speedPairList = BuildPointPairList(c2.ToArray());
            List<int> c3 = _cadence.Select(s => Convert.ToInt32(s)).ToList();
            cadencePairList = BuildPointPairList(c3.ToArray());
            List<int> c4 = _power.Select(s => Convert.ToInt32(s)).ToList();
            powerPairList = BuildPointPairList(c4.ToArray());
            List<int> c5 = _altitude.Select(s => Convert.ToInt32(s)).ToList();
            altitudePairList = BuildPointPairList(c5.ToArray());

            LineItem heartCurve = myPane.AddCurve("HeartRate",
                   heartPairList, Color.Red, SymbolType.None);

            LineItem speedCurve = myPane.AddCurve("Speed",
                  speedPairList, Color.Black, SymbolType.None);

            LineItem cadenceCurve = myPane.AddCurve("Cadence",
                   cadencePairList, Color.DarkCyan, SymbolType.None);

            LineItem powerCurve = myPane.AddCurve("Power",
                  speedPairList, Color.Green, SymbolType.None);

            LineItem altitudeCurve = myPane.AddCurve("Altitude",
                  altitudePairList, Color.DarkGoldenrod, SymbolType.None
                  );
            zGraph.AxisChange();
        }

        /// <summary>
        /// set size of graph
        /// </summary>
        private void SetSize()
        {
            zGraph.Location = new Point(0, 0);
            zGraph.IsShowPointValues = true;
            zGraph.Size = new Size(this.ClientRectangle.Width - 20, this.ClientRectangle.Height - 50);
        }
    }
}
