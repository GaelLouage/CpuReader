
using LibreHardwareMonitor.Hardware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for GpuControl.xaml
    /// </summary>
    public partial class GpuControl : UserControl
    {
        private Computer _computer;
        private DispatcherTimer _timer;

        private IHardware? _gpu;
        public GpuControl(Computer computer)
        {
            InitializeComponent();
            _computer = computer;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            //_timer = new DispatcherTimer();
            //_timer.Interval = TimeSpan.FromMilliseconds(500);
            //_timer.Tick += Gpu_Tick;
            //_timer.Start();
            //_gpu = _gpuData.Get(_computer);
            //txtGpuName.Text = _gpu.Name ?? "Unknown";
        }
        void Gpu_Tick(object sender, EventArgs e)
        {
            //var sb = new StringBuilder();
            //foreach (var sensor in _gpu.Sensors)
            //{
            //    if (sensor.SensorType == SensorType.Voltage)
            //    {
            //        sb.AppendLine($"Voltage:{sensor.Name} {sensor.Value}");
            //    }

            //    if (sensor.SensorType == SensorType.Clock)
            //    {
            //        sb.AppendLine($"Clock Min: {sensor.Min}");
            //        sb.AppendLine($"Clock: {sensor.Value}");
            //        sb.AppendLine($"Clock Max: {sensor.Max}");
            //    }

            //    if (sensor.SensorType == SensorType.Load)
            //    {
            //        sb.AppendLine($"Load: {sensor.Value}");
            //    }

            //    if (sensor.SensorType == SensorType.Frequency)
            //    {
            //        sb.AppendLine($"Frequency: {sensor.Value}");
            //    }

            //    if (sensor.SensorType == SensorType.Humidity)
            //    {
            //        sb.AppendLine($"Humidity: {sensor.Value}");
            //    }

            //    if (sensor.SensorType == SensorType.Voltage)
            //    {
            //        sb.AppendLine($"Voltage: {sensor.Value}");
            //    }

            //    if (sensor.SensorType == SensorType.Noise)
            //    {
            //        sb.AppendLine($"Noise: {sensor.Value}");
            //    }

            //    if (sensor.SensorType == SensorType.Humidity)
            //    {
            //        sb.AppendLine($"Humidity: {sensor.Value}");
            //    }

            //    if (sensor.SensorType == SensorType.Conductivity)
            //    {
            //        sb.AppendLine($"Conductivity: {sensor.Value}");
            //    }
            //}
            //txtGpuData.Text = sb.ToString();
        }
    }
}
