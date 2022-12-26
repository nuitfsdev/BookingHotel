using BookingHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Booking_Info : ContentPage
    {
        Hotel Thishotel;
        public Page_Booking_Info(Hotel hotel)
        {
            InitializeComponent();
            Thishotel = hotel;
            hinhKS.Source = hotel.HinhAnhKH;
            tenKS.Text = hotel.TenKH;
            tinh.Text = hotel.Tinh;
            quan.Text = hotel.QuanHuyen;
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private void book_btn_Clicked(object sender, EventArgs e)
        {

        }
    }
}