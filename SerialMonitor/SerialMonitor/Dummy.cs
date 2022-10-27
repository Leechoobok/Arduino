using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SerialMonitor
{
    internal class Dummy : IDeviceSerial
    {
        public string RecevieData { get ; set; }
        private bool switch_cnt = false;

        public event EventHandler DataEvent;
        DispatcherTimer dispatcher = new DispatcherTimer();
        private int count;
        public Dummy()
        {
            dispatcher.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcher.Interval = new TimeSpan(0, 0, 0, 0, 50);
        }

        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            if (count == 100) switch_cnt = true;
            else if (count == 0) switch_cnt = false;
            if (switch_cnt == false) count++;
            else if(switch_cnt == true) count--;

            RecevieData = count.ToString();
            DataEvent(this, EventArgs.Empty);
        }

        public bool Close()
        {
            dispatcher.Stop();
            return true;
        }

        public bool Connect(int portName, int baudRate = 9600, int DataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One)
        {
            dispatcher.Start();
            return true;
        }

        public bool sendData(string str)
        {
            return true;
        }
    }
}
