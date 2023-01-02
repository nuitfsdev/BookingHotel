using BookingHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Find_Room : ContentPage
    {
        Hotel thishotel;
        async void hienthiks(string urlAPI)
        {
            HttpClient httpClient = new HttpClient();
            var HotelList = await httpClient.GetStringAsync(urlAPI);
            var HoteltListConverted = JsonConvert.DeserializeObject<List<Room>>(HotelList);
            RoomList_Collection.ItemsSource = HoteltListConverted;
        }

        public Page_Find_Room()
        {
            InitializeComponent();
            hienthiks("https://bookinghotel.onrender.com/rooms");
        }

        private void RoomList_Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room room = e.CurrentSelection[0] as Room;
            if (room == null)
                return;
            RoomList_Collection.SelectedItem = SelectableItemsView.EmptyViewProperty;
            LayHotel(room.maht);
            Shell.Current.Navigation.PushAsync(new Page_Room_Info(thishotel,room));
        }

        private void Filter_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Filter());
        }

        private void book_btn_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Room room = (Room)btn.CommandParameter;
            LayHotel(room.maht);
            Shell.Current.Navigation.PushAsync(new Page_Booking_Info(thishotel, room));
        }

        async void LayHotel(string maht)
        {
            HttpClient httpClient = new HttpClient();
            var Hotel = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/hotels?maht={maht}");
            var HotelConverted = JsonConvert.DeserializeObject<List<Hotel>>(Hotel);
            thishotel = HotelConverted[0];
        }

        private void KS_btn_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Room room = (Room)btn.CommandParameter;
            LayHotel(room.maht);
            Shell.Current.Navigation.PushAsync(new Page_Hotel(thishotel));
        }
    }
}