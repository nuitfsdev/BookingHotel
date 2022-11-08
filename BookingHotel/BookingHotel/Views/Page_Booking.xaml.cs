using BookingHotel.Models;
using Syncfusion.XForms.PopupLayout;
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
    public partial class Page_Booking : ContentPage
    {
        public ObservableCollection<Hotel> dsks;
        void hienthiks()
        {
            dsks= new ObservableCollection<Hotel>();
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });

            Booking_Collection.ItemsSource = dsks;
        }

        public Page_Booking()
        {
            InitializeComponent();
            hienthiks();
        }

        private void Add_Like_List_Tapped(object sender, EventArgs e)
        {
            Image tab =(Image)sender;
            if(tab.Source.ToString() == "File: heartWhite.png")
            {
                tab.Source = "heart.png";
                DisplayAlert("Thông báo","Đã thêm vào yêu thích","OK");
            }
            else
            {
                tab.Source = "heartWhite.png";
            }
        }

        private void Booking_filter_btn_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender; 

        }
    }
}