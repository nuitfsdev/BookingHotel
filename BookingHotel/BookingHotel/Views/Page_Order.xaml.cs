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
    public partial class Page_Order : ContentPage
    {
        public ObservableCollection<Hotel> dsks;
        void hienthiks()
        {
            dsks = new ObservableCollection<Hotel>();
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

            Order_Collection.ItemsSource = dsks;
        }
        public Page_Order()
        {
            InitializeComponent();
            hienthiks();
        }

        private async void Search_Btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//main/search");
        }

        private void Order_Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hotel hotel = e.CurrentSelection[0] as Hotel;
            if (hotel == null)
                return;
            Order_Collection.SelectedItem = SelectableItemsView.EmptyViewProperty;
            Shell.Current.Navigation.PushAsync(new Page_Hotel(hotel));
        }

        private void Active_Clicked(object sender, EventArgs e)
        {
            Active.TextColor = Color.FromHex("#585de4");
            Active.BorderColor = Color.FromHex("#585de4");
            Active.FontAttributes = FontAttributes.Bold;
            Pass.TextColor = Color.Gray;
            Pass.BorderColor = Color.FromHex("#ccc");
            Pass.FontAttributes = FontAttributes.None;
            Cancle.TextColor = Color.Gray;
            Cancle.BorderColor = Color.FromHex("#ccc");
            Cancle.FontAttributes = FontAttributes.None;
        }

        private void Pass_Clicked(object sender, EventArgs e)
        {
            Active.TextColor = Color.Gray;
            Active.BorderColor = Color.FromHex("#ccc");
            Active.FontAttributes = FontAttributes.None;
            Pass.TextColor = Color.FromHex("#585de4");
            Pass.BorderColor = Color.FromHex("#585de4");
            Pass.FontAttributes = FontAttributes.Bold;
            Cancle.TextColor = Color.Gray;
            Cancle.BorderColor = Color.FromHex("#ccc");
            Cancle.FontAttributes |= FontAttributes.None;
        }

        private void Cancle_Clicked(object sender, EventArgs e)
        {
            Active.TextColor = Color.Gray;
            Active.BorderColor = Color.FromHex("#ccc");
            Active.FontAttributes = FontAttributes.None;
            Pass.TextColor = Color.Gray;
            Pass.BorderColor = Color.FromHex("#ccc");
            Pass.FontAttributes = FontAttributes.None;
            Cancle.TextColor = Color.FromHex("#585de4");
            Cancle.BorderColor = Color.FromHex("#585de4");
            Cancle.FontAttributes = FontAttributes.Bold;
        }
    }
}