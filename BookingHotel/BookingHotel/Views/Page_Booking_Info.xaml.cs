using BookingHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Booking_Info : ContentPage
    {
        Hotel Thishotel;
        public Page_Booking_Info(Hotel hotel,Room room)
        {
            InitializeComponent();
            Thishotel = hotel;
            hinhKS.Source = hotel.hinh[0];
            tenKS.Text = hotel.tenht;
            diachi.Text=hotel.diachi;
            sosao.Text = hotel.sosao;
            ten_r.Text = room.tenphong;
            loai_r.Text = room.loaiphong;
            sogiuong_r.Text = room.sogiuong.ToString();
            hinh_r.Source = room.hinh[0];
        

            //Hiện thông tin các tiện ích mà khách sạn đang có
            //foreach (Tienich tienich in hotel.tienichs)
            //{
            //    StackLayout stack = new StackLayout();
            //    if (tienich.tienich == "gym")
            //        stack = new StackLayout
            //        {
            //            Orientation = StackOrientation.Horizontal,
            //            Children = {
            //                new Image {Source = "nam_gym.png", WidthRequest=20, Margin= new Thickness(10,5,0,0)},
            //                new Label {Text = "Gym", FontSize=15, VerticalOptions=LayoutOptions.EndAndExpand, TextColor=Color.Black, Margin=new Thickness(0,-5,5,0)},
            //            }
            //        };
            //    else if (tienich.tienich == "view")
            //        stack = new StackLayout
            //        {
            //            Orientation = StackOrientation.Horizontal,
            //            Children = {
            //                new Image {Source = "nam_bar.png", WidthRequest=20, Margin= new Thickness(10,5,0,0)},
            //                new Label {Text = "Quầy bar",FontSize=15, VerticalOptions=LayoutOptions.EndAndExpand, TextColor=Color.Black, Margin=new Thickness(0,-5,0,0)},
            //            }
            //        };
            //    else if (tienich.tienich == "hoboi")
            //        stack = new StackLayout
            //        {
            //            Orientation = StackOrientation.Horizontal,
            //            Children = {
            //                new Image {Source = "nam_swimmingpool.png", WidthRequest=20, Margin= new Thickness(10,5,0,0)},
            //                new Label {Text = "Hồ bơi",FontSize=15, VerticalOptions=LayoutOptions.EndAndExpand, TextColor=Color.Black, Margin=new Thickness(0,-5,0,0)},
            //            }
            //        };
            //    tienich_hotel.Children.Add(stack);
            //}
            showBank();
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private void book_btn_Clicked(object sender, EventArgs e)
        {

        }

        //Xử lý tăng giảm số lượng người lớn, trẻ em và số lượng phòng
        private void adult_decre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(Adult.Text);
            if(old_value > 1)
                Adult.Text = $"{old_value - 1}";  
        }

        private void adult_incre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(Adult.Text);
            Adult.Text = $"{old_value + 1}";
        }

        private void child_decre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(Child.Text);
            if (old_value > 1)
                Child.Text = $"{old_value - 1}";
        }

        private void child_incre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(Child.Text);
            Child.Text = $"{old_value + 1}";
        }

        private void room_qty_incre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(Room_qty.Text);
            Room_qty.Text = $"{old_value + 1}";
        }

        private void room_qty_decre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(Room_qty.Text);
            if (old_value > 1)
                Room_qty.Text = $"{old_value - 1}";
        }

        //private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        //{
        //    RadioButton radioButton = sender as RadioButton;
        //    if (radioButton.Content == "Thanh toán online")
        //    {
        //        online_payment.IsVisible = true;
        //        offline_payment.IsVisible = false;
        //    }    
        //    else
        //    {
        //        online_payment.IsVisible = false;
        //        offline_payment.IsVisible = true;
        //    }
           
        //}

        void showBank()
        {
            List<string> bank = new List<string>();
            bank.Add("BIDV");
            bank.Add("SCB");
            bank.Add("Sacombank");
            bank.Add("DongABank");
            bank.Add("Argribank");
            bank.Add("Momo");
            user_bank.ItemsSource = bank;
        }

        private void user_bank_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void online_radionbtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (online_radionbtn.IsChecked == true)
            {
                online_payment.IsVisible = true;
                offline_payment.IsVisible = false;
                online_paymentmethod.BorderColor = Color.FromHex("#585de4");
            }
            else
            {
                online_paymentmethod.BorderColor = Color.FromHex("#ccc");
            }
            //if (online_radionbtn.IsChecked == false)
            //{
            //    online_payment.IsVisible = false;
            //    offline_payment.IsVisible = true;
            //}
        }

        private void offline_radionbtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (offline_radionbtn.IsChecked == true)
            {
                online_payment.IsVisible = false;
                offline_payment.IsVisible = true;
                offline_paymentmethod.BorderColor = Color.FromHex("#585de4");
            }
            else
            {
                offline_paymentmethod.BorderColor = Color.FromHex("#ccc");

            }
            //if (offline_radionbtn.IsChecked == false)
            //{
            //    online_payment.IsVisible = true;
            //    offline_payment.IsVisible = false;
            //}
        }
    }
}