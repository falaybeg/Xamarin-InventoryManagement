using StockApp.Helpers;
using StockApp.Services;
using StockApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StockApp.ViewModels
{
    public class LoginViewModel
    {
        ApiServices _apiService = new ApiServices();

        public string UserName { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {

                    var accessToken = await _apiService.LoginAsync(UserName, Password);
                    if (accessToken != null)
                    {
                        Settings.AccessToken = accessToken;
                        Application.Current.MainPage = new NavigationPage(new ProductPage(Settings.AccessToken));

                    }
                });
            }
        }
        public LoginViewModel()
        {
            UserName = Settings.Username;
            Password = Settings.Password;
        }
    }
}
