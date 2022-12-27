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
    public partial class Page_Room_Info : ContentPage
    {
        Hotel Thishotel;
        Room Thisroom;
        public Page_Room_Info(Hotel hotel ,Room room)
        {
            InitializeComponent();
            Thisroom = room;
            Thishotel = hotel;
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private async void book_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new Page_Booking_Info(Thishotel, Thisroom));
        }
    }
}