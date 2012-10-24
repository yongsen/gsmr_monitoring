using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CellInfo
{
    public partial class Form4 : Form
    {
        public static DataTable dt = new DataTable();
      
        public Form4()
        {
            InitializeComponent();                     
        }
        public void Neighbor_Assignment(string[] result)
        {
            DataRow row1 = Form4.dt.NewRow();
            DataRow row2 = Form4.dt.NewRow();
            DataRow row3 = Form4.dt.NewRow();

            Form4.dt.Rows.Add(row1);
            Form4.dt.Rows.Add(row2);
            Form4.dt.Rows.Add(row3);

            //给第一行数据赋值
            row1["Cell Num"] = "N1";
            row1["chann"] = result[9];
            row1["rs"] = result[10];
            row1["dBm"] = result[11];
            row1["MCC"] = result[12];
            row1["MNC"] = result[13];
            row1["BCC"] = result[14];
            row1["C1"] = result[15];
            row1["C2"] = result[16];

            //给第二行数据赋值
            row2["Cell Num"] = "N2";
            row2["chann"] = result[17];
            row2["rs"] = result[18];
            row2["dBm"] = result[19];
            row2["MCC"] = result[20];
            row2["MNC"] = result[21];
            row2["BCC"] = result[22];
            row2["C1"] = result[23];
            row2["C2"] = result[24];

            //给第三行数据赋值
            row3["Cell Num"] = "N3";
            row3["chann"] = result[25];
            row3["rs"] = result[26];
            row3["dBm"] = result[27];
            row3["MCC"] = result[28];
            row3["MNC"] = result[29];
            row3["BCC"] = result[30];
            row3["C1"] = result[31];
            row3["C2"] = result[32];
        }

        private void Form4_Load(object sender, EventArgs e)
        {   
                //新建列
                DataColumn col1 = new DataColumn("Cell Num", typeof(string));
                DataColumn col2 = new DataColumn("chann", typeof(string));
                DataColumn col3 = new DataColumn("rs", typeof(string));
                DataColumn col4 = new DataColumn("dBm", typeof(string));
                DataColumn col5 = new DataColumn("MCC", typeof(string));
                DataColumn col6 = new DataColumn("MNC", typeof(string));
                DataColumn col7 = new DataColumn("BCC", typeof(string));
                DataColumn col8 = new DataColumn("C1", typeof(string));
                DataColumn col9 = new DataColumn("C2", typeof(string));

                //向表中添加列()
                dt.Columns.Add(col1);
                dt.Columns.Add(col2);
                dt.Columns.Add(col3);
                dt.Columns.Add(col4);
                dt.Columns.Add(col5);
                dt.Columns.Add(col6);
                dt.Columns.Add(col7);
                dt.Columns.Add(col8);
                dt.Columns.Add(col9);

            //给DataGrid绑定数据
            this.dataGridView1.DataSource = dt;
        }           
    }
}
