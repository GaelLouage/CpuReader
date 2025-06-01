using CpuReader.Enums;
using CpuReader.Extensions;
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
        // private fields
        private DispatcherTimer _timer;
        private IHardware _cpu;
        // databinding properties
        public ChartDataEntity LoadChart { get; set; }
        public ChartDataEntity FrequenciesChart { get; set; }

        public CpuControl(IHardware cpu)
        {
            InitializeComponent();
            _cpu = cpu;
            // initialize properties
            LoadChart = new ChartDataEntity();
            FrequenciesChart = new ChartDataEntity();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
         

            txtCpuName.Text = _cpu.Name;
            _cpu.Update();  // This ensures you get current sensor data
            // set the chart sensors on frequancy and loads
            FrequenciesChart.SetChartSensors(_cpu, x => x.SensorType == SensorType.Clock && x.Value.HasValue, x => (double)x.Value.Value);
            LoadChart.SetChartSensors(_cpu, x => x.SensorType == SensorType.Load, x => Math.Round((double)x.Value));


            // set frequencies chartData
            (var frequencies, var xfrequenciesAxes, var yfrequenciesAxes) =  ChartHelpers.SetChartData(FrequenciesChart.Values, FrequenciesChart.Sensors, "MHz", 0, 8000);
            FrequenciesChart.Series = frequencies;
            FrequenciesChart.XAxes = xfrequenciesAxes;
            FrequenciesChart.YAxes = yfrequenciesAxes;

            // set load frequencies chartData
            (var loads, var xloadsAxes, var yloadsAxes) = ChartHelpers.SetChartData(LoadChart.Values, LoadChart.Sensors, "%",0,100);
            LoadChart.Series = loads;
            LoadChart.XAxes = xloadsAxes;
            LoadChart.YAxes = yloadsAxes;


            DataContext = this;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(500);
            _timer.Tick += Gpu_Tick;
            _timer.Start();
        }



        void Gpu_Tick(object sender, EventArgs e)
        {
            _cpu.Update();

            // set the chart sensors on frequancy and loads
            FrequenciesChart.SetChartSensors(_cpu, x => x.SensorType == SensorType.Clock && x.Value.HasValue, x => (double)x.Value.Value);
            LoadChart.SetChartSensors(_cpu, x => x.SensorType == SensorType.Load, x => Math.Round((double)x.Value));
            // set the column series on frequancy and loads
            FrequenciesChart.SetColumnSeries();
            LoadChart.SetColumnSeries();


            var temperature = _cpu.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Temperature);
            var power = _cpu.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Power);
            // placing the data of temperature and power into the circular gauges
            temperatureCircularGauge.SetCircularGauge(temperature);
            wattageCircularGauge.SetCircularGauge(power);

            UpdateTextBlocksUI(temperature, power);
        }

     

        private void UpdateTextBlocksUI(ISensor? temperature, ISensor? power)
        {
            txtMinTemperature.Text = $"{Math.Round(temperature.Min.Value)}{temperature.SensorType.GetUnit()}";
            txtValueTemperature.Text = $"{Math.Round(temperature.Value.Value)}{temperature.SensorType.GetUnit()}";
            txtMaxTemperature.Text = $"{Math.Round(temperature.Max.Value)}{temperature.SensorType.GetUnit()}";
            //wattage ui
            txtMinWattage.Text = $"{Math.Round(power.Min.Value)}{power.SensorType.GetUnit()}";
            txtCurrentWattage.Text = $"{Math.Round(power.Value.Value)}{power.SensorType.GetUnit()}";
            txtMaxWattage.Text = $"{Math.Round(power.Max.Value)}{power.SensorType.GetUnit()}";
        }
    }
}
