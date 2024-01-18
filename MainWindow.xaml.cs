using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LibreHardwareMonitor.Hardware;
using LibreHardwareMonitor.Hardware.Cpu;
using CpuReader.Models;

namespace CpuReader
{
    public partial class MainWindow : Window
    {
        private Cpu _cpu = new Cpu();
        private BackgroundWorker cpuMonitoringWorker;
        private readonly Computer computer;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
           
            cpuMonitoringWorker = new BackgroundWorker();
            cpuMonitoringWorker.DoWork += CpuMonitoringWorker_DoWork;
            // Subscribe to the Window Closed event to ensure proper cleanup
        
            computer = new Computer() { IsCpuEnabled = true, IsGpuEnabled = true };
            computer.Open();
            Closed += MainWindow_Closed;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            cpuMonitoringWorker.RunWorkerAsync();
        }
     

        private  void MainWindow_Closed(object sender, EventArgs e)
        {
            cpuMonitoringWorker.CancelAsync();
        }
        private async void CpuMonitoringWorker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            var sb = new StringBuilder();
            while (!cpuMonitoringWorker.CancellationPending)
            {
              
                try
                {
                    foreach (IHardware hardware in computer.Hardware)
                    {
                        hardware.Update();

                        if (hardware.HardwareType == HardwareType.Cpu)
                        {
                            var firstCore = hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Temperature);
                            var clockSpeed = hardware.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Clock).Value;
                            var platform = hardware.Identifier;
                            _cpu.Name = hardware.Name;
                            _cpu.ClockSpeed = (int)Math.Round((double)clockSpeed);
                            _cpu.Temperature = (int)Math.Round((double)firstCore.Value);
                            _cpu.MinTemperature = (int)Math.Round((double)firstCore.Min);
                            _cpu.MaxTemperature = (int)Math.Round((double)firstCore.Max);


                            _cpu.Clocks = new List<CpuClock>();
                            
                            
                            _cpu.Clocks.AddRange(hardware.Sensors
                           .Where(x => x.SensorType is SensorType.Clock)
                           .Select(x => new CpuClock() { ClockName = x.Name, ClockSpeed = (int)Math.Round((double)x.Value), Load = (int)x.Hardware.Sensors.Where( x => x.SensorType == SensorType.Load).Select(x => x.Value).First()}));
                          
                        }
                    }
                }
                catch (Exception ex)
                {
                    Application.Current.Dispatcher?.Invoke(() =>
                    {
                        txtCpuName.Text = $"CPU not found! \n Error: {ex.Message}";
                    });
                }

                Application.Current.Dispatcher?.Invoke(() =>
                {
                    txtCpuName.Text = $"{_cpu.Name} {_cpu.Clocks.Skip(1).Count()}-Core";
                    pbCpuTemp.Value = _cpu.Temperature;
                    txtCpuMinTemperature.Text = $"Température minimum: {_cpu.MinTemperature}°";
                    txtCpuMaxTemperature.Text = $"Température maximale: {_cpu.MaxTemperature}°";

                    txtClocks.Text = _cpu.GetGlocksData().ToString();
                });
            
                await Task.Delay(1000); // Avoid async void deadlock
            }
        }
    }
}
