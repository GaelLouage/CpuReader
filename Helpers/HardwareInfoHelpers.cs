using LibreHardwareMonitor.Hardware;
using CpuReader.Extensions;
using CpuReader.Services.Interfaces;
using System.Text;

namespace CpuReader.Helpers
{
    public static class HardwareInfoHelpers
    {

        public static string GetHardwareInfo(IHardware hardware)
        {
            StringBuilder sb = new StringBuilder();


            hardware.Update();

            sb.AppendLine($"Hardware: {hardware.Name}");

            foreach (ISensor sensor in hardware.Sensors)
            {
                sb.AppendLine($"Sensor: {sensor.Name}");
                sb.AppendLine($"  Type: {sensor.SensorType}");
                sb.AppendLine($"  Min: {sensor.Min?.ToString("0.##")} {sensor.SensorType.GetUnit()}");
                sb.AppendLine($"  Value: {sensor.Value?.ToString("0.##")} {sensor.SensorType.GetUnit()}");
                sb.AppendLine($"  Max: {sensor.Max?.ToString("0.##")} {sensor.SensorType.GetUnit()}");
            }
            return sb.ToString();
        }
    }
}
