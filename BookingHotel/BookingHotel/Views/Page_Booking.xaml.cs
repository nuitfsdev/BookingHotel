using BookingHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(Setoption), "option")]

    public partial class Page_Booking : ContentPage
    {
        public string Setoption {
            set
            {
                LoadOption(value);
            } 
        }
        void LoadOption(string value)
        {
            if (value == "1")
            {
                uudaiButton();
                hienthiks("https://bookinghotel.onrender.com/hotels?uudai=true");
            }
            else if (value == "2")
            {
                noibatButton();
                hienthiks("https://bookinghotel.onrender.com/hotels?noibat=true");
            }
            else
            {
                allButton();
                hienthiks("https://bookinghotel.onrender.com/hotels");
            }
        }

        async void hienthiks(string urlAPI)
        {
            HttpClient httpClient = new HttpClient();
            var HotelList = await httpClient.GetStringAsync(urlAPI);
            var HotelLoveList = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/loves/hotel?makh={App.BookingDb.GetUser().mauser}");
            var HoteltListConverted = JsonConvert.DeserializeObject<List<Hotel>>(HotelList);
            var HoteltLoveListConverted = JsonConvert.DeserializeObject<List<Hotel>>(HotelLoveList);
            if (HoteltLoveListConverted.Count > 0)
                foreach (Hotel i in HoteltListConverted)
                    if (HoteltLoveListConverted.Any(hotel => hotel.maht == i.maht))
                        i.loveurl = "heart.png";
            Booking_Collection.ItemsSource = HoteltListConverted;
        }

        public Page_Booking()
        {
            InitializeComponent();
            allButton();
            hienthiks("https://bookinghotel.onrender.com/hotels");
        }

        private async void Add_Like_List_Tapped(object sender, EventArgs e)
        {
            ImageButton tab = (ImageButton)sender;
            Hotel hotel = (Hotel)tab.CommandParameter;

            Love_hotel love_Hotel = new Love_hotel();
            love_Hotel.makh = App.BookingDb.GetUser().mauser;
            love_Hotel.maht = hotel.maht;

            HttpClient httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(love_Hotel);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = null;

            if (tab.Source.ToString() == "File: heartWhite.png")
            {
                tab.Source = "heart.png";
                responseMessage = await httpClient.PostAsync($"https://bookinghotel.onrender.com/loves/hotel?makh={love_Hotel.makh}&maht={love_Hotel.maht}",content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _ = DisplayAlert("Thông báo", $"Đã thêm {hotel.tenht} vào yêu thích", "OK");
                }
                else
                {
                    _ = DisplayAlert("Thông báo", $"Thêm {hotel.tenht} vào yêu thích THẤT BẠI", "OK");
                }    
            }
            else
            {
                tab.Source = "heartWhite.png";
                responseMessage = await httpClient.DeleteAsync($"https://bookinghotel.onrender.com/loves/hotel?makh={love_Hotel.makh}&maht={love_Hotel.maht}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    _ = DisplayAlert("Thông báo", $"Đã xóa {hotel.tenht} khỏi yêu thích", "OK");
                }
                else
                {
                    _ = DisplayAlert("Thông báo", $"Xóa {hotel.tenht} vào yêu thích THẤT BẠI", "OK");
                }
            }
        }

        private async void Search_Btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//main/search");
        }

        private void Booking_Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hotel hotel = e.CurrentSelection[0] as Hotel;
            if (hotel == null)
                return;
            Booking_Collection.SelectedItem = SelectableItemsView.EmptyViewProperty;
            Shell.Current.Navigation.PushAsync(new Page_Hotel(hotel));
        }

        private void noibat_Clicked(object sender, EventArgs e)
        {
            noibatButton();
            hienthiks("https://bookinghotel.onrender.com/hotels?noibat=true");
        }

        private void uudai_Clicked(object sender, EventArgs e)
        {
            uudaiButton();
            hienthiks("https://bookinghotel.onrender.com/hotels?uudai=true");
        }

        private void all_Clicked(object sender, EventArgs e)
        {
            allButton();
            hienthiks("https://bookinghotel.onrender.com/hotels");
        }

        void allButton()
        {
            all.TextColor = Color.FromHex("#585de4");
            all.BorderColor = Color.FromHex("#585de4");
            all.FontAttributes = FontAttributes.Bold;
            noibat.TextColor = Color.Gray;
            noibat.BorderColor = Color.FromHex("#ccc");
            noibat.FontAttributes = FontAttributes.None;
            uudai.TextColor = Color.Gray;
            uudai.BorderColor = Color.FromHex("#ccc");
            uudai.FontAttributes = FontAttributes.None;
        }
        void noibatButton()
        {
            all.TextColor = Color.Gray;
            all.BorderColor = Color.FromHex("#ccc");
            all.FontAttributes = FontAttributes.None;
            noibat.TextColor = Color.FromHex("#585de4");
            noibat.BorderColor = Color.FromHex("#585de4");
            noibat.FontAttributes = FontAttributes.Bold;
            uudai.TextColor = Color.Gray;
            uudai.BorderColor = Color.FromHex("#ccc");
            uudai.FontAttributes = FontAttributes.None;
        }
        void uudaiButton()
        {
            all.TextColor = Color.Gray;
            all.BorderColor = Color.FromHex("#ccc");
            all.FontAttributes = FontAttributes.None;
            noibat.TextColor = Color.Gray;
            noibat.BorderColor = Color.FromHex("#ccc");
            noibat.FontAttributes = FontAttributes.None;
            uudai.TextColor = Color.FromHex("#585de4");
            uudai.BorderColor = Color.FromHex("#585de4");
            uudai.FontAttributes = FontAttributes.Bold;
        }

    }     
}