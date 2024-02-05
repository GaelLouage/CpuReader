using CpuReader.Extensions;
using CpuReader.Models;
using CpuReader.Service.Interfaces;
using CpuReader.Singleton;
using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CpuReader.Helpers
{
    public static class UIUpdater
    {
        public static void RunCpuUI(IHardWareService hardWareService, TextBlock txtCpuName,TextBlock txtCpuTempPgb, ProgressBar pbCpuTemp, TextBlock txtCpuMinTemperature , TextBlock txtCpuMaxTemperature, TextBlock txtClocks,
            TextBlock txtLoads,
            TextBlock txtWatts)
        {
       
            var (HardWare, Success) = hardWareService.CpuData();
            HardWareSingleton.Instance.Hardware = HardWare;
            var hardWareSingleton = HardWareSingleton.Instance.Hardware;
            if (!Success)
            {
                MessageBox.Show("An Error occured!");
                return;
            }
            Application.Current.Dispatcher?.Invoke(() =>
            {
                txtCpuName.Text = $"{hardWareSingleton.Cpu.Name} {hardWareSingleton.Cpu.Clocks.Skip(1).Count()}-Core";
                var currentCpuTemperature = HardWare.Cpu.Temperature.Current;

                CelsiusUpdater(pbCpuTemp, txtCpuTempPgb, txtCpuMinTemperature, txtCpuMaxTemperature, hardWareSingleton, currentCpuTemperature);

            


                txtClocks.Text = hardWareSingleton.Cpu.GetClocksFrequencyToString();

                txtLoads.Text = hardWareSingleton.Cpu.GetLoadsToString();

                txtWatts.Text = hardWareSingleton.Cpu.GetPowersToString();
            });
        }

        private static void CelsiusUpdater(ProgressBar pbCpuTemp, TextBlock txtCpuTempPgb, TextBlock txtCpuMinTemperature, TextBlock txtCpuMaxTemperature, HWare hardWareSingleton, float? currentCpuTemperature)
        {
            var roundedCpuTemp = Math.Round((double)hardWareSingleton.Cpu.Temperature.Current, 1);
            pbCpuTemp.Value = roundedCpuTemp;
            txtCpuTempPgb.Text = $"{roundedCpuTemp}°";
            txtCpuMinTemperature.Text = $"Minimum temperature: {Math.Round((double)hardWareSingleton.Cpu.Temperature.Min, 1)}°";
            txtCpuMaxTemperature.Text = $"Maximum temperature: {Math.Round((double)hardWareSingleton.Cpu.Temperature.Max, 1)}°";

            if (currentCpuTemperature <= 50)
            {
                pbCpuTemp.Foreground = Brushes.LightGreen;
            }
            else if (currentCpuTemperature <= 60)
            {
                pbCpuTemp.Foreground = Brushes.Green;
            }
            else if (currentCpuTemperature <= 72)
            {
                pbCpuTemp.Foreground = Brushes.Orange;
            }
            else
            {
                pbCpuTemp.Foreground = Brushes.Red;
            }
        }

        private static void FahrenheitUpdater(ProgressBar pbCpuTemp,TextBlock txtCpuTempPgb ,TextBlock txtCpuMinTemperature, TextBlock txtCpuMaxTemperature, HWare hardWareSingleton, float? currentCpuTemperature)
        {

            var roundedCpuTemp = (float)MathHelper.ToFahrenheit(Math.Round((double)hardWareSingleton.Cpu.Temperature.Current, 1));
            pbCpuTemp.Value = roundedCpuTemp;
            txtCpuTempPgb.Text = $"{roundedCpuTemp}F";
            txtCpuMinTemperature.Text = $"Minimum temperature: {(float)MathHelper.ToFahrenheit((Math.Round((double)hardWareSingleton.Cpu.Temperature.Min, 1)))}F";
            txtCpuMaxTemperature.Text = $"Maximum temperature: {(float)MathHelper.ToFahrenheit(Math.Round((double)hardWareSingleton.Cpu.Temperature.Max, 1))}F";

            if (currentCpuTemperature <= MathHelper.ToFahrenheit(50))
            {
                pbCpuTemp.Foreground = Brushes.LightGreen;
            }
            else if (currentCpuTemperature <= MathHelper.ToFahrenheit(60))
            {
                pbCpuTemp.Foreground = Brushes.Green;
            }
            else if (currentCpuTemperature <= MathHelper.ToFahrenheit(72))
            {
                pbCpuTemp.Foreground = Brushes.Orange;
            }
            else
            {
                pbCpuTemp.Foreground = Brushes.Red;
            }
        }
    }
}
