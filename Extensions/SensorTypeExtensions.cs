using LibreHardwareMonitor.Hardware;

namespace CpuReader.Extensions
{
    public static class SensorTypeExtensions
    {
        public static string GetUnit(this SensorType type)
        {
            return type switch
            {
                SensorType.Data => "GB",
                SensorType.Load => "%",
                SensorType.Temperature => "°C",
                SensorType.Clock => "MHz",
                SensorType.Voltage => "V",
                SensorType.Power => "W",
                SensorType.Fan => "RPM",
                SensorType.Flow => "L/h",
                SensorType.Control => "%",
                _ => ""
            };
        }
    }
}
