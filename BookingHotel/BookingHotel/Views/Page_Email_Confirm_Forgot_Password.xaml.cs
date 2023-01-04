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
    public partial class Page_Email_Confirm_Forgot_Password : ContentPage
    {
        public Page_Email_Confirm_Forgot_Password()
        {
            InitializeComponent();
        }

        private void Confirm_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Confirm());
        }

        private void login_btn_Tapped(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopAsync();
        }

        private void register_btn_Tapped(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Register());
        }
    }
}