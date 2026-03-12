using CommunityToolkit.Mvvm.Input;
using EMapScanner;
using EMapScannerGui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EMapScannerGui.ViewModels
{
    public class DevicesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Device> _devices;

        List<(IPAddress, PhysicalAddress)> detectedAddresses = new List<(IPAddress, PhysicalAddress)>();
        MacVendorInfo result;
        MacLookupService service = new MacLookupService();

      
        public DevicesViewModel()
        {
            //System.Diagnostics.Debug.WriteLine("=== ViewModel CONSTRUCTOR STARTED ===");

            Devices = new ObservableCollection<Device>();
            LoadDataCommand = new AsyncRelayCommand(LoadData);

            //System.Diagnostics.Debug.WriteLine($"=== ViewModel CREATED: People count = {Devices.Count} ===");
         
        }


        public async Task ScanAsync()
        {
            await Task.Delay(1000);
            MapScanner mapScanner = new MapScanner(detectedAddresses);
            mapScanner.QuickScan();

            if (detectedAddresses.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("Не найдено активных устройств.");
            }
            else
            {
                string hostName;
                System.Diagnostics.Debug.WriteLine("Найдены устройства на следующих адресах:");
                foreach (var detectedAddress in detectedAddresses)
                {

                    result = await service.LookupMacAddressAsync(detectedAddress.Item2.ToString());

                    if (result != null)
                    {
                        System.Diagnostics.Debug.WriteLine("- {0}: {1}: {2}", detectedAddress.Item1, detectedAddress.Item2, result.Company);
                        Devices.Add(new Device(detectedAddress.Item1.ToString(), detectedAddress.Item2.ToString(), result.Company));
                      
                        //Console.WriteLine("- {0}: {1}: {2}", detectedAddress.Item1, detectedAddress.Item2, result.Company);
                    }
                    else
                    {
                        //Console.WriteLine("- {0}: {1}: {2}", detectedAddress.Item1, detectedAddress.Item2, "Unknown");
                        System.Diagnostics.Debug.WriteLine("- {0}: {1}: {2}", detectedAddress.Item1, detectedAddress.Item2, "Unknow");
                        Devices.Add(new Device(detectedAddress.Item1.ToString(), detectedAddress.Item2.ToString(), "Unkown"));
                    }
                }
            }
        }

        public ObservableCollection<Device> Devices
        {
            get => _devices;
            set
            {
                _devices = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
