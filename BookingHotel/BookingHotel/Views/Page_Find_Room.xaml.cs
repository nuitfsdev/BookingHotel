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
    public partial class Page_Find_Room : ContentPage
    {
        public Page_Find_Room()
        {
            InitializeComponent();
        }

        private void tinh_filter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void quan_filter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void people_decre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(People.Text);
            if (old_value > 1)
                People.Text = $"{old_value - 1}";
        }

        private void people_incre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(People.Text);
            People.Text = $"{old_value + 1}";
        }

        private void bed_decre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(People.Text);
            if (old_value > 1)
                Bed.Text = $"{old_value - 1}";
        }

        private void bed_incre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(People.Text);
            Bed.Text = $"{old_value + 1}";
        }

        private void book_btn_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}