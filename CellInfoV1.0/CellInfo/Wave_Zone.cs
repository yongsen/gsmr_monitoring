using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CellInfo
{
    public partial class Wave_Zone : Form
    {
        #region 变量定义
        public List<float> x1 = new List<float>();
        public List<float> y1 = new List<float>();
        public List<float> x2 = new List<float>();
        public List<float> y2 = new List<float>();
        public List<float> x3 = new List<float>();
        public List<float> y3 = new List<float>();
        public List<float> x4 = new List<float>();
        public List<float> y4 = new List<float>();

        int timerDrawI = 0;//波形图上表示横轴变量t
        public int dBmMain;
        public int dBmNeighbour1;
        public int dBmNeighbour2;
        public int dBmNeighbour3;
        public int dBmNeighbour4;
        public int dBmNeighbour5;
        public int dBmNeighbour6;

        #endregion

        public Wave_Zone()
        {
            InitializeComponent();
            InitializeForm();
        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        private void InitializeForm()
        {
            x1.Clear();
            y1.Clear();
            x2.Clear();
            y2.Clear();
            x3.Clear();
            y3.Clear();
            x4.Clear();
            y4.Clear();

            zGraph1.f_ClearAllPix();
            zGraph1.f_reXY();
            zGraph1.f_LoadOnePix(ref x1, ref y1, Color.Red, 2);
            zGraph1.f_AddPix(ref x2, ref y2, Color.Yellow, 2);
            zGraph1.f_AddPix(ref x3, ref y3, Color.Blue, 2);
            zGraph1.f_AddPix(ref x4, ref y4, Color.Green, 2);

            zGraph1.m_fXBeginSYS = 0;
            zGraph1.m_fXEndSYS = 120;
            zGraph1.m_fYBeginSYS = -120;
            zGraph1.m_fYEndSYS = 0;
            zGraph1.m_SySnameX = "时间/s";
            zGraph1.m_SySnameY = "信号强度/dBm";

            timer1.Interval = 300;
            timer1.Enabled = false;
        }

        /// <summary>
        /// 重新绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 刷新_Click(object sender, EventArgs e)
        {
            x1.Clear();
            y1.Clear();
            x2.Clear();
            y2.Clear();
            x3.Clear();
            y3.Clear();
            x4.Clear();
            y4.Clear();

            zGraph1.f_ClearAllPix();
            zGraph1.f_reXY();
            zGraph1.f_LoadOnePix(ref x1, ref y1, Color.Red, 2);
            zGraph1.f_AddPix(ref x2, ref y2, Color.Yellow, 2);
            zGraph1.f_AddPix(ref x3, ref y3, Color.Blue, 2);
            zGraph1.f_AddPix(ref x4, ref y4, Color.Green, 2);
            timerDrawI = 0;
            timer1.Start();
        }

        /// <summary>
        /// 曲线绘制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            zGraph1.f_Refresh();

            x1.Add(timerDrawI);
            y1.Add(dBmMain);
            x2.Add(timerDrawI);
            y2.Add(dBmNeighbour1);
            x3.Add(timerDrawI);
            y3.Add(dBmNeighbour2);
            x4.Add(timerDrawI);
            y4.Add(dBmNeighbour3);
            timerDrawI = timerDrawI + 1;
        }

        /// <summary>
        /// 描点定时器启动
        /// </summary>
        public void TimerStart()
        {
            timer1.Interval = 300;
            timer1.Start();
        }
    }
}
