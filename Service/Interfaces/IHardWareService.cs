using CpuReader.Models;

namespace CpuReader.Service.Interfaces
{
    public interface IHardWareService
    {
        (HWare HardWare, bool Success) CpuData();
    }
}