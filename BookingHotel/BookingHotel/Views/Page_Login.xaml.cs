using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Login : ContentPage
    {
        public Page_Login()
        {
            InitializeComponent();
        }

        private async void Login_Btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//main");

        }

        private void register_btn_Tapped(object sender, EventArgs e)
        {

        }
    }
}