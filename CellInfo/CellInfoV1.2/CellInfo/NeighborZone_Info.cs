using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CellInfo
{
    public partial class NeighborZone_Info : Form
    {
        public DataTable dt = new DataTable();
        public NeighborZone_Info()
        {
            InitializeComponent();
            //新建列
            DataColumn col1 = new DataColumn("Time", typeof(string));
            DataColumn col2 = new DataColumn("Cell Num", typeof(string));
            DataColumn col3 = new DataColumn("chann", typeof(string));
            DataColumn col4 = new DataColumn("rs", typeof(string));
            DataColumn col5 = new DataColumn("dBm", typeof(string));
            DataColumn col6 = new DataColumn("MCC", typeof(string));
            DataColumn col7 = new DataColumn("MNC", typeof(string));
            DataColumn col8 = new DataColumn("BCC", typeof(string));
            DataColumn col9 = new DataColumn("C1", typeof(string));
            DataColumn col10 = new DataColumn("C2", typeof(string));

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


            //给DataGrid绑定数据
            this.dataGridView1.DataSource = dt;
        }
    }
}
