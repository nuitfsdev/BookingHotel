using BookingHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Rooms : ContentPage
    {
        Hotel Thishotel;
        Room Thisroom;

        async void hienthir(string urlAPI)
        {
            HttpClient httpClient = new HttpClient();
            var RoomlList = await httpClient.GetStringAsync(urlAPI);
            var RoomltListConverted = JsonConvert.DeserializeObject<List<Room>>(RoomlList);
            Rooms_Collection.ItemsSource = RoomltListConverted;
        }

        public Page_Rooms(Hotel hotel)
        {
            InitializeComponent();
            Thishotel = hotel;
            hienthir($"https://bookinghotel.onrender.com/rooms?maht={hotel.maht}");

            //Room room = (Room)book_room_btn.CommandBinding;
            //foreach (string tienich in room.tienich)
            //{
            //    StackLayout stack = new StackLayout
            //    {
            //        Orientation = StackOrientation.Horizontal,
            //        Padding = new Thickness(0, 0, 10, 0),
            //        HeightRequest = 20,
            //        Children = {
            //            new Image {Source = "dat_wifi.png", WidthRequest=50, Margin= new Thickness(0,5,0,0), HeightRequest=10, VerticalOptions = LayoutOptions.Start},
            //            new Label {Text = tienich, TextColor=Color.Black},
            //        }
            //    };
               
            //}
        }

        private void book_btn_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Room room = (Room)btn.CommandParameter;
            Shell.Current.Navigation.PushAsync(new Page_Booking_Info(Thishotel, room));
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private void Rooms_Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Thisroom = e.CurrentSelection[0] as Room;
            if (Thisroom == null)
                return;
            Rooms_Collection.SelectedItem = SelectableItemsView.EmptyViewProperty;
            Shell.Current.Navigation.PushAsync(new Page_Room_Info(Thishotel, Thisroom));
        }
    }
}