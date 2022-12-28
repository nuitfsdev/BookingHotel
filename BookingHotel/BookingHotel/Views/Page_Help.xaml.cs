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
    public partial class Page_Help : ContentPage
    {
        public Page_Help()
        {
            InitializeComponent();
            this.Content = main_content;
        }

        private void back_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopAsync();
        }
    }
}