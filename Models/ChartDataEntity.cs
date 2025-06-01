using LibreHardwareMonitor.Hardware;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;


namespace CpuReader.UserControls
{
        public class ChartDataEntity
        {
            public Axis[] YAxes { get; set; }
            public Axis[] XAxes { get; set; }
            public ISeries[] Series { get; set; }
            public ISensor[] Sensors { get; set; }
            public double[] Values { get; set; }
        }
}
