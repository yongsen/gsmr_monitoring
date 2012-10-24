using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.IO;

namespace CellInfo
{
    public partial class MainForm : Form
    {
        private string Dialcontent;
        private bool flg = false;

        static string[] result;
        static string[] result1;

        static string[] resultBackup;
        static string[] result1Backup;

        static string ServingCellInfo;
        static string NeighborCellInfo;

        static string[] temp = new string[12];
        static string[,] temp2 = new string[6, 8];

        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////
        /// </summary>
        ComPortClass Serialport = new ComPortClass();
        Form3 Servingfrm = new Form3();
        Form4 Neighborfrm = new Form4();
        Form6 Wavefrm = new Form6();
        // FileOperate FO = new FileOperate();
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////
        /// </summary>

        public MainForm()
        {
            InitializeComponent();
            InitializeForms();
            timer1.Enabled = false;
        }

        /// <summary>
        /// /////////////////////////////   子窗口初始化 ///////////////////////////////////////////////////
        /// </summary>
        private void InitializeForms()
        {
            //
            if (Servingfrm == null || Servingfrm.IsDisposed)
            {
                Servingfrm = new Form3();
            }
            Servingfrm.MdiParent = this; //建立父子关系
            Servingfrm.Show(); //显示子窗口
            Servingfrm.Bounds = new Rectangle(0, 0, 387, 342);

            //
            if (Neighborfrm == null || Neighborfrm.IsDisposed)
            {
                Neighborfrm = new Form4();
            }
            Neighborfrm.MdiParent = this; //建立父子关系
            Neighborfrm.Show(); //显示子窗口
            Neighborfrm.Bounds = new Rectangle(0, 343, 547, 176);

            //
            if (Wavefrm == null || Wavefrm.IsDisposed)
            {
                Wavefrm = new Form6();
            }
            Wavefrm.MdiParent = this; //建立父子关系
            Wavefrm.Show(); //显示子窗口
            Wavefrm.Bounds = new Rectangle(390, 0, 489, 342);
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void timer1_Tick(object sender, EventArgs e)
        {
           // ComPortClass Serialport = new ComPortClass(PortName, BaudRate, HandShake, parity, DataBits, StopBits);
            Serialport.OpenComPort();
            try
            {  
                ServingCellInfo = Serialport.AT_Serving();
                NeighborCellInfo = Serialport.AT_Neighbor();                
                                
                result = FileOperate.DataPull(ServingCellInfo);
                result1 = FileOperate.DataPull(NeighborCellInfo);

                Servingfrm.Serving_Assignment(result);
                Neighborfrm.Neighbor_Assignment(result1);
                Wavefrm.dBm_Assignment(result, result1);
                Wavefrm.TimerStart();
               
                //数据备份
                resultBackup = result;
                result1Backup = result1;
            }

            catch
            {
            }
            //SerialPort.CloseCom();
            }

        public void toolStripButton1_Click(object sender, EventArgs e)
        {
            //串口设置
                Form1 frm1 = new Form1();               
                toolStripStatusLabel1.Text = "";

                if (frm1.ShowDialog() == DialogResult.OK && frm1.portName != "")
                {
                    ComPortClass.Port_Assignment(frm1.portName, frm1.baudRate, frm1.handShake, frm1.parity, frm1.dataBits, frm1.stopBits);

                    toolStripStatusLabel1.Text = "Port Name:" + frm1.portName + " Baud Rate:" + Convert.ToString(frm1.baudRate) + " Handshake:" + frm1.handShake + " Parity:" + frm1.parity + " Data Bits:" + Convert.ToString(frm1.dataBits) + " Stop Bits:" + frm1.stopBits;

                }

                else if (frm1.portName == "")
                {
                    toolStripStatusLabel1.Text = "No COM Port Found!";

                }
                else
                {
                    MessageBox.Show("用户取消了操作", "提示信息");
                    return;
                }
                
                flg = true;
            }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Start

         if (flg)
            {
                //采样刷新
                timer1.Interval = 1000;
                timer1.Enabled = true;                          
            }
            else
            {
                MessageBox.Show("请先进行串口串口设置", "提示信息");
                return;
            }
        }

        //-------------------------------------------------------------------------------------------------

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Dial
            timer1.Enabled = false;
          //  ComPortClass SerialPort = new ComPortClass(PortName, BaudRate, HandShake, parity, DataBits, StopBits);
            Dialcontent = Serialport.Dial(15921965826,false);
            Form2 frm2 = new Form2(Dialcontent);
         
            frm2.Show();
            
            Serialport.CloseCom();
            timer1.Enabled = true;
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //End call
        //    ComPortClass SerialPort = new ComPortClass(PortName, BaudRate, HandShake, parity, DataBits, StopBits);
            Serialport.Dial(15921965826, true);
            Serialport.CloseCom();            
        }

        

        /// <summary>
        /// ///////////////////////////////////////////  判断之后打开   ///////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void servingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Serving zone
            if (Servingfrm == null || Servingfrm.IsDisposed)
            {
                Servingfrm = new Form3();
            }
            Servingfrm.MdiParent = this; //建立父子关系
            Servingfrm.Show(); //显示子窗口
            Servingfrm.Bounds = new Rectangle(0, 0, 387, 342);
        }

        private void neighborToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Neignbor zone
            if (Neighborfrm == null || Neighborfrm.IsDisposed)
            {
                Neighborfrm = new Form4();
            }
            Neighborfrm.MdiParent = this; //建立父子关系
            Neighborfrm.Show(); //显示子窗口
            Neighborfrm.Bounds = new Rectangle(0, 343, 547, 176);            
        }

        private void waveFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //WaveForm            
            if (Wavefrm == null || Wavefrm.IsDisposed)
            {
                Wavefrm = new Form6();
            }
            Wavefrm.MdiParent = this; //建立父子关系
            Wavefrm.Show(); //显示子窗口
            Wavefrm.Bounds = new Rectangle(390, 0, 489, 342);
        }

        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //层叠窗口
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //水平平铺
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //垂直平铺
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void portToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Port Configuration

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Waveform Configuration


        }       

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close all Form
            Form[] frmList = this.MdiChildren;
            foreach (Form frm in frmList)
            {
                frm.Close();
            }
        }

     private void exportToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Export Logfile

            //获得文件路径
            //localFilePath = saveFileDialog1.FileName.ToString();
            //获取文件名，不带路径
            //fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);
            //获取文件路径，不带文件名
            //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));
     /* 
            saveFileDialog1.Title = "导出历史记录文件";
            saveFileDialog1.Filter = "历史记录文件(*.xml)|*.xml|All files(*.*)|*.*";
            //   string SavePath = saveFileDialog1.FileName;
            saveFileDialog1.InitialDirectory = @"c:\";
            saveFileDialog1.ShowDialog();

            string FileNamePath = saveFileDialog1.FileName.ToString();
            string FilePath = FileNamePath.Substring(FileNamePath.LastIndexOf("\\") + 1);

            recorder.infoRecorder.setSignalFilePath(FilePath);

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
       */  
        }

      }      
    }
