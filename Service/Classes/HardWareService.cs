using CpuReader.Extensions;
using CpuReader.Models;
using CpuReader.Service.Interfaces;
using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuReader.Service.Classes
{
    public class HardWareService : IHardWareService
    {
        private readonly Computer computer;
        public HardWareService()
        {
            computer = new Computer() { IsCpuEnabled = true, IsGpuEnabled = true };
            computer.Open();
        }

        public (HWare HardWare, bool Success) CpuData()
        {
            var hWare = new HWare();
            try
            {
                foreach (IHardware hardware in computer.Hardware)
                {
                    hardware.Update();

                    hWare.SetCpuProperties(hardware);
                }
                return (hWare, true);
            }
            catch (Exception ex)
            {
                return (hWare, false);
            }
        }
    }
}
