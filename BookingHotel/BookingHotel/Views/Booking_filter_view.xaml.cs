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
    public partial class Booking_filter_view : ContentView
    {

        public Booking_filter_view()
        {
            InitializeComponent();
            string []picker_list_Tinh = {"Thành phố Hồ Chí Minh","Thành phố Hà Nội", "Thành phố Hải Phòng","Quảng Nghãi" };
            Booking_filter_Tinh.ItemsSource = picker_list_Tinh;
            string []picker_list_Quan_Huyen = {"Thủ Đức","Quận 1", "Quận 5","Thủ Thừa" };
            Booking_filter_Quan_Huyen.ItemsSource = picker_list_Quan_Huyen;
        }

        private void Booking_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pic = (Picker)sender;
            int item = pic.SelectedIndex;
            //Dùng item lưu index sau đó dùng index để lọc
        }

        private void Delete_all_Clicked(object sender, EventArgs e)
        {
            Booking_filter_Tinh.SelectedIndex = -1;
            Booking_filter_Quan_Huyen.SelectedIndex = -1;

        }

        private void Filter_btn_Clicked(object sender, EventArgs e)
        {

        }

        private void Back_btn_Clicked(object sender, EventArgs e)
        {
            ContentViewBookingFilter.IsVisible = false;
        }
    }
}