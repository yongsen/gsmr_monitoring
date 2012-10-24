using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

/// <summary>
/// record the info about signal and neighbor
/// signalDetail & neighborDetail are public elements
/// </summary>
/// 

namespace recorder
{
    public class infoRecorder
    {

        private static string signalFilePath = @"C:\signal.xml";
        private static XmlDocument signalXmlFile = new XmlDocument();
        private static XmlNode signalFatherNode;
        private static bool ifSignalNeedInitial = true;
        public static string[] signalDetail = { "chann", "rs", "dBm", "MCC", "MNC", "LAC", "cell", "NCC", "BCC", "PWR", "RXLev", "C1" };
        private static string signalXmlPath = @"signalInfo/rawData";

        private static string neighborFilePath = @"C:\neighbor.xml";              
        private static XmlDocument neighborXmlFile = new XmlDocument();
        private static XmlNode neighborFatherNode;        
        private static bool ifNeighborNeedInitial = true;        
        public static string[] neighborDetail = { "chann", "rs", "dBm", "MCC", "MNC", "BCC", "C1", "C2" };
        private static string neighborXmlPath = @"neighborInfo/rawData";

        

        /// <summary>
        /// read signal XmlFile from the beginning
        /// </summary>
        public static void resetSignalReader()
        {
            ifSignalNeedInitial = true;
        }

        /// <summary>
        /// read neighbor XmlFile from the beginning
        /// </summary>
        public static void resetNeighborReader()
        {
            ifNeighborNeedInitial = true;
        }

        /// <summary>
        /// set the signal recording file path
        /// </summary>
        /// <param name="newPath">new path of the XML file</param>
        public static void setSignalFilePath(string newPath)
        {
            signalFilePath = newPath;
        }

        /// <summary>
        /// set the neighbor recording file path
        /// </summary>
        /// <param name="newPath">new path of the XML file</param>
        public static void setNeighborFilePath(string newPath)
        {
            neighborFilePath = newPath;
        }



        /// <summary>
        /// get NextXmlData about Signal from localdisk
        /// </summary>
        /// <param name="result">raw data </param>
        /// <param name="id">record time refers to data</param>
        /// <returns>0 for success,1 for fail(that is:no more data)</returns>
        public static int getNextSignalData(out string[] result, out string id)
        {
            int arrayLength = signalDetail.GetLength(0);
            result = new string[arrayLength];
            id = "";
            signalXmlFile.Load(signalFilePath);


            if (ifSignalNeedInitial)
            {
                signalFatherNode = signalXmlFile.SelectSingleNode(signalXmlPath); //"signalInfo/rawData[last()]"
                ifSignalNeedInitial = false;
            }
            else
            {
                if (signalFatherNode.NextSibling == null) return 1;
                signalFatherNode = signalFatherNode.NextSibling;

            }


            id = signalFatherNode.Attributes.GetNamedItem("ID").Value;
            XmlNodeList nodeDetail = signalFatherNode.ChildNodes;
            int i = 0;
            foreach (XmlNode node in nodeDetail)
            {
                result[i] = node.InnerText;
                ++i;
            }

            return 0;

        }


        /// <summary>
        /// get NextXmlData about Neighbor from localdisk
        /// </summary>
        /// <param name="result[,]">raw data </param>
        /// <param name="id">record time refers to data</param>
        /// <returns>0 for success,1 for fail(that is:no more data)</returns>
        public static int getNextNeighborData(out string[,] result, out string id)
        {
            result = new string[6,neighborDetail.GetLength(0)];
            id = "";
            neighborXmlFile.Load(neighborFilePath);


            if (ifNeighborNeedInitial)
            {
                neighborFatherNode = neighborXmlFile.SelectSingleNode(neighborXmlPath);
                ifNeighborNeedInitial = false;
                //Console.WriteLine(neighborFatherNode.InnerText);
            }
            else
            {
                if (neighborFatherNode.NextSibling == null) return 1;
                neighborFatherNode = neighborFatherNode.NextSibling;

            }


            id = neighborFatherNode.Attributes.GetNamedItem("ID").Value;
            XmlNodeList nodeNeighbors = neighborFatherNode.ChildNodes;
            int i = 0,j=0;
            foreach (XmlNode neighbor in nodeNeighbors)
            {
                XmlNodeList nodeDetail = neighbor.ChildNodes;
                j = 0;
                foreach (XmlNode node in nodeDetail)
                {
                    result[i,j] = node.InnerText;
                    ++j;
                }
                ++i;
            }

            return 0;

        }


        /// <summary>
        /// write signal info to XML file
        /// </summary>
        /// <param name="info">the signal info to write</param>
        /// <returns>0-success,1-fail</returns>
        public static int writeSignalToXml(string[] info)
        {        
            string no_ID = Convert.ToString(DateTime.Now);
            try
            {
                if (!File.Exists(signalFilePath))  //创建文件
                {
                    XmlTextWriter writer = new XmlTextWriter(signalFilePath, null);
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartElement("signalInfo");
                    writer.WriteStartElement("fileInfo");
                    writer.WriteStartElement("creatTime");
                    writer.WriteCData(Convert.ToString(DateTime.Now));
                    writer.WriteEndElement();
                    writer.WriteStartElement("lastModify");
                    writer.WriteCData(Convert.ToString(DateTime.Now));
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteFullEndElement();
                    writer.Close();
                }
                //Modify
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(signalFilePath);
                int i;
                string[] dataName = { "chann", "rs", "dBm", "MCC", "MNC", "LAC", "cell", "NCC", "BCC", "PWR", "RXLev", "C1" };

                //记录修改时间
                XmlNode time = xmlDoc.SelectSingleNode("signalInfo/fileInfo/lastModify");
                time.InnerText = @"<![CDATA[ " + Convert.ToString(DateTime.Now) + " ]]>";  //用CData，防止空格干扰

                //追加记录
                XmlNode root = xmlDoc.SelectSingleNode("signalInfo");
                XmlElement newEle = xmlDoc.CreateElement("rawData"); ;//xmlNode为抽象类，不能实例化，而xmlElement则是从它抽象而来

                newEle.SetAttribute("ID", Convert.ToString(no_ID));
                for (i = 0; i <= signalDetail.GetLength(0); i++) 
                {
                    XmlElement newInfo = xmlDoc.CreateElement(dataName[i]);
                    newInfo.InnerText = info[i];
                    newEle.AppendChild(newInfo);
                    root.AppendChild(newEle);
                }
                xmlDoc.Save(signalFilePath); 

                return 0;

            }
            catch (Exception)
            {
                return 1;
            }



        }

        /// <summary>
        /// write neighbor info to XML file
        /// </summary>
        /// <param name="info">the neighbor info to write</param>
        /// <returns>0-success,1-fail</returns>
        public static int writeNeighborToXml(string[,] info)
        {
            string no_ID = Convert.ToString(DateTime.Now);
            try
            {
                if (!File.Exists(neighborFilePath))  //创建文件
                {
                    XmlTextWriter writer = new XmlTextWriter(neighborFilePath, null);
                    writer.Formatting = Formatting.Indented;

                    writer.WriteStartElement("neighborInfo");
                    writer.WriteStartElement("fileInfo");
                    writer.WriteStartElement("creatTime");
                    writer.WriteCData(Convert.ToString(DateTime.Now));
                    writer.WriteEndElement();
                    writer.WriteStartElement("lastModify");
                    writer.WriteCData(Convert.ToString(DateTime.Now));
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteFullEndElement();
                    writer.Close();

                }


                //Modify
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(neighborFilePath);
                int i, j;
                string[] dataName = { "chann", "rs", "dBm", "MCC", "MNC", "BCC", "C1", "C2" };
                //记录修改时间
                XmlNode time = xmlDoc.SelectSingleNode("neighborInfo/fileInfo/lastModify");
                time.InnerText = "\r\n<![CDATA[ " + Convert.ToString(DateTime.Now) + " ]]>\r\n";  //用CData，防止空格干扰

                //追加记录
                XmlNode root = xmlDoc.SelectSingleNode("neighborInfo");
                XmlElement newEle = xmlDoc.CreateElement("rawData"); ;//xmlNode为抽象类，不能实例化，而xmlElement则是从它抽象而来
                newEle.SetAttribute("ID", Convert.ToString(no_ID));//Convert.ToString(no_ID));
                for (j = 0; j <= 5; j++)  //六个邻小区
                {
                    XmlElement neighborInfo = xmlDoc.CreateElement("neighbor" + Convert.ToString(j));
                    for (i = 0; i <= neighborDetail.GetLength(0)-1; i++)  
                    {
                        XmlElement newInfo = xmlDoc.CreateElement(dataName[i]);
                        newInfo.InnerText = info[j, i];
                        neighborInfo.AppendChild(newInfo);
                    }
                    newEle.AppendChild(neighborInfo);
                }
                root.AppendChild(newEle);
                xmlDoc.Save(neighborFilePath);


                return 0;

            }
            catch (Exception)
            {
                return 1;
            }


        }

    }
}
