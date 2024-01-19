using CpuReader.Models;
using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuReader.Singleton
{
    public sealed class HardWareSingleton
    {
        private static HardWareSingleton instance = null;
        private static readonly object padlock = new object();

        // Private constructor to prevent instantiation from outside
        private HardWareSingleton()
        {
            Hardware = new HWare();
        }

        public static HardWareSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new HardWareSingleton();
                    }
                    return instance;
                }
            }
        }

        public HWare Hardware { get;  set; }
    }
}
