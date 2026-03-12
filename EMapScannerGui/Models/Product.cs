using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EMapScannerGui.Models
{
    public class Product 
    {
        private string _name;
        private string _category;
        //private decimal _price;
        //private int _quantity;
        //private bool _isAvailable;

        public int Id { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                //OnPropertyChanged();
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                //OnPropertyChanged();
            }
        }

        //public decimal Price
        //{
        //    get => _price;
        //    set
        //    {
        //        _price = value;
        //        OnPropertyChanged();
        //        OnPropertyChanged(nameof(PriceWithCurrency));
        //    }
        //}

        //public int Quantity
        //{
        //    get => _quantity;
        //    set
        //    {
        //        _quantity = value;
        //        OnPropertyChanged();
        //        OnPropertyChanged(nameof(TotalValue));
        //    }
        //}

        //public bool IsAvailable
        //{
        //    get => _isAvailable;
        //    set
        //    {
        //        _isAvailable = value;
        //        OnPropertyChanged();
        //    }
        //}

        public DateTime AddedDate { get; set; }

        // Вычисляемые свойства
        //public string PriceWithCurrency => $"{Price:F2} ₽";
        //public decimal TotalValue => Price * Quantity;

        // INotifyPropertyChanged implementation
        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
