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
using System.Windows.Input;
using CpuReader.UserControls;
using CpuReader.Services.Interfaces;
using CpuReader.Services.Classes;

namespace CpuReader
{
    public partial class MainWindow : Window
    {
        private readonly IComputerService _computerService;

        public MainWindow(IComputerService computerService)
        {
            _computerService = computerService;
        }

        public MainWindow() : this (new ComputerService())
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new DashboardControl(_computerService);
        }
        private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainContent.Content = new DashboardControl(_computerService);
        }

        private void btnCpu_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainContent.Content = new CpuControl(_computerService.Cpu);
        }

        private void btnGpu_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainContent.Content = new GpuControl(_computerService.Gpu);
        }

        private void txtMinimizeApp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void txtCloseApp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
