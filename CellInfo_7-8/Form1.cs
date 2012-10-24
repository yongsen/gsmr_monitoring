using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.IO;

namespace CellInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            ComPortClass SerialPort = new ComPortClass("COM3", 9600);

            string ServingCellInfo = SerialPort.AT_Serving();
            textBox1.Text = ServingCellInfo;
            SerialPort.CloseCom();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ComPortClass SerialPort = new ComPortClass("COM3", 9600);

            string NeighborCellInfo = SerialPort.AT_Neighbor();
            //byte[] buffer = new byte[SerialPort.sp.BytesToRead];
            //SerialPort.sp.Read(buffer, 0, buffer.Length);
            //MessageBox.Show(System.Text.Encoding.ASCII.GetString(buffer));
            textBox2.Text = NeighborCellInfo;
            SerialPort.CloseCom();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}