using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace CellInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string portName;
        public int baudRate;
        public string handShake;
        public string parity;
        public int dataBits;
        public string stopBits;

       
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.portName = comboBox1.Text;
            this.baudRate = Convert.ToInt32(comboBox2.Text);
            this.handShake = comboBox3.Text;
            this.parity = comboBox4.Text;
            this.dataBits = Convert.ToInt32(comboBox5.Text);
            this.stopBits = comboBox6.Text;
            this.Close();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
