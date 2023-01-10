using BookingHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Behaviors;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_User_Info : ContentPage
    {
        public Page_User_Info()
        {
            InitializeComponent();
            User user = App.BookingDb.GetUser();
            user_name.Text = user.name;
            user_email.Text = user.email;
            user_telephone.Text = user.sdt;
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private void change_avatar_Clicked(object sender, EventArgs e)
        {

        }

        private void save_btn_Clicked(object sender, EventArgs e)
        {
            User user = App.BookingDb.GetUser();
            user.name = user_name.Text;
            user.email = user_email.Text;
            user.sdt = user_telephone.Text;
            if(App.BookingDb.UpdateUser(user))
                DisplayAlert("Thông báo","Cập nhật thành công","Ok");
            else
                DisplayAlert("Thông báo", "Thất bại!", "Ok");
        }
    }
}