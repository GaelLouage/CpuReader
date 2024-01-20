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
            gpuPpanel.Visibility = Visibility.Collapsed;
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


                // gpu data
                var (Gpu, Success)  = _hardWareService.GpuData();
                if(!Success)
                {
                    return;
                }
                HardWareSingleton.Instance.Hardware.Gpu = _hardWareService.GpuData().Gpu;
                var hardwareSingleton = HardWareSingleton.Instance.Hardware.Gpu;
                var hardwareSensors = hardwareSingleton.Sensors;
                var gpuTemperature = hardwareSensors.GetSensorByEnum(SensorType.Temperature);
                var gpuTemperatureValue = (double)gpuTemperature.Value;
           
                var gpuPower = hardwareSensors.GetSensorByName("GPU Power");
                string gpuTempAsString = $"{gpuTemperatureValue}°";
              

                var gpuLoad = hardwareSingleton.Sensors.FirstOrDefault(x => x.SensorType is SensorType.Load).Value;
            
                Application.Current.Dispatcher?.Invoke( () =>
                {
                    pbGpuTemp.Maximum = 110;
                    pbGpuTemp.Value = (double)gpuTemperatureValue;
                    txtGpuTempPgb.Text = $"{(double)gpuTemperatureValue}°";
                    if ((bool)rdbFahrenheit.IsChecked)
                    {
                        pbGpuTemp.Maximum = (pbGpuTemp.Maximum * 9 / 5) + 32;
                        gpuTemperatureValue = (float)MathHelper.ToFahrenheit(gpuTemperatureValue);
                        gpuTempAsString = $"{gpuTemperatureValue}F";
                        pbGpuTemp.Value = (double)gpuTemperatureValue;
                        txtGpuTempPgb.Text = $"{gpuTemperatureValue.ToString("0.0")}F";
                    }
                  
                    txtGpuName.Text = Gpu.Name;

                    #region GpuMemory
                    var sbGpuMermory = new StringBuilder();
                    sbGpuMermory.AppendLine($"Total {"".PadLeft(25)}{MathHelper.RoundToOneDecimal(hardwareSensors.GetSensorByName("GPU Memory Total").Value)} MB");
                    sbGpuMermory.AppendLine($"Used {"".PadLeft(25)} {hardwareSingleton.Sensors.GetSensorByName("GPU Memory Used").Value} MB");
                    sbGpuMermory.AppendLine("----------------------------------");
                    sbGpuMermory.AppendLine($"Free {"".PadLeft(25)} {hardwareSingleton.Sensors.GetSensorByName("GPU Memory Free").Value} MB");


                    txtGpuMemory.Text = sbGpuMermory.ToString();
                  
                    #endregion
                    txtGpuLoad.Text = $"Load: {gpuLoad}";
                  
                    txtGpuPower.Text = $"{MathHelper.RoundToOneDecimal(gpuPower.Value)}";
                });
                await Task.Delay(1000);
            }
        }

      
        private void txtCpuTab_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            panel_cpu.Visibility = Visibility.Visible;
            panel_settings.Visibility = Visibility.Collapsed;
            gpuPpanel.Visibility = Visibility.Collapsed;
            _cpuTabIsclicked = true;
            _gpuTabIsclicked = false;
            _settingsTabIsClicked = false;
            _ramTabIsClicked = false;
        }

        private void txtSettings_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            panel_cpu.Visibility = Visibility.Collapsed;
            gpuPpanel.Visibility = Visibility.Collapsed;
            panel_settings.Visibility = Visibility.Visible;

            _settingsTabIsClicked = true;
            _cpuTabIsclicked = false;
             _gpuTabIsclicked  = false;
            _ramTabIsClicked = false;
        }

        private void txtGpuTab_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            gpuPpanel.Visibility = Visibility.Visible;
            panel_cpu.Visibility = Visibility.Collapsed;
            panel_settings.Visibility = Visibility.Collapsed;
            _gpuTabIsclicked = true;
            _cpuTabIsclicked = false;
            _settingsTabIsClicked = true;
            _ramTabIsClicked = false;
        }

        private void txtRamTab_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            gpuPpanel.Visibility = Visibility.Collapsed;
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
