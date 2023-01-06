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
        void hienthiorder()
        {
            dsorder = new ObservableCollection<Order>();
            dsorder.Add(new Order { maht = "HT0", maroom = "RM0", tenht = "Khách sạn Hải Âu", tenphong = "Phòng cơ bản", hinh = "https://d2ile4x3f22snf.cloudfront.net/wp-content/uploads/sites/174/2017/08/10060639/Deluxe-3092-700x490.jpg", tinh = "Bình Định", quan = "Phù Mỹ", checkin= "3/1/2022", checkout="4/1/2022", total= 100000, create="1/1/2022", adult=2, child=0, bed=1, timecheckin="19:00",timecheckout="7:00", status= 1, customer_request ="Đây chỉ là test thử 3", kieudat = true });
            dsorder.Add(new Order { maht = "HT2", maroom = "RM9", tenht = "Khách sạn Hải Âu 3", tenphong = "Phòng cơ bản2", hinh = "https://d2ile4x3f22snf.cloudfront.net/wp-content/uploads/sites/174/2017/08/10060639/Deluxe-3092-700x490.jpg", tinh = "Bình Định", quan = "Phù Mỹ", checkin= "3/1/2022", checkout="4/1/2022", total = 100000, create = "1/1/2022", adult = 3, child = 2, bed = 3, timecheckin = "19:00", timecheckout = "7:00", status = 2, customer_request = "Đây chỉ là test thử 2", kieudat = false });
            dsorder.Add(new Order { maht = "HT3", maroom = "RM10", tenht = "Khách sạn Hải Âu 4", tenphong = "Phòng cơ bản2", hinh = "https://d2ile4x3f22snf.cloudfront.net/wp-content/uploads/sites/174/2017/08/10060639/Deluxe-3092-700x490.jpg", tinh = "Bình Định", quan = "Phù Mỹ", checkin= "3/1/2022", checkout="4/1/2022", total = 100000, create = "1/1/2022", adult = 2, child = 0, bed = 1, timecheckin = "20:00", timecheckout = "8:00", status = 3, customer_request = "Đây chỉ là test thử asdf ", kieudat = true });
            dsorder.Add(new Order { maht = "HT1", maroom = "RM5", tenht = "Khách sạn Hải Âu 2", tenphong = "Phòng cơ bản5", hinh = "https://d2ile4x3f22snf.cloudfront.net/wp-content/uploads/sites/174/2017/08/10060639/Deluxe-3092-700x490.jpg", tinh = "Bình Định", quan = "Phù Mỹ", checkin= "3/1/2022", checkout="4/1/2022", total = 100000, create = "1/1/2022", adult = 4, child = 0, bed = 2, timecheckin = "19:00", timecheckout = "9:00", status = 1, customer_request = "Đây chỉ là test thử 234", kieudat = false });
            dsorder.Add(new Order { maht = "HT0", maroom = "RM1", tenht = "Khách sạn Hải Âu", tenphong = "Phòng cơ bản2", hinh = "https://d2ile4x3f22snf.cloudfront.net/wp-content/uploads/sites/174/2017/08/10060639/Deluxe-3092-700x490.jpg", tinh = "Bình Định", quan = "Phù Mỹ", checkin= "3/1/2022", checkout="4/1/2022", total = 100000, create = "1/1/2022", adult = 3, child = 0, bed = 3, timecheckin = "17:00", timecheckout = "12:00", status = 2, customer_request = "Đây chỉ 3 là test thử", kieudat = true });
            dsorder.Add(new Order { maht = "HT1", maroom = "RM6", tenht = "Khách sạn Hải Âu 2", tenphong = "Phòng cơ bản4", hinh = "https://d2ile4x3f22snf.cloudfront.net/wp-content/uploads/sites/174/2017/08/10060639/Deluxe-3092-700x490.jpg", tinh = "Bình Định", quan = "Phù Mỹ", checkin= "3/1/2022", checkout="4/1/2022", total = 100000, create = "1/1/2022", adult = 2, child = 1, bed = 1, timecheckin = "19:00", timecheckout = "9:45", status = 3, customer_request = "Đây chỉ là test thử", kieudat = false });
            dsorder.Add(new Order { maht = "HT0", maroom = "RM2", tenht = "Khách sạn Hải Âu", tenphong = "Phòng cơ bản3", hinh = "https://d2ile4x3f22snf.cloudfront.net/wp-content/uploads/sites/174/2017/08/10060639/Deluxe-3092-700x490.jpg", tinh = "Bình Định", quan = "Phù Mỹ", checkin= "3/1/2022", checkout="4/1/2022", total = 100000, create = "1/1/2022", adult = 3, child = 2, bed = 2, timecheckin = "9:00", timecheckout = "7:30", status = 1, customer_request = "Đây chỉ là testfasf  thử", kieudat = true });
            dsorder.Add(new Order { maht = "HT2", maroom = "RM9", tenht = "Khách sạn Hải Âu 3", tenphong = "Phòng cơ bản2", hinh = "https://d2ile4x3f22snf.cloudfront.net/wp-content/uploads/sites/174/2017/08/10060639/Deluxe-3092-700x490.jpg", tinh = "Bình Định", quan = "Phù Mỹ", checkin= "3/1/2022", checkout="4/1/2022", total = 100000, create = "1/1/2022", adult = 2, child = 0, bed = 1, timecheckin = "16:00", timecheckout = "10:00", status = 2, customer_request = "Đâyafg afg adf a chỉ là test thử", kieudat = false });

            Order_Collection.ItemsSource = dsorder;
        }
        public Page_Order()
        {
            InitializeComponent();
            hienthiorder();
        }

        private async void Search_Btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//main/search");
        }

        private void Order_Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Order order = e.CurrentSelection[0] as Order;
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