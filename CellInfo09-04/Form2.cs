using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CellInfo
{
    public partial class Form2 : Form
    {
        public Form2(string DialContent)
        {
            InitializeComponent();
            richTextBox1.Text= DialContent ;
        }
     //   public string DialContent;

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
