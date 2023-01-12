using BookingHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Hotel : ContentPage
    {
        Hotel Thishotel;
        public Page_Hotel(Hotel hotel)
        {
            InitializeComponent();
            // 1000 là số giây
            detail.TranslateTo(0,0,1000);
            Thishotel = hotel;
            BannerCarousel.ItemsSource = hotel.hinh;
            tenKS.Text = hotel.tenht;
            diachi.Text = hotel.diachi;
            min.Text = String.Format( "{0:0,0}" , hotel.giamin);
            max.Text = String.Format("{0:0,0 VNĐ}", hotel.giamax);
            rate.Text = hotel.sosao.ToString();
            desc.Text =  hotel.mota;
            contact.Text =hotel.lienhe;
            sale_cost.Text = hotel.giamgia.ToString() + "%";
            //map.Source = hotel.map;

            Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
            {
                BannerCarousel.Position = (BannerCarousel.Position + 1) % indicatorView.Count;
                return true;
            }));

            hienthiksLove(App.BookingDb.GetUser().mauser);

            //Hiện thông tin các tiện ích mà khách sạn đang có
            if (hotel.tienichs.Count > 0)
                foreach(Tienich item in hotel.tienichs)
                {
                    StackLayout stack= new StackLayout();
                    if (item.tienich == "gym")
                    {
                        stack = new StackLayout
                        {

                            Children = {
                                new Image {Source = "nam_gym.png", WidthRequest=30,VerticalOptions=LayoutOptions.Center},
                                new Label {Text = "Gym", FontSize=16, VerticalOptions=LayoutOptions.Center, TextColor=Color.Gray},
                            }
                        };
                    }
                    else if (item.tienich == "hoboi")
                    {
                        stack = new StackLayout
                        {

                            Children = {
                                new Image {Source = "nam_swimmingpool.png", WidthRequest=30,VerticalOptions=LayoutOptions.Center},
                                new Label {Text = "Hồ bơi",FontSize=16, VerticalOptions=LayoutOptions.Center, TextColor=Color.Gray},
                            }
                        };
                    }
                    else if (item.tienich == "bar")
                    {
                        stack = new StackLayout
                        {

                            Children = {
                                new Image {Source = "nam_bar.png", WidthRequest=30,VerticalOptions=LayoutOptions.Center},
                                new Label {Text = "Quầy bar",FontSize=16, VerticalOptions=LayoutOptions.Center, TextColor=Color.Gray},
                            }
                        };
                    }
                    stack.Orientation = StackOrientation.Horizontal;


                    stack.WidthRequest = 110;
                   
                    tienich_hotel.Children.Add(stack);
                }
            else
            {
                Label label = new Label { Text = "Đang cập nhật", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Black, Margin = new Thickness(10), FontSize = 20 };
                tienich_hotel.Children.Add(label);
            } 
                
        }

        async void hienthiksLove(string makh)
        {
            HttpClient httpClient = new HttpClient();
            var HotelList = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/loves/hotel?makh={makh}");
            var HoteltListConverted = JsonConvert.DeserializeObject<List<Hotel>>(HotelList);
            //hiện trái tim đỏ khi đã nằm trong yêu thích
            if (HoteltListConverted.Count > 0)
                foreach (Hotel i in HoteltListConverted)
                    if (i.maht == Thishotel.maht)
                    {
                        Add_Like_List.Source = "heart.png";
                        break;
                    }
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private async void Add_Like_List_Tapped(object sender, EventArgs e)
        {
            ImageButton tab = (ImageButton)sender;
            Hotel hotel = Thishotel;

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
                responseMessage = await httpClient.PostAsync($"https://bookinghotel.onrender.com/loves/hotel?makh={love_Hotel.makh}&maht={love_Hotel.maht}", content);
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

        private void book_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Rooms(Thishotel));
        }

        //private void map_ht_Clicked(object sender, EventArgs e)
        //{
        //    Shell.Current.Navigation.PushAsync(new Page_Hotel_Map(Thishotel));
        //}
        private void maphotel_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Hotel_Map(Thishotel));
        }
    }
}