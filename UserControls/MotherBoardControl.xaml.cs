using LibreHardwareMonitor.Hardware;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CpuReader.UserControls
{
    /// <summary>
    /// Interaction logic for MotherBoardControl.xaml
    /// </summary>
    public partial class MotherBoardControl : UserControl, INotifyPropertyChanged
    {
        private Computer _computer;

        private ISeries[] _mySeries;
        public ISeries[] MySeries
        {
            get => _mySeries;
            set
            {
                _mySeries = value;
                OnPropertyChanged();
            }
        }

        public MotherBoardControl(Computer computer)
        {
            InitializeComponent();
            _computer = computer;
            DataContext = this; // Bind properties to the control itself
        }

        private void Grid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //IHardwareFactory mdb = new MotherboardData();
            //var data = mdb.GetData(_computer.Hardware.FirstOrDefault(x => x.HardwareType == HardwareType.Motherboard));
            //txtMdbName.Text = data?.Name ?? "Unknown";
            //var props = data.SubHardware.Select(x => x.Sensors).FirstOrDefault();
            
            //MySeries = new ISeries[]
            //{
            //    new LineSeries<double>
            //    {
            //        Values = new double[] { 5, 6, 7, 8 },
            //        Name = "Fines Issued"
            //    }
            //};

  
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
