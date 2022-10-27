using CommunityToolkit;
using CommunityToolkit.Mvvm.ComponentModel;
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
using System.Threading;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace SerialMonitor
{

    internal class DeviceSerial : IDeviceSerial
    {

        SerialPort serialPort = new SerialPort();
        //public ChartValues<double> Values { get; set; }
        public event EventHandler DataEvent;
        public DeviceSerial()
        {

        }


        public string receiveData = "";

        public string RecevieData { get; private set; }


        public bool Connect(int portName, int baudRate = (int)9600, int DataBits = (int)8, Parity parity = Parity.None, StopBits stopBits = StopBits.One)
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
            if (serialPort.IsOpen == true)
            {
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
            string tmp = serialPort.ReadLine();
            if (String.IsNullOrEmpty(tmp) == false)
            {
                RecevieData = tmp.Trim().ToString();
                DataEvent(this, EventArgs.Empty);
            }
        }

        public bool Close()
        {
            serialPort.Close();
            return true;
        }
    }
}
