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
    public partial class Page_Search : ContentPage
    {
        public Page_Search()
        {
            InitializeComponent();
        }

        private async void back_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "../" );
        }
    }
}