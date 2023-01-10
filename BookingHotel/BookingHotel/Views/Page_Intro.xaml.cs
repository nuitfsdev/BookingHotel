using BookingHotel.Models;
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
    public partial class Page_Intro : ContentPage
    {
        public Page_Intro()
        {
            InitializeComponent();

            if(App.BookingDb.checkIntro())
            {
                Shell.Current.GoToAsync(state: "//login");
            }    

            List<Banner> bannerList = new List<Banner>();
            bannerList.Add(new Banner { Image = "Banner1.png", Content="Đặt phòng mọi lúc, mọi nơi, với nhiều chương trình khuyến mãi" });
            bannerList.Add(new Banner { Image = "Banner2.png", Content="Thoải mái thanh toán với nhiều phương thức khác nhau" });
            bannerList.Add(new Banner { Image = "Banner3.png", Content="Khách sạn đa dạng, phòng nhiều tùy chọn" });
            bannerList.Add(new Banner { Image = "Banner4.png", Content="Ko biết nữa" });
            bannerList.Add(new Banner { Image = "Banner5.png", Content = "Ko biết nữa" });

            BannerCarousel.ItemsSource = bannerList;

            Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
            {
                BannerCarousel.Position = (BannerCarousel.Position + 1) % indicatorView.Count;
                return true;
            }));
        }

        private async void skip_btn_Clicked(object sender, EventArgs e)
        {
            App.BookingDb.CreateIntro();
            await Shell.Current.GoToAsync(state: "//login");
        }

        private void continue_btn_Clicked(object sender, EventArgs e)
        {
            BannerCarousel.Position = (BannerCarousel.Position + 1) % indicatorView.Count;
        }
    }
}