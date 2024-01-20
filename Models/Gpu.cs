using LibreHardwareMonitor.Hardware;

namespace CpuReader.Models
{
    public class Gpu
    {
        public string Name { get; set; }    
        public float? Memory { get; set; }
        public float? UsedMemory  => Sensors.FirstOrDefault(x => x.Name == "GPU Memory Used").Value;
        public float? FreeMemory { get; set; }
        public float? HotSpot { get; set; }
        public Temperature Temperature { get; set; } = new Temperature();
        public float? Power { get; set; }
        public List<ISensor> Sensors { get; set; } = new List<ISensor>();
    }
}
