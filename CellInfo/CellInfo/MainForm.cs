using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CellInfo
{
    public partial class MainForm : Form
    {
        private bool flg = false;

        PortConfigure Portconfigure = new PortConfigure();
        Serving_Zone Servingfrm = new Serving_Zone();
        Neighbor_Zone Neighborfrm = new Neighbor_Zone();
        ComPortClass Serialport = new ComPortClass();

        static string[] result;
        static string[] result1;

        static string[] resultBackup;
        static string[] result1Backup;

        static string ServingCellInfo;
        static string NeighborCellInfo;

        static string[] temp = new string[12];
        static string[,] temp2 = new string[6, 8];

        public MainForm()
        {
            InitializeComponent();
            InitializeForms();
        }

        /// <summary>
        /// 窗体初始化
        /// </summary>
        private void InitializeForms()
        {
            timer1.Enabled = false;

            Servingfrm.MdiParent = this;
            Servingfrm.Show();
            Servingfrm.Bounds = new Rectangle(0, 0, 483, 389);

            Neighborfrm.MdiParent = this;
            Neighborfrm.Show();
            Neighborfrm.Bounds = new Rectangle(0, 390, 547, 199);

            
        }

        /// <summary>
        /// 到处历史文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 读入邻居小区历史信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neighborZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 读入当前小区历史信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void servingZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void escapeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 显示当前小区信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 当前小区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Servingfrm == null || Servingfrm.IsDisposed)
            {
                Servingfrm = new Serving_Zone();
            }
            Servingfrm.MdiParent = this; //建立父子关系
            Servingfrm.Show(); //显示子窗口
            Servingfrm.Bounds = new Rectangle(0, 0, 483, 389);
        }

        /// <summary>
        /// 显示邻居小区信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 邻居小区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Neighborfrm == null || Neighborfrm.IsDisposed)
            {
                Neighborfrm = new Neighbor_Zone();
            }
            Neighborfrm.MdiParent = this; //建立父子关系
            Neighborfrm.Show(); //显示子窗口
            Neighborfrm.Bounds = new Rectangle(0, 390, 547, 199);
        }

        /// <summary>
        /// 显示当前小区和邻居小区波形图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 波形图ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 层叠当前子窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 层叠窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// 水平平铺当前子窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 水平平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// 垂直平铺当前子窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 垂直平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        /// <summary>
        /// 关闭所有当前子窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 关闭所有子窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] frmList = this.MdiChildren;
            foreach (Form frm in frmList)
            {
                frm.Close();
            }
        }

        /// <summary>
        /// 串口设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Portconfigure.ShowDialog();
            toolStripStatusLabel1.Text = "";

            if (Portconfigure.portName == "")
            {
                toolStripStatusLabel1.Text = "No COM Port Found!";
            }
            
            flg = true;
        }

        /// <summary>
        /// 开始运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (flg)
            {
                Serialport.Port_Assignment(Portconfigure.portName, Portconfigure.baudRate, Portconfigure.handShake, Portconfigure.parity, Portconfigure.dataBits, Portconfigure.stopBits);
                toolStripStatusLabel1.Text = "Port Name:" + Portconfigure.portName + " Baud Rate:" + Convert.ToString(Portconfigure.baudRate) + " Handshake:" + Portconfigure.handShake + " Parity:" + Portconfigure.parity + " Data Bits:" + Convert.ToString(Portconfigure.dataBits) + " Stop Bits:" + Portconfigure.stopBits;                
                //采样刷新
                timer1.Interval = 1000;
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("请先进行串口设置", "提示信息");
            }
        }

        /// <summary>
        /// 串口信息更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Serialport.OpenComPort();
            try
            {
                ServingCellInfo = Serialport.AT_Serving();
                NeighborCellInfo = Serialport.AT_Neighbor();

                result = FileOperate.DataPull(ServingCellInfo);
                result1 = FileOperate.DataPull(NeighborCellInfo);                 

                Servingfrm.Serving_Assignment(result);
                Neighborfrm.Neighbor_Assignment(result1);
                //数据备份
                resultBackup = result;
                result1Backup = result1;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Servingfrm.Serving_Assignment(resultBackup);
                Neighborfrm.Neighbor_Assignment(result1Backup);
            }
        }

    }
}
