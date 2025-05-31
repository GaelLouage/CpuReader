using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LibreHardwareMonitor.Hardware;

namespace CpuReader.Services.Classes
{
    public class ChartEntity
    {
        public Axis[] XAxes { get; set; }
        public Axis[] YAxes { get; set; }
        public ISeries[] Frequencies { get; set; }
        public ISensor[] Clocks { get; set; }
        public string FrequencyName { get; set; }
        public string XAxisName { get; set; }
        public string YAxisName { get; set; }
        public double[] Values { get; set; }
    }
}
