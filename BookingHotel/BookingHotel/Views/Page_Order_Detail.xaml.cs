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

        async void hienthi(Order order)
        {
            HttpClient httpClient = new HttpClient();
            var Hotel = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/hotels?maht={order.maht}");
            var HotelConverted = JsonConvert.DeserializeObject<List<Hotel>>(Hotel);
            thishotel = HotelConverted[0];

            //var Room = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/room?maroom={order.maroom}");
            //var RoomConverted = JsonConvert.DeserializeObject<List<Room>>(Room);
            //thisroom = RoomConverted;

            hinh.Source = thishotel.hinh[0].ToString();
            tenKS.Text = thishotel.tenht;
            tenphong.Text = "Phòng Cơ bản";
            diachi.Text = thishotel.diachi;
            rate.Text = thishotel.sosao;
            maphong.Text = order.maroom;
            adult_qty.Text = String.Format("{0}", order.adult);
            child_qty.Text = String.Format("{0}", order.child);
            bed_qty.Text = String.Format("{0}", order.bed);
            checkin_date.Text = order.checkin;
            checkout_date.Text = order.checkout;
            timecheckin_date.Text = order.timecheckin;
            timecheckout_date.Text= order.timecheckout;
            create_date.Text = order.create;
            if (order.status == 1) cancle_booking.IsVisible = true;
            //dientich.Text = "50 m2";
            //desc.Text ="\t"+ thishotel.mota;
            //mota.Text = "\t" + "Phòng xịn nhất";
            //contact.Text = thishotel.lienhe;
            total.Text = String.Format("{0:0,0 vnđ}", order.total);

            //Hiện thông tin các tiện ích mà khách sạn đang có
            if (thishotel.tienichs.Count > 0)
                foreach (Tienich item in thishotel.tienichs)
                {
                    StackLayout stack = new StackLayout();
                    if (item.tienich == "gym")
                    {
                        stack = new StackLayout
                        {

                            Children = {
                                new Image {Source = "nam_gym.png", WidthRequest=30,VerticalOptions=LayoutOptions.Center},
                                new Label {Text = "Gym", FontSize=16, VerticalOptions=LayoutOptions.Center, TextColor=Color.Gray},
                            }
                        };
                    }
                    else if (item.tienich == "hoboi")
                    {
                        stack = new StackLayout
                        {

                            Children = {
                                new Image {Source = "nam_swimmingpool.png", WidthRequest=30,VerticalOptions=LayoutOptions.Center},
                                new Label {Text = "Hồ bơi",FontSize=16, VerticalOptions=LayoutOptions.Center, TextColor=Color.Gray},
                            }
                        };
                    }
                    else if (item.tienich == "bar")
                    {
                        stack = new StackLayout
                        {

                            Children = {
                                new Image {Source = "nam_bar.png", WidthRequest=30,VerticalOptions=LayoutOptions.Center},
                                new Label {Text = "Quầy bar",FontSize=16, VerticalOptions=LayoutOptions.Center, TextColor=Color.Gray},
                            }
                        };
                    }
                    stack.Orientation = StackOrientation.Horizontal;


                    stack.WidthRequest = 110;

                    tienich_hotel.Children.Add(stack);
                }
            else
            {
                Label label = new Label { Text = "Đang cập nhật", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Black, Margin = new Thickness(10), FontSize = 20 };
                tienich_hotel.Children.Add(label);
            }
        }

        public Page_Order_Detail(Order order)
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

        }

        private void book_btn_Clicked(object sender, EventArgs e)
        {

        }
    }
}