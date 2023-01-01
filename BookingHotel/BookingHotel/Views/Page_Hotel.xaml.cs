using BookingHotel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Hotel : ContentPage
    {
        Hotel Thishotel;
        public Page_Hotel(Hotel hotel)
        {
            InitializeComponent();
            Thishotel = hotel;
            BannerCarousel.ItemsSource = hotel.hinh;
            tenKS.Text = hotel.tenht;
            diachi.Text = hotel.diachi;
            min.Text = String.Format( "{0:0,0}" , hotel.giamin);
            max.Text = String.Format("{0:0,0 VNĐ}", hotel.giamax);
            rate.Text = hotel.sosao.ToString();
            desc.Text = "\t" + hotel.mota;
            contact.Text ="\t" + hotel.lienhe;
            //map.Source = hotel.map;

            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                BannerCarousel.Position = (BannerCarousel.Position + 1) % indicatorView.Count;
                return true;
            }));

            //Hiện thông tin các tiện ích mà khách sạn đang có
            if(hotel.tienich.Count > 0)
                foreach(string tienich in hotel.tienich)
                {
                    StackLayout stack= new StackLayout();
                    if (tienich == "gym")
                    {
                        stack = new StackLayout
                        {

                            Children = {
                                new Image {Source = "nam_gym.png", WidthRequest=30,VerticalOptions=LayoutOptions.Center},
                                new Label {Text = "Gym", FontSize=16, VerticalOptions=LayoutOptions.Center, TextColor=Color.Gray},
                            }
                        };
                    }
                    else if (tienich == "hoboi")
                    {
                        stack = new StackLayout
                        {

                            Children = {
                                new Image {Source = "nam_swimmingpool.png", WidthRequest=30,VerticalOptions=LayoutOptions.Center},
                                new Label {Text = "Hồ bơi",FontSize=16, VerticalOptions=LayoutOptions.Center, TextColor=Color.Gray},
                            }
                        };
                    }
                    else if (tienich == "view")
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

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private void Add_Like_List_Tapped(object sender, EventArgs e)
        {
            ImageButton tab = (ImageButton)sender;
            if (tab.Source.ToString() == "File: heartWhite.png")
            {
                tab.Source = "heart.png";
                DisplayAlert("Thông báo", $"Đã thêm {Thishotel.tenht} vào yêu thích", "OK");
            }
            else
            {
                tab.Source = "heartWhite.png";
            }
        }

        private void book_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Rooms(Thishotel));
        }

        //private void map_ht_Clicked(object sender, EventArgs e)
        //{
        //    Shell.Current.Navigation.PushAsync(new Page_Hotel_Map(Thishotel));
        //}
        private void maphotel_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Hotel_Map(Thishotel));
        }
    }
}