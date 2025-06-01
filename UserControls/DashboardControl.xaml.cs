using CpuReader.Extensions;
using CpuReader.Services.Interfaces;
using LibreHardwareMonitor.Hardware;
using LibreHardwareMonitor.Hardware.Motherboard;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
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

namespace CpuReader.UserControls
{
    /// <summary>
    /// Interaction logic for DashboardControl.xaml
    /// </summary>
    public partial class DashboardControl : UserControl
    {
        private readonly IComputerService _computerService;
        private DispatcherTimer _timer;
        public DashboardControl(IComputerService computerService)
        {
            InitializeComponent();
            _computerService = computerService;
            DataContext = this;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
     
            txtMbdName.Text = _computerService.MotherBoard.Name;
            // setting groubox header names of cpu & gpu
            gbCpuName.Header = _computerService.Cpu.Name;
            gbGpuName.Header = _computerService.Gpu.Name;
            gbStorageName.Header = _computerService.Storage.Name;
            DataContext = this;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick += Gpu_Tick;
            _timer.Start();
        }

        void Gpu_Tick(object sender, EventArgs e)
        {
            _computerService.Storage.Update();
            _computerService.Cpu.Update();
            _computerService.MotherBoard.Update();
            _computerService.Gpu.Update();
            // cpu temperature

            var cpuTemperature = _computerService.Cpu.Sensors
                .FirstOrDefault(x => x.SensorType == SensorType.Temperature);

            // gpu temperature 
            var gpuTemperature = _computerService.Gpu.Sensors
              .FirstOrDefault(x => x.SensorType == SensorType.Temperature);

            // storage temperature 
            var storageTemperature = _computerService.Storage.Sensors
              .FirstOrDefault(x => x.SensorType == SensorType.Temperature);

            // placing the data of temperature  into the circular gauges
            CPUtemperatureCircularGauge.SetCircularGauge(cpuTemperature);
            GPUtemperatureCircularGauge.SetCircularGauge(gpuTemperature);
            StoragetemperatureCircularGauge.SetCircularGauge(storageTemperature);
            UpdateTextboxes(cpuTemperature, gpuTemperature, storageTemperature);
        }


        private void btnGpuDetails_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                _timer.Stop();
                mainWindow.MainContent.Content = new GpuControl(_computerService.Gpu);
            }
        }


        private void btnCpuDetails_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                _timer.Stop();
                mainWindow.MainContent.Content = new CpuControl(_computerService.Cpu);
            }
        }



        private void UpdateTextboxes(ISensor? cpuTemperature, ISensor? gpuTemperature, ISensor? storageTemperature)
        {
            // setting the values of cpu & gpu in textboxes
            txtValueTemperature.Text = $"{Math.Round(cpuTemperature.Value.Value)} {cpuTemperature.SensorType.GetUnit()}";
            txtGpuValueTemperature.Text = $"{Math.Round(gpuTemperature.Value.Value)}{gpuTemperature.SensorType.GetUnit()}";
            // set storage data in textboxes
            txtStorageMinTemperature.Text = $"{Math.Round(storageTemperature.Min.Value)}{storageTemperature.SensorType.GetUnit()}";
            txtStorageValueTemperature.Text = $"{Math.Round(storageTemperature.Value.Value)}{storageTemperature.SensorType.GetUnit()}";
            txtStorageMaxTemperature.Text = $"{Math.Round(storageTemperature.Max.Value)}{storageTemperature.SensorType.GetUnit()}";
        }
    }
}
