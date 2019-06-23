using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Graphs : UserControl
    {
        public Graphs()
        {
            InitializeComponent();
            chart1.Visible = true;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = false;
            chart7.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            chart1.Visible = true;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = false;
            chart7.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = true;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = false;
            chart7.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = true;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = false;
            chart7.Visible = false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = true;
            chart5.Visible = false;
            chart6.Visible = false;
            chart7.Visible = false;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = true;
            chart6.Visible = false;
            chart7.Visible = false;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = true;
            chart7.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                String TimeString = DateTime.Now.ToString("yyyyMMdd_hmmtt_");
                this.chart1.SaveImage("c:\\CansatData\\" + TimeString + "Temperture.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                this.chart2.SaveImage("c:\\CansatData\\" + TimeString + "Pressure.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                this.chart3.SaveImage("c:\\CansatData\\" + TimeString + "Humidty.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                this.chart4.SaveImage("c:\\CansatData\\" + TimeString + "Gas.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                this.chart5.SaveImage("c:\\CansatData\\" + TimeString + "UVA-UVB.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                this.chart6.SaveImage("c:\\CansatData\\" + TimeString + "UVI.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                this.chart7.SaveImage("c:\\CansatData\\" + TimeString + "Acceleration.png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            }
            catch
            { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = false;
            chart7.Visible = true;
        }
    }
}
