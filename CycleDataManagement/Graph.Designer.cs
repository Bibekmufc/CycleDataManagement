namespace CycleDataManagement
{
    partial class Graph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.zGraph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zGraph
            // 
            this.zGraph.IsShowPointValues = false;
            this.zGraph.Location = new System.Drawing.Point(3, 3);
            this.zGraph.Name = "zGraph";
            this.zGraph.PointValueFormat = "G";
            this.zGraph.Size = new System.Drawing.Size(1099, 691);
            this.zGraph.TabIndex = 0;
            this.zGraph.Resize += new System.EventHandler(this.Graph_Resize);
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 693);
            this.Controls.Add(this.zGraph);
            this.Name = "Graph";
            this.Text = "Graph";
            this.Load += new System.EventHandler(this.Graph_Load);
            this.Resize += new System.EventHandler(this.Graph_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zGraph;
    }
}