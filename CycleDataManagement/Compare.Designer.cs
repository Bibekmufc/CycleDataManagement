namespace CycleDataManagement
{
    partial class Compare
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
            this.txtfile1 = new System.Windows.Forms.TextBox();
            this.txtfile2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btncompare = new System.Windows.Forms.Button();
            this.filedata1 = new System.Windows.Forms.DataGridView();
            this.device1 = new System.Windows.Forms.Label();
            this.device2 = new System.Windows.Forms.Label();
            this.filedata2 = new System.Windows.Forms.DataGridView();
            this.txtdifference = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnfile1 = new System.Windows.Forms.Button();
            this.btnfile2 = new System.Windows.Forms.Button();
            this.btngraph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.filedata1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filedata2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtfile1
            // 
            this.txtfile1.Location = new System.Drawing.Point(151, 47);
            this.txtfile1.Name = "txtfile1";
            this.txtfile1.ReadOnly = true;
            this.txtfile1.Size = new System.Drawing.Size(207, 22);
            this.txtfile1.TabIndex = 0;
            // 
            // txtfile2
            // 
            this.txtfile2.Location = new System.Drawing.Point(623, 42);
            this.txtfile2.Name = "txtfile2";
            this.txtfile2.ReadOnly = true;
            this.txtfile2.Size = new System.Drawing.Size(207, 22);
            this.txtfile2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "File 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(541, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "File 2:";
            // 
            // btncompare
            // 
            this.btncompare.Location = new System.Drawing.Point(988, 41);
            this.btncompare.Name = "btncompare";
            this.btncompare.Size = new System.Drawing.Size(91, 23);
            this.btncompare.TabIndex = 4;
            this.btncompare.Text = "Compare";
            this.btncompare.UseVisualStyleBackColor = true;
            this.btncompare.Click += new System.EventHandler(this.btncompare_Click_1);
            // 
            // filedata1
            // 
            this.filedata1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filedata1.Location = new System.Drawing.Point(458, 123);
            this.filedata1.Name = "filedata1";
            this.filedata1.RowTemplate.Height = 24;
            this.filedata1.Size = new System.Drawing.Size(621, 254);
            this.filedata1.TabIndex = 5;
            this.filedata1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.filedata1_CellClick);
            // 
            // device1
            // 
            this.device1.AutoSize = true;
            this.device1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.device1.Location = new System.Drawing.Point(455, 81);
            this.device1.Name = "device1";
            this.device1.Size = new System.Drawing.Size(209, 39);
            this.device1.TabIndex = 6;
            this.device1.Text = "First Device";
            // 
            // device2
            // 
            this.device2.AutoSize = true;
            this.device2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.device2.Location = new System.Drawing.Point(459, 415);
            this.device2.Name = "device2";
            this.device2.Size = new System.Drawing.Size(260, 39);
            this.device2.TabIndex = 8;
            this.device2.Text = "Second Device";
            // 
            // filedata2
            // 
            this.filedata2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.filedata2.Location = new System.Drawing.Point(462, 457);
            this.filedata2.Name = "filedata2";
            this.filedata2.RowTemplate.Height = 24;
            this.filedata2.Size = new System.Drawing.Size(617, 254);
            this.filedata2.TabIndex = 7;
            this.filedata2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.filedata1_CellClick);
            // 
            // txtdifference
            // 
            this.txtdifference.Location = new System.Drawing.Point(12, 207);
            this.txtdifference.Multiline = true;
            this.txtdifference.Name = "txtdifference";
            this.txtdifference.ReadOnly = true;
            this.txtdifference.Size = new System.Drawing.Size(420, 504);
            this.txtdifference.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 39);
            this.label5.TabIndex = 10;
            this.label5.Text = "Difference";
            // 
            // btnfile1
            // 
            this.btnfile1.Location = new System.Drawing.Point(392, 45);
            this.btnfile1.Name = "btnfile1";
            this.btnfile1.Size = new System.Drawing.Size(75, 23);
            this.btnfile1.TabIndex = 11;
            this.btnfile1.Text = "Open";
            this.btnfile1.UseVisualStyleBackColor = true;
            this.btnfile1.Click += new System.EventHandler(this.btnfile1_Click);
            // 
            // btnfile2
            // 
            this.btnfile2.Location = new System.Drawing.Point(836, 39);
            this.btnfile2.Name = "btnfile2";
            this.btnfile2.Size = new System.Drawing.Size(75, 23);
            this.btnfile2.TabIndex = 11;
            this.btnfile2.Text = "Open";
            this.btnfile2.UseVisualStyleBackColor = true;
            this.btnfile2.Click += new System.EventHandler(this.btnfile2_Click);
            // 
            // btngraph
            // 
            this.btngraph.Location = new System.Drawing.Point(344, 178);
            this.btngraph.Name = "btngraph";
            this.btngraph.Size = new System.Drawing.Size(75, 23);
            this.btngraph.TabIndex = 12;
            this.btngraph.Text = "Graph";
            this.btngraph.UseVisualStyleBackColor = true;
            this.btngraph.Click += new System.EventHandler(this.btngraph_Click);
            // 
            // Compare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 748);
            this.Controls.Add(this.btngraph);
            this.Controls.Add(this.btnfile2);
            this.Controls.Add(this.btnfile1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtdifference);
            this.Controls.Add(this.device2);
            this.Controls.Add(this.filedata2);
            this.Controls.Add(this.device1);
            this.Controls.Add(this.filedata1);
            this.Controls.Add(this.btncompare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtfile2);
            this.Controls.Add(this.txtfile1);
            this.Name = "Compare";
            this.Text = "Compare";
            ((System.ComponentModel.ISupportInitialize)(this.filedata1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filedata2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtfile1;
        private System.Windows.Forms.TextBox txtfile2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btncompare;
        private System.Windows.Forms.DataGridView filedata1;
        private System.Windows.Forms.Label device1;
        private System.Windows.Forms.Label device2;
        private System.Windows.Forms.DataGridView filedata2;
        private System.Windows.Forms.TextBox txtdifference;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnfile1;
        private System.Windows.Forms.Button btnfile2;
        private System.Windows.Forms.Button btngraph;
    }
}