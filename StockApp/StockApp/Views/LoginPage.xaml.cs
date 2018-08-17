using StockApp.Helpers;
using StockApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StockApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
            InitializeComponent();
        }

        private async void RegisterPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void HomePage_Clicked(object sender, EventArgs e)
        {
            if(Settings.AccessToken != null)
            {
                await Navigation.PushAsync(new ProductPage(Settings.AccessToken));
            }
            else
            {
                await DisplayAlert("Alert", "Internet Connection Error !", "OK");
                await Navigation.PushAsync(new LoginPage());
            }
        }
    }
}