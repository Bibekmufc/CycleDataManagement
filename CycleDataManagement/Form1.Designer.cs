﻿namespace CycleDataManagement
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbldevice = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.lblinterval = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbunit = new System.Windows.Forms.ComboBox();
            this.lblavhrate = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lblmaxhrate = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lblavpwr = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lblmaxpwr = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lblmaxspeed = new System.Windows.Forms.Label();
            this.lblavalt = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lblavspeed = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.graph = new System.Windows.Forms.ToolStripMenuItem();
            this.individualGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(3, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 643);
            this.panel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.dataGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.Size = new System.Drawing.Size(1095, 615);
            this.splitContainer1.SplitterDistance = 1066;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.lbldevice);
            this.panel2.Controls.Add(this.lblStartTime);
            this.panel2.Controls.Add(this.lbl11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lbldate);
            this.panel2.Controls.Add(this.lblinterval);
            this.panel2.Controls.Add(this.lbl9);
            this.panel2.Location = new System.Drawing.Point(810, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 342);
            this.panel2.TabIndex = 0;
            // 
            // lbldevice
            // 
            this.lbldevice.AutoSize = true;
            this.lbldevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldevice.Location = new System.Drawing.Point(14, 31);
            this.lbldevice.Name = "lbldevice";
            this.lbldevice.Size = new System.Drawing.Size(166, 29);
            this.lbldevice.TabIndex = 11;
            this.lbldevice.Text = "Device Name";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(105, 172);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(31, 17);
            this.lblStartTime.TabIndex = 3;
            this.lblStartTime.Text = "N/A";
            // 
            // lbl11
            // 
            this.lbl11.AutoSize = true;
            this.lbl11.Location = new System.Drawing.Point(16, 172);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(85, 17);
            this.lbl11.TabIndex = 3;
            this.lbl11.Text = "Start Time : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Interval : ";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Location = new System.Drawing.Point(72, 125);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(31, 17);
            this.lbldate.TabIndex = 0;
            this.lbldate.Text = "N/A";
            // 
            // lblinterval
            // 
            this.lblinterval.AutoSize = true;
            this.lblinterval.Location = new System.Drawing.Point(105, 224);
            this.lblinterval.Name = "lblinterval";
            this.lblinterval.Size = new System.Drawing.Size(31, 17);
            this.lblinterval.TabIndex = 2;
            this.lblinterval.Text = "N/A";
            // 
            // lbl9
            // 
            this.lbl9.AutoSize = true;
            this.lbl9.Location = new System.Drawing.Point(16, 125);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(50, 17);
            this.lbl9.TabIndex = 0;
            this.lbl9.Text = "Date : ";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cmbunit);
            this.panel3.Controls.Add(this.lblavhrate);
            this.panel3.Controls.Add(this.lbl4);
            this.panel3.Controls.Add(this.lblmaxhrate);
            this.panel3.Controls.Add(this.lbl5);
            this.panel3.Controls.Add(this.lblavpwr);
            this.panel3.Controls.Add(this.lbl6);
            this.panel3.Controls.Add(this.lblmaxpwr);
            this.panel3.Controls.Add(this.lbl7);
            this.panel3.Controls.Add(this.lblmaxspeed);
            this.panel3.Controls.Add(this.lblavalt);
            this.panel3.Controls.Add(this.lbl8);
            this.panel3.Controls.Add(this.lblavspeed);
            this.panel3.Controls.Add(this.lbl3);
            this.panel3.Controls.Add(this.lbltotal);
            this.panel3.Controls.Add(this.lbl2);
            this.panel3.Controls.Add(this.lbl1);
            this.panel3.Location = new System.Drawing.Point(0, 351);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1063, 261);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(833, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "Select Speed Unit";
            // 
            // cmbunit
            // 
            this.cmbunit.FormattingEnabled = true;
            this.cmbunit.Items.AddRange(new object[] {
            "mph",
            "kmph"});
            this.cmbunit.Location = new System.Drawing.Point(838, 84);
            this.cmbunit.Name = "cmbunit";
            this.cmbunit.Size = new System.Drawing.Size(199, 24);
            this.cmbunit.TabIndex = 11;
            this.cmbunit.SelectedIndexChanged += new System.EventHandler(this.Cmbunit_SelectedIndexChanged);
            // 
            // lblavhrate
            // 
            this.lblavhrate.AutoSize = true;
            this.lblavhrate.Location = new System.Drawing.Point(239, 138);
            this.lblavhrate.Name = "lblavhrate";
            this.lblavhrate.Size = new System.Drawing.Size(31, 17);
            this.lblavhrate.TabIndex = 10;
            this.lblavhrate.Text = "N/A";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(33, 138);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(174, 17);
            this.lbl4.TabIndex = 10;
            this.lbl4.Text = "Average Heartbeat Rate : ";
            // 
            // lblmaxhrate
            // 
            this.lblmaxhrate.AutoSize = true;
            this.lblmaxhrate.Location = new System.Drawing.Point(241, 168);
            this.lblmaxhrate.Name = "lblmaxhrate";
            this.lblmaxhrate.Size = new System.Drawing.Size(31, 17);
            this.lblmaxhrate.TabIndex = 9;
            this.lblmaxhrate.Text = "N/A";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(35, 168);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(146, 17);
            this.lbl5.TabIndex = 9;
            this.lbl5.Text = "Max Heartbeat Rate : ";
            // 
            // lblavpwr
            // 
            this.lblavpwr.AutoSize = true;
            this.lblavpwr.Location = new System.Drawing.Point(241, 197);
            this.lblavpwr.Name = "lblavpwr";
            this.lblavpwr.Size = new System.Drawing.Size(31, 17);
            this.lblavpwr.TabIndex = 8;
            this.lblavpwr.Text = "N/A";
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Location = new System.Drawing.Point(35, 197);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(116, 17);
            this.lbl6.TabIndex = 8;
            this.lbl6.Text = "Average Power : ";
            // 
            // lblmaxpwr
            // 
            this.lblmaxpwr.AutoSize = true;
            this.lblmaxpwr.Location = new System.Drawing.Point(623, 43);
            this.lblmaxpwr.Name = "lblmaxpwr";
            this.lblmaxpwr.Size = new System.Drawing.Size(31, 17);
            this.lblmaxpwr.TabIndex = 7;
            this.lblmaxpwr.Text = "N/A";
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Location = new System.Drawing.Point(462, 43);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(88, 17);
            this.lbl7.TabIndex = 7;
            this.lbl7.Text = "Max Power : ";
            // 
            // lblmaxspeed
            // 
            this.lblmaxspeed.AutoSize = true;
            this.lblmaxspeed.Location = new System.Drawing.Point(241, 106);
            this.lblmaxspeed.Name = "lblmaxspeed";
            this.lblmaxspeed.Size = new System.Drawing.Size(31, 17);
            this.lblmaxspeed.TabIndex = 3;
            this.lblmaxspeed.Text = "N/A";
            // 
            // lblavalt
            // 
            this.lblavalt.AutoSize = true;
            this.lblavalt.Location = new System.Drawing.Point(623, 76);
            this.lblavalt.Name = "lblavalt";
            this.lblavalt.Size = new System.Drawing.Size(31, 17);
            this.lblavalt.TabIndex = 4;
            this.lblavalt.Text = "N/A";
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.Location = new System.Drawing.Point(462, 76);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(124, 17);
            this.lbl8.TabIndex = 4;
            this.lbl8.Text = "Average Altitude : ";
            // 
            // lblavspeed
            // 
            this.lblavspeed.AutoSize = true;
            this.lblavspeed.Location = new System.Drawing.Point(238, 76);
            this.lblavspeed.Name = "lblavspeed";
            this.lblavspeed.Size = new System.Drawing.Size(31, 17);
            this.lblavspeed.TabIndex = 2;
            this.lblavspeed.Text = "N/A";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(35, 106);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(123, 17);
            this.lbl3.TabIndex = 3;
            this.lbl3.Text = "Maximum Speed : ";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Location = new System.Drawing.Point(238, 43);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(31, 17);
            this.lbltotal.TabIndex = 1;
            this.lbltotal.Text = "N/A";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(32, 76);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(118, 17);
            this.lbl2.TabIndex = 2;
            this.lbl2.Text = "Average Speed : ";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(32, 43);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(111, 17);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Total Distance : ";
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(0, 3);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.Height = 24;
            this.dataGrid.Size = new System.Drawing.Size(804, 342);
            this.dataGrid.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDataToolStripMenuItem,
            this.graph});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1095, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewDataToolStripMenuItem
            // 
            this.viewDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open});
            this.viewDataToolStripMenuItem.Name = "viewDataToolStripMenuItem";
            this.viewDataToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.viewDataToolStripMenuItem.Text = "View Data";
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(147, 26);
            this.Open.Text = "Open File";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // graph
            // 
            this.graph.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.individualGraphToolStripMenuItem,
            this.mainGraphToolStripMenuItem});
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(97, 24);
            this.graph.Text = "View Graph";
            // 
            // individualGraphToolStripMenuItem
            // 
            this.individualGraphToolStripMenuItem.Name = "individualGraphToolStripMenuItem";
            this.individualGraphToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.individualGraphToolStripMenuItem.Text = "Individual Graph";
            this.individualGraphToolStripMenuItem.Click += new System.EventHandler(this.IndividualGraphToolStripMenuItem_Click);
            // 
            // mainGraphToolStripMenuItem
            // 
            this.mainGraphToolStripMenuItem.Name = "mainGraphToolStripMenuItem";
            this.mainGraphToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.mainGraphToolStripMenuItem.Text = "Main Graph";
            this.mainGraphToolStripMenuItem.Click += new System.EventHandler(this.MainGraphToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 645);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Home";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graph;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lblinterval;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label lblavhrate;
        private System.Windows.Forms.Label lblmaxhrate;
        private System.Windows.Forms.Label lblavpwr;
        private System.Windows.Forms.Label lblmaxpwr;
        private System.Windows.Forms.Label lblmaxspeed;
        private System.Windows.Forms.Label lblavalt;
        private System.Windows.Forms.Label lblavspeed;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem individualGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainGraphToolStripMenuItem;
        private System.Windows.Forms.Label lbldevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbunit;
    }
}

