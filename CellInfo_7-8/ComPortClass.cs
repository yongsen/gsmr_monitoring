using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace CellInfo
{
    public class ComPortClass
    {
        public SerialPort sp = new SerialPort ( );

        //构造函数，初始化建串口类实例
        public ComPortClass ( string PortName , int PortNum )
        {
            sp = new SerialPort ( PortName , PortNum , Parity.None , 8 );
            sp.ReceivedBytesThreshold = 16;
            sp.Handshake = Handshake.RequestToSend;
            sp.Parity = Parity.None;
            sp.ReadTimeout = 800;
            sp.WriteTimeout = 800;
            //sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived); 
            //sp.ErrorReceived += new SerialErrorReceivedEventHandler(sp_ErrorReceived); 
            sp.Open ( );
        }

        //------------------------串口操作部分开始------------------------- 

        //当前小区信息AT命令
        public string AT_Serving()
        {
            try
            {
                sp.Write("AT^MONI\r");
                Thread.Sleep(100);
                byte[] buffer = new byte[sp.BytesToRead];
                sp.Read(buffer, 0, buffer.Length);
                return System.Text.Encoding.ASCII.GetString(buffer);
            }
            catch
            {
                return "发送失败！";
            }
        }

        //邻居小区信息AT命令
        public string AT_Neighbor()
        {
            try
            {
                sp.Write("AT^MONP\r");
                Thread.Sleep(100);
                byte[] buffer = new byte[sp.BytesToRead];
                sp.Read(buffer, 0, buffer.Length);
                return System.Text.Encoding.ASCII.GetString(buffer);
            }
            catch
            {
                return "发送失败！";
            }
        }       

        //小区监控_1AT命令
        public string AT_CellMonitor_1()
        {
            try
            {
                sp.Write("AT^SMONC\r");
                Thread.Sleep(100);
                byte[] buffer = new byte[sp.BytesToRead];
                sp.Read(buffer, 0, buffer.Length);
                return System.Text.Encoding.ASCII.GetString(buffer);
            }
            catch
            {
                return "发送失败！";
            }
        }

        //小区监控_2AT命令
        public string AT_CellMonitor_2()
        {
            try
            {
                sp.Write("AT^SMNOD\r");
                Thread.Sleep(100);
                byte[] buffer = new byte[sp.BytesToRead];
                sp.Read(buffer, 0, buffer.Length);
                return System.Text.Encoding.ASCII.GetString(buffer);
            }
            catch
            {
                return "发送失败！";
            }
        }

        //关闭串口 
        public void CloseCom ( )
        {
            sp.Dispose ( );
            sp.Close ( );
        }

        //------------------------串口操作部分结束------------------------- 

        //--------------------------事件部分开始-------------------- 

        //接收事件
        private void sp_DataReceived ( Object sender , SerialDataReceivedEventArgs e ) 
        {
            System.Windows.Forms.MessageBox.Show ( sp.ReadExisting ( ) );
        }

        //错误事件 
        private void sp_ErrorReceived ( Object sender , SerialErrorReceivedEventArgs e )
        {
        }
        //--------------------------事件部分结束-------------------- 

    }
}