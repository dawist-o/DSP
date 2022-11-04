using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace trDSP
{
    public partial class DSP_1 : Form
    {
        System.Windows.Forms.DataVisualization.Charting.Series DataSer;
        System.Windows.Forms.DataVisualization.Charting.Legend HarS;
        private List<TrackBar> trLst = new List<TrackBar>();
        private List<Label> lbLst = new List<Label>();
        double A, f, phi;
        double[] phc = new double[15];
        public DSP_1()
        {
            InitializeComponent();
            BuildHarmGraph();
       
            #region ListFill
            trLst.Add(trackBar4);//phi1
            trLst.Add(trackBar5);//f1
            trLst.Add(trackBar6);//A1
            trLst.Add(trackBar7);//phi2
            trLst.Add(trackBar8);//...
            trLst.Add(trackBar9);
            trLst.Add(trackBar10);
            trLst.Add(trackBar11);
            trLst.Add(trackBar12);
            trLst.Add(trackBar13);
            trLst.Add(trackBar14);
            trLst.Add(trackBar15);
            trLst.Add(trackBar16);
            trLst.Add(trackBar17);
            trLst.Add(trackBar18);//A5
            lbLst.Add(label7);
            lbLst.Add(label8);
            lbLst.Add(label9);
            lbLst.Add(label13);
            lbLst.Add(label14);
            lbLst.Add(label15);
            lbLst.Add(label19);
            lbLst.Add(label20);
            lbLst.Add(label21);
            lbLst.Add(label25);
            lbLst.Add(label26);
            lbLst.Add(label27);
            lbLst.Add(label31);
            lbLst.Add(label32);
            lbLst.Add(label33);
            #endregion
            for (int i = 0; i <= 14; i++)
            {
                lbLst[i].Text = Convert.ToString(trLst[i].Value);
                phc[i] = trLst[i].Value;
                trLst[i].Scroll += new System.EventHandler(BuildPolyHarmGraph);
            }
        }

        private void BuildHarmGraph()
        {
            try
            {
                chart1.Series.Remove(DataSer);
            }
            finally
            {
                DataSer = new System.Windows.Forms.DataVisualization.Charting.Series();
                HarS = new System.Windows.Forms.DataVisualization.Charting.Legend();
                DataSer.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                DataSer.Color = Color.Red;
                HarS.Name = "Harmonic signal";
                HarS.Title = "Harmonic signal";

                //int N = Convert.ToInt16(this.periodComboBox.GetItemText(this.periodComboBox.SelectedItem));
                int N = 1024;
                A = (double)trackBar2.Value;
                f = (double)trackBar3.Value;
                phi = (double)trackBar1.Value;
                label4.Text = Convert.ToString(trackBar2.Value);
                label5.Text = Convert.ToString(trackBar3.Value);
                label6.Text = Convert.ToString(trackBar1.Value);
                for (int n = 1; n <= N - 1; n++)
                {
                    DataSer.Points.AddXY(n, A * Math.Sin(2 * Math.PI * f * n / N + (double)phi / 180 * Math.PI));
                }
            }
            chart1.ResetAutoValues();
            chart1.Series.Add(DataSer);
        }

        private void BuildPolyHarmGraph(object sender, EventArgs e)
        {
            try
            {
                chart1.Series.Remove(DataSer);
            }
            finally
            {
                for (int i = 0; i <= 14; i++)
                {
                    lbLst[i].Text = Convert.ToString(trLst[i].Value);
                    phc[i] = trLst[i].Value;
                }
                DataSer = new System.Windows.Forms.DataVisualization.Charting.Series();
                HarS = new System.Windows.Forms.DataVisualization.Charting.Legend();
                DataSer.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                DataSer.Color = Color.Red;
                HarS.Name = "Harmonic signal";
                HarS.Title = "Harmonic signal";
                int N = 1024;
                for (int n = 1; n <= N - 1; n++)
                {
                    double res = 0;
                    for (int k = 0; k <= 4; k++)
                    {
                        // original 
                        // double t = (3 * phc[k*3 + 2]) * Math.Sin(2 * Math.PI * (3 * phc[k*3 + 1]) * n / N + (double)(3 * phc[k*3]) / 180 * Math.PI);
                        // without 3
                        double t = (phc[k*3 + 2]) * Math.Sin(2 * Math.PI * (phc[k*3 + 1]) * n / N + (double)(phc[k*3]) / 180 * Math.PI);
                        res += t;
                    }
                    DataSer.Points.AddXY(n, res);
                }
            }
            chart1.ResetAutoValues();
            chart1.Series.Add(DataSer);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            BuildHarmGraph();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            BuildHarmGraph();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            BuildHarmGraph();
        }

        private void buttonBuildGrowthGraph(object sender, EventArgs e)
        {
            try
            {
                chart1.Series.Remove(DataSer);
            }
            finally
            {
                for (int i = 0; i <= 14; i++)
                {
                    lbLst[i].Text = Convert.ToString(trLst[i].Value);
                    phc[i] = trLst[i].Value;
                }
                DataSer = new System.Windows.Forms.DataVisualization.Charting.Series();
                HarS = new System.Windows.Forms.DataVisualization.Charting.Legend();
                DataSer.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
                DataSer.Color = Color.Red;
                HarS.Name = "Harmonic signal";
                HarS.Title = "Harmonic signal";
                int N = 1024;
                double A = 7;
                double f = 1;
                double fis = 100;

                for (int n = 1; n <= N - 1; n++)
                {
                    var ntpm = n % N;
                    A += 0.2 * n / N;
                    f -= 0.1 * n / N;
                    fis += 0.05 * n / N;

                    double res = A * Math.Sin( 2 * Math.PI * f * ntpm / N + fis);

                    DataSer.Points.AddXY(n, res);
                }
            }
            chart1.ResetAutoValues();
            chart1.Series.Add(DataSer);
        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox4.Enabled = false;
            BuildHarmGraph();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox4.Enabled = true;
            BuildPolyHarmGraph(sender,e);
        }

            
                

        }

    }
