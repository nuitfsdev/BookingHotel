using BookingHotel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Room_Info : ContentPage
    {
        Hotel Thishotel;
        Room Thisroom;
        public Page_Room_Info(Hotel hotel ,Room room)
        {
            InitializeComponent();
            Thisroom = room;
            Thishotel = hotel;

            hinh.Source = room.hinh[0];
            tenphong.Text = room.tenphong;
            theogio.Text = String.Format("{0:0,0 vnd/h}", room.giagio);
            theongay.Text = String.Format("{0:0,0 vnd/ngay}", room.giangay);
            dientich.Text = String.Format("{0} m²", room.dientich);
            mota.Text = room.mota;

            if (room.noibat)
                UudaiVaNoibat.Children.Add(new Label { Text = "Nổi bật", TextColor = Color.White, BackgroundColor = Color.Red, Padding = new Thickness(5) });

            if (room.uudai)
                UudaiVaNoibat.Children.Add(new Label { Text = "Ưu đãi", TextColor = Color.Red, BackgroundColor = Color.AntiqueWhite, Padding = new Thickness(5) });

            //hiện danh sách tiện nghi của phòng
            if (room.tienich.Count > 0)
                foreach (string tienich in room.tienich)
                {
                    StackLayout stack = new StackLayout
                    {
                        Children = {
                            new Image {Source = "dat_wifi.png", WidthRequest=50, Margin= new Thickness(20,10)},
                            new Label {Text = tienich, HorizontalOptions=LayoutOptions.CenterAndExpand, TextColor=Color.Black, Margin=new Thickness(0,-10,0,0)},
                        }
                    };
                    tienichlist.Children.Add(stack);
                }
            else
            {
                Label label = new Label { Text = "Đang cập nhật", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Black, Margin = new Thickness(10), FontSize = 20 };
                tienichlist.Children.Add(label);
            }    
              
            //hiện danh sách các tiện nghi khác
            if(room.khac.Count > 0)
                foreach (string khac in room.khac)
                {
                    StackLayout stack = new StackLayout
                    {
                        Children = {
                            new Image {Source = "dat_wifi.png", WidthRequest=50, Margin= new Thickness(20,10)},
                            new Label {Text = khac, HorizontalOptions=LayoutOptions.CenterAndExpand, TextColor=Color.Black, Margin=new Thickness(0,-10,0,0)},
                        }
                    };
                    khaclist.Children.Add(stack);
                }
            else
            {
                Label label = new Label { Text = "Đang cập nhật", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Black, Margin = new Thickness(10), FontSize= 20 };
                khaclist.Children.Add(label);
            }

        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private async void book_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new Page_Booking_Info(Thishotel, Thisroom));
        }
    }
}