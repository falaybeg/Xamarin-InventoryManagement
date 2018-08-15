using StockApp.Helpers;
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
                MainPage = new NavigationPage(new ProductPage());
            }
            else if(!string.IsNullOrEmpty(Settings.Username) && !string.IsNullOrEmpty(Settings.Password))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new RegisterPage());
            }
        }
	}
}
