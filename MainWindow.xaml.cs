using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibreHardwareMonitor.Hardware;
using LibreHardwareMonitor.Hardware.Cpu;
using CpuReader.Models;
using CpuReader.Extensions;
using CpuReader.Service.Interfaces;
using CpuReader.Service.Classes;
using System.Windows.Media;

namespace CpuReader
{
    public partial class MainWindow : Window
    {
        private BackgroundWorker cpuMonitoringWorker;
        private readonly IHardWareService _hardWareService;

        public MainWindow(IHardWareService hardWareService)
        {
            _hardWareService = hardWareService;
        }

        public MainWindow() : this(new HardWareService())
        {
            InitializeComponent();
            DataContext = this;
           
            cpuMonitoringWorker = new BackgroundWorker();
            cpuMonitoringWorker.DoWork += CpuMonitoringWorker_DoWork;
           
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cpuMonitoringWorker.RunWorkerAsync();
        }
     

      
        private async void CpuMonitoringWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!cpuMonitoringWorker.CancellationPending)
            {

                var (HardWare, Success) = _hardWareService.CpuData();
                if(!Success)
                {
                    MessageBox.Show("An Error occured!");
                    return;
                }
                Application.Current.Dispatcher?.Invoke(() =>
                {
                    txtCpuName.Text = $"{HardWare.Cpu.Name} {HardWare.Cpu.Clocks.Skip(1).Count()}-Core";
                    var currentCpuTemperature = HardWare.Cpu.Temperature.Current;
                    if (currentCpuTemperature <= 50)
                    {
                        pbCpuTemp.Foreground = Brushes.LightGreen;
                    }
                    else if(currentCpuTemperature <= 60)
                    {
                        pbCpuTemp.Foreground = Brushes.Green;
                    }
                    else if (currentCpuTemperature <= 72)
                    {
                        pbCpuTemp.Foreground = Brushes.Orange;
                    }
                    else
                    {
                        pbCpuTemp.Foreground = Brushes.Red;
                    }
                    pbCpuTemp.Value = (double)HardWare.Cpu.Temperature.Current;
                    txtCpuMinTemperature.Text = $"Température minimum: {Math.Round((double)HardWare.Cpu.Temperature.Min,1)}°";
                    txtCpuMaxTemperature.Text = $"Température maximale: {Math.Round((double)HardWare.Cpu.Temperature.Max,1)}°";

                    txtClocks.Text = HardWare.Cpu.GetClocksFrequencyToString();

                    txtLoads.Text = HardWare.Cpu.GetLoadsToString();

                    txtWatts.Text = HardWare.Cpu.GetPowersToString();
                });
            
                await Task.Delay(1000); 
            }
        }
    }
}
