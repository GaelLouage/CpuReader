using LibreHardwareMonitor.Hardware;

namespace CpuReader.Services.Interfaces
{
    public interface IComputerService
    {
        IHardware Cpu { get; }
        IHardware Gpu { get; }
        IHardware MotherBoard { get; }
        IHardware Ram { get; }
        IHardware Storage { get; }
    }
}