using LibreHardwareMonitor.Hardware;

namespace CpuReader.Models
{
    public sealed class HardwareDataEntity
    {
        public ISensor[]? Sensors { get; set; }
        public string Name { get; set; }
        public IHardware[]? SubHardware { get; set; }
        public Identifier? Identifier { get; set; }
        public IHardware? Parent { get; set; }
        public IDictionary<string, string>? Properties { get; set; }
    }
}