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
    public partial class Page_Register : ContentPage
    {
        public Page_Register()
        {
            InitializeComponent();
        }

        private void login_btn_Tapped(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(state: "//login");
        }

        private void Register_btn_Clicked(object sender, EventArgs e)
        {

        }
    }
}