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

namespace CpuReader
{
    public partial class MainWindow : Window
    {
        private BackgroundWorker cpuMonitoringWorker;
        private readonly IHardWareService _hardWareService;
        private bool _gpuTabIsclicked = false;
        private bool _cpuTabIsclicked = false;
        private bool _settingsTabIsClicked = false;
        private bool _ramTabIsClicked = false;

        public MainWindow(IHardWareService hardWareService)
        {
            _hardWareService = hardWareService;
        }

        public MainWindow() : this(new HardWareService())
        {
            InitializeComponent();
            DataContext = this;

            // ui startup
            panel_settings.Visibility = Visibility.Collapsed;

            cpuMonitoringWorker = new BackgroundWorker();
            cpuMonitoringWorker.WorkerSupportsCancellation = true;
            cpuMonitoringWorker.DoWork += MonitoringWorker_DoWork;

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cpuMonitoringWorker.RunWorkerAsync();
        }
        private async void MonitoringWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!cpuMonitoringWorker.CancellationPending)
            {
              
                UIUpdater.RunCpuUI(_hardWareService, txtCpuName, txtCpuTempPgb,pbCpuTemp, txtCpuMinTemperature, txtCpuMaxTemperature, txtClocks, txtLoads,txtWatts, rdbFahrenheit);
                await Task.Delay(1000);
            }
        }

      
        private void txtCpuTab_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            panel_cpu.Visibility = Visibility.Visible;
            panel_settings.Visibility = Visibility.Collapsed;
            _cpuTabIsclicked = true;
            _gpuTabIsclicked = false;
            _settingsTabIsClicked = false;
            _ramTabIsClicked = false;
        }

        private void txtSettings_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            panel_cpu.Visibility = Visibility.Collapsed;
            panel_settings.Visibility = Visibility.Visible;
            _settingsTabIsClicked = true;
            _cpuTabIsclicked = false;
             _gpuTabIsclicked  = false;
            _ramTabIsClicked = false;
        }

        private void txtGpuTab_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            panel_cpu.Visibility = Visibility.Collapsed;
            panel_settings.Visibility = Visibility.Collapsed;
            _gpuTabIsclicked = true;
            _cpuTabIsclicked = false;
            _settingsTabIsClicked = true;
            _ramTabIsClicked = false;
        }

        private void txtRamTab_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            panel_cpu.Visibility = Visibility.Collapsed;
            panel_settings.Visibility = Visibility.Collapsed;
            _ramTabIsClicked = true;
            _gpuTabIsclicked = false;
            _cpuTabIsclicked = false;
            _settingsTabIsClicked = false;
        }
        #region settings
        // settings combobox
     
        private void rdbFahrenheit_Checked(object sender, RoutedEventArgs e)
        {
            pbCpuTemp.Maximum = MathHelper.ToFahrenheit(110);
        }
        private void rdbCelsius_Checked(object sender, RoutedEventArgs e)
        {
            pbCpuTemp.Maximum = 110;
        }
        #endregion


    }
}
