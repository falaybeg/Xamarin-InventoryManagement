using StockApp.Helpers;
using StockApp.Services;
using StockApp.ViewModels;
using StockApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace StockApp
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            SetMainPage();
			//MainPage = new NavigationPage(new RegisterPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        private void SetMainPage()
        {
            if(!string.IsNullOrEmpty(Settings.AccessToken))
            {
                if(DateTime.UtcNow.AddHours(1) > Settings.AccessTokenExpirationDate)
                {
                    var loginViewModel = new LoginViewModel();
                    loginViewModel.LoginCommand.Execute(null);
                }
                MainPage = new NavigationPage(new ProductPage(Settings.AccessToken));
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }
	}
}
