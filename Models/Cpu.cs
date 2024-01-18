using System.Text;

namespace CpuReader.Models
{
    public class Cpu 
    {
        public string Name { get; set; }
        public int ClockSpeed { get; set; }
        public Temperature Temperature { get; set; } = new Temperature();

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
