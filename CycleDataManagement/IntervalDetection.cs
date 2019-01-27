using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CycleDataManagement
{
    /// <summary>
    /// this class displays a form to display data of intervals
    /// </summary>
    public partial class IntervalDetection : Form
    {
        string showAverages;
        /// <summary>
        /// constructor of this class
        /// </summary>
        /// <param name="average"></param>
        public IntervalDetection(string average)
        {
            InitializeComponent();
            this.showAverages = average;

            textBox1.Text = showAverages.Replace("\n", Environment.NewLine);
        }
    }
}
