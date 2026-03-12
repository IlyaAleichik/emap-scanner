using EMapScannerGui.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EMapScannerGui.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {


        private ObservableCollection<Product> _products;

        //private Product _selectedProduct;
        //private string _searchText;
        //private ObservableCollection<Product> _filteredProducts;

        // Команды
        //public ICommand AddProductCommand { get; }
        //public ICommand DeleteProductCommand { get; }
        //public ICommand EditProductCommand { get; }
        //public ICommand RefreshCommand { get; }
        //public ICommand ClearFiltersCommand { get; }
        //public ICommand ExportToCsvCommand { get; }
        //public ICommand SaveProductCommand { get; }

        public MainWindowViewModel()
        {
            // Инициализация данных
            Products = new ObservableCollection<Product>
            {
                new Product { Id = 1, Name = "Ноутбук", Category = "Электроника", AddedDate = DateTime.Now.AddDays(-10) },
                new Product { Id = 2, Name = "Мышь", Category = "Периферия", AddedDate = DateTime.Now.AddDays(-5) },
                new Product { Id = 3, Name = "Клавиатура", Category = "Периферия", AddedDate = DateTime.Now.AddDays(-3) },
                new Product { Id = 4, Name = "Монитор", Category = "Электроника", AddedDate = DateTime.Now.AddDays(-7) }
             };

            //FilteredProducts = new ObservableCollection<Product>(Products);

            // Инициализация команд
            //AddProductCommand = new RelayCommand(ExecuteAddProduct);
            //DeleteProductCommand = new RelayCommand(ExecuteDeleteProduct, CanExecuteDeleteProduct);
            //EditProductCommand = new RelayCommand(ExecuteEditProduct, CanExecuteEditProduct);
            //RefreshCommand = new RelayCommand(ExecuteRefresh);
            //ClearFiltersCommand = new RelayCommand(ExecuteClearFilters);
            //ExportToCsvCommand = new RelayCommand(ExecuteExportToCsv);
            //SaveProductCommand = new RelayCommand<Product>(ExecuteSaveProduct);
        }

        // Свойства с уведомлением об изменениях
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        //public ObservableCollection<Product> FilteredProducts
        //{
        //    get => _filteredProducts;
        //    set
        //    {
        //        _filteredProducts = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public Product SelectedProduct
        //{
        //    get => _selectedProduct;
        //    set
        //    {
        //        _selectedProduct = value;
        //        OnPropertyChanged();

        //        // Обновляем состояние команд при изменении выбранного элемента
        //        (DeleteProductCommand as RelayCommand)?.RaiseCanExecuteChanged();
        //        (EditProductCommand as RelayCommand)?.RaiseCanExecuteChanged();
        //    }
        //}

        //public string SearchText
        //{
        //    get => _searchText;
        //    set
        //    {
        //        _searchText = value;
        //        OnPropertyChanged();
        //        FilterProducts();
        //    }
        //}

        // Методы команд
        //private void ExecuteAddProduct(object parameter)
        //{
        //    var newProduct = new Product
        //    {
        //        Id = Products.Count > 0 ? Products.Max(p => p.Id) + 1 : 1,
        //        Name = $"Новый товар {Products.Count + 1}",
        //        Category = "Другое",
        //        Price = 0,
        //        Quantity = 0,
        //        IsAvailable = true,
        //        AddedDate = DateTime.Now
        //    };

        //    Products.Add(newProduct);
        //    FilterProducts();
        //    SelectedProduct = newProduct;
        //}

        //private bool CanExecuteDeleteProduct(object parameter)
        //{
        //    return SelectedProduct != null;
        //}

        //private void ExecuteDeleteProduct(object parameter)
        //{
        //    if (SelectedProduct != null)
        //    {
        //        Products.Remove(SelectedProduct);
        //        FilterProducts();
        //    }
        //}

        //private bool CanExecuteEditProduct(object parameter)
        //{
        //    return SelectedProduct != null;
        //}

        //private void ExecuteEditProduct(object parameter)
        //{
        //    if (SelectedProduct != null)
        //    {
        //        // В реальном приложении открыть диалог редактирования
        //        SelectedProduct.Name += " (ред.)";
        //        OnPropertyChanged(nameof(FilteredProducts));
        //    }
        //}

        //private void ExecuteRefresh(object parameter)
        //{
        //    FilteredProducts = new ObservableCollection<Product>(Products);
        //    SearchText = string.Empty;
        //}

        //private void ExecuteClearFilters(object parameter)
        //{
        //    SearchText = string.Empty;
        //}

        //private void ExecuteExportToCsv(object parameter)
        //{
        //    var csv = "Id,Name,Category,Price,Quantity,IsAvailable,AddedDate\n";
        //    foreach (var product in FilteredProducts)
        //    {
        //        csv += $"{product.Id},{product.Name},{product.Category},{product.Price},{product.Quantity},{product.IsAvailable},{product.AddedDate:yyyy-MM-dd}\n";
        //    }
        //    System.IO.File.WriteAllText($"products_export_{DateTime.Now:yyyyMMdd_HHmmss}.csv", csv);
        //}

        private void ExecuteSaveProduct(Product product)
        {
            if (product != null)
            {
                // Логика сохранения продукта
                Console.WriteLine($"Сохранение продукта: {product.Name}");
            }
        }

        // Вспомогательные методы
        //private void FilterProducts()
        //{
        //    if (string.IsNullOrWhiteSpace(SearchText))
        //    {
        //        FilteredProducts = new ObservableCollection<Product>(Products);
        //    }
        //    else
        //    {
        //        var filtered = Products.Where(p =>
        //            p.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
        //            p.Category.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
        //            p.Id.ToString().Contains(SearchText)
        //        ).ToList();

        //        FilteredProducts = new ObservableCollection<Product>(filtered);
        //    }
        //}

        // Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
