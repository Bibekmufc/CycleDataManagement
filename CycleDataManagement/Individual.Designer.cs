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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdAltitude = new System.Windows.Forms.RadioButton();
            this.rdPower = new System.Windows.Forms.RadioButton();
            this.rdCadence = new System.Windows.Forms.RadioButton();
            this.rdSpeed = new System.Windows.Forms.RadioButton();
            this.rdHR = new System.Windows.Forms.RadioButton();
            this.zaltitude = new ZedGraph.ZedGraphControl();
            this.zpower = new ZedGraph.ZedGraphControl();
            this.zcadence = new ZedGraph.ZedGraphControl();
            this.zspeed = new ZedGraph.ZedGraphControl();
            this.zheart = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rdAltitude);
            this.panel1.Controls.Add(this.rdPower);
            this.panel1.Controls.Add(this.rdCadence);
            this.panel1.Controls.Add(this.rdSpeed);
            this.panel1.Controls.Add(this.rdHR);
            this.panel1.Controls.Add(this.zaltitude);
            this.panel1.Controls.Add(this.zpower);
            this.panel1.Controls.Add(this.zcadence);
            this.panel1.Controls.Add(this.zspeed);
            this.panel1.Controls.Add(this.zheart);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1155, 480);
            this.panel1.TabIndex = 0;
            // 
            // rdAltitude
            // 
            this.rdAltitude.AutoSize = true;
            this.rdAltitude.Location = new System.Drawing.Point(767, 57);
            this.rdAltitude.Name = "rdAltitude";
            this.rdAltitude.Size = new System.Drawing.Size(76, 21);
            this.rdAltitude.TabIndex = 10;
            this.rdAltitude.TabStop = true;
            this.rdAltitude.Text = "Altitude";
            this.rdAltitude.UseVisualStyleBackColor = true;
            this.rdAltitude.CheckedChanged += new System.EventHandler(this.rdAltitude_CheckedChanged);
            // 
            // rdPower
            // 
            this.rdPower.AutoSize = true;
            this.rdPower.Location = new System.Drawing.Point(601, 57);
            this.rdPower.Name = "rdPower";
            this.rdPower.Size = new System.Drawing.Size(68, 21);
            this.rdPower.TabIndex = 10;
            this.rdPower.TabStop = true;
            this.rdPower.Text = "Power";
            this.rdPower.UseVisualStyleBackColor = true;
            this.rdPower.CheckedChanged += new System.EventHandler(this.rdPower_CheckedChanged);
            // 
            // rdCadence
            // 
            this.rdCadence.AutoSize = true;
            this.rdCadence.Location = new System.Drawing.Point(424, 57);
            this.rdCadence.Name = "rdCadence";
            this.rdCadence.Size = new System.Drawing.Size(85, 21);
            this.rdCadence.TabIndex = 10;
            this.rdCadence.TabStop = true;
            this.rdCadence.Text = "Cadence";
            this.rdCadence.UseVisualStyleBackColor = true;
            this.rdCadence.CheckedChanged += new System.EventHandler(this.rdCadence_CheckedChanged);
            // 
            // rdSpeed
            // 
            this.rdSpeed.AutoSize = true;
            this.rdSpeed.Location = new System.Drawing.Point(239, 57);
            this.rdSpeed.Name = "rdSpeed";
            this.rdSpeed.Size = new System.Drawing.Size(70, 21);
            this.rdSpeed.TabIndex = 10;
            this.rdSpeed.TabStop = true;
            this.rdSpeed.Text = "Speed";
            this.rdSpeed.UseVisualStyleBackColor = true;
            this.rdSpeed.CheckedChanged += new System.EventHandler(this.rdSpeed_CheckedChanged);
            // 
            // rdHR
            // 
            this.rdHR.AutoSize = true;
            this.rdHR.Location = new System.Drawing.Point(87, 57);
            this.rdHR.Name = "rdHR";
            this.rdHR.Size = new System.Drawing.Size(64, 21);
            this.rdHR.TabIndex = 10;
            this.rdHR.TabStop = true;
            this.rdHR.Text = "Heart";
            this.rdHR.UseVisualStyleBackColor = true;
            this.rdHR.CheckedChanged += new System.EventHandler(this.rdHR_CheckedChanged);
            // 
            // zaltitude
            // 
            this.zaltitude.IsShowPointValues = false;
            this.zaltitude.Location = new System.Drawing.Point(0, 107);
            this.zaltitude.Name = "zaltitude";
            this.zaltitude.PointValueFormat = "G";
            this.zaltitude.Size = new System.Drawing.Size(1130, 290);
            this.zaltitude.TabIndex = 9;
            // 
            // zpower
            // 
            this.zpower.IsShowPointValues = false;
            this.zpower.Location = new System.Drawing.Point(3, 107);
            this.zpower.Name = "zpower";
            this.zpower.PointValueFormat = "G";
            this.zpower.Size = new System.Drawing.Size(1127, 290);
            this.zpower.TabIndex = 8;
            // 
            // zcadence
            // 
            this.zcadence.IsShowPointValues = false;
            this.zcadence.Location = new System.Drawing.Point(3, 107);
            this.zcadence.Name = "zcadence";
            this.zcadence.PointValueFormat = "G";
            this.zcadence.Size = new System.Drawing.Size(1127, 290);
            this.zcadence.TabIndex = 7;
            // 
            // zspeed
            // 
            this.zspeed.IsShowPointValues = false;
            this.zspeed.Location = new System.Drawing.Point(3, 107);
            this.zspeed.Name = "zspeed";
            this.zspeed.PointValueFormat = "G";
            this.zspeed.Size = new System.Drawing.Size(1127, 290);
            this.zspeed.TabIndex = 6;
            // 
            // zheart
            // 
            this.zheart.IsShowPointValues = false;
            this.zheart.Location = new System.Drawing.Point(3, 107);
            this.zheart.Name = "zheart";
            this.zheart.PointValueFormat = "G";
            this.zheart.Size = new System.Drawing.Size(1127, 290);
            this.zheart.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(468, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "Please select a category for its graph";
            // 
            // Individual
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1124, 512);
            this.Controls.Add(this.panel1);
            this.Name = "Individual";
            this.Text = "Individual Graph";
            this.Load += new System.EventHandler(this.Individual_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ZedGraph.ZedGraphControl zaltitude;
        private ZedGraph.ZedGraphControl zpower;
        private ZedGraph.ZedGraphControl zcadence;
        private ZedGraph.ZedGraphControl zspeed;
        private ZedGraph.ZedGraphControl zheart;
        private System.Windows.Forms.RadioButton rdAltitude;
        private System.Windows.Forms.RadioButton rdPower;
        private System.Windows.Forms.RadioButton rdCadence;
        private System.Windows.Forms.RadioButton rdSpeed;
        private System.Windows.Forms.RadioButton rdHR;
        private System.Windows.Forms.Label label1;
    }
}