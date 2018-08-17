using Newtonsoft.Json;
using System.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using StockApp.ViewModels;
using StockApp.Models;
using Newtonsoft.Json.Linq;
using StockApp.Helpers;

namespace StockApp.Services
{
    public class ApiServices
    {
        HttpClient client = new HttpClient(new Xamarin.Android.Net.AndroidClientHandler());



        public async Task<bool> RegisterAsync(string FirstName, string LastName, string PhoneNumber, string CardNumber, string Email, string Password, string ConfirmPassword)
        {

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

            var response = await client.PostAsync(Constants.BaseApiAddress + "api/Account/Register", content);

            return response.IsSuccessStatusCode;
        }


        public async Task<string> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, Constants.BaseApiAddress + "Token");
            request.Content = new FormUrlEncodedContent(keyValues);
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(content);

            var accessToken = jwtDynamic.Value<string>("access_token");
            var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");


            if (accessToken != null)
            {
                Settings.AccessToken = accessToken;
                Settings.AccessTokenExpirationDate = accessTokenExpiration;
                Debug.WriteLine(content);
                return accessToken;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ProductModel>> GetAllProducts(string accessToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/Products");

            var products = JsonConvert.DeserializeObject<List<ProductModel>>(json);

            return products;
        }

        public async Task<bool> MakeOrder(OrderModel order, string accessToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);
            

            var json = JsonConvert.SerializeObject(order);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(Constants.BaseApiAddress + "api/Orders", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<OrderModel>> GetMyOrders(string accessToken)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer", accessToken);

            var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/Orders/GetMyOrders");

            var myOrders = JsonConvert.DeserializeObject<List<OrderModel>>(json);

            return myOrders;
        }



    }
}
