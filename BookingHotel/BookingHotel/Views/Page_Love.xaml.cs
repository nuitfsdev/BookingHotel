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
    public partial class Page_Love : ContentPage
    {
        Hotel Thishotel;
        Room Thisroom;

        User user = App.BookingDb.GetUser();
        async void hienthiks(string urlAPI)
        {
            HttpClient httpClient = new HttpClient();
            var subjectList = await httpClient.GetStringAsync(urlAPI);
            var subjectListConverted = JsonConvert.DeserializeObject<List<Hotel>>(subjectList);
            Love_Collection.ItemsSource = subjectListConverted;
        }

        async void hienthidsroom(string urlAPI)
        {
            HttpClient httpClient = new HttpClient();
            var subjectList = await httpClient.GetStringAsync(urlAPI);
            var subjectListConverted = JsonConvert.DeserializeObject<List<Room>>(subjectList);
            Room_Collection.ItemsSource = subjectListConverted;
        }

        public Page_Love()
        {
            InitializeComponent();
            hienthiks($"https://bookinghotel.onrender.com/loves/hotel?makh={user.mauser}");
            hienthidsroom($"https://bookinghotel.onrender.com/loves/room?makh={user.mauser}");
        }

        private async void Search_Btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//main/search");
        }

        private void Love_Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hotel hotel = e.CurrentSelection[0] as Hotel;
            if (hotel == null)
                return;
            Love_Collection.SelectedItem = SelectableItemsView.EmptyViewProperty;
            Shell.Current.Navigation.PushAsync(new Page_Hotel(hotel));
        }

        private void book_btn_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Hotel hotel = (Hotel)button.CommandParameter;
            Shell.Current.Navigation.PushAsync(new Page_Hotel(hotel));
        }

        private void back_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopAsync();
        }

        private void ks_btn_Clicked(object sender, EventArgs e)
        {
            hienthiks($"https://bookinghotel.onrender.com/loves/hotel?makh={user.mauser}");
            ks_underline.IsVisible = true;
            room_underline.IsVisible = false;
            Love_Collection.IsVisible = true;
            Room_Collection.IsVisible = false;
            if (Love_Collection.ItemsSource == null)
            {
                loading_gif.IsVisible = false;
                NullList.IsVisible = true;
            }    
        }

        private void room_btn_Clicked(object sender, EventArgs e)
        {
            hienthidsroom($"https://bookinghotel.onrender.com/loves/room?makh={user.mauser}");
            ks_underline.IsVisible = false;
            room_underline.IsVisible = true;
            Love_Collection.IsVisible = false;
            Room_Collection.IsVisible = true;
            if (Room_Collection.ItemsSource == null)
            {
                room_loading_gif.IsVisible = false;
                RoomNullList.IsVisible = true;
            }
        }

        private async void Room_Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room room = e.CurrentSelection[0] as Room;
            if (room == null)
                return;
            Room_Collection.SelectedItem = SelectableItemsView.EmptyViewProperty;

            HttpClient httpClient = new HttpClient();
            var Hotel = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/hotels?maht={room.maht}");
            var HotelConverted = JsonConvert.DeserializeObject<List<Hotel>>(Hotel);

            await Shell.Current.Navigation.PushAsync(new Page_Room_Info(HotelConverted[0], room));
        }

        private async void KS_btn_Clicked_1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Room room = (Room)btn.CommandParameter;

            HttpClient httpClient = new HttpClient();
            var Hotel = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/hotels?maht={room.maht}");
            var HotelConverted = JsonConvert.DeserializeObject<List<Hotel>>(Hotel);

            await Shell.Current.Navigation.PushAsync(new Page_Hotel(HotelConverted[0]));
        }

        private async void book_btn_Clicked_1(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Room room = (Room)btn.CommandParameter;

            HttpClient httpClient = new HttpClient();
            var Hotel = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/hotels?maht={room.maht}");
            var HotelConverted = JsonConvert.DeserializeObject<List<Hotel>>(Hotel);

            await Shell.Current.Navigation.PushAsync(new Page_Booking_Info(HotelConverted[0], room));
        }

        private void Add_Like_List_Clicked(object sender, EventArgs e)
        {
            ImageButton tab = (ImageButton)sender;
            Hotel hotel = (Hotel)tab.CommandParameter;

            if (tab.Source.ToString() == "File: heart.png")
            {
                tab.Source = "heartWhite.png";
                DisplayAlert("Thông báo", $"Đã xóa {hotel.tenht} khỏi danh sách yêu thích", "OK");
            }
            else
            {
                tab.Source = "heart.png";
            }
        }

        private async void Hotel_SwipeItem_Invoked(object sender, EventArgs e)
        {
            SwipeItem swipeItem = (SwipeItem)sender;
            Hotel hotel = swipeItem.CommandParameter as Hotel;
            bool answer = await DisplayAlert("Cảnh báo", $"Bạn thật sự muốn xóa {hotel.tenht} khỏi danh sách yêu thích", "Yes", "No");
            if (answer)
            {
                HttpClient httpClient = new HttpClient();
                Love_hotel love_Hotel = new Love_hotel();
                love_Hotel.makh = App.BookingDb.GetUser().mauser;
                love_Hotel.maht = hotel.maht;

                HttpResponseMessage responseMessage = null;
                responseMessage = await httpClient.DeleteAsync($"https://bookinghotel.onrender.com/loves/hotel?makh={love_Hotel.makh}&maht={love_Hotel.maht}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    _ = DisplayAlert("Thông báo", $"Đã xóa {hotel.tenht} khỏi yêu thích", "OK");
                    hienthiks($"https://bookinghotel.onrender.com/loves/hotel?makh={user.mauser}");
                }
                else
                {
                    _ = DisplayAlert("Thông báo", $"Xóa {hotel.tenht} vào yêu thích THẤT BẠI", "OK");
                }
            }
        }
        private async void Room_SwipeItem_Invoked(object sender, EventArgs e)
        {
            SwipeItem swipeItem = (SwipeItem)sender;
            Room room = swipeItem.CommandParameter as Room;
            bool answer = await DisplayAlert("Cảnh báo", $"Bạn thật sự muốn xóa {room.tenphong} khỏi danh sách yêu thích", "Yes", "No");
            if (answer)
            {
                HttpClient httpClient = new HttpClient();
                Love_room love_Room = new Love_room();
                love_Room.makh = App.BookingDb.GetUser().mauser;
                love_Room.maroom = room.maroom;

                HttpResponseMessage responseMessage = null;
                responseMessage = await httpClient.DeleteAsync($"https://bookinghotel.onrender.com/loves/room?makh={love_Room.makh}&maroom={love_Room.maroom}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    _ = DisplayAlert("Thông báo", $"Đã xóa {room.tenphong} khỏi yêu thích", "OK");
                    hienthidsroom($"https://bookinghotel.onrender.com/loves/room?makh={user.mauser}");
                }
                else
                {
                    _ = DisplayAlert("Thông báo", $"Xóa {room.tenphong} vào yêu thích THẤT BẠI", "OK");
                }
            }
        }
        
    }
}