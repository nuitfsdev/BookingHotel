using BookingHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var HoteltListConverted = JsonConvert.DeserializeObject<List<Hotel>>(HotelList);
            Booking_Collection.ItemsSource = HoteltListConverted;
        }

        //public Page_Booking()
        //{
        //    InitializeComponent();
        //    hienthiks("https://bookinghotel.onrender.com/hotels");
        //}

        public Page_Booking()
        {

            InitializeComponent();
            //1 la uu dai
            //2 la noi bat

            //textOption.IsVisible = false;
            //DisplayAlert("TB",textOption.Text, "OK");
            //if (textOption.Text == "1")
            //{
            //    uudaiButton();
            //    hienthiks("https://bookinghotel.onrender.com/hotels?uudai=true");
            //}
            //else if (textOption.Text == "2")
            //{
            //    noibatButton();
            //    hienthiks("https://bookinghotel.onrender.com/hotels?noibat=true");
            //}
            //else
            //{
            //    allButton();
            //    hienthiks("https://bookinghotel.onrender.com/hotels");
            //}
            allButton();
            hienthiks("https://bookinghotel.onrender.com/hotels");

        }

        private void Add_Like_List_Tapped(object sender, EventArgs e)
        {
            ImageButton tab = (ImageButton)sender;
            Hotel hotel = (Hotel)tab.CommandParameter;

            if (tab.Source.ToString() == "File: heartWhite.png")
            {
                tab.Source = "heart.png";
                DisplayAlert("Thông báo", $"Đã thêm {hotel.tenht} vào yêu thích", "OK");
            }
            else
            {
                tab.Source = "heartWhite.png";
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