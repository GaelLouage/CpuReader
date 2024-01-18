using System.Text;

namespace CpuReader.Models
{
    public class Cpu
    {
        public string Name { get; set; }
        public int ClockSpeed { get; set; }
        public int Temperature { get; set; }
        public int MinTemperature { get; set; }
        public int MaxTemperature { get; set; }
        public int Cores { get; set; }
        public List<CpuClock>? Clocks { get; set; } 
        public StringBuilder GetGlocksData()
        {
            var sb = new StringBuilder();
            if(Clocks is null)
            {
                return null;
            }
            sb.AppendLine(string.Join("\n", Clocks.Take(Clocks.Count -1).Select((x,i) => $"Fréquence Coeur {++i}: {x.ClockSpeed} MHz")));
            return sb;
        }
    }
}
