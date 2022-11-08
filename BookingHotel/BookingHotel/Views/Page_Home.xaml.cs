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
    public partial class Page_Home : ContentPage
    {
        public ObservableCollection<Hotel> listHotel;
        public void KhachSanNoiBat()
        {
            listHotel = new ObservableCollection<Hotel>();
            listHotel.Add(new Hotel { MAKH = "0001", HinhAnhKH="hai_au.jpg", TenKH = "Khách sạn Hải Âu", DiaChiChiTiet = "123 Chu Văn An, Phù Mỹ, Bình Định", GiaMin = "100000", GiaMax = "1000000", RateKH =4});
            listHotel.Add(new Hotel { MAKH = "0001", HinhAnhKH = "hoa_binh.jpg", TenKH = "Khách sạn Hoà Bình", DiaChiChiTiet = "123 Chu Văn An, Thủ Đức, TP Hồ Chí Minh", GiaMin = "320000", GiaMax = "10000000", RateKH = 5 });
            listHotel.Add(new Hotel { MAKH = "0001", HinhAnhKH = "nam_ngoc.jpg", TenKH = "Khách sạn Nam Ngọc", DiaChiChiTiet = "Sông Cầu, Phú Yên", GiaMin = "100000", GiaMax = "9000000", RateKH = 4 });
            listHotel.Add(new Hotel { MAKH = "0001", HinhAnhKH = "asia.jpg", TenKH = "Khách sạn Asia", DiaChiChiTiet = "123 Chu Văn An, Thị Trấn Phù Mỹ, Huyện Phù Mỹ, Bình Định", GiaMin = "100000", GiaMax = "1000000", RateKH = 4 });
            listHotel.Add(new Hotel { MAKH = "0001", HinhAnhKH = "hoan_vu.jpg", TenKH = "Khách sạn Hoàn Vũ", DiaChiChiTiet = "123 Chu Văn An, Phù Mỹ, Bình Định", GiaMin = "100000", GiaMax = "1000000", RateKH = 5 });
            khachsannoibat.ItemsSource = listHotel;
        }
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


            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                BannerCarousel.Position = (BannerCarousel.Position + 1) %  indicatorView.Count;
                return true;
            }));
            KhachSanNoiBat();


        }
    }
}