using CpuReader.Models;
using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CpuReader.Extensions
{
    public static class HardwareExtensions
    {
        public static HWare Get(this IHardware hardware, SensorType sensorType)
        {
            var myHardware = new HWare();
            var hd = hardware.Sensors.FirstOrDefault(x => x.SensorType == sensorType);

            var sensorTypeDictionary = new Dictionary<SensorType, Action>()
            {
                {SensorType.Clock, () => { myHardware.Cpu.ClockSpeed = (int)hd.Value; } },
                {SensorType.Temperature, () => {
                                                myHardware.Cpu.Temperature.Current = hd.Value;
                                                myHardware.Cpu.Temperature.Min = hd.Min;
                                                myHardware.Cpu.Temperature.Max  = hd.Max;
                                                }
                },
            };

            if (sensorTypeDictionary.ContainsKey(sensorType))
            {
                sensorTypeDictionary[sensorType]?.Invoke();
            }
            return myHardware;
        }



        public static void SetCpuProperties(this HWare hWare, IHardware hardware)
        {
            if (hardware.HardwareType == HardwareType.Cpu)
            {
                var cpuTemp = hardware.Get(SensorType.Temperature);
                var clockSpeed = hardware.Get(SensorType.Clock).Cpu.ClockSpeed;
                var load = hardware.Get(SensorType.Load);
                
                hWare.Cpu.Name = hardware.Name;
                hWare.Cpu.ClockSpeed = (int)Math.Round((double)clockSpeed);
                hWare.Cpu.Temperature.Current = cpuTemp.Cpu.Temperature.Current;
                hWare.Cpu.Temperature.Min = cpuTemp.Cpu.Temperature.Min;
                hWare.Cpu.Temperature.Max = cpuTemp.Cpu.Temperature.Max;

                hWare.Cpu.Clocks =
                [
                    .. hardware.Sensors
                    .Where(x => x.SensorType is SensorType.Clock)
                    .Select(x =>
                    new CpuClock()
                    {
                       ClockName = x.Name,
                       ClockSpeed = (int)Math.Round((double)x.Value)
                    }),
                ];
                hWare.Cpu.Loads =
                [
                    .. hardware.Sensors
                        .Where(x => x.SensorType is SensorType.Load)
                        .Select(x => new CpuLoad()
                        {
                            Core = x.Name,
                            Max = x.Max,
                            Value = x.Value,

                        }),
                ];
                hWare.Cpu.Powers =
                [
                    .. hardware.Sensors
                    .Where(x => x.SensorType is SensorType.Power)
                    .Select(x => new Power()
                    {
                        Core = x.Name,
                        Max = x.Max,
                        Value = x.Value,
                    })
                ];
            }

        }

    }
}
