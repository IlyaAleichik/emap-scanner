using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EMapScannerGui.Models
{
    public class Device : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _ip;
        private string _mac;
        private string _oem;


        public Device()
        {
      
        }

        public Device(string ip, string mac, string oem)
        {
            _ip = ip;
            _mac = mac;
            _oem = oem;
        }

        public string Ip
        {
            get => _ip;
            set
            {
                _ip = value;
                OnPropertyChanged();
            }
        }

        public string Mac
        {
            get => _mac;
            set
            {
                _mac = value;
                OnPropertyChanged();
            }
        }

        public string Oem
        {
            get => _oem;
            set
            {
                _oem = value;
                OnPropertyChanged();
            }
        }

        public DateTime AddedDate { get; set; }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
