using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CellInfo
{
    public partial class MainForm : Form
    {
        private bool flg = false;
        private bool Record_flag = false;
        private int delt_t = 300;
        private int RefreshInterval = 1000;

        PortConfigure Portconfigure = new PortConfigure();
        Serving_Zone Servingfrm = new Serving_Zone();
        Neighbor_Zone Neighborfrm = new Neighbor_Zone();
        Wave_Zone Wavefrm = new Wave_Zone();
        TCH_Zone TCHfrm = new TCH_Zone();
        ComPortClass Serialport = new ComPortClass();
        ErrorReportForm ErrorReportfrm = new ErrorReportForm();
        ListInfo listInform = new ListInfo();

        static public string PortStatusLabel = "SerialPort's Status";
        

        private string[] result;
        private string[] result1;

        private string[] resultBackup;
        private string[] result1Backup;

        private string ServingCellInfo;
        private string NeighborCellInfo;

        private string[] temp = new string[12];
        private string[,] temp2 = new string[6, 8];

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
            Servingfrm.Bounds = new Rectangle(0, 0, 410, 340);

            Neighborfrm.MdiParent = this;
            Neighborfrm.Show();
            Neighborfrm.Bounds = new Rectangle(0, 340, 540, 280);

            Wavefrm.MdiParent = this;
            Wavefrm.Show();
            Wavefrm.Bounds = new Rectangle(410, 0, 550, 340);

            TCHfrm.MdiParent = this;
            TCHfrm.Show();
            TCHfrm.Bounds = new Rectangle(540, 340, 420, 240);

            this.toolStripStatusLabel1.Text = PortStatusLabel;
        }

        /// <summary>
        /// 菜单栏“记录历史信息”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Record_flag = true;
     /*       saveFileDialog1.Title = "设置历史记录文件的存储路径";
            saveFileDialog1.Filter = "历史记录文件(*.xml)|*.xml|All files(*.*)|*.*";
            saveFileDialog1.InitialDirectory = @"c:\";
            saveFileDialog1.ShowDialog();

            string FileNamePath = saveFileDialog1.FileName.ToString();
            string FilePath = FileNamePath.Substring(FileNamePath.LastIndexOf("\\") + 1);

            recorder.infoRecorder.setSignalFilePath(FilePath); 
      */  }

        

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
            Servingfrm.MdiParent = this;
            Servingfrm.Show();
            Servingfrm.Bounds = new Rectangle(0, 0, 410, 340);
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
            Neighborfrm.MdiParent = this;
            Neighborfrm.Show();
            Neighborfrm.Bounds = new Rectangle(0, 340, 540, 280);
        }

        /// <summary>
        /// 显示当前业务信道基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 业务信道_Click(object sender, EventArgs e)
        {
            if (TCHfrm == null || TCHfrm.IsDisposed)
            {
                TCHfrm = new TCH_Zone();
            }
            TCHfrm.MdiParent = this;
            TCHfrm.Show();
            TCHfrm.Bounds = new Rectangle(540,340, 420, 240);
        }

        /// <summary>
        /// 显示当前小区和邻居小区波形图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 波形图ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Wavefrm == null || Wavefrm.IsDisposed)
            {
                Wavefrm = new Wave_Zone();
            }
            Wavefrm.MdiParent = this;
            Wavefrm.Show();
            Wavefrm.Bounds = new Rectangle(410, 0, 550, 340);
        }        
        /// <summary>
        /// 显示错误报告信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 错误报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ErrorReportfrm == null || ErrorReportfrm.IsDisposed)
            {
                ErrorReportfrm = new ErrorReportForm();
            }
            ErrorReportfrm.MdiParent = this; //建立父子关系
            ErrorReportfrm.Show(); //显示子窗口
            ErrorReportfrm.Bounds = new Rectangle(0, 390, 547, 199);
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
            //    toolStripStatusLabel1.Text = "Port Name:" + Portconfigure.portName +"; Baud Rate:" + Portconfigure.baudRate + "; Handshake:" + Portconfigure.handShake + "; Parity:" + Portconfigure.parity + "; Data Bits:" + Convert.ToString(Portconfigure.dataBits) + "; Stop Bits:" + Portconfigure.stopBits;
                
                //采样刷新
                timer1.Interval = RefreshInterval;
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
                ServingCellInfo = Serialport.AT_Serving(delt_t);
                NeighborCellInfo = Serialport.AT_Neighbor(delt_t);

                result = FileOperate.DataPull(ServingCellInfo);
                result1 = FileOperate.DataPull(NeighborCellInfo);

                if (result[26] != "ChMod")
                {
                    Servingfrm.Serving_Assignment(result);
                    Neighborfrm.Neighbor_Assignment(result1);
                    Wavefrm.Wave_Assignment(result, result1);
                                      
                    Wavefrm.TimerStart();

                    //数据备份
                    resultBackup = result;
                    result1Backup = result1;

                    if (Record_flag)
                    {
                        for (int i = 0; i <= recorder.infoRecorder.signalDetail.GetLength(0) - 1; i++)
                        {
                            temp[i] = result[i + 26];
                        }
                        recorder.infoRecorder.writeSignalToXml(temp);

                        for (int i = 0; i <= 2; i++)
                        {
                            for (int j = 0; j <= recorder.infoRecorder.neighborDetail.GetLength(0) - 1; j++)
                            {
                                temp2[i, j] = Convert.ToString(result1[j + 9 + i * 8]);
                                temp2[i + 3, j] = Convert.ToString(result1[j + 9 + i * 8]);
                            }
                        }
                        recorder.infoRecorder.writeNeighborToXml(temp2);
                    }

                    //while (result[39] != "No" && result[39] != "Limited" && result[39] != "Cell" && result[39] != "I")
                    //{
                    //    TCHfrm.TCH_Assignment(result);
                    //}
                }
       
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                Servingfrm.Serving_Assignment(resultBackup);
                Neighborfrm.Neighbor_Assignment(result1Backup);
            }
        }                

        private void 历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             //获得文件路径
            //localFilePath = saveFileDialog1.FileName.ToString();
            //获取文件名，不带路径
            //fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);
            //获取文件路径，不带文件名
            //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));
    
            saveFileDialog1.Title = "导出历史记录文件";
            saveFileDialog1.Filter = "历史记录文件(*.xml)|*.xml|All files(*.*)|*.*";
            //   string SavePath = saveFileDialog1.FileName;
            saveFileDialog1.InitialDirectory = @"c:\";
            saveFileDialog1.ShowDialog();

            string FileNamePath = saveFileDialog1.FileName.ToString();
            string FilePath = FileNamePath.Substring(FileNamePath.LastIndexOf("\\") + 1);

            recorder.infoRecorder.setSignalFilePath(FilePath);
        }

        /// <summary>
        /// 菜单栏串口设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 串口配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Portconfigure == null || Portconfigure.IsDisposed)
            {
                Portconfigure = new PortConfigure();
            }
            Portconfigure.ShowDialog();
            toolStripStatusLabel1.Text = "";

            if (Portconfigure.portName == "")
            {
                toolStripStatusLabel1.Text = "No COM Port Found!";
            }

            flg = true;
        }


        /// <summary>
        /// 系统菜单栏路径配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 路径配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        

        /// <summary>
        /// 开始测试菜单栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 开始测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flg)
            {
                Serialport.Port_Assignment(Portconfigure.portName, Portconfigure.baudRate, Portconfigure.handShake, Portconfigure.parity, Portconfigure.dataBits, Portconfigure.stopBits);
                toolStripStatusLabel1.Text = "Port Name:" + Portconfigure.portName + "; Baud Rate:" + Portconfigure.baudRate + "; Handshake:" + Portconfigure.handShake + "; Parity:" + Portconfigure.parity + "; Data Bits:" + Convert.ToString(Portconfigure.dataBits) + "; Stop Bits:" + Portconfigure.stopBits;
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
        /// 工具栏“停止”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            Wavefrm.TimerEnd();
         //   Application.Exit();
        }

        /// <summary>
        /// 菜单栏“系统退出”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 系统退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        //    timer1.Enabled = false;
            Application.Exit();
        }


        /// <summary>
        /// 历史菜单栏->导入波形图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 波形图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listInform == null || listInform.IsDisposed)
            {
                listInform = new ListInfo();
                listInform.Show();
            }

           
            listInform.MdiParent = this;
            listInform.Show();
            listInform.Bounds = new Rectangle(0, 340, 500, 410);
        
        }


        /// <summary>
        /// 历史菜单栏->导入当前小区历史信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void servingZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //"chann", "rs", "dBm", "MCC", "MNC", "LAC", "cell", "NCC", "BCC", "PWR", "RXLev", "C1"   
            openFileDialog1.Title = "导出历史记录文件";
            openFileDialog1.Filter = "当前小区信息历史记录文件(*.xml)|*.xml|All files(*.*)|*.*";
            openFileDialog1.InitialDirectory = @"c:\";
            openFileDialog1.ShowDialog();

            ServingZone_Info ServingXml = new ServingZone_Info();
            ServingXml.MdiParent = this;

            string[] servingTemp;
            string servingTime;

            int i;
          
            recorder.infoRecorder.signalFilePath = openFileDialog1.FileName.ToString();
            while (recorder.infoRecorder.getNextSignalData(out servingTemp, out servingTime) != 1)
            {
                DataRow Servingrow = ServingXml.dt.NewRow();
                ServingXml.dt.Rows.Add(Servingrow);
                Servingrow["Time"] = servingTime;
                for (i = 0; i <= recorder.infoRecorder.signalDetail.GetLength(0) - 1; i++)
                {
                    Servingrow[recorder.infoRecorder.signalDetail[i]] = servingTemp[i];
                }
                Thread.Sleep(200);
            }
            ServingXml.Show();
        }

        /// <summary>
        /// 历史菜单栏导入->邻居小区历史信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neighborZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NeighborZone_Info NeighborXml = new NeighborZone_Info();
            NeighborXml.MdiParent = this;

            openFileDialog2.Title = "导出历史记录文件";
            openFileDialog2.Filter = "当前小区信息历史记录文件(*.xml)|*.xml|All files(*.*)|*.*";
            openFileDialog2.InitialDirectory = @"c:\";
            openFileDialog2.ShowDialog();

            recorder.infoRecorder.neighborFilePath = openFileDialog2.FileName.ToString();

            string[,] neighborTemp;
            string neighborTime;

            int i, j, k = 0;

            while (recorder.infoRecorder.getNextNeighborData(out neighborTemp, out neighborTime) != 1)
            {

                DataRow Neighborrow = NeighborXml.dt.NewRow();


                NeighborXml.dt.Rows.Add(Neighborrow);
                Neighborrow["Time"] = neighborTime;

                Neighborrow["Cell Num"] = ++k;
                for (j = 0; j < 6; j++)
                {
                    for (i = 0; i <= recorder.infoRecorder.neighborDetail.GetLength(0) - 1; i++)
                    {
                        Neighborrow[recorder.infoRecorder.neighborDetail[i]] = neighborTemp[j, i];
                    }
                    Thread.Sleep(200);
                }
            }
            NeighborXml.Show();

        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Record_flag = true;
        }      
    }
}
