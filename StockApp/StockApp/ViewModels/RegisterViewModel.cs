using StockApp.Helpers;
using StockApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace StockApp.ViewModels
{
    class RegisterViewModel
    {
        ApiServices _apiServices = new ApiServices();

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public string PhoneNumber { get; set; }



        public string Message { get; set; }
        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var result = await _apiServices.RegisterAsync(FirstName,LastName,PhoneNumber,CardNumber,Email,Password,ConfirmPassword);
                    Settings.Username = Email;
                    Settings.Password = Password;


                    if (result)
                        Message = "Registered Successfully";
                    else
                        Message = "Please try again !";
                }); 
            }

        }
    }
}
