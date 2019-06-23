namespace WindowsFormsApp2
{
    partial class SerialCommandCentre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerialCommandCentre));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DataProcessing = new System.Windows.Forms.Timer(this.components);
            this.DataHandling = new System.Windows.Forms.Timer(this.components);
            this.gps1 = new WindowsFormsApp2.GPS();
            this.home1 = new WindowsFormsApp2.Home();
            this.serialMointor1 = new WindowsFormsApp2.SerialMointor();
            this.ric1 = new WindowsFormsApp2.RIC();
            this.graphs1 = new WindowsFormsApp2.Graphs();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 861);
            this.panel1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(9, 383);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(144, 44);
            this.button5.TabIndex = 7;
            this.button5.Text = "     RIC";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(9, 307);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 70);
            this.button3.TabIndex = 5;
            this.button3.Text = "     Serial\r\n     Monitor";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.SteelBlue;
            this.button4.Cursor = System.Windows.Forms.Cursors.Default;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(9, 145);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(144, 48);
            this.button4.TabIndex = 4;
            this.button4.Text = "     Home";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(9, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 48);
            this.button2.TabIndex = 4;
            this.button2.Text = "     GPS";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(9, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "     Graphs";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DataProcessing
            // 
            this.DataProcessing.Tick += new System.EventHandler(this.DataProcessing_Tick);
            // 
            // DataHandling
            // 
            this.DataHandling.Tick += new System.EventHandler(this.DataHandling_Tick);
            // 
            // gps1
            // 
            this.gps1.BackColor = System.Drawing.Color.Gainsboro;
            this.gps1.Location = new System.Drawing.Point(156, 0);
            this.gps1.Name = "gps1";
            this.gps1.Size = new System.Drawing.Size(1428, 861);
            this.gps1.TabIndex = 2;
            // 
            // home1
            // 
            this.home1.BackColor = System.Drawing.Color.Gainsboro;
            this.home1.Location = new System.Drawing.Point(156, 0);
            this.home1.Name = "home1";
            this.home1.Size = new System.Drawing.Size(1428, 861);
            this.home1.TabIndex = 1;
            // 
            // serialMointor1
            // 
            this.serialMointor1.BackColor = System.Drawing.Color.Gainsboro;
            this.serialMointor1.Location = new System.Drawing.Point(156, 0);
            this.serialMointor1.Name = "serialMointor1";
            this.serialMointor1.Size = new System.Drawing.Size(1428, 861);
            this.serialMointor1.TabIndex = 4;
            // 
            // ric1
            // 
            this.ric1.BackColor = System.Drawing.Color.Gainsboro;
            this.ric1.Location = new System.Drawing.Point(156, 0);
            this.ric1.Name = "ric1";
            this.ric1.Size = new System.Drawing.Size(1764, 1057);
            this.ric1.TabIndex = 3;
            // 
            // graphs1
            // 
            this.graphs1.BackColor = System.Drawing.Color.Gainsboro;
            this.graphs1.Location = new System.Drawing.Point(156, 0);
            this.graphs1.Name = "graphs1";
            this.graphs1.Size = new System.Drawing.Size(1428, 861);
            this.graphs1.TabIndex = 5;
            // 
            // SerialCommandCentre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.graphs1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ric1);
            this.Controls.Add(this.gps1);
            this.Controls.Add(this.home1);
            this.Controls.Add(this.serialMointor1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "SerialCommandCentre";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Command Centre";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer DataProcessing;
        private GPS userControl21;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Home Home;
        private SerialMointor userControl31;
        private Graphs userControl11;
        private System.Windows.Forms.Button button5;
        private RIC RIC;
        private System.Windows.Forms.Timer DataHandling;
        private Home home1;
        private GPS gps1;
        private RIC ric1;
        private SerialMointor serialMointor1;
        private Graphs graphs1;
    }
}

