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
    public partial class PortConfigure : Form
    {
        internal string portName;
        internal int baudRate;
        internal string handShake;
        internal string parity;
        internal int dataBits;
        internal string stopBits;

        public PortConfigure()
        {
            InitializeComponent();
            PortSet();
        }

        private void PortSet()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                this.comboBox1.Items.Add(port);
            }

            this.comboBox1.FormattingEnabled = true;

            this.comboBox1.TabIndex = 0;
            if (ports.Length > 0)
            {
                this.comboBox1.SelectedIndex = 0;
            }
            
            this.comboBox2.SelectedIndex = 3;
            
            this.comboBox3.SelectedIndex = 0;
            this.comboBox4.SelectedIndex = 0;
            this.comboBox5.SelectedIndex = 4;
            this.comboBox6.SelectedIndex = 0; 

        }
       
        /// <summary>
        /// 单击确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //this.comboBox2.SelectedText = comboBox2.Text;

            this.DialogResult = DialogResult.OK;
            this.portName = comboBox1.Text;
            this.baudRate = Convert.ToInt32(comboBox2.Text);
            this.handShake = comboBox3.Text;
            this.parity = comboBox4.Text;
            this.dataBits = Convert.ToInt32(comboBox5.Text);
            this.stopBits = comboBox6.Text;
            this.Close();
        }

        /// <summary>
        /// 单击取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
