using BookingHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Logo : ContentPage
    {
        public Page_Logo()
        {
            InitializeComponent();
            
           
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GoToMaster();
        }

        private async void GoToMaster()
        {
            await Task.Delay(4000);
            await Shell.Current.GoToAsync(state: "//intro");
           
        }
    }
}