using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CellInfo
{
    public partial class Form3 : Form
    {
        public static string[] result;
        public static string ServingCellInfo;
        FileOperate FO = new FileOperate();

        public Form3()
        {
            InitializeComponent();

            GetData();          
        }

        public void GetData()
        {
            if (MainForm.SerTimerflag == true)
            {
                result = FO.DataPull(ServingCellInfo);

                textBox1.Text = result[26];
                textBox2.Text = result[27];
                textBox3.Text = result[28];
                textBox4.Text = result[29];
                textBox5.Text = result[30];
                textBox6.Text = result[31];
                textBox7.Text = result[32];
                textBox8.Text = result[33];
                textBox9.Text = result[34];
                textBox10.Text = result[35];
                textBox11.Text = result[36];
                textBox12.Text = result[37];

                MainForm.SerTimerflag = false;
            }
        }
    }
}
