using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CellInfo
{
    public partial class Serving_Zone : Form
    {
        public Serving_Zone()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 当前小区信息显示
        /// </summary>
        /// <param name="result"></param>
        public void Serving_Assignment(string[] result)
        {
            this.textBox1.Text = result[26];
            this.textBox2.Text = result[27];
            this.textBox3.Text = result[28];
            this.textBox4.Text = result[29];
            this.textBox5.Text = result[30];
            this.textBox6.Text = result[31];
            this.textBox7.Text = result[32];
            this.textBox8.Text = result[33];
            this.textBox9.Text = result[34];
            this.textBox10.Text = result[35];
            this.textBox11.Text = result[36];
            this.textBox12.Text = result[37];

            if (int.Parse(textBox3.Text) < -90)
            {
                textBox2.BackColor = Color.Red;
            }
        }

        /*
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(this.textBox3.Text) < -90)
                    {
                        textBox2.BackColor =Color.Red;
                    }
        }
         */
    }
}
