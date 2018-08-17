using StockApp.Helpers;
using StockApp.Models;
using StockApp.Services;
using StockApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StockApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyOrdersPage : ContentPage
    {
        private ObservableCollection<OrderModel> items = new ObservableCollection<OrderModel>();
        ApiServices _api = new ApiServices();

        public MyOrdersPage()
        {
            InitializeComponent();
            Init();
        }


        public async void Init()
        {
            var prod = await _api.GetMyOrders(Settings.AccessToken);
            foreach(var item in prod)
            {
                items.Add(item);
            }
            OrderListView.ItemsSource = this.items;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage(Settings.AccessToken));
        }
    }
}