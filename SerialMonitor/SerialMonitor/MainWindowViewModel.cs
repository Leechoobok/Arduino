using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SerialMonitor
{
    public class MainWindowViewModel:ObservableObject
    {
        public string receiveData = "";
        public SeriesCollection SeriesCollection { get; set; }
        readonly IDeviceSerial deviceSerial = new Dummy();
        public string RecevieData
        {
            
            get => receiveData;
            set => SetProperty(ref receiveData, value);
        }
        public RelayCommand OpenButtonCommand { get; }
        public RelayCommand CloseButtonCommand { get; }
        public MainWindowViewModel()
        {
            deviceSerial.DataEvent += new EventHandler(DataReceived);
            OpenButtonCommand = new RelayCommand(ConnectButton);
            CloseButtonCommand = new RelayCommand(CloseButton);
            SeriesCollection = new SeriesCollection//livechart
            {
                new LineSeries
                {
                    Title = "Series 1",

                    Values = new ChartValues<double>{1 }

                }//livechar data값(막대~)
                
            };
        }
        /*
  *Nuget 패키지 설치 LiveCharts.Wpf.
  * MainWindow.xaml파일에
  * xmlns:lvc="clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf" 추가
  * <lvc:CartesianChart Series="{Binding SeriesCollection}"> 추가
  */
        private void DataReceived(object? sender, EventArgs e)
        {
            var tmp = sender as IDeviceSerial;
            RecevieData = tmp.RecevieData;
            var values = Convert.ToDouble(RecevieData);
            SeriesCollection[0].Values.Add(values);
            if (SeriesCollection[0].Values.Count > 200) SeriesCollection[0].Values.RemoveAt(0);
        }
        private void ConnectButton()
        {
            deviceSerial.Connect(5);
        }
        private void CloseButton()
        {
            deviceSerial.Close();
        }
    }
}
