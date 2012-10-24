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
        public string PortName;
        private int BaudRate;
        private string HandShake;
        private string parity;
        private int DataBits;
        private string StopBits;
        private string Dialcontent;
     
        private bool flg = false;

        Form3 Servingfrm = new Form3();
        Form4 Neighborfrm = new Form4();
        Form6 Wavefrm = new Form6();       

        public MainForm()
        {
            InitializeComponent();

            InitializeForms();        
        }

        private void InitializeForms()
        {
            Servingfrm.MdiParent = this;
            Servingfrm.Show();
            Servingfrm.Bounds = new Rectangle(0, 0, 387, 342);

            Neighborfrm.MdiParent = this;
            Neighborfrm.Show();
            Neighborfrm.Bounds = new Rectangle(0, 343, 547, 176);

            Wavefrm.MdiParent = this;
            Wavefrm.Show();
            Wavefrm.Bounds = new Rectangle(390, 0, 489, 342);
        }

        public static bool SerTimerflag = false;
        public static bool NeiTimerflag = false;

        public static string[] result;
        public static string[] result1;

        static string[] resultBackup;
        static string[] result1Backup;

        public static string ServingCellInfo;
        public static string NeighborCellInfo;

        static string[] temp = new string[12];
        static string[,] temp2 = new string[6, 8];
        
        public void toolStripButton1_Click(object sender, EventArgs e)
        {
            //串口设置
            Form1 frm1 = new Form1();

            toolStripStatusLabel1.Text = "";

            if (frm1.ShowDialog() == DialogResult.OK && frm1.portName != "")
            {
                PortName = frm1.portName;
                BaudRate = frm1.baudRate;
                HandShake = frm1.handShake;
                parity = frm1.parity;
                DataBits = frm1.dataBits;
                StopBits = frm1.stopBits;

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

                /*
                try
                {
                    result = FO.DataPull(ServingCellInfo);
                    result1 = FO.DataPull(NeighborCellInfo);

                    Servingfrm.textBox1.Text = result[26];
                    Servingfrm.textBox2.Text = result[27];
                    Servingfrm.textBox3.Text = result[28];
                    Servingfrm.textBox4.Text = result[29];
                    Servingfrm.textBox5.Text = result[30];
                    Servingfrm.textBox6.Text = result[31];
                    Servingfrm.textBox7.Text = result[32];
                    Servingfrm.textBox8.Text = result[33];
                    Servingfrm.textBox9.Text = result[34];
                    Servingfrm.textBox10.Text = result[35];
                    Servingfrm.textBox11.Text = result[36];
                    Servingfrm.textBox12.Text = result[37];

                    //给第一行数据赋值
                    row1["Cell Num"] = "N1";
                    row1["chann"] = result1[9];
                    row1["rs"] = result1[10];
                    row1["dBm"] = result1[11];
                    row1["MCC"] = result1[12];
                    row1["MNC"] = result1[13];
                    row1["BCC"] = result1[14];
                    row1["C1"] = result1[15];
                    row1["C2"] = result1[16];

                    //给第二行数据赋值
                    row2["Cell Num"] = "N2";
                    row2["chann"] = result1[17];
                    row2["rs"] = result1[18];
                    row2["dBm"] = result1[19];
                    row2["MCC"] = result1[20];
                    row2["MNC"] = result1[21];
                    row2["BCC"] = result1[22];
                    row2["C1"] = result1[23];
                    row2["C2"] = result1[24];

                    //给第三行数据赋值
                    row3["Cell Num"] = "N3";
                    row3["chann"] = result1[25];
                    row3["rs"] = result1[26];
                    row3["dBm"] = result1[27];
                    row3["MCC"] = result1[28];
                    row3["MNC"] = result1[29];
                    row3["BCC"] = result1[30];
                    row3["C1"] = result1[31];
                    row3["C2"] = result1[32];


                    //
                    //dBm
                    //

                    Form6.dBmMain = System.Int32.Parse(result[28]);
                    Form6.dBmNeighbour1 = System.Int32.Parse(result1[11]);
                    Form6.dBmNeighbour2 = System.Int32.Parse(result1[19]);
                    Form6.dBmNeighbour3 = System.Int32.Parse(result1[27]);

                    for (int i = 0; i <= recorder.infoRecorder.signalDetail.GetLength(0)-1; i++)
                    {
                        temp[i] = result[i + 26];
                    }
                    recorder.infoRecorder.writeSignalToXml(temp);

                    for (int i = 0; i <= 2; i++)
                    {
                        for (int j = 0; j <= recorder.infoRecorder.neighborDetail.GetLength(0)-1; j++)
                        {
                            temp2[i, j] = Convert.ToString(result1[j + 9 + i * 8]);
                            temp2[i + 3, j] = Convert.ToString(result1[j + 9 + i * 8]);

                        }
                    }

                    recorder.infoRecorder.writeNeighborToXml(temp2);
                
                }
                catch( Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }  
                 */
            }
            else
            {
                MessageBox.Show("请先进行串口串口设置", "提示信息");
                return;
            }
        }

        public void timer1_Tick(object sender, EventArgs e)
        {            
            ComPortClass Serialport = new ComPortClass(PortName, BaudRate, HandShake, parity, DataBits, StopBits);
            //Serialport.OpenComPort();
            try
            {              
                ServingCellInfo = Serialport.AT_Serving();
                NeighborCellInfo = Serialport.AT_Neighbor();

                //数据备份
                resultBackup = result;
                result1Backup = result1;

                SerTimerflag = true;
                NeiTimerflag = true;              
            }

            catch
            {
              
            }
            Serialport.CloseCom();
        }        

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Dial
            timer1.Enabled = false;
            ComPortClass Serialport = new ComPortClass(PortName, BaudRate, HandShake, parity, DataBits, StopBits);
            Dialcontent = Serialport.Dial(15921965826,false);
            Form2 frm2 = new Form2(Dialcontent);
         
            frm2.Show();
            
            Serialport.CloseCom();
            timer1.Enabled = true;
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //End call
            ComPortClass Serialport = new ComPortClass(PortName, BaudRate, HandShake, parity, DataBits, StopBits);
            Serialport.Dial(15921965826, true);
            Serialport.CloseCom();
            
        }

        private void servingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Serving zone

            if (Servingfrm== null || Servingfrm.IsDisposed)
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

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close all Form
            Form[] frmList = this.MdiChildren;
            foreach (Form frm in frmList)
            {
                frm.Dispose();
                frm.Close();
            }
        }          
        }      
    }
