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
using Xamarin.CommunityToolkit.Markup;

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

             bannerCarousel.ItemsSource= room.hinh;
            tenphong.Text = room.tenphong;
            theogio.Text = String.Format("{0:0,0}", room.giagio);
            theongay.Text = String.Format("{0:0,0}", room.giangay);
            dientich.Text = String.Format("{0} m²", room.dientich);
            mota.Text = "\t"+room.mota;
            loaiphong.Text = room.loaiphong;
            sogiuong.Text = room.sogiuong.ToString();
            Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
            {
                bannerCarousel.Position = (bannerCarousel.Position + 1) % indicatorView.Count;
                return true;
            }));
            if (room.noibat == false)
                noibat.IsVisible = false;

            if (room.uudai==false)
                uudai.IsVisible = false;

            //hiện danh sách tiện nghi của phòng
            if (room.tienichs.Count > 0)
                foreach (TienIchRoom item in room.tienichs)
                {
                    StackLayout stack = new StackLayout
                    {
                        Children = {
                            new Image {Source = item.hinh, WidthRequest=50, Margin= new Thickness(20,10)},
                            new Label {Text = item.tienich, HorizontalOptions=LayoutOptions.CenterAndExpand, FontSize=16, TextColor=Color.Black, Margin=new Thickness(0,-10,0,0)},
                        }
                    };
                    tienichlist.Children.Add(stack);
                }
            else
            {
                Label label = new Label { Text = "Đang cập nhật", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Black, Margin = new Thickness(10), FontSize = 20 };
                tienichlist.Children.Add(label);
            }    
              
            ////hiện danh sách các tiện nghi khác
            //if(room.khac.Count > 0)
            //    foreach (string khac in room.khac)
            //    {
            //        StackLayout stack = new StackLayout
            //        {
            //            Children = {
            //                new Image {Source = "dat_wifi.png", WidthRequest=50, Margin= new Thickness(20,10)},
            //                new Label {Text = khac, HorizontalOptions=LayoutOptions.CenterAndExpand, TextColor=Color.Black, Margin=new Thickness(0,-10,0,0)},
            //            }
            //        };
            //        khaclist.Children.Add(stack);
            //    }
            //else
            //{
            //    Label label = new Label { Text = "Đang cập nhật", HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = Color.Black, Margin = new Thickness(10), FontSize= 20 };
            //    khaclist.Children.Add(label);
            //}

        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private async void book_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new Page_Booking_Info(Thishotel, Thisroom));
        }

        private void Add_Like_List_Clicked(object sender, EventArgs e)
        {

        }
    }
}