using BookingHotel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            hinhKS.Source = hotel.HinhAnhKH;
            tenKS.Text = hotel.TenKH;
            tinh.Text = hotel.Tinh;
            quan.Text = hotel.QuanHuyen;
            min.Text = hotel.GiaMin;
            max.Text = hotel.GiaMax;
            rate.Text = hotel.RateKH.ToString();
            desc.Text = hotel.Mota;
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private void Add_Like_List_Tapped(object sender, EventArgs e)
        {
            Image tab = (Image)sender;
            if (tab.Source.ToString() == "File: heartWhite.png")
            {
                tab.Source = "heart.png";
                DisplayAlert("Thông báo", "Đã thêm vào yêu thích", "OK");
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
    }
}