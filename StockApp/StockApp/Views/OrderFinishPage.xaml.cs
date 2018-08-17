using Android.Widget;
using StockApp.Helpers;
using StockApp.Models;
using StockApp.Services;
using StockApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StockApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderFinishPage : ContentPage
    {
        ProductModel model = null;
        public OrderFinishPage(ProductModel order)
        {
            InitializeComponent();
            this.model = order;
            //  BindingContext = orderInfo;
            ProductCode.Text = model.Code;
            ProductName.Text = model.Name;
            ProductCategory.Text = model.CategoryName;
            ProductPrice.Text = model.SellingPrice.ToString();
        }

        private async void FinishOrder_Clicked(object sender, System.EventArgs e)
        {
            ApiServices _api = new ApiServices();

            OrderModel order = new OrderModel
            {
                ProductId = model.Id,
                ShippingAddress = ShippingAddress.Text
            };

            var result = await _api.MakeOrder(order, Settings.AccessToken);
            if(result)
            {
                await DisplayAlert("Success", "Ordering has been completed", "OK");
                await Navigation.PushAsync(new MyOrdersPage());
            }
            else
            {
                await DisplayAlert("Error", "Encountered with error !", "OK");
            }

        }


       
    }
}