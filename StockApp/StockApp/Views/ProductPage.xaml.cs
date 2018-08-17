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
    public partial class ProductPage : ContentPage
    {
        private ObservableCollection<ProductModel> items = new ObservableCollection<ProductModel>();
        ApiServices _api = new ApiServices();

        public ProductPage(string accessToken)
        {
            InitializeComponent();
            Init(accessToken);
            DisplayAlert("Alert", "For making order click on selected product item !", "OK");

        }

        public async void Init(string accessToken)
        {
            var prod = await _api.GetAllProducts(accessToken);

            foreach (var item in prod)
            {
                items.Add(item);
            }
            ProductListView.ItemsSource = this.items;
        }


        //private void MakeOrderClick(object sender, EventArgs e)
        //{
        //    var button = sender as Button;
        //    var product = button?.BindingContext as ProductModel;
        //    var vm = BindingContext as ProductViewModel;
        //  //  vm.MakeOrderCommand.Execute(product);


        //    //var item = (MenuItem)sender;
        //    //var model = (ProductModel)item.CommandParameter;
        //    //await _api.MakeOrder(model.Id, Settings.AccessToken);
        //}

        private async void ProductListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var action = await DisplayAlert("", "Do you want to order this product ?", "Yes", "No");
            if (action)
            {
                var product = e.Item as ProductModel;
                await Navigation.PushAsync(new OrderFinishPage(product));
            }
        }

        private async void MyOrders_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyOrdersPage());
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            Settings.AccessToken = "";
            Settings.Username = "";
            Settings.Password = "";
            await Navigation.PushAsync(new LoginPage());
        }


    }
}