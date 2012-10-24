using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace CellInfo
{
    public class ComPortClass
    {
        public SerialPort sp = new SerialPort();

        /// <summary>
        /// 串口参数配置
        /// </summary>
        /// <param name="Portname"></param> 
        /// <param name="Baudrate"></param>
        /// <param name="handshake"></param>
        /// <param name="parity"></param>
        /// <param name="Databits"></param>
        /// <param name="Stopbits"></param>
        public void Port_Assignment(string Portname, int Baudrate, string handshake, string parity, int Databits, string Stopbits)
        {
            sp.PortName = Portname;
            sp.BaudRate = Baudrate;

            switch (handshake)
            {
                case "None":
                    sp.Handshake = Handshake.None;
                    break;
                case "XonXoff":
                    sp.Handshake = Handshake.XOnXOff;
                    break;
                case "RequestToSend":
                    sp.Handshake = Handshake.RequestToSend;
                    break;
                case "RequestToSendXonXoff":
                    sp.Handshake = Handshake.RequestToSendXOnXOff;
                    break;
                default:
                    MessageBox.Show("Handshake尚未输入", "提示信息");
                    break;
            }

            switch (parity)
            {
                case "None":
                    sp.Parity = Parity.None;
                    break;
                case "Odd":
                    sp.Parity = Parity.Odd;
                    break;
                case "Even":
                    sp.Parity = Parity.Even;
                    break;
                case "Mark":
                    sp.Parity = Parity.Mark;
                    break;
                case "Space":
                    sp.Parity = Parity.Space;
                    break;
                default:
                    MessageBox.Show("Parity尚未输入", "提示信息");
                    break;
            }

            switch (Stopbits)
            {
                case "One":
                    sp.StopBits = StopBits.One;
                    break;
                case "Two":
                    sp.StopBits = StopBits.Two;
                    break;
                case "OnePointFive":
                    sp.StopBits = StopBits.OnePointFive;
                    break;
                default:
                    MessageBox.Show("Stop Bits尚未输入", "提示信息");
                    break;
            }

            sp.DataBits = Databits;
            sp.ReceivedBytesThreshold = 16;
        }

        //------------------------串口操作部分开始------------------------- 
                

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns></returns>
        internal bool OpenComPort()
        {
            bool success = false;
            
            if ((!(sp.IsOpen)))
            {
                sp.Open();
                if (sp.IsOpen)
                {
                    sp.ReadTimeout = 5000;
                    sp.WriteTimeout = 5000;

                    //  Specify the routines that run when a DataReceived or ErrorReceived event occurs.
                    
                    //  Send data to other modules.
                    success = true;
                    //  The port is open with the current parameters.
                }
            }
            return success;
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <param name="portToClose"></param>
        internal void CloseComPort(SerialPort portToClose)
        {
            object transTemp0 = portToClose;
            if (!(transTemp0 == null))
            {
                if (portToClose.IsOpen)
                {
                    portToClose.Close();
                }
            }
        }

        /// <summary>
        /// Provide a central mechanism for displaying exception information.
        /// Display a message that describes the exception.
        /// </summary>
        /// 
        /// <param name="ex"> The exception </param> 
        /// <param name="moduleName" > the module where the exception was raised. </param>
        private void DisplayException(string moduleName, Exception ex)
        {
            string errorMessage = null;
            errorMessage = "Exception: " + ex.Message + " Module: " + moduleName + ". Method: " + ex.TargetSite.Name;
        }

        /// <summary>
        /// Respond to error events.
        /// </summary>
        private void ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            SerialError SerialErrorReceived1 = 0;

            SerialErrorReceived1 = e.EventType;

            switch (SerialErrorReceived1)
            {
                case SerialError.Frame:
                    Console.WriteLine("Framing error.");

                    break;
                case SerialError.Overrun:
                    Console.WriteLine("Character buffer overrun.");

                    break;
                case SerialError.RXOver:
                    Console.WriteLine("Input buffer overflow.");

                    break;
                case SerialError.RXParity:
                    Console.WriteLine("Parity error.");

                    break;
                case SerialError.TXFull:
                    Console.WriteLine("Output buffer full.");
                    break;
            }
        }

        /// <summary>
        /// 接收事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceived(Object sender, SerialDataReceivedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(sp.ReadExisting());
        }

        //------------------------串口操作部分结束------------------------- 

        //--------------------------AT命令开始-------------------- 
        /// <summary>
        /// 当前小区信息AT命令
        /// </summary>
        /// <returns></returns>
        public string AT_Serving(int time)
        {
            try
            {
                sp.Write("AT^MONI\r");
                Thread.Sleep(time);
                byte[] buffer = new byte[sp.BytesToRead];
                sp.Read(buffer, 0, buffer.Length);
                return System.Text.Encoding.ASCII.GetString(buffer);
            }
            catch
            {
                return "发送失败！";
            }
        }
       
        /// <summary>
        /// 邻居小区信息AT命令
        /// </summary>
        /// <returns></returns>
        public string AT_Neighbor(int time)
        {
            try
            {
                sp.Write("AT^MONP\r");
                Thread.Sleep(time);
                byte[] buffer = new byte[sp.BytesToRead];
                sp.Read(buffer, 0, buffer.Length);
                return System.Text.Encoding.ASCII.GetString(buffer);
            }
            catch
            {
                return "发送失败！";
            }
        }

        /// <summary>
        /// 小区监控_1AT命令
        /// </summary>
        /// <returns></returns>
        public string AT_CellMonitor_1(int time)
        {
            try
            {
                sp.Write("AT^SMONC\r");
                Thread.Sleep(time);
                byte[] buffer = new byte[sp.BytesToRead];
                sp.Read(buffer, 0, buffer.Length);
                return System.Text.Encoding.ASCII.GetString(buffer);
            }
            catch
            {
                return "发送失败！";
            }
        }

        /// <summary>
        /// 小区监控_2AT命令
        /// </summary>
        /// <returns></returns>
        public string AT_CellMonitor_2(int time)
        {
            try
            {
                sp.Write("AT^SMNOD\r");
                Thread.Sleep(time);
                byte[] buffer = new byte[sp.BytesToRead];
                sp.Read(buffer, 0, buffer.Length);
                return System.Text.Encoding.ASCII.GetString(buffer);
            }
            catch
            {
                return "发送失败！";
            }
        }

        //--------------------------AT命令结束-------------------- 

    }
}
