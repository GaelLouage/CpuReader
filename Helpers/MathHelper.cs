using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CpuReader.Extensions
{
    public static class MathHelper
    {
        public static double RoundToOneDecimal(ref float? number)
        {
            return Math.Round((double)number, 1);
        }
        public static double RoundToOneDecimal(float? number)
        {
            return Math.Round((double)number, 1);
        }
        public static double ToFahrenheit(double celsius) => (celsius * 9 / 5) + 32;
        
    }
}
