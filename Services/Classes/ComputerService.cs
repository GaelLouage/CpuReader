using CpuReader.Services.Interfaces;
using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuReader.Services.Classes
{
    public class ComputerService : IComputerService
    {
        private Computer _computer;

        public ComputerService()
        {
            _computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
                IsMotherboardEnabled = true,
                IsControllerEnabled = true,
                IsStorageEnabled = true,
                IsNetworkEnabled = true,
                IsBatteryEnabled = true,
                IsPsuEnabled = true,
            };

            _computer.Open();

        }

        public IHardware MotherBoard => _computer.Hardware.FirstOrDefault(x => x.HardwareType == HardwareType.Motherboard);
        public IHardware Cpu => _computer.Hardware.FirstOrDefault(x => x.HardwareType == HardwareType.Cpu);
        public IHardware Gpu => _computer.Hardware.FirstOrDefault(x => x.HardwareType == HardwareType.GpuNvidia);
        public IHardware Ram => _computer.Hardware.FirstOrDefault(x => x.HardwareType == HardwareType.Memory);
        public IHardware Storage => _computer.Hardware.FirstOrDefault(x => x.HardwareType == HardwareType.Storage);
    }
}
