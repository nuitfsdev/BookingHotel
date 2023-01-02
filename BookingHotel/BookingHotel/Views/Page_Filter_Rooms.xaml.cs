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
    public partial class Page_Filter_Rooms : ContentPage
    {
        public Page_Filter_Rooms()
        {
            InitializeComponent();
        }

        private void back_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopAsync();
        }

        private void clear_btn_Tapped(object sender, EventArgs e)
        {

        }

        private void tinh_filter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void quan_filter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}