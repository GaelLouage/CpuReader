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
using CpuReader.Helpers;
using CpuReader.Singleton;
using System.Diagnostics.CodeAnalysis;

namespace CpuReader
{
    public partial class MainWindow : Window
    {
        private BackgroundWorker _monitoringWorker;
        private readonly IHardWareService _hardWareService;

        public MainWindow(IHardWareService hardWareService)
        {
            _hardWareService = hardWareService;
        }

        public MainWindow() : this(new HardWareService())
        {
            InitializeComponent();
            DataContext = this;
            BackGroundWorker();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _monitoringWorker.RunWorkerAsync();
        }
        private async void MonitoringWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!_monitoringWorker.CancellationPending)
            {
              
                UIUpdater.RunCpuUI(_hardWareService,
                    txtCpuName,
                    txtCpuTempPgb,pbCpuTemp, 
                    txtCpuMinTemperature, 
                    txtCpuMaxTemperature, 
                    txtClocks, 
                    txtLoads,
                    txtWatts);
                // update every second
                await Task.Delay(1000);
            }
        }
        private void BackGroundWorker()
        {
            _monitoringWorker = new BackgroundWorker();
            _monitoringWorker.WorkerSupportsCancellation = true;
            _monitoringWorker.DoWork += MonitoringWorker_DoWork;
        }

    }
}
