using StockApp.Helpers;
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

        private async void NavigateButton_Clicked(object sender, EventArgs e)
        {
            if(Settings.AccessToken != null)
            {
                await Navigation.PushAsync(new ProductPage());
            }
        }
    }
}