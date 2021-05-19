using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            Random rnd = new Random();
            int N = 0;
            int k = 1;
            int i = 0;
            double[] p = new double[5];
            double[] Frenquesy = new double[5]; ;
            double[] Statistic = new double[5];
            p[0] = Convert.ToDouble(textBox1.Text);
            p[1] = Convert.ToDouble(textBox2.Text);
            p[2] = Convert.ToDouble(textBox3.Text);
            p[3] = Convert.ToDouble(textBox4.Text);
            p[4] = 1 - (p[0] + p[1] + p[2] + p[3]);
            N = Convert.ToInt32(textBox6.Text);
            double sum = 0;
            double XKV = 0;
            for (int j = 0; j < 5; j++)
            {
                sum = +p[j] * (j + 1);
            }
            label7.Text = "Average: " + Math.Round(sum,3).ToString();
            double D = 0;
            for (int j = 0; j < 5; j++)
            {
                D = +p[j] * (j + 1) * (j + 1) - (sum * sum);
            }
            label10.Text = "Variance: " + Math.Round(D,3).ToString();
            while (i < N)
            {
                double a = rnd.NextDouble();
                double A = a;
                k = 0;
                while (true)
                {
                    A = A - p[k];
                    if (A <= 0)
                    {
                        break;
                    }
                    k++;
                }

                Statistic[k]++;
                i++;
            }
            for (int j = 0; j < 5; j++)
            {
                XKV = (Statistic[j] / (N * p[j]));
            }
            label11.Text = "Chi-squared: " + Math.Round(XKV,2).ToString();
            for (int j = 0; j < 5; j++)
            {
                Frenquesy[j] = Statistic[j] / N;
                chart1.Series[0].Points.AddXY(j + 1, Frenquesy[j]);
            }
            double sumex = 0;
            double Dex = 0;
            for (int j = 0; j < 5; j++)
            {
                sumex = Frenquesy[j] * (j + 1);
            }
            for (int j = 0; j < 5; j++)
            {
                Dex = (Frenquesy[j] * ((j + 1) * (j + 1)) - (sumex * sumex));
            }
            double delsum = 0, delD = 0;
            delsum = (sumex - sum) * 100;
            delD = ((Dex - D) * 100);
            if (delsum < 0)
            {
                delsum *= -1;
            }
            if (delD < 0)
            {
                delD *= -1;
            }
            int Dint = 0, Mint = 0;
            Dint += Convert.ToInt32(delD);
            Mint += Convert.ToInt32(delsum);
            label8.Text = "(error = " + Mint.ToString() + "%)";
            label9.Text = "(error = " + Dint.ToString() + "%)";
        }
    }
}
