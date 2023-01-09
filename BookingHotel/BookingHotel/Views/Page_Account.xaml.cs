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
    public partial class Page_Account : ContentPage
    {
        public Page_Account()
        {
            InitializeComponent();
            User user = App.BookingDb.GetUser();
            user_name.Text = user.name;
            user_email.Text = user.email;
        }

        private void infomation_Tapped(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync( new Page_User_Info());
        }

        private async void notification_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//main/announcement");
        }

        private void help_Tapped(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Help());
        }

        private void feedback_Tapped(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Feedback());
        }

        private void love_Tapped(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Love());
        }

        private void dangxuat_Clicked(object sender, EventArgs e)
        {
            App.BookingDb.DeleteLoginResponse();
            Shell.Current.GoToAsync("//login");
        }
    }
}