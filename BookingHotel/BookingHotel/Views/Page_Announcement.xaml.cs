using BookingHotel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Announcement : ContentPage
    {
        public ObservableCollection<Announcement> dstb;
        void hienthitb()
        {
            dstb = new ObservableCollection<Announcement>();
           
            dstb.Add(new Announcement { Hinh = "dat_success.png", Title = "Bạn đã đặt vé thành công", Content="Vé khách sạn 1 đêm Hải Âu của bạn đã được đặt thành công!"});
            dstb.Add(new Announcement { Hinh = "dat_warning.png", Title = "Bạn đã đặt vé thành công", Content="Vé khách sạn 1 đêm Hải Âu của bạn đã được đặt thành công!"});
            dstb.Add(new Announcement { Hinh = "dat_fail.png", Title = "Bạn đã đặt vé thành công", Content="Vé khách sạn 1 đêm Hải Âu của bạn đã được đặt thành công!"});

            Announcement_Collection.ItemsSource = dstb;
        }
        public Page_Announcement()
        {
            InitializeComponent();
            hienthitb();
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "../");
        }
    }
}