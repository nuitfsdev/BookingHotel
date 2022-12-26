using BookingHotel.Models;
using System;
using System.Collections.Generic;
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
        public Page_Hotel(Hotel hotel)
        {
            InitializeComponent();
            hinhKS.Source = hotel.HinhAnhKH;
            tenKS.Text = hotel.TenKH;
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }
    }
}