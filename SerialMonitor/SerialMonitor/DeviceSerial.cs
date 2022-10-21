using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SerialMonitor
{
 
    internal class DeviceSerial : UserControl
    {

        SerialPort serialPort = new SerialPort();
        public DeviceSerial()
        {
            //values = new ChartValues<double>();
            /*
            SeriesCollection = new SeriesCollection//livechart
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = values
                    //Values = new ChartValues<double> {1, 2, 3, 4, 5}

                }//livechar data값(막대~)
                
            };*/
            
            //values.Add(0);
            /*lineSeries = new LineSeries
            {
                
            };*/

            //values = new ChartValues<double>{RecevieData};
        }
        /*
         *Nuget 패키지 설치 LiveCharts.Wpf.
         * MainWindow.xaml파일에
         * xmlns:lvc="clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf" 추가
         * <lvc:CartesianChart Series="{Binding SeriesCollection}"> 추가
         */
        
        public string receiveData = "";

        public string RecevieData { get; set; }


        public bool Connect(int portName, int baudRate = (int)9600, int DataBits = (int)8, Parity parity=Parity.None, StopBits stopBits=StopBits.One)
        {

            if (serialPort.IsOpen == false)
            {
                serialPort.PortName = "COM" + portName.ToString();
                serialPort.BaudRate = baudRate;
                serialPort.Parity = parity;
                serialPort.StopBits = stopBits;
                serialPort.DataBits = DataBits;

                serialPort.Open();
                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceiveHandler);
            }
            return true;
        }
 
        public bool sendData(string str)
        {
            if(serialPort.IsOpen==true){
                serialPort.Write(str); 
            }
            else
            {
                this.Connect(5);
            }
            

            return true;
        }

        private void DataReceiveHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = (SerialPort)sender;
            RecevieData = serialPort.ReadLine();
            //receiveData = serialPort.ReadExisting();
        }

        public bool Close()
        {
            serialPort.Close();
            return true;
        }
    }
}
