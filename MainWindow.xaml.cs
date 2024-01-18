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
                    pbCpuTemp.Value = HardWare.Cpu.Temperature.Current;
                    txtCpuMinTemperature.Text = $"Température minimum: {HardWare.Cpu.Temperature.Min}°";
                    txtCpuMaxTemperature.Text = $"Température maximale: {HardWare.Cpu.Temperature.Max}°";

                    txtClocks.Text = HardWare.Cpu.GetGlocksData().ToString();
                });
            
                await Task.Delay(1000); // Avoid async void deadlock
            }
        }
    }
}
