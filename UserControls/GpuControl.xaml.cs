
using CpuReader.Extensions;
using CpuReader.Helpers;
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
        private DispatcherTimer _timer;
        public ChartDataEntity LoadChart { get; set; }
        public ChartDataEntity FrequenciesChart { get; set; }
        private IHardware _gpu;
        public GpuControl(IHardware gpu)
        {
            InitializeComponent();
            _gpu = gpu;
            LoadChart = new ChartDataEntity();
            FrequenciesChart = new ChartDataEntity();
        }
 
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {


            txtGpuName.Text = _gpu.Name;
            _gpu.Update();  // This ensures you get current sensor data
            // set the chart sensors on frequancy and loads
            FrequenciesChart.SetChartSensors(_gpu, x => x.SensorType == SensorType.Clock && x.Value.HasValue, x => (double)x.Value.Value);
            LoadChart.SetChartSensors(_gpu, x => x.SensorType == SensorType.Load, x => Math.Round((double)x.Value));


            // set frequencies chartData
            (var frequencies, var xfrequenciesAxes, var yfrequenciesAxes) = ChartHelpers.SetChartData(FrequenciesChart.Values, FrequenciesChart.Sensors, "MHz", 0, 8000);
            FrequenciesChart.Series = frequencies;
            FrequenciesChart.XAxes = xfrequenciesAxes;
            FrequenciesChart.YAxes = yfrequenciesAxes;

            // set load frequencies chartData
            (var loads, var xloadsAxes, var yloadsAxes) = ChartHelpers.SetChartData(LoadChart.Values, LoadChart.Sensors, "%", 0, 100);
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
            _gpu.Update();

            // set the chart sensors on frequancy and loads
            FrequenciesChart.SetChartSensors(_gpu, x => x.SensorType == SensorType.Clock && x.Value.HasValue, x => (double)x.Value.Value);
            LoadChart.SetChartSensors(_gpu, x => x.SensorType == SensorType.Load, x => Math.Round((double)x.Value));
            // set the column series on frequancy and loads
            FrequenciesChart.SetColumnSeries();
            LoadChart.SetColumnSeries();


            var temperature = _gpu.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Temperature);
            var power = _gpu.Sensors.FirstOrDefault(x => x.SensorType == SensorType.Power);
            // placing the data of temperature and power into the circular gauges
            GputemperatureCircularGauge.SetCircularGauge(temperature);
            GpuCoreClockCircularGauge.SetCircularGauge(power);

            UpdateTextBlocksUI(temperature, power);
        }



        private void UpdateTextBlocksUI(ISensor? temperature, ISensor? power)
        {
            txtGpuMinTemperature.Text = $"{Math.Round(temperature.Min.Value)}{temperature.SensorType.GetUnit()}";
            txtGpuValueTemperature.Text = $"{Math.Round(temperature.Value.Value)}{temperature.SensorType.GetUnit()}";
            txtGpuMaxTemperature.Text = $"{Math.Round(temperature.Max.Value)}{temperature.SensorType.GetUnit()}";
            //wattage ui
            txtClockMin.Text = $"{Math.Round(power.Min.Value)}{power.SensorType.GetUnit()}";
            txtClockValue.Text = $"{Math.Round(power.Value.Value)}{power.SensorType.GetUnit()}";
            txtClockMax.Text = $"{Math.Round(power.Max.Value)}{power.SensorType.GetUnit()}";
        }
    }
}
