using BookingHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Test : ContentPage
    {
        public Page_Test()
        {
            InitializeComponent();
            hienthiks();

        }

         async void hienthiks()
        {
            HttpClient httpClient = new HttpClient();
            var subjectList = await httpClient.GetStringAsync("https://bookinghotel.onrender.com/hotels");
            var subjectListConverted = JsonConvert.DeserializeObject<List<HotelTest>>(subjectList);
            Rooms_Collection.ItemsSource = subjectListConverted;
        }

        private void back_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopAsync();

        }

        private void book_btn_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            HotelTest hotel = (HotelTest)button.CommandParameter;

            DisplayAlert("Thong bao",$"{hotel._id}","Ok" );
        }
    }
}