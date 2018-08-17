using StockApp.Helpers;
using StockApp.Models;
using StockApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace StockApp.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        ApiServices _apiService = new ApiServices();

        public string AccessToken { get; set; }
        private List<ProductModel> _products;
        public ProductModel Product { get; set; }

        public List<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetProductsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accessToken = Settings.AccessToken;
                    Products = await _apiService.GetAllProducts(accessToken);
                });
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
