using LibreHardwareMonitor.Hardware.Gpu;
using System.Security.Policy;

namespace CpuReader.Models
{
    public  class HWare 
    {
        public Cpu Cpu { get; set; } = new Cpu();
        public Gpu Gpu { get; set; } = new Gpu();
    }
}
