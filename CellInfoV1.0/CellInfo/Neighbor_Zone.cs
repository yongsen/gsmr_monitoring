using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CellInfo
{
    public partial class Neighbor_Zone : Form
    {
        public static DataTable dt = new DataTable();
        
         DataRow row1 = Neighbor_Zone.dt.NewRow();
         DataRow row2 = Neighbor_Zone.dt.NewRow();
         DataRow row3 = Neighbor_Zone.dt.NewRow();
         DataRow row4 = Neighbor_Zone.dt.NewRow();
         DataRow row5 = Neighbor_Zone.dt.NewRow();
         DataRow row6 = Neighbor_Zone.dt.NewRow();

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

           
        public Neighbor_Zone()
        {
            InitializeComponent();

           
           
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

            dt.Rows.Add(row1);
            dt.Rows.Add(row2);
            dt.Rows.Add(row3);
            dt.Rows.Add(row4);
            dt.Rows.Add(row5);
            dt.Rows.Add(row6);

            //给DataGrid绑定数据
            this.dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 邻居小区信息显示
        /// </summary>
        /// <param name="result"></param>
        public void Neighbor_Assignment(string[] result)
        {
      /*      row1 = this.dt.NewRow();
            row2 = this.dt.NewRow();
            row3 = this.dt.NewRow();
            */

           

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

            //给第一行数据赋值
            row4["Cell Num"] = "N4";
            row4["chann"] = result[33];
            row4["rs"] = result[34];
            row4["dBm"] = result[35];
            row4["MCC"] = result[36];
            row4["MNC"] = result[37];
            row4["BCC"] = result[38];
            row4["C1"] = result[39];
            row4["C2"] = result[40];

            //给第二行数据赋值
            row5["Cell Num"] = "N5";
            row5["chann"] = result[41];
            row5["rs"] = result[42];
            row5["dBm"] = result[43];
            row5["MCC"] = result[44];
            row5["MNC"] = result[45];
            row5["BCC"] = result[46];
            row5["C1"] = result[47];
            row5["C2"] = result[48];

            //给第三行数据赋值
            row6["Cell Num"] = "N6";
            row6["chann"] = result[49];
            row6["rs"] = result[50];
            row6["dBm"] = result[51];
            row6["MCC"] = result[52];
            row6["MNC"] = result[53];
            row6["BCC"] = result[54];
            row6["C1"] = result[55];
            row6["C2"] = result[56];
        }
    }
}
