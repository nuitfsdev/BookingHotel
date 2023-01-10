using BookingHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Order_Detail : ContentPage
    {
        Hotel thishotel;
        Room thisroom;

        void hienthi(HoaDon order)
        {
            thishotel = order.hotel;
            thisroom = order.room;

            //var Room = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/room?maroom={order.maroom}");
            //var RoomConverted = JsonConvert.DeserializeObject<List<Room>>(Room);
            //thisroom = RoomConverted;

            hinh.Source = order.hotel.hinh[0].ToString();
            tenKS.Text = order.hotel.tenht;
            tenphong.Text = order.room.tenphong;
            diachi.Text = thishotel.diachi;
            rate.Text = thishotel.sosao;
            
            adult_qty.Text = String.Format("{0}", order.slnguoilon);
            child_qty.Text = String.Format("{0}", order.sltreem);
            bed_qty.Text = String.Format("{0}", order.slphong);
            checkin_date.Text = order.ngaynhan;
            checkout_date.Text = order.ngaytra;
            timecheckin_date.Text = order.gionhan;
            timecheckout_date.Text= order.giotra;
            create_date.Text = order.ngayhd;
            ptthanhtoan.Text = order.phuongthuc;
            tenkh.Text = order.tenkh;
            email.Text = order.email;
            sdt.Text = order.sdt;
            if (order.tinhtrang == "Đang xử lí") cancle_booking.IsVisible = true;

            //order.kieudat la true la theo gio, false la theo ngay
            if(order.ptdatphong=="Theo giờ")
            {
                follow_time.IsVisible = true;
                follow_day.IsVisible = false;
                total_time.IsVisible = true;
                total_day.IsVisible = false;
                giagio.Text = String.Format("{0:0,0}", order.gia);
                sogio.Text = order.sogio.ToString();
            }
            else
            {
                follow_time.IsVisible = false;
                follow_day.IsVisible = true;
                total_time.IsVisible = false;
                total_day.IsVisible = true;
                giangay.Text = String.Format("{0:0,0}", order.gia);
                songay.Text = order.songay.ToString();

            }
            if (order.phuongthuc == "online")
            {
                ttthanhtoan.IsVisible = true;
                nganhang.Text = order.nganhang;
                tennganhang.Text = order.tennganhang;
                stk.Text = order.sotaikhoan;
            }

            //dientich.Text = "50 m2";
            //desc.Text ="\t"+ thishotel.mota;
            //mota.Text = "\t" + "Phòng xịn nhất";
            //contact.Text = thishotel.lienhe;
            total.Text = String.Format("{0:0,0}", order.trigia);
            request_of_customer.Text = "\t"+ order.khac;

            //Hiện thông tin các tiện ích mà khách sạn đang có
            //if (thishotel.tienichs.Count > 0)
            //    foreach (Tienich item in thishotel.tienichs)
            //    {
            //        StackLayout stack = new StackLayout();
            //        if (item.tienich == "gym")
            //        {
            //            stack = new StackLayout
            //            {

            //                Children = {
            //                    new Image {Source = "nam_gym.png", WidthRequest=30,VerticalOptions=LayoutOptions.Center},
            //                    new Label {Text = "Gym", FontSize=16, VerticalOptions=LayoutOptions.Center, TextColor=Color.Gray},
            //                }
            //            };
            //        }
            //        else if (item.tienich == "hoboi")
            //        {
            //            stack = new StackLayout
            //            {

            //                Children = {
            //                    new Image {Source = "nam_swimmingpool.png", WidthRequest=30,VerticalOptions=LayoutOptions.Center},
            //                    new Label {Text = "Hồ bơi",FontSize=16, VerticalOptions=LayoutOptions.Center, TextColor=Color.Gray},
            //                }
            //            };
            //        }
            //        else if (item.tienich == "bar")
            //        {
            //            stack = new StackLayout
            //            {

            //                Children = {
            //                    new Image {Source = "nam_bar.png", WidthRequest=30,VerticalOptions=LayoutOptions.Center},
            //                    new Label {Text = "Quầy bar",FontSize=16, VerticalOptions=LayoutOptions.Center, TextColor=Color.Gray},
            //                }
            //            };
            //        }
            //        stack.Orientation = StackOrientation.Horizontal;


            //        stack.WidthRequest = 110;

            //        tienich_hotel.Children.Add(stack);
            //    }
            //else
            //{
            //    Label label = new Label { Text = "Đang cập nhật", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Black, Margin = new Thickness(10), FontSize = 20 };
            //    tienich_hotel.Children.Add(label);
            //}
        }

        public  Page_Order_Detail(HoaDon order)
        {
            InitializeComponent();
            hienthi(order);
        }

        private void back_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopAsync();
        }

        private void maphotel_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Hotel_Map(thishotel));
        }

        private void KS_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Hotel(thishotel));
        }

        private void Room_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Room_Info(thishotel,thisroom));
        }
        //private void book_btn_Clicked(object sender, EventArgs e)
        //{

        //}
    }
}