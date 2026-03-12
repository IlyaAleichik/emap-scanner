using Avalonia.Controls;
using EMapScannerGui.ViewModels;

namespace EMapScannerGui.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            System.Diagnostics.Debug.WriteLine($"BEFORE InitializeComponent - DataContext: {DataContext}");
            InitializeComponent();     
            System.Diagnostics.Debug.WriteLine($"AFTER InitializeComponent - DataContext: {DataContext}");

            DataContext = new DevicesViewModel();
            System.Diagnostics.Debug.WriteLine($"AFTER MANUAL SET - DataContext: {DataContext}");

        }
    }
}