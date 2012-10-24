using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CellInfo
{
    public partial class TCH_Zone : Form
    {
        public TCH_Zone()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 业务信道信息
        /// </summary>
        /// <param name="result"></param>
        public void TCH_Assignment(string[] result)
        {
            this.textBox1.Text = result[39];
            this.textBox2.Text = result[40];
            this.textBox3.Text = result[41];
            this.textBox4.Text = result[42];
            this.textBox5.Text = result[43];
            this.textBox6.Text = result[44];
            this.textBox7.Text = result[45];
        }
    }
}
