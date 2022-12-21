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
    public partial class Page_Filter : ContentPage
    {
        public Page_Filter()
        {
            InitializeComponent();
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "../");
        }

        private void clear_btn_Tapped(object sender, EventArgs e)
        {

        }
    }
}