using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibreHardwareMonitor.Hardware;
using LibreHardwareMonitor.Hardware.Cpu;
using CpuReader.Extensions;
using System.Windows.Media;
using CpuReader.Helpers;
using System.Diagnostics.CodeAnalysis;

using CpuReader.UserControls;

namespace CpuReader
{
    public partial class MainWindow : Window
    {
        private  Computer _computer;
    
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
                IsMotherboardEnabled = true,
                IsControllerEnabled = true,
                IsStorageEnabled = true,
                IsNetworkEnabled = true,
                IsBatteryEnabled = true,
                IsPsuEnabled = true,
            };
            _computer.Open();
        }

        private void btnMotherBoard_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainContent.Content = new MotherBoardControl(_computer);
        }

        private void btnCpu_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainContent.Content = new CpuControl(_computer);
        }

        private void btnGpu_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainContent.Content = new GpuControl(_computer);
        }
    }
}
