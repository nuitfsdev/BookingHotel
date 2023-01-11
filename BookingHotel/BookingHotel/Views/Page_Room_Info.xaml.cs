using BookingHotel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Markup;
using Newtonsoft.Json;
using System.Net.Http;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Room_Info : ContentPage
    {
        Hotel Thishotel;
        Room Thisroom;
        public Page_Room_Info(Hotel hotel ,Room room)
        {
            InitializeComponent();
            // 1000 là số giây
            detail.TranslateTo(0, 0, 1000);
            Thisroom = room;
            Thishotel = hotel;
            hienthiphongLove(App.BookingDb.GetUser().mauser);
             bannerCarousel.ItemsSource= room.hinh;
            tenphong.Text = room.tenphong;
            theogio.Text = String.Format("{0:0,0}", room.giagio);
            theongay.Text = String.Format("{0:0,0}", room.giangay);
            dientich.Text = String.Format("{0} m²", room.dientich);
            mota.Text = room.mota;
            loaiphong.Text = room.loaiphong;
            sogiuong.Text = room.sogiuong.ToString();
            Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
            {
                bannerCarousel.Position = (bannerCarousel.Position + 1) % indicatorView.Count;
                return true;
            }));
            if (room.noibat == false)
                noibat.IsVisible = false;

            if (room.uudai==false)
                uudai.IsVisible = false;

            //hiện danh sách tiện nghi của phòng
            if (room.tienichs.Count > 0)
                foreach (TienIchRoom item in room.tienichs)
                {
                    StackLayout stack = new StackLayout
                    {
                        Children = {
                            new Image {Source = item.hinh, WidthRequest=50, Margin= new Thickness(20,10)},
                            new Label {Text = item.tienich, HorizontalOptions=LayoutOptions.CenterAndExpand, FontSize=16, TextColor=Color.Black, Margin=new Thickness(0,-10,0,0)},
                        }
                    };
                    tienichlist.Children.Add(stack);
                }
            else
            {
                Label label = new Label { Text = "Đang cập nhật", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Black, Margin = new Thickness(10), FontSize = 20 };
                tienichlist.Children.Add(label);
            }    
        }

        async void hienthiphongLove(string makh)
        {
            HttpClient httpClient = new HttpClient();
            var RoomList = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/loves/room?makh={makh}");
            var RoomListConverted = JsonConvert.DeserializeObject<List<Room>>(RoomList);
            //hiện trái tim đỏ khi đã nằm trong yêu thích
            if (RoomListConverted.Count > 0)
                foreach (Room i in RoomListConverted)
                    if (i.maroom == Thisroom.maroom)
                    {
                        Add_Like_List.Source = "heart.png";
                        break;
                    }
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private async void book_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new Page_Booking_Info(Thishotel, Thisroom));
        }

        private async void Add_Like_List_Clicked(object sender, EventArgs e)
        {
            ImageButton tab = (ImageButton)sender;
            Room room = Thisroom;

            Love_room love_room = new Love_room();
            love_room.makh = App.BookingDb.GetUser().mauser;
            love_room.maroom = room.maroom;

            HttpClient httpClient = new HttpClient();
            string json = JsonConvert.SerializeObject(love_room);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = null;

            if (tab.Source.ToString() == "File: heartWhite.png")
            {
                tab.Source = "heart.png";
                responseMessage = await httpClient.PostAsync($"https://bookinghotel.onrender.com/loves/room?makh={love_room.makh}&maroom={love_room.maroom}", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _ = DisplayAlert("Thông báo", $"Đã thêm {room.tenphong} vào yêu thích", "OK");
                }
                else
                {
                    _ = DisplayAlert("Thông báo", $"Thêm {room.tenphong} vào yêu thích THẤT BẠI", "OK");
                }
            }
            else
            {
                tab.Source = "heartWhite.png";
                responseMessage = await httpClient.DeleteAsync($"https://bookinghotel.onrender.com/loves/room?makh={love_room.makh}&maroom={love_room.maroom}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    _ = DisplayAlert("Thông báo", $"Đã xóa {room.tenphong} khỏi yêu thích", "OK");
                }
                else
                {
                    _ = DisplayAlert("Thông báo", $"Xóa {room.tenphong} vào yêu thích THẤT BẠI", "OK");
                }
            }
        }
    }
}