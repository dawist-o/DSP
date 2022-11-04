namespace DSP_3
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fftBox = new System.Windows.Forms.CheckBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maxGBar = new System.Windows.Forms.TrackBar();
            this.minGBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.filter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxGBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minGBar)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            this.chart1.Location = new System.Drawing.Point(30, 129);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1180, 220);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            this.chart2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea8.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea8);
            this.chart2.Location = new System.Drawing.Point(31, 372);
            this.chart2.Margin = new System.Windows.Forms.Padding(4);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(1180, 220);
            this.chart2.TabIndex = 2;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            this.chart3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea9.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea9);
            this.chart3.Location = new System.Drawing.Point(31, 619);
            this.chart3.Margin = new System.Windows.Forms.Padding(4);
            this.chart3.Name = "chart3";
            this.chart3.Size = new System.Drawing.Size(1180, 220);
            this.chart3.TabIndex = 3;
            this.chart3.Text = "chart3";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.fftBox);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(31, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(513, 89);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сигнал";
            // 
            // fftBox
            // 
            this.fftBox.AutoSize = true;
            this.fftBox.Location = new System.Drawing.Point(121, 51);
            this.fftBox.Name = "fftBox";
            this.fftBox.Size = new System.Drawing.Size(248, 21);
            this.fftBox.TabIndex = 2;
            this.fftBox.Text = "Быстрое преобразование Фурье";
            this.fftBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fftBox.UseVisualStyleBackColor = true;
            this.fftBox.CheckedChanged += new System.EventHandler(this.fftBox_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(269, 23);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(163, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Полигармонический";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_Checked);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(73, 23);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(132, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Гармонический";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_Checked);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.maxGBar);
            this.groupBox2.Controls.Add(this.minGBar);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.filter);
            this.groupBox2.Location = new System.Drawing.Point(551, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 89);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Фильтр";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Максимальная гармоника: ";
            // 
            // maxGBar
            // 
            this.maxGBar.Location = new System.Drawing.Point(477, 33);
            this.maxGBar.Margin = new System.Windows.Forms.Padding(4);
            this.maxGBar.Maximum = 360;
            this.maxGBar.Minimum = 1;
            this.maxGBar.Name = "maxGBar";
            this.maxGBar.Size = new System.Drawing.Size(182, 56);
            this.maxGBar.TabIndex = 7;
            this.maxGBar.Value = 1;
            this.maxGBar.Scroll += new System.EventHandler(this.maxGBar_Scroll);
            // 
            // minGBar
            // 
            this.minGBar.Location = new System.Drawing.Point(235, 33);
            this.minGBar.Margin = new System.Windows.Forms.Padding(4);
            this.minGBar.Maximum = 360;
            this.minGBar.Minimum = 1;
            this.minGBar.Name = "minGBar";
            this.minGBar.Size = new System.Drawing.Size(182, 56);
            this.minGBar.TabIndex = 4;
            this.minGBar.Value = 1;
            this.minGBar.Scroll += new System.EventHandler(this.minGBar_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Минимальная гармоника: ";
            // 
            // filter
            // 
            this.filter.FormattingEnabled = true;
            this.filter.Items.AddRange(new object[] {
            "Отсутсвие фильтра",
            "Низко частотный",
            "Высоко частотный",
            "Полосный фильтр"});
            this.filter.Location = new System.Drawing.Point(11, 33);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(181, 24);
            this.filter.TabIndex = 0;
            this.filter.SelectedIndexChanged += new System.EventHandler(this.filter_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 853);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Дискретное преобразование Фурье";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxGBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minGBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox filter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar maxGBar;
        private System.Windows.Forms.TrackBar minGBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox fftBox;
    }
}

