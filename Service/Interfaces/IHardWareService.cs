using CpuReader.Models;
using LibreHardwareMonitor.Hardware;

namespace CpuReader.Service.Interfaces
{
    public interface IHardWareService
    {
        (HWare HardWare, bool Success) CpuData();
        
    }
}