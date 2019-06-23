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
    public partial class RIC : UserControl
    {
        public bool labelChanged = false;
        public RIC()
        {
            InitializeComponent();
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {

        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            try
            {
                String TimeString = DateTime.Now.ToString("yyyyMMdd_hmmtt_");
                this.chart1.SaveImage("c:\\CansatData\\" + TimeString + "Temperture(RIC).png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                this.chart2.SaveImage("c:\\CansatData\\" + TimeString + "Humidity(RIC).png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                this.chart3.SaveImage("c:\\CansatData\\" + TimeString + "Gas(RIC).png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                this.chart4.SaveImage("c:\\CansatData\\" + TimeString + "Pressure(RIC).png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                this.chart5.SaveImage("c:\\CansatData\\" + TimeString + "UVI(RIC).png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                this.chart6.SaveImage("c:\\CansatData\\" + TimeString + "UVA-UVB(RIC).png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
                this.chart7.SaveImage("c:\\CansatData\\" + TimeString + "Acceleration(RIC).png", System.Windows.Forms.DataVisualization.Charting.ChartImageFormat.Png);
            }
            catch
            { }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void altlabel_Click(object sender, EventArgs e)
        {

        }

        private void longlabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            labelChanged = true;
            commandLabel.Text = textBox2.Text;
        }
    }
}
