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
    public class OrderViewModel : INotifyPropertyChanged
    {
        ApiServices _api = new ApiServices();

        public ProductModel OrderProduct { get; set; }

        private List<OrderModel> _orders;
        public List<OrderModel> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }



        public ICommand FinishOrderCommand
        {
            get
            {
                return new Command(async () => {

                    OrderModel order = new OrderModel
                    {
                        ProductId = OrderProduct.Id,

                    };
                    await _api.MakeOrder(order, Settings.AccessToken);
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
