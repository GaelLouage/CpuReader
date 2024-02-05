using CpuReader.Enums;
using CpuReader.Extensions;
using CpuReader.Models;
using CpuReader.Service.Interfaces;
using CpuReader.Singleton;
using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
            try
            {
                foreach (IHardware hardware in computer.Hardware)
                {
                    hardware.Update();

                    HardWareSingleton.Instance.Hardware.SetCpuProperties(hardware);
                }
                return (HardWareSingleton.Instance.Hardware, true);
            }
            catch 
            {
                return (HardWareSingleton.Instance.Hardware, false);
            }
        }
    
    }
}
