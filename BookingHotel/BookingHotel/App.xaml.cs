using BookingHotel.Models;
using BookingHotel.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel
{
    public partial class App : Application
    {
        public static BookingDatabase BookingDb = new BookingDatabase();
        public static string quick_checkinday = "";
        public static string quick_checkoutday = "";
        public static string quick_tinh = "";
        public static string quick_quan = "";
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
