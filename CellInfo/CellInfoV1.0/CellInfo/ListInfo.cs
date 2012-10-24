using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace CellInfo
{
    public partial class ListInfo : Form
    {
        bool flag = false;//加载图形之前要先打开文件，flag变为true
        public ListInfo()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            zGraph1.m_fXBeginSYS = 0;
            zGraph1.m_fXEndSYS = 120;
            zGraph1.m_fYBeginSYS = -120;
            zGraph1.m_fYEndSYS = 0;
            zGraph1.m_SySnameX = "时间/s";
            zGraph1.m_SySnameY = "信号强度/dBm";
            zGraph1.m_SyStitle = "历史信息";
        }
        //选择文件按钮

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        
        //选择文件
        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
            flag = true;
            textBox1.Text = openFileDialog1.FileName;
        }
        //默认图形，显示当前小区和三个邻居小区的信号dBm
        private void button2_Click_1(object sender, EventArgs e)
        {
            label1.Text = "红-当前小区 黄-邻居小区1 蓝-邻居小区2 绿-邻居小区3";
            if (flag)
            {
                List<float> x1 = new List<float>();
                List<float> y1 = new List<float>();//当前小区
                List<float> y2 = new List<float>();//
                List<float> y3 = new List<float>();//邻居小区
                List<float> y4 = new List<float>();//                        
                int t = 0;

                ///<summary>
                ///清除原有数据
                ///</summary>
                x1.Clear();
                y1.Clear();
                y2.Clear();
                y3.Clear();
                y4.Clear();


                zGraph1.f_ClearAllPix();
                zGraph1.f_reXY();
                //加载图形
                zGraph1.f_LoadOnePix(ref x1, ref y1, Color.Red, 1);

                //添加图形
                zGraph1.f_AddPix(ref x1, ref y2, Color.Yellow, 1);
                zGraph1.f_AddPix(ref x1, ref y3, Color.Blue, 1);
                zGraph1.f_AddPix(ref x1, ref y4, Color.Green, 1);


                XmlDocument xml = new XmlDocument();
                xml.Load(openFileDialog1.FileName);
                XmlNodeList list = xml.SelectNodes("//rawData/neighbor0/dBm");
                foreach (XmlNode nod in list)
                {
                    x1.Add(t);
                    y1.Add(System.Int32.Parse(nod.InnerText));
                    ++t;
                }

                list = xml.SelectNodes("//rawData/neighbor1/dBm");
                foreach (XmlNode nod in list)
                {
                    y2.Add(System.Int32.Parse(nod.InnerText));

                }

                list = xml.SelectNodes("//rawData/neighbor2/dBm");
                foreach (XmlNode nod in list)
                {
                    y3.Add(System.Int32.Parse(nod.InnerText));

                }

                list = xml.SelectNodes("//rawData/neighbor3/dBm");
                foreach (XmlNode nod in list)
                {
                    y4.Add(System.Int32.Parse(nod.InnerText));
                }

                zGraph1.f_Refresh();
            }

            else MessageBox.Show("请先选择文件！");
        }
        //当前小区
        private void button3_Click_1(object sender, EventArgs e)
        {
            drawSet("当前小区", Color.Red, "//rawData/neighbor0/dBm");
        }

        //邻居小区1
        private void button4_Click_1(object sender, EventArgs e)
        {
            drawSet("邻居小区1", Color.Yellow, "//rawData/neighbor1/dBm");
        }
        //邻居小区2
        private void button5_Click(object sender, EventArgs e)
        {            
            drawSet("邻居小区2", Color.Blue , "//rawData/neighbor2/dBm");
        }
        //邻居小区3
        private void button6_Click_1(object sender, EventArgs e)
        {
            drawSet("邻居小区3", Color.Green, "//rawData/neighbor3/dBm");
        }
        //邻居小区4
        private void button7_Click_1(object sender, EventArgs e)
        {
            drawSet("邻居小区4", Color.Purple, "//rawData/neighbor4/dBm");
        }
        //邻居小区5
        private void button8_Click(object sender, EventArgs e)
        {
            drawSet("邻居小区5", Color.Pink, "//rawData/neighbor5/dBm");
        }
        //画图
        void drawSet(string text,Color color,string path)
        {
            label1.Text = text;
            if (flag)
            {
                List<float> x1 = new List<float>();
                List<float> y1 = new List<float>();
                int t = 0;

                ///<summary>
                ///清除原有数据
                ///</summary>
                x1.Clear();
                y1.Clear();

                zGraph1.f_ClearAllPix();
                zGraph1.f_reXY();
                //加载图形
                zGraph1.f_LoadOnePix(ref x1, ref y1, color, 1);


                XmlDocument xml = new XmlDocument();
                xml.Load(openFileDialog1.FileName);
                XmlNodeList list = xml.SelectNodes(path);
                foreach (XmlNode nod in list)
                {
                    x1.Add(t);
                    y1.Add(System.Int32.Parse(nod.InnerText));
                    ++t;
                }

                zGraph1.f_Refresh();
            }

            else MessageBox.Show("请先选择文件！");
 
        } 
    }
}
