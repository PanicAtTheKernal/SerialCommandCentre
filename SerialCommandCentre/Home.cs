using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public partial class Home : UserControl
    {
        private const int NumberOfParameters = 11;
        private string comport;
        public string output;
        public Boolean serialSwitch = false;
        public SerialPort sp;
        public List<String> replayFileList = new List<string>();
        public List<float> timePara = new List<float>();
        public List<float> temperturePara = new List<float>();
        public List<float> pressurePara = new List<float>();
        public List<float> humiditPara = new List<float>();
        public List<float> gasPara = new List<float>();
        public List<float> uvaPara = new List<float>();
        public List<float> uvbPara = new List<float>();
        public List<float> uviPara = new List<float>();
        public List<float> acc = new List<float>();
        public List<float> acc2 = new List<float>();
        public List<float> acc3 = new List<float>();
        public bool DataValid = false;
        public Thread comthread;
        public ThreadStart workerObject;
        public float LastTemperature;
        string folderName;
        string pathString;
        string fileName;
        public Dictionary<string, float> dataDictonary = new Dictionary<string, float>();
        public bool formClosing = false;
        bool replayFile = false;
        string[] charactersToRemove = { "\n", "\r" };

        public Home()
        {
            InitializeComponent();
            scanForPorts();
            serialSwitch = false;
            button2.Enabled = false;
            createNewFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialSwitch = true;
            button1.Enabled = false;
            button2.Enabled = true;
            try
            {
                comport = comboBox1.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("There are no port!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                serialSwitch = false;
                button1.Enabled = true;
                button2.Enabled = false;
            }
            workerObject = new ThreadStart(StartReader);
            comthread = new Thread(workerObject);
            comthread.Start();
        }
        public void StartReader()
        {
            // Initialize serial communication 
            if (replayFile == false)
            {
                try
                {
                    sp = new SerialPort(comport, 9600, Parity.None, 8, StopBits.One);
                    sp.Open();
                    //for radio modem
                    sp.DtrEnable = false;
                    sp.RtsEnable = false;
                }
                catch
                {
                    MessageBox.Show("Can't open port!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }



            try
            {
                //
                while (!shouldStop)
                {
                    if (replayFile == false)
                    {
                        while ((output = sp.ReadLine()) != null)
                        {
                            using (StreamWriter files = File.AppendText(pathString))
                            {
                                files.WriteLine(output);
                            }
                            ProcessData(output);
                            Thread.Sleep(100);
                        }
                    }
                    if(replayFile == true)
                    {
                        foreach(string line in replayFileList)
                        {
                            output = line;
                            ProcessData(output);
                            Thread.Sleep(100);
                        }
                        replayFile = false;
                        formClosing = true;
                    }
                }
            }
            catch
            {
                if (formClosing == false)
                {
                    MessageBox.Show("Port has disconnected!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    serialSwitch = false;
                    InvokeButton1();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sp.Close();
            }
            catch { }
            button1.Enabled = true;
            button2.Enabled = false;
            serialSwitch = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] charactersToRemove = { "\n\r" };

            foreach (var c in charactersToRemove)
            {
                output = output.Replace(c, string.Empty);
            }
            Console.WriteLine(output);
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckState state = replayModeCheck.CheckState;
            switch (state)
            {
                case CheckState.Checked:
                    panel2.Enabled = false;
                    openFile.Enabled = true;
                    break;
                case CheckState.Unchecked:
                    panel2.Enabled = true;
                    openFile.Enabled = false;
                    break;
            }
        }

        public void RequestStop()
        {
            shouldStop = true;
        }
        private volatile bool shouldStop;

        private void button5_Click(object sender, EventArgs e)
        {
            serialSwitch = true;
            openFile.Enabled = false;
            replayModeCheck.Enabled = false;
            using (OpenFileDialog openFile = new OpenFileDialog() { Filter = "Text Documents|*.candata", ValidateNames = true, Multiselect = false })
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(openFile.FileName))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (line != string.Empty)
                            {
                                replayFileList.Add(line);
                            }
                        }
                        replayFile = true;
                        workerObject = new ThreadStart(StartReader);
                        comthread = new Thread(workerObject);
                        comthread.Start();
                    }
                }
                else
                {
                    this.openFile.Enabled = true;
                    replayModeCheck.Enabled = true;
                }
            }
        }
        private void scanForPorts()
        {
            string[] allports = SerialPort.GetPortNames();

            foreach (string port in allports)
            {
                if (comboBox1.FindString(port) == -1)
                    // Add communication ports to combobox
                    comboBox1.Items.Add(port);

            }

            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            scanForPorts();
        }
        private void createNewFile()
        {
            folderName = @"c:\CansatData";
            pathString = Path.Combine(folderName, "Data");
            Directory.CreateDirectory(pathString);
            fileName = Path.GetRandomFileName();
            fileName = fileName.Replace(".", string.Empty);
            fileName = fileName + ".candata";
            pathString = Path.Combine(pathString, fileName);

            if (!File.Exists(pathString))
            {
                using (StreamWriter files = File.AppendText(pathString))
                {
                    files.WriteLine("Start");
                }
            }
            else
            {
                MessageBox.Show("File \"{0}\" already exists.", fileName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void InvokeButton1()
        {
            if (button1.InvokeRequired)
            {
                button1.Invoke((MethodInvoker)delegate ()
                {
                    InvokeButton1();
                });
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = false;
            }
        }
        public void ProcessData(string data)
        {
            foreach (var c in charactersToRemove)
            {
                data = data.Replace(c, string.Empty);
            }
            String[] SplitString = data.Split('|');
            // Blank string check
            if (SplitString.Length < 2)
                return;
            // Process String
            try
            {
                AddValueToCorrectKey(SplitString, "//time", "", "", timePara, null, null);
                AddValueToCorrectKey(SplitString,"temp", "", "", temperturePara, null, null);
                AddValueToCorrectKey(SplitString, "press", "", "", pressurePara, null, null);
                AddValueToCorrectKey(SplitString, "latitude", "", "", null, null, null);
                AddValueToCorrectKey(SplitString, "longitude", "", "", null, null, null);
                AddValueToCorrectKey(SplitString, "altitude", "", "", null, null, null);
                AddValueToCorrectKey(SplitString, "humidty", "", "", humiditPara, null, null);
                AddValueToCorrectKey(SplitString, "gas", "", "", gasPara, null, null);
                AddValueToCorrectKey(SplitString, "UVA", "", "", uvaPara, null, null);
                AddValueToCorrectKey(SplitString, "UVB", "", "", uvbPara, null, null);
                AddValueToCorrectKey(SplitString, "UVI", "", "", uviPara, null, null);
                AddValueToCorrectKey(SplitString, "linAcc", "acc2", "acc3", acc, acc2, acc3);
                DataValid = true;
            }
            catch
            {
                DataValid = false;
            }
        }
        public void AddValueToCorrectKey(string[] rawData, string keyword, string keyword2, string keyword3, List<float> parameter, List<float> parameter2, List<float> parameter3)
        {
            string[] characterToRemove = { "(", ")" };
            lock (output)
            {
                foreach (string dataTemp in rawData)
                {
                    String[] tempString = dataTemp.Split(':');
                    if (tempString[0] == keyword)
                    {
                        if (tempString[1].Contains("("))
                        {
                            foreach (var character in characterToRemove)
                            {
                                tempString[1] = tempString[1].Replace(character, string.Empty);
                            }

                            string[] thresSplit = tempString[1].Split(',');
                            if (keyword2 != "")
                            {
                                dataDictonary[keyword] = (float)Convert.ToDouble(thresSplit[0]);
                                dataDictonary[keyword2] = (float)Convert.ToDouble(thresSplit[1]);
                                dataDictonary[keyword3] = (float)Convert.ToDouble(thresSplit[2]);
                            }
                            if (parameter2 != null)
                            {
                                parameter.Add((float)Convert.ToDouble(thresSplit[0]));
                                parameter2.Add((float)Convert.ToDouble(thresSplit[1]));
                                parameter3.Add((float)Convert.ToDouble(thresSplit[2]));
                            }
                        }
                        else
                        {
                            dataDictonary[keyword] = (float)Convert.ToDouble(tempString[1]);
                            if (parameter != null)
                            {
                                parameter.Add(dataDictonary[keyword]);
                            }
                        }
                    }
                }
            }

        }
    }
}
