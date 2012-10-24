using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CellInfo
{
    public partial class ServingZone_Info : Form
    {
        public DataTable dt = new DataTable();
        public ServingZone_Info()
        {
            InitializeComponent();
            //"chann", "rs", "dBm", 6"MCC", "MNC", "LAC", "cell", "NCC", "BCC", "PWR", "RXLev", "C1" 
            DataColumn col1 = new DataColumn("Time", typeof(string));
            DataColumn col2 = new DataColumn("chann", typeof(string));
            DataColumn col3 = new DataColumn("rs", typeof(string));
            DataColumn col4 = new DataColumn("dBm", typeof(string));
            DataColumn col5 = new DataColumn("MCC", typeof(string));
            DataColumn col6 = new DataColumn("MNC", typeof(string));
            DataColumn col7 = new DataColumn("LAC", typeof(string));
            DataColumn col8 = new DataColumn("cell", typeof(string));
            DataColumn col9 = new DataColumn("NCC", typeof(string));
            DataColumn col10 = new DataColumn("BCC", typeof(string));
            DataColumn col11 = new DataColumn("PWR", typeof(string));
            DataColumn col12 = new DataColumn("RxLev", typeof(string));
            DataColumn col13 = new DataColumn("C1", typeof(string));


            //向表中添加列
            dt.Columns.Add(col1);
            dt.Columns.Add(col2);
            dt.Columns.Add(col3);
            dt.Columns.Add(col4);
            dt.Columns.Add(col5);
            dt.Columns.Add(col6);
            dt.Columns.Add(col7);
            dt.Columns.Add(col8);
            dt.Columns.Add(col9);
            dt.Columns.Add(col10);
            dt.Columns.Add(col11);
            dt.Columns.Add(col12);
            dt.Columns.Add(col13);


            //给DataGrid绑定数据
            this.dataGridView1.DataSource = dt;
        }
    }
}
