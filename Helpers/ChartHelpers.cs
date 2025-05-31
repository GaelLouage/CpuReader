using CpuReader.Services.Classes;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using LibreHardwareMonitor.Hardware;

namespace CpuReader.Helpers
{
    public class ChartHelpers
    {

        public static void SetChartData(out ISeries[] frequencies, out Axis[] xAxes, out Axis[] yAxes, double[] values, ISensor[] clocks, string frequencyName, string xAxisName, string yAxisName)
        {
            // Now bind the real values to the chart
            frequencies = new ISeries[]
            {
                     new ColumnSeries<double>
                     {
                         Values = values,
                         Name = frequencyName,
                         Fill = new SolidColorPaint(SKColors.Red),
                         Stroke = null // Optional: removes the outline,
                     }
            };

            xAxes = new Axis[]
            {
                 new Axis
                 {
                     LabelsPaint = new SolidColorPaint(SKColors.White),
                     NamePaint = new SolidColorPaint(SKColors.White),
                     Labels = clocks.Select(sensor => sensor.Name).ToList(),
                     LabelsRotation = 90,
                     Name = xAxisName
                 }
            };

            yAxes = new Axis[]
             {
                 new Axis
                 {
                     LabelsPaint = new SolidColorPaint(SKColors.White),
                     NamePaint = new SolidColorPaint(SKColors.White),
                     Name = yAxisName,
                     MinLimit = 0,
                     MaxLimit = 8000 // or whatever upper bound fits your data
                 }
             };
        }
    }
}
