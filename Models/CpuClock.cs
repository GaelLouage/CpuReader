using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuReader.Models
{
    public class CpuClock 
    {
        public string ClockName { get; set; }
        public int ClockSpeed { get; set; }
        public int Load {  get; set; }
        public string ToString()
        {
            return $"{ClockName}:{ClockSpeed} MHz";
        }
    }
}
