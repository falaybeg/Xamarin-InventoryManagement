using System;
using System.Collections.Generic;
using System.Text;

namespace StockApp.Models
{
    public class RegisterBindingModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CardNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}
