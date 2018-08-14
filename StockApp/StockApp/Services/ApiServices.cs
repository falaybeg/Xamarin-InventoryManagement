using Newtonsoft.Json;
using StockApp.Models;
using StockApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Services
{
    public class ApiServices
    {

        public async Task<bool> RegisterAsync(string FirstName, string LastName, string PhoneNumber, string CardNumber, string Email, string Password, string ConfirmPassword)
        {
            var client = new HttpClient();

            RegisterBindingModel user = new RegisterBindingModel
            {
                FirstName = FirstName,
                LastName = LastName,
                PhoneNumber = PhoneNumber,
                CardNumber = CardNumber,
                Email = Email,
                Password = Password,
                ConfirmPassword = ConfirmPassword,
            };

            var json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync("http://inventorywebapi.azurewebsites.net/api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }

    }
}
