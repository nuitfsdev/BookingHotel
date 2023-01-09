using BookingHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Order : ContentPage
    {
        public ObservableCollection<Order> dsorder;
        async void  hienthiorder(string makhachhang,string tt = "Đang xử lí")
        {
            HttpClient httpClient = new HttpClient();
            var dsorderList = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/hoadons?makh={makhachhang}&tinhtrang={tt}");
            var dsorderListConverted = JsonConvert.DeserializeObject<List<GetHoaDon>>(dsorderList);
            List<HoaDon> hoaDonList = new List<HoaDon>();
            foreach (var item in dsorderListConverted)
            {
                var hotel = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/hotels?maht={item.maht}");
                var hotelConverted = JsonConvert.DeserializeObject<List<Hotel>>(hotel);
                var room = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/rooms?maroom={item.maroom}");
                var roomConverted = JsonConvert.DeserializeObject<List<Room>>(room);
                string color = "Orange";
                if (item.tinhtrang == "Thành công")
                {
                    color = "Green";
                }
                if (item.tinhtrang == "Đã hủy")
                {
                    color = "Red";
                }
                hoaDonList.Add(new HoaDon {
                    _id=item._id,
                    mahd=item.mahd,
                    hotel = hotelConverted[0],
                    room = roomConverted[0],
                    tenkh=item.tenkh,
                    email=item.email,
                    sdt=item.sdt,
                    ngayhd=item.ngayhd,
                    tinhtrang=item.tinhtrang,
                    gia=item.gia,
                    trigia=item.trigia,
                    ptdatphong=item.ptdatphong,
                    ngaynhan=item.ngaynhan,
                    ngaytra=item.ngaytra,
                    gionhan=item.gionhan,
                    giotra=item.giotra,
                    sogio=item.sogio,
                    songay=item.songay,
                    slnguoilon=item.slnguoilon,
                    sltreem=item.sltreem,
                    slphong=item.slphong,
                    phuongthuc=item.phuongthuc,
                    nganhang=item.nganhang,
                    tennganhang=item.tennganhang,
                    sotaikhoan=item.sotaikhoan,
                    khac=item.khac,
                    createdAt=item.createdAt,
                    updatedAt=item.updatedAt,
                    tinhtrangColor=color
                });
               
            }
            Order_Collection.ItemsSource = hoaDonList;
        }
        public Page_Order()
        {
            InitializeComponent();
            hienthiorder("KH1");
        }

        private async void Search_Btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//main/search");
        }

        private void Order_Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HoaDon order = e.CurrentSelection[0] as HoaDon;
            if (order == null)
                return;
            Order_Collection.SelectedItem = SelectableItemsView.EmptyViewProperty;
            Shell.Current.Navigation.PushAsync(new Page_Order_Detail(order));
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
            hienthiorder("KH1","Đang xử lí");
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
            hienthiorder("KH1", "Thành công");
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
            hienthiorder("KH1", "Đã hủy");

        }
    }
}