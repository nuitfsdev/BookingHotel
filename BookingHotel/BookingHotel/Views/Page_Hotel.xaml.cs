using BookingHotel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            Thishotel = hotel;
            BannerCarousel.ItemsSource = hotel.hinh;
            tenKS.Text = hotel.tenht;
            diachi.Text = hotel.diachi;
            min.Text = String.Format( "{0:0,0}" , hotel.giamin);
            max.Text = String.Format("{0:0,0 vnđ}", hotel.giamax);
            rate.Text = hotel.sosao.ToString();
            desc.Text = "\t" + hotel.mota;
            contact.Text ="\t" + hotel.lienhe;
            //map.Source = hotel.map;

            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                BannerCarousel.Position = (BannerCarousel.Position + 1) % indicatorView.Count;
                return true;
            }));

            //Hiện thông tin các tiện ích mà khách sạn đang có
            foreach(string tienich in hotel.tienich)
            {
                StackLayout stack = new StackLayout
                {
                    Children = {
                        new Image {Source = "dat_wifi.png", WidthRequest=50, Margin= new Thickness(20,10)},
                        new Label {Text = tienich, HorizontalOptions=LayoutOptions.CenterAndExpand, TextColor=Color.Black, Margin=new Thickness(0,-10,0,0)},
                    }
                };
                tienich_hotel.Children.Add(stack);
            }    
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private void Add_Like_List_Tapped(object sender, EventArgs e)
        {
            ImageButton tab = (ImageButton)sender;
            if (tab.Source.ToString() == "File: heartWhite.png")
            {
                tab.Source = "heart.png";
                DisplayAlert("Thông báo", $"Đã thêm {Thishotel.tenht} vào yêu thích", "OK");
            }
            else
            {
                tab.Source = "heartWhite.png";
            }
        }

        private void book_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Rooms(Thishotel));
        }

        private void map_ht_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Hotel_Map(Thishotel));
        }
    }
}