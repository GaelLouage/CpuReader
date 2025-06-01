using CpuReader.UserControls;
using LibreHardwareMonitor.Hardware;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CpuReader.Extensions
{
    public static class ChartExtensions
    {
        public static void SetChartSensors(this ChartDataEntity chart,IHardware cpu, Func<ISensor, bool> where, Func<ISensor, double> select)
        {
            chart.Sensors = cpu.Sensors.Where(where).ToArray();
            chart.Values = chart.Sensors.Select(select).ToArray();
        }
        public static void SetColumnSeries(this ChartDataEntity chart)
        {
            if (chart.Series[0] is ColumnSeries<double> columnSeries)
            {
                columnSeries.Values = chart.Values;
            }
            else
            {
                MessageBox.Show($"Unexpected series type: {chart.Series[0]?.GetType()?.Name}");
            }
        }
    }
}
