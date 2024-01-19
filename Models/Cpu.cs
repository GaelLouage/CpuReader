using CpuReader.Extensions;
using System.Text;

namespace CpuReader.Models
{
    public class Cpu
    {
        public string Name { get; set; }
        public int ClockSpeed { get; set; }
        public static int UpdatedClockSpeedMax { get; set; }   
        public Temperature Temperature { get; set; } = new Temperature();

        public int Cores { get; set; }
        public List<CpuClock>? Clocks { get; set; }
        public List<CpuLoad>? Loads { get; set; }
        public List<Power>? Powers { get; set; }

        public string GetClocksFrequencyToString()
        {
            var clocks = Clocks.Take(Clocks.Count);
         
         
            var sb = new StringBuilder();
            if (Clocks is null)
            {
                return null;
            }
           
            if(clocks.Any( x => x.ClockSpeed > UpdatedClockSpeedMax))
            {
                UpdatedClockSpeedMax = clocks.First(x => x.ClockSpeed > UpdatedClockSpeedMax).ClockSpeed;
            }
            sb.AppendLine($"Bus Speed  {"".PadLeft(12)} {clocks.Last().ClockSpeed} MHz");
            sb.AppendLine("-------------------------------");
            sb.AppendLine(string.Join("\n", clocks.Take(clocks.Count()-1).Select((x, i) => $"CPU Core #{++i}{"".PadLeft(10)} {x.ClockSpeed} MHz")));
            sb.AppendLine("-------------------------------");
            sb.AppendLine($"Max {"".PadLeft(22)} {UpdatedClockSpeedMax} Mhz");
            return sb.ToString();
        }
        public string GetLoadsToString()
        {
            var loads = Loads.Skip(1).Take(Clocks.Count - 1).ToList();
          
            var sb = new StringBuilder();
            if (Clocks is null)
            {
                return null;
            }
            var max = loads.Select(x => x.Max).Sum() / loads.Count;
            
    
            sb.AppendLine($"CPU Total: {"".PadLeft(16)}  {Math.Round((double)loads.Select(x => x.Value).Sum() / loads.Count,1)} %");
            sb.AppendLine("-------------------------------");
            sb.AppendLine(string.Join("\n", loads.Select((x, i) => $"CPU Core # {++i} {"".PadLeft(10)}  {Math.Round((double)x.Value,1)} %")));
            sb.AppendLine("-------------------------------");
            sb.AppendLine($"Max {"".PadLeft(25)} {MathHelper.RoundToOneDecimal(ref max)} %");

            return sb.ToString();
        }

        public string GetPowersToString()
        {
            var powers = Powers.Take(Clocks.Count).ToList();

            var sb = new StringBuilder();
            if (Clocks is null)
            {
                return null;
            }
            var max = powers.Select(x => x.Max).Sum() / powers.Count;
            var min = powers.Select(x => x.Min).Sum() / powers.Count;
            sb.AppendLine($"CPU Package {"".PadLeft(10)} {Math.Round((double)Powers.First().Value, 1)} W");
            sb.AppendLine("-------------------------------");
            sb.AppendLine(string.Join("\n", powers.Skip(1).Select((x, i) => $"CPU Core # {++i} {"".PadLeft(10)} {Math.Round((double)x.Value, 1)} W")));
            sb.AppendLine("-------------------------------");
            sb.AppendLine($"Max {"".PadLeft(25)} {MathHelper.RoundToOneDecimal(ref max)} W");
        
            return sb.ToString();
        }
    }
}
