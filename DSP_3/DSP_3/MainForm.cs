using DSC_P3.Model;
using DSC_P3.Signals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DSP_3
{
    public partial class MainForm : Form
    {
        Series DataSer_1, DataSer_2, DataSer_3, DataSer_4, DataSer_5;
        enum SignalType { Harmonic, Polyharmonic }

        public MainForm()
        {
            InitializeComponent();
            Calculate(SignalType.Harmonic);
        }

        private void Calculate(SignalType st)
        {

            List<Signal> signals = new List<Signal>();
            int N = 1024;
            double A = 100;
            double F = 20;
            double P = -Math.PI / 4;
            if (st == SignalType.Harmonic)
            {

                signals.Add(new SinusoidSignal(A, F, P, N));
            }
            else
            {
                double[] As = new double[7] { 2, 3, 5, 9, 10, 12, 15 };
                double[] phases = new double[7] { Math.PI / 6, Math.PI / 4, Math.PI / 3, Math.PI / 2, 3 * Math.PI / 4, Math.PI, Math.PI };
                for (int i = 0; i < 7; i++) {
                    signals.Add(new SinusoidSignal(As[i], F * i, phases[i], N));
                }
            }
            PolyHarmonicSignal signal = new PolyHarmonicSignal(signals, getFilterType(), minGBar.Value, maxGBar.Value);
            signal.GenerateSpectrum(fftBox.Checked);

            chart1.Series.Clear();
            chart1.Legends.Clear();
            DataSer_1 = new Series();
            Legend l1 = new Legend();
            chart1.Legends.Add(l1);
            l1.Title = "Сигналы";
            DataSer_1.ChartType = SeriesChartType.Spline;
            DataSer_1.Color = Color.Red;
            DataSer_1.Name = "Исходный сигнал";
            DataSer_4 = new Series();
            DataSer_4.ChartType = SeriesChartType.Spline;
            DataSer_4.Color = Color.Blue;
            DataSer_4.Name = "Восстановленный сигнал";
            DataSer_5 = new Series();
            DataSer_5.ChartType = SeriesChartType.Spline;
            DataSer_5.Color = Color.Yellow;
            DataSer_5.Name = "Восстановленный сигнал \r\nбез учета фазы";
            for (int i = 0; i < 360; i++)
            {
                DataSer_1.Points.AddXY(2 * Math.PI * i / 360, signal.Values[i]);
                DataSer_4.Points.AddXY(2 * Math.PI * i / 360, signal.RestoreSignal[i]);
                DataSer_5.Points.AddXY(2 * Math.PI * i / 360, signal.RestoreNonPhasedSignal[i]);
            }
            chart1.ResetAutoValues();
            chart1.Series.Add(DataSer_1);
            chart1.Series.Add(DataSer_4);
            chart1.Series.Add(DataSer_5);
            chart2.Series.Clear();
            chart3.Series.Clear();
            chart2.Legends.Clear();
            chart3.Legends.Clear();
            Legend l2 = new Legend();
            chart2.Legends.Add(l2);
            Legend l3 = new Legend();
            chart3.Legends.Add(l3);
            DataSer_2 = new Series();
            DataSer_2.ChartType = SeriesChartType.Candlestick;
            DataSer_2.Color = Color.Red;
            DataSer_2.Name = "Фазовый спектр";
            DataSer_3 = new Series();
            DataSer_3.ChartType = SeriesChartType.Candlestick;
            DataSer_3.Color = Color.Green;
            DataSer_3.Name = "Амплитудный спектр";
            for (int i = 0; i < N / 2; i++)
            {
                DataSer_2.Points.AddXY(i, signal.PhaseSpectrum[i]);
                DataSer_3.Points.AddXY(i, signal.AmplitudeSpectrum[i]);
            }
            chart2.ResetAutoValues();
            chart2.Series.Add(DataSer_2);
            chart3.ResetAutoValues();
            chart3.Series.Add(DataSer_3);
        }

        private FiltrationType getFilterType()
        {
            switch (filter.SelectedIndex) {
                case 0: return FiltrationType.None;
                case 1: return FiltrationType.LowFrequencies;
                case 2: return FiltrationType.HighFrequencies;
                case 3: return FiltrationType.BandPass;
            }
            return FiltrationType.None;
        }

        private void fftBox_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Calculate(SignalType.Harmonic);
            }
            else
            {
                Calculate(SignalType.Polyharmonic);
            }
        }

        private void filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Calculate(SignalType.Harmonic);
            }
            else
            {
                Calculate(SignalType.Polyharmonic);
            }
        }

        private void minGBar_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Минимальная гармоника: " + Convert.ToString(minGBar.Value);
            if (radioButton1.Checked)
            {
                Calculate(SignalType.Harmonic);
            }
            else
            {
                Calculate(SignalType.Polyharmonic);
            }
        }

        private void maxGBar_Scroll(object sender, EventArgs e)
        {
            label3.Text = "Максимальная гармоника: " + Convert.ToString(maxGBar.Value);
            if (radioButton1.Checked)
            {
                Calculate(SignalType.Harmonic);
            }
            else
            {
                Calculate(SignalType.Polyharmonic);
            }
        }

        private void radioButton1_Checked(object sender, EventArgs e)
        {
            Calculate(SignalType.Harmonic);
        }

        private void radioButton2_Checked(object sender, EventArgs e)
        {
            Calculate(SignalType.Polyharmonic);
        }

    }
}
