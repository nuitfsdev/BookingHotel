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
        HoaDon thisorder;

        void hienthi(HoaDon order)
        {
            thisorder = order;
            thishotel = order.hotel;
            thisroom = order.room;

            hinh.Source = order.hotel.hinh[0].ToString();
            tenKS.Text = order.hotel.tenht;
            tenphong.Text = order.room.tenphong;
            diachi.Text = thishotel.diachi;
            rate.Text = thishotel.sosao;
            madp.Text = order.mahd;
            hinh_r.Source = order.room.hinh[0];
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

            total.Text = String.Format("{0:0,0}", order.trigia);
            request_of_customer.Text = "\t"+ order.khac;
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

        private async void cancle_Tapped(object sender, EventArgs e)
        {
             bool answer=await DisplayAlert("Cảnh báo", "Bạn có chắc chắn hủy đơn đặt phòng này không?", "Ok", "Hủy");
            if (answer)
            {
                UpdateHoadon updateHoadon = new UpdateHoadon();
                updateHoadon.tinhtrang = "Đã hủy";
                string json = JsonConvert.SerializeObject(updateHoadon);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage httpResponseMessage = null;
                httpResponseMessage = await httpClient.PostAsync($"https://bookinghotel.onrender.com/hoadons/{thisorder._id}", content);
                if(httpResponseMessage != null)
                {
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        await DisplayAlert("Thông báo", "Đã hủy đơn đặt phòng thành công", "Ok");
                        await Shell.Current.GoToAsync("//main/order");

                    }
                    else
                    {
                        await DisplayAlert("Thất bại", "Đã có lỗi xảy ra", "Ok");
                    }
                }
            }
        }
    }
}