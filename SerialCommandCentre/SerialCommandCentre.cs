using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;

namespace WindowsFormsApp2
{
    public partial class SerialCommandCentre : Form
    {
        //
        static private GMapOverlay overlay_ = new GMapOverlay();
        static private int TimerTimeout = 0;
        public float tempertureAverage;
        public float pressureAverage;
        public float humitdiyAverage;
        public float gasAverage;
        public float uvaAverage;
        public float uvbAverage;
        public float uviAverage;
        public float accAverage;
        public float acc2Average;
        public float acc3Average;


        public SerialCommandCentre()
        {
            InitializeComponent();
            home1.BringToFront();
            DataProcessing.Start();
            serialMointor1.listBox1.Items.Add("Start");
            gps1.gMapControl1.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            gps1.gMapControl1.Position = new GMap.NET.PointLatLng(53.336215, -6.425606);
            gps1.gMapControl1.Zoom = 18;
            ric1.gMapControl1.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            ric1.gMapControl1.Position = new GMap.NET.PointLatLng(53.336215, -6.425606);
            ric1.gMapControl1.Zoom = 18;
            this.WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphs1.BringToFront();
            this.WindowState = FormWindowState.Normal;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            gps1.BringToFront();
            this.WindowState = FormWindowState.Normal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialMointor1.BringToFront();
            this.WindowState = FormWindowState.Normal;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            home1.BringToFront();
            this.WindowState = FormWindowState.Normal;

        }
        public void ListBoxUpdate(string text)
        {
            if (serialMointor1.listBox1.InvokeRequired)
            {
                serialMointor1.listBox1.Invoke((MethodInvoker)delegate ()
                {
                    ListBoxUpdate(text);
                });
            }
            else
            {
                if (home1.output != null)
                {
                    try
                    {
                        serialMointor1.listBox1.Items.Add(text);
                        int visibleItems = serialMointor1.listBox1.ClientSize.Height / serialMointor1.listBox1.ItemHeight;
                        serialMointor1.listBox1.TopIndex = Math.Max(serialMointor1.listBox1.Items.Count - visibleItems + 1, 0);
                        ric1.textBox1.Text = home1.output;

                        tryToUpdateLabel(ric1.latlabel, "latitude", "°");
                        tryToUpdateLabel(ric1.longlabel, "longitude", "°");
                        tryToUpdateLabel(ric1.altlabel, "altitude", "m");
                        tryToUpdateLabel(ric1.pressLabel, "press", "Hpa");
                        tryToUpdateLabel(ric1.tempLabel, "temp", "C°");
                        tryToUpdateLabel(ric1.humLabel, "humidty", "%");
                        tryToUpdateLabel(ric1.gasLabel, "gas", "%");
                        tryToUpdateLabel(ric1.uvaLabel, "UVA", " µW/cm²");
                        tryToUpdateLabel(ric1.uvbLabel, "UVB", " µW/cm²");
                        tryToUpdateLabel(ric1.uviLabel, "UVI", "");
                        tryToUpdateLabel(ric1.accLabel, "linAcc"," m/s²");
                        tryToUpdateLabel(ric1.accLabel2, "acc2"," m/s²");
                        tryToUpdateLabel(ric1.accLabel3, "acc3"," m/s²");

                        double Altitude = AltitudeFromPressure((double)(home1.dataDictonary["press"]));
                        DisplayTemperatureGauge((int)(home1.dataDictonary["temp"]));

                        DisplayAltitudeGauge((int)(Altitude));
                    }
                    catch { }

                    lock (home1.output)
                    {
                        graphs1.chart1.Series[0].Points.DataBindY(home1.temperturePara.ToList());
                        ric1.chart1.Series[0].Points.DataBindY(home1.temperturePara.ToList());
                        tempertureAverage = AverageOfArray(home1.temperturePara);
                        graphs1.chart1.Titles[1].Text = "Mean: " + Convert.ToString(tempertureAverage);

                        graphs1.chart2.Series[0].Points.DataBindY(home1.pressurePara.ToList());
                        ric1.chart4.Series[0].Points.DataBindY(home1.pressurePara.ToList());
                        pressureAverage = AverageOfArray(home1.pressurePara);
                        graphs1.chart2.Titles[1].Text = "Mean: " + Convert.ToString(pressureAverage);

                        graphs1.chart3.Series[0].Points.DataBindY(home1.humiditPara.ToList());
                        ric1.chart2.Series[0].Points.DataBindY(home1.humiditPara.ToList());
                        humitdiyAverage = AverageOfArray(home1.humiditPara);
                        graphs1.chart3.Titles[1].Text = "Mean: " + Convert.ToString(humitdiyAverage);

                        graphs1.chart4.Series[0].Points.DataBindY(home1.gasPara.ToList());
                        ric1.chart3.Series[0].Points.DataBindY(home1.gasPara.ToList());
                        gasAverage = AverageOfArray(home1.gasPara);
                        graphs1.chart4.Titles[1].Text = "Mean: " + Convert.ToString(gasAverage);

                        graphs1.chart5.Series[0].Points.DataBindY(home1.uvaPara.ToList());
                        graphs1.chart5.Series[1].Points.DataBindY(home1.uvbPara.ToList());
                        ric1.chart6.Series[0].Points.DataBindY(home1.uvaPara.ToList());
                        ric1.chart6.Series[1].Points.DataBindY(home1.uvbPara.ToList());
                        uvaAverage = AverageOfArray(home1.uvaPara);
                        uvbAverage = AverageOfArray(home1.uvbPara);
                        graphs1.chart5.Titles[1].Text = "(UVA)Mean: " + Convert.ToString(uvaAverage) + "(UVB)Mean: " + Convert.ToString(uvbAverage);

                        graphs1.chart6.Series[0].Points.DataBindY(home1.uviPara.ToList());
                        ric1.chart5.Series[0].Points.DataBindY(home1.uviPara.ToList());
                        uviAverage = AverageOfArray(home1.uviPara);
                        graphs1.chart6.Titles[1].Text = "Mean: " + Convert.ToString(uviAverage);

                        graphs1.chart7.Series[0].Points.DataBindY(home1.acc.ToList());
                        graphs1.chart7.Series[1].Points.DataBindY(home1.acc2.ToList());
                        graphs1.chart7.Series[2].Points.DataBindY(home1.acc3.ToList());
                        ric1.chart7.Series[0].Points.DataBindY(home1.acc.ToList());
                        ric1.chart7.Series[1].Points.DataBindY(home1.acc2.ToList());
                        ric1.chart7.Series[2].Points.DataBindY(home1.acc3.ToList());
                        accAverage = AverageOfArray(home1.acc);
                        acc2Average = AverageOfArray(home1.acc2);
                        acc3Average = AverageOfArray(home1.acc3);
                        graphs1.chart7.Titles[1].Text = "(X)Mean: " + Convert.ToString(accAverage) + "(Y)Mean: " + Convert.ToString(acc2Average) + "(Z)Mean: " + Convert.ToString(acc3Average);

                        Markers();
                    }
                }
            }
            if (ric1.labelChanged == true)
            {
                try
                {
                    home1.sp.Write(ric1.textBox2.Text);
                }
                catch
                {
                    MessageBox.Show("Not connected to serial port!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ric1.labelChanged = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ric1.BringToFront();
            this.WindowState = FormWindowState.Maximized;
        }
        private void Markers()
        {
            try
            {
                gps1.latitudeLabel.Text = Convert.ToString(home1.dataDictonary["latitude"]);
                gps1.longitudeLabel.Text = Convert.ToString(home1.dataDictonary["longitude"]);
                gps1.altitudeLabel.Text = Convert.ToString(home1.dataDictonary["altitude"]);
                GMapOverlay Markers = new GMapOverlay("Markers");
                GMapMarker marker = new GMarkerGoogle(
                    new PointLatLng(Convert.ToDouble(home1.dataDictonary["latitude"]), Convert.ToDouble(home1.dataDictonary["longitude"])),
                    GMarkerGoogleType.red_dot);
                Markers.Markers.Add(marker);
                gps1.gMapControl1.Overlays.Add(Markers);
                gps1.gMapControl1.Position = new GMap.NET.PointLatLng(Convert.ToDouble(home1.dataDictonary["latitude"]), Convert.ToDouble(home1.dataDictonary["longitude"]));
                ric1.gMapControl1.Overlays.Add(Markers);
                ric1.gMapControl1.Position = new GMap.NET.PointLatLng(Convert.ToDouble(home1.dataDictonary["latitude"]), Convert.ToDouble(home1.dataDictonary["longitude"]));
            }
            catch { }
        }

        //Send commands using keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Right)
                SendCommand("$Right#");
            else if (keyData == Keys.Left)
                SendCommand("$Left#");
            else if (keyData == Keys.Up)
                SendCommand("$Up#");
            else if (keyData == Keys.Down)
                SendCommand("$Down#");

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SendCommand(String commandString)
        {
            try
            {
                home1.sp.Write(commandString);
                ric1.commandLabel.Text = commandString;
            }
            catch
            {
                MessageBox.Show("Not connected to serial port! Unable to send command " + commandString, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public float AverageOfArray(List<float> arrayAverage)
        {
            float average = 0;
            lock (arrayAverage)
            {
                try
                {
                    int length = arrayAverage.Count;
                    float sum = arrayAverage.Sum();
                    average = 1f;
                    if (length > 0)
                    {
                        average = sum / (float)length;
                    }
                    else
                    {
                        average = 1f;
                    }
                }
                catch { }
            }
            return average;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            home1.formClosing = true;
            try
            {
                home1.sp.Close();
                home1.RequestStop();
                home1.comthread.Join();
            }
            catch { }
        }

        private void DisplayAltitudeGauge(int Altitude)
        {
            try
            {
                if (Altitude < ric1.AltitudeGauge.MinValue)
                {
                    ric1.AltitudeGauge.Value = ric1.AltitudeGauge.MinValue;
                }
                else
                if (Altitude > ric1.AltitudeGauge.MaxValue)
                {
                    ric1.AltitudeGauge.Value = ric1.AltitudeGauge.MaxValue;
                }
                else
                    ric1.AltitudeGauge.Value = Altitude;
            }
            catch
            { }
        }

        private void DisplayTemperatureGauge(int TemperatureToDisplay)
        {
            try
            {
                if (TemperatureToDisplay > ric1.TemperatureMeter.MaximumValue)
                {
                    ric1.TemperatureMeter.CurrentValue = ric1.TemperatureMeter.MaximumValue;
                }
                else
                if (TemperatureToDisplay < ric1.TemperatureMeter.MinimumValue)
                {
                    ric1.TemperatureMeter.CurrentValue = ric1.TemperatureMeter.MinimumValue;
                }
                else
                    ric1.TemperatureMeter.CurrentValue = TemperatureToDisplay;


            }
            catch
            { }
        }
        private void tryToUpdateLabel(Label label, string keyword, string units)
        {
            try
            {
                label.Text = Convert.ToString(home1.dataDictonary[keyword]) + units;
            }
            catch { }
        }

        private double AltitudeFromPressure(double InputPressure)
        {
            double Temp = (InputPressure - 5) * 100; // 5 is difference between 1000 and barometer
            Temp = Temp / 101325;
            Temp = Math.Log(Temp);
            Temp = Temp * 287.053;
            Temp = Temp * ((65 + 459.67) * 5) / 9; // 65 is 20 celcius in farenheight
            Temp = Temp / (-9.8);
            return Temp;

        }

        private void DataProcessing_Tick(object sender, EventArgs e)
        {

        }

        private void DataHandling_Tick(object sender, EventArgs e)
        {
            if (home1.serialSwitch == true)
            {
                ric1.apcStatLab.Text = "Connected";
                ric1.panel2.BackColor = Color.Lime;
                home1.apcStatusLabel.Text = "Connected";
                if (home1.output != "")
                {
                    if (home1.DataValid)
                    {
                        serialMointor1.dataQLabel.Text = "Locked";
                    }
                    else
                    {
                        serialMointor1.dataQLabel.Text = "Errors";
                    }
                    TimerTimeout = 0;
                    ListBoxUpdate(home1.output);
                    home1.output = "";

                }
                else
                    TimerTimeout++;
                if (TimerTimeout > 200)
                {
                    serialMointor1.dataQLabel.Text = "No Data";
                }
                DataProcessing.Interval = 100;
            }
            else
            {
                ric1.apcStatLab.Text = "Disconnected";
                home1.apcStatusLabel.Text = "Disconnected";
                ric1.panel2.BackColor = Color.Brown;
                serialMointor1.dataQLabel.Text = "No Data";
            }

        }
    }
}
