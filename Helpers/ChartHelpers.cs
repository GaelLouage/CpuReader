using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using LibreHardwareMonitor.Hardware;

namespace CpuReader.Helpers
{
    public class ChartHelpers
    {

        public static (ISeries[] frequencies, Axis[] xAxes, Axis[] yAxes) SetChartData(double[] values, ISensor[] sensors, string frequencyName,  int min, int max)
        {
            var frequencies = new ISeries[]
            {
                     new ColumnSeries<double>
                     {
                         Values = values,
                         Name = frequencyName,
                         Fill = new SolidColorPaint(SKColors.Red),
                         Stroke = null // Optional: removes the outline,
                     }
            };

            var xAxes = new Axis[]
            {
                 new Axis
                 {
                     LabelsPaint = new SolidColorPaint(SKColors.White),
                     NamePaint = new SolidColorPaint(SKColors.White),
                     Labels = sensors.Select(x => x.Name).ToList(),
                     LabelsRotation = 90,
                 }
            };

           var yAxes = new Axis[]
             {
                 new Axis
                 {
                     LabelsPaint = new SolidColorPaint(SKColors.White),
                     NamePaint = new SolidColorPaint(SKColors.White),
                     Name = frequencyName,
                     MinLimit = min,
                     MaxLimit = max // or whatever upper bound fits your data
                 }
             };
            return (frequencies, xAxes, yAxes);
        }
    }
}
