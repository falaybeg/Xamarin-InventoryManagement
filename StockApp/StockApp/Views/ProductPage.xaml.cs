using StockApp.Helpers;
using StockApp.Models;
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
	public partial class ProductPage : ContentPage
	{
        public ProductPage ()
		{
            InitializeComponent();
        }
    }
}