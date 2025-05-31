using CpuReader.Enums;
using CpuReader.Helpers;
using LibreHardwareMonitor.Hardware;
using LibreHardwareMonitor.Hardware.Cpu;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using OpenTK.Graphics.OpenGL;
using SkiaSharp;
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.UI.Xaml.Gauges;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
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
    /// Interaction logic for CpuControl.xaml
    /// </summary>
    public partial class CpuControl : UserControl
    {
        private ISensor[] _loadsSensors;
        private double[] _loadValues;
        public Axis[] XLoadsAxes { get; set; }
        public Axis[] YLoadsAxes { get; set; }
        public ISeries[] Loads { get; set; }
        public Axis[] XAxes { get; set; }
        public Axis[] YAxes { get; set; }
        public ISeries[] Frequencies { get; set; }
        private double[] _values;
        private ISensor[] _clocks;

        private Computer _computer;
        private DispatcherTimer _timer;
        private IHardware _cpu;

        public CpuControl(Computer computer)
        {
            InitializeComponent();
            _computer = computer;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            ISeries[] frequencies;
            Axis[] yAxes;
            Axis[] xAxes;

            ISeries[] loads;
            Axis[] yloadsAxes;
            Axis[] xloadsAxes;

            _cpu = _computer.Hardware.FirstOrDefault(x => x.HardwareType == HardwareType.Cpu);
            txtCpuName.Text = _cpu.Name;
            _cpu.Update();  // This ensures you get current sensor data

            // Get clock sensors with valid values
            _clocks = _cpu.Sensors.Where(x => x.SensorType == SensorType.Clock  && x.Value.HasValue).ToArray();
            _values = _clocks.Select(x => (double)x.Value.Value).ToArray();


            _loadsSensors = _cpu.Sensors.Where(x => x.SensorType == SensorType.Load && x.Value.HasValue).ToArray();
            _loadValues = _loadsSensors.Select(x => (double)x.Value.Value).ToArray();

            ChartHelpers.SetChartData(out frequencies, out xAxes, out yAxes, _values, _clocks, "MHz", "", "Frequency (MHz)");
            Frequencies = frequencies;
            XAxes = xAxes;
            YAxes = yAxes;


            ChartHelpers.SetChartData(out loads, out xloadsAxes, out yloadsAxes, _values, _clocks, "%", "", "%");
            Loads = loads;
            XLoadsAxes = xloadsAxes;
            YLoadsAxes = yloadsAxes;
          
            var temperature = _cpu.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Temperature);
            var power = _cpu.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Power);
            var pointer = circularGaugeUi.Scales[0].Pointers[0] as Syncfusion.UI.Xaml.Gauges.CircularPointer;
            if (pointer != null)
            {
                pointer.Value = temperature.Value.Value;
            }

            DataContext = this;




            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick += Gpu_Tick;
            _timer.Start();

        }



        void Gpu_Tick(object sender, EventArgs e)
        {
            _cpu.Update();

            _clocks = _cpu.Sensors.Where(x => x.SensorType == SensorType.Clock && x.Value.HasValue).ToArray();
            _values = _clocks.Select(x => (double)x.Value.Value).ToArray();


            _loadsSensors = _cpu.Sensors.Where(x => x.SensorType == SensorType.Load && x.Value.HasValue).ToArray();
            _loadValues = _loadsSensors.Select(x => (double)x.Value.Value).ToArray();


            if (Frequencies[0] is ColumnSeries<double> columnSeries)
            {
                columnSeries.Values = _values;
            }
            else
            {
                MessageBox.Show($"Unexpected series type: {Frequencies[0]?.GetType()?.Name}");
            }


            if (Loads[0] is ColumnSeries<double> columnLoadsSeries)
            {
                columnLoadsSeries.Values = _loadValues;
            }
            else
            {
                MessageBox.Show($"Unexpected series type: {Frequencies[0]?.GetType()?.Name}");
            }

            var temperature = _cpu.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Temperature);
            var power = _cpu.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Power);
            var temperaturePointer = circularGaugeUi.Scales[0].Pointers[0] as Syncfusion.UI.Xaml.Gauges.CircularPointer;
            if (temperaturePointer != null)
            {
                temperaturePointer.Value = temperature.Value.Value;
            }

            var powerPointer = circularGaugeUiWattage.Scales[0].Pointers[0] as Syncfusion.UI.Xaml.Gauges.CircularPointer;
            if (powerPointer != null)
            {
                powerPointer.Value = power.Value.Value;
            }
            UpdateTextBlocksUI(temperature, power);

        }



        private void SetChartData()
        {

            // Now bind the real values to the chart
            Frequencies = new ISeries[]
            {
                     new ColumnSeries<double>
                     {
                         Values = _values,
                         Name = "MHz",
                         Fill = new SolidColorPaint(SKColors.Red),
                         Stroke = null // Optional: removes the outline,
                     }
            };

            XAxes = new Axis[]
            {
                 new Axis
                 {
                     LabelsPaint = new SolidColorPaint(SKColors.White),
                     NamePaint = new SolidColorPaint(SKColors.White),
                     Labels = _clocks.Select(sensor => sensor.Name).ToList(),
                     LabelsRotation = 90,
                     Name = "Core"
                 }
            };

            YAxes = new Axis[]
             {
                 new Axis
                 {
                     LabelsPaint = new SolidColorPaint(SKColors.White),
                     NamePaint = new SolidColorPaint(SKColors.White),
                     Name = "Frequency (MHz)",
                     MinLimit = 0,
                     MaxLimit = 8000 // or whatever upper bound fits your data
                 }
             };
        }
        private void UpdateTextBlocksUI(ISensor? temperature, ISensor? power)
        {

            txtMinTemperature.Text = $"{Math.Round(temperature.Min.Value)}°";
            txtValueTemperature.Text = $"{Math.Round(temperature.Value.Value)}°";
            txtMaxTemperature.Text = $"{Math.Round(temperature.Max.Value)}°";
            //wattage ui
            txtMinWattage.Text = $"{Math.Round(power.Min.Value)} W";
            txtCurrentWattage.Text = $"{Math.Round(power.Value.Value)} W";
            txtMaxWattage.Text = $"{Math.Round(power.Max.Value)} W";
        }
    }
}
