using EMapScannerGui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EMapScannerGui.ViewModels
{
    public class DevicesViewModel
    {
        private ObservableCollection<Device> _devices;

        public DevicesViewModel()
        {

            Devices = new ObservableCollection<Device>
            {
                new Device { Id = 1, Ip = "192.168.0.6", Mac = "805EC0095278", Oem = "YEALINK(XIAMEN) NETWORK TECHNOLOGY CO.,LTD.",},
                   new Device { Id = 2, Ip = "192.168.0.2", Mac = "805EC0095278", Oem = "YEALINK(XIAMEN) NETWORK TECHNOLOGY CO.,LTD.",},
             new Device { Id = 3, Ip = "192.168.0.3", Mac = "805EC0095278", Oem = "YEALINK(XIAMEN) NETWORK TECHNOLOGY CO.,LTD.",},
                     new Device { Id = 4, Ip = "192.168.0.4", Mac = "805EC0095278", Oem = "YEALINK(XIAMEN) NETWORK TECHNOLOGY CO.,LTD.",},
             };
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
