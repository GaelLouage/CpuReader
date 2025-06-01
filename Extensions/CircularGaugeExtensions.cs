using LibreHardwareMonitor.Hardware;

namespace CpuReader.Extensions
{
    public static class CircularGaugeExtensions
    {
        public static void SetCircularGauge(this Syncfusion.UI.Xaml.Gauges.SfCircularGauge circularGauge,  ISensor? sensor)
        {
            var pointer = circularGauge.Scales[0].Pointers[0] as Syncfusion.UI.Xaml.Gauges.CircularPointer;
            if (pointer != null)
            {
                pointer.Value = sensor.Value.Value;
            }
        }
    }
}
