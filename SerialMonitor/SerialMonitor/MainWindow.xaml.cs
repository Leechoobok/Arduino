using LiveCharts;
using LiveCharts.Definitions.Charts;
using LiveCharts.Wpf;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SerialMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChartValues<double> Values { get; set; }
        DeviceSerial arduinoSerial;
        DispatcherTimer dispatcher = new DispatcherTimer();

        public MainWindow()
        {

            InitializeComponent();
            arduinoSerial = new DeviceSerial();

            dispatcher.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcher.Interval = new TimeSpan(0, 0, 0, 0, 50);

            DataContext = this;

            Values = new ChartValues<double>();

        }

        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
       
            textbox1.Text = arduinoSerial.RecevieData;
            string a = arduinoSerial.RecevieData;
            a.Trim();
            if (a != null)
            {
                double s = double.Parse(a);
                Values.Add(s);
                if (Values.Count > 200) Values.RemoveAt(0);
            }
 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            arduinoSerial.Connect(5);
            dispatcher.Start();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            arduinoSerial.Close();
            dispatcher.Stop();
        }
        private void LED_Check_Click(object sender, RoutedEventArgs e)
        {
            if (LED_Check.IsChecked == false)
            {
                arduinoSerial.sendData("0");
            }
            else
            {
                arduinoSerial.sendData("1");
            }
        }
    }
}
