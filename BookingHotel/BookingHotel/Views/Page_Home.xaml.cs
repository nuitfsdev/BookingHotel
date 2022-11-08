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
    public partial class Page_Home : ContentPage
    {
        public Page_Home()
        {
            InitializeComponent();
            List<Banner> bannerList = new List<Banner>();
            bannerList.Add(new Banner { Image="Banner1.png"});
            bannerList.Add(new Banner { Image = "Banner2.png" });
            bannerList.Add(new Banner { Image = "Banner3.png" });
            bannerList.Add(new Banner { Image = "Banner4.png" });
            bannerList.Add(new Banner { Image = "Banner5.png" });

            BannerCarousel.ItemsSource = bannerList;
            NoiBatCarousel.ItemsSource = bannerList;

            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                BannerCarousel.Position = (BannerCarousel.Position + 1) %  indicatorView.Count;
                return true;
            }));

        }
    }
}