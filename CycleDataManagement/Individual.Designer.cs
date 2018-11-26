namespace CycleDataManagement
{
    partial class Individual
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
            this.zheart = new ZedGraph.ZedGraphControl();
            this.zspeed = new ZedGraph.ZedGraphControl();
            this.zcadence = new ZedGraph.ZedGraphControl();
            this.zpower = new ZedGraph.ZedGraphControl();
            this.zaltitude = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zheart
            // 
            this.zheart.IsShowPointValues = false;
            this.zheart.Location = new System.Drawing.Point(-2, 2);
            this.zheart.Name = "zheart";
            this.zheart.PointValueFormat = "G";
            this.zheart.Size = new System.Drawing.Size(1093, 178);
            this.zheart.TabIndex = 0;
            // 
            // zspeed
            // 
            this.zspeed.IsShowPointValues = false;
            this.zspeed.Location = new System.Drawing.Point(-2, 198);
            this.zspeed.Name = "zspeed";
            this.zspeed.PointValueFormat = "G";
            this.zspeed.Size = new System.Drawing.Size(1093, 178);
            this.zspeed.TabIndex = 1;
            // 
            // zcadence
            // 
            this.zcadence.IsShowPointValues = false;
            this.zcadence.Location = new System.Drawing.Point(-2, 397);
            this.zcadence.Name = "zcadence";
            this.zcadence.PointValueFormat = "G";
            this.zcadence.Size = new System.Drawing.Size(1093, 178);
            this.zcadence.TabIndex = 2;
            // 
            // zpower
            // 
            this.zpower.IsShowPointValues = false;
            this.zpower.Location = new System.Drawing.Point(-2, 581);
            this.zpower.Name = "zpower";
            this.zpower.PointValueFormat = "G";
            this.zpower.Size = new System.Drawing.Size(1093, 178);
            this.zpower.TabIndex = 3;
            // 
            // zaltitude
            // 
            this.zaltitude.IsShowPointValues = false;
            this.zaltitude.Location = new System.Drawing.Point(-2, 766);
            this.zaltitude.Name = "zaltitude";
            this.zaltitude.PointValueFormat = "G";
            this.zaltitude.Size = new System.Drawing.Size(1093, 178);
            this.zaltitude.TabIndex = 4;
            // 
            // Individual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 956);
            this.Controls.Add(this.zaltitude);
            this.Controls.Add(this.zpower);
            this.Controls.Add(this.zcadence);
            this.Controls.Add(this.zspeed);
            this.Controls.Add(this.zheart);
            this.Name = "Individual";
            this.Text = "Individual Graph";
            this.Load += new System.EventHandler(this.Individual_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zheart;
        private ZedGraph.ZedGraphControl zspeed;
        private ZedGraph.ZedGraphControl zcadence;
        private ZedGraph.ZedGraphControl zpower;
        private ZedGraph.ZedGraphControl zaltitude;
    }
}