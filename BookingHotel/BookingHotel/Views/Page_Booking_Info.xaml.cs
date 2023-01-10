using BookingHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Booking_Info : ContentPage
    {
        Hotel Thishotel = new Hotel();
        Room Thisroom = new Room();

        long save_cost_time;
        long save_cost_day;
        AddHoaDon addHoaDon = new AddHoaDon();
        public Page_Booking_Info(Hotel hotel,Room room)
        {
            InitializeComponent();
            User user = App.BookingDb.GetUser();
            Thishotel = hotel;
            Thisroom = room;
            user_name.Text = user.name;
            user_email.Text = user.email;
            user_telephone.Text = user.sdt;

            hinhKS.Source = hotel.hinh[0];
            tenKS.Text = hotel.tenht;
            diachi.Text=hotel.diachi;
            sosao.Text = hotel.sosao;
            ten_r.Text = room.tenphong;
            loai_r.Text = room.loaiphong;
            sogiuong_r.Text = room.sogiuong.ToString();
            hinh_r.Source = room.hinh[0];
            save_cost_time = room.giagio;
            save_cost_day = room.giangay;
            cost_time.Text = String.Format("{0:0,0}", room.giagio);
            cost_day.Text = String.Format("{0:0,0}", room.giangay);
            //Add Hotel
            addHoaDon.maht = hotel.maht;
            addHoaDon.maroom = room.maroom;
            addHoaDon.makh = user.mauser;
            addHoaDon.tenkh = user.name;
            addHoaDon.email = user.email;
            addHoaDon.sdt = user.sdt;
            addHoaDon.ngayhd = DateTime.Now.ToString("dd-MM-yyyy");
            addHoaDon.tinhtrang = "Đang xử lí";
            addHoaDon.ptdatphong = "Theo giờ";
            addHoaDon.phuongthuc = "online";

            Theo_gio_show();


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
        //void setHotel(Hotel hotel)
        //{
        //    Thishotel.maht = hotel.maht;
        //    Thishotel.diachi= hotel.diachi;
        //    Thishotel.sosao = hotel.sosao;
        //}
        //void setRoom(Room room)
        //{
        //    Thisroom.giagio = room.giagio;
        //    Thisroom.giangay = room.giangay;
        //}

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private async void book_btn_Clicked(object sender, EventArgs e)
        {
            if (user_name.Text == "" || user_email.Text == "" || user_telephone.Text == "")
            {
                await DisplayAlert("Thông báo", "Vui lòng điền đầy đủ thông tin khách hàng", "OK");
            }
            else if (addHoaDon.phuongthuc == "online" && (addHoaDon.nganhang == null || addHoaDon.tennganhang == null || addHoaDon.sotaikhoan == null || addHoaDon.nganhang == "" || addHoaDon.tennganhang == "" || addHoaDon.sotaikhoan == ""))
            {
                   await DisplayAlert("Thông báo", "Vui lòng điền đầy đủ thông tin ngân hàng", "OK");
            }
            else
            {
                addHoaDon.ngaynhan = checkin_day.Date.ToString("dd-MM-yyyy");
                addHoaDon.ngaytra = checkout_day.Date.ToString("dd-MM-yyyy");
                addHoaDon.gionhan = checkin_time.Time.ToString().Substring(0,5);
                addHoaDon.giotra = checkout_time.Time.ToString().Substring(0,5);
                addHoaDon.sogio = int.Parse(time_uses_final.Text);
                addHoaDon.songay = int.Parse(day_final.Text);
                addHoaDon.slnguoilon = int.Parse(Adult.Text);
                addHoaDon.sltreem = int.Parse(Child.Text);
                addHoaDon.slphong = int.Parse(Room_qty.Text);
                addHoaDon.khac = khac.Text==null? khac.Text:"";
                await DisplayAlert("TB", $"{addHoaDon.maht}\n{addHoaDon.maroom}\n{addHoaDon.makh}\n{addHoaDon.trigia}\n{addHoaDon.gia}\n{addHoaDon.ngayhd}\n{addHoaDon.ngaynhan}\n{addHoaDon.ngaytra}\n{addHoaDon.gionhan}\n{addHoaDon.giotra}\n{addHoaDon.sogio}\n{addHoaDon.songay}\n{addHoaDon.phuongthuc}\n{addHoaDon.ptdatphong}\n{addHoaDon.slnguoilon}\n{addHoaDon.sltreem}\n{addHoaDon.slphong}\n{addHoaDon.nganhang}\n{addHoaDon.tennganhang}\n{addHoaDon.sotaikhoan}\n{addHoaDon.khac}\n{addHoaDon.tenkh}\n{addHoaDon.email}\n{addHoaDon.sdt}", "OK");
                HttpClient httpClient = new HttpClient();
                string json = JsonConvert.SerializeObject(addHoaDon);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = null;
                responseMessage = await httpClient.PostAsync("https://bookinghotel.onrender.com/hoadons", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    await DisplayAlert("Thành công", "Đặt phòng thành công", "OK");
                    await Shell.Current.GoToAsync("//main/order");
                }
                else
                {
                    await DisplayAlert("Thất bại", $"Đã xảy ra lỗi", "OK");
                }
            }
        }

        private void time_decre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(time_uses.Text);
            if (old_value > 1)
            {
                time_uses.Text = $"{old_value - 1}";
                time_uses_final.Text = time_uses.Text;

                //nếu thời gian trừ đi làm quay về ngày hôm trước
                if (checkout_time.Time.Hours == 0)
                {
                    checkout_day.Date = checkout_day.Date.AddDays(-1);
                    checkout_day_final.Text = checkout_day.Date.ToString("dd/MM/yyyy");
                    checkout_time.Time = TimeSpan.Parse($"23:{checkout_time.Time.Minutes}:00");
                }
                else
                    checkout_time.Time -= TimeSpan.Parse("1:00");
                checkout_time_final.Text = checkout_time.Time.ToString(@"hh\:mm");

                long total_cost = save_cost_time + Thisroom.giagio2 * (long.Parse(time_uses.Text) - 1);
                addHoaDon.trigia = total_cost;
                total.Text = String.Format("{0:0,0}", total_cost);
            }    
        }

        private void time_incre_Clicked(object sender, EventArgs e)
        {
            //chỉ cho phép ở trong 23h
            if(int.Parse(time_uses.Text) < 23)
            {
                int old_value = int.Parse(time_uses.Text);
                time_uses.Text = $"{old_value + 1}";
                time_uses_final.Text = time_uses.Text;

                if (checkout_time.Time.Hours == 23)
                {
                    checkout_time.Time = TimeSpan.Parse($"0:{checkout_time.Time.Minutes}:00");
                    checkout_day.Date = checkin_day.Date.AddDays(1);
                }    
                else
                    checkout_time.Time += TimeSpan.Parse("1:00:00");
                checkout_time_final.Text = checkout_time.Time.Hours.ToString() + ":" + checkout_time.Time.Minutes.ToString();
  
                checkout_day_final.Text = checkout_day.Date.ToString("dd/MM/yyyy");

                long total_cost = save_cost_time + save_cost_time * (long.Parse(time_uses.Text)-1) / 2;
                addHoaDon.trigia=total_cost;
                total.Text = String.Format("{0:0,0}", total_cost);
            }    
        }

        //Xử lý tăng giảm số lượng người lớn, trẻ em và số lượng phòng
        private void adult_decre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(Adult.Text);
            if(old_value > 1)
                Adult.Text = $"{old_value - 1}";
            time_uses_final.Text = time_uses.Text;
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
            user_bank.ItemsSource = bank;
        }

        private void user_bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(user_bank.SelectedItem.ToString() == "BIDV")
            {
                bank_logo.Source = "nam_bar.png";
            }
            if (user_bank.SelectedItem.ToString() == "SCB")
            {
                bank_logo.Source = "nam_bellicon.png";
            }
            if (user_bank.SelectedItem.ToString() == "Sacombank")
            {
                bank_logo.Source = "nam_bedroom.png";
            }
            if (user_bank.SelectedItem.ToString() == "DongABank")
            {
                bank_logo.Source = "nam_gym.png";
            }
            if (user_bank.SelectedItem.ToString() == "Argribank")
            {
                bank_logo.Source = "nam_maylanh.png";
            }
            addHoaDon.nganhang = user_bank.SelectedItem.ToString();
           
        }

        private void online_radionbtn_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (online_radionbtn.IsChecked == true)
            {
                online_payment.IsVisible = true;
                offline_payment.IsVisible = false;
                online_paymentmethod.BorderColor = Color.FromHex("#585de4");
                addHoaDon.phuongthuc = "online";
                
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
                addHoaDon.phuongthuc = "tại khách sạn";
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

        private void follow_time_btn_Clicked(object sender, EventArgs e)
        {
            time_underline.IsVisible = true;

            cost_time_show.IsVisible = true;
            cost_day_show.IsVisible = false;
            
            day_underline.IsVisible = false;

            checkin_day.IsEnabled = true;
            checkout_day.IsEnabled = false;

            checkin_time.IsEnabled = true;
            checkout_time.IsEnabled = false;

            time_uses_layout.IsVisible = true;

            time_uses_show.IsVisible = true;
           
            day_show.IsVisible = false;
            addHoaDon.gia = Thisroom.giagio;
            addHoaDon.ptdatphong = "Theo giờ";
            Theo_gio_show();
        }

        private void follow_day_Clicked(object sender, EventArgs e)
        {
            time_underline.IsVisible = false;

            cost_time_show.IsVisible = false;
            cost_day_show.IsVisible = true;

            day_underline.IsVisible = true;

            checkin_day.IsEnabled = true;
            checkout_day.IsEnabled = true;

            checkin_time.IsEnabled = true;
            checkout_time.IsEnabled = false;

            time_uses_layout.IsVisible = false;

            time_uses_show.IsVisible = false;
            
            day_show.IsVisible = true;
            addHoaDon.gia = Thisroom.giangay;
            addHoaDon.ptdatphong = "Theo ngày";
            Theo_Ngay_show();
        }

        //Làm tròn đến d phút
        DateTime RoundUp(DateTime dt, TimeSpan d)
        {
            return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
        }

        DateTime date;

        void Theo_gio_show()
        {
            date = RoundUp(DateTime.Now, TimeSpan.FromMinutes(30));
            //giờ
            checkin_time.Time = date.TimeOfDay;
            checkout_time.Time = date.AddHours(1).TimeOfDay;
            //ngày
            checkin_day.MinimumDate = DateTime.Now.Date;
            checkout_day.MinimumDate = DateTime.Now.Date;
            checkin_day.Date = date.Date;

            if (checkin_time.Time.Hours < 23)
            {
                checkout_day.Date = checkin_day.Date;
            }    
            else
            {
                checkout_day.Date = checkin_day.Date.AddDays(1);
            }

            //thanh toán - giờ
            checkin_time_final.Text = date.TimeOfDay.ToString(@"hh\:mm");
            checkout_time_final.Text = date.AddHours(1).TimeOfDay.ToString(@"hh\:mm");
            //thanh toán - ngày
            checkin_day_final.Text = checkin_day.Date.ToString("dd/MM/yyyy");
            checkout_day_final.Text = checkout_day.Date.ToString("dd/MM/yyyy");

            time_uses.Text = "1";
                time_uses_final.Text = "1";

            if(time_underline.IsVisible)
            {
                long total_cost = save_cost_time * 1;
                addHoaDon.gia = save_cost_time;
                addHoaDon.trigia = total_cost;
                total.Text = String.Format("{0:0,0}", total_cost);
            }    
        }
        void Theo_Ngay_show()
        {
            date = RoundUp(DateTime.Now, TimeSpan.FromMinutes(30));
           
            //ngày
            checkin_day.MinimumDate = DateTime.Now.Date;
            checkout_day.MinimumDate = DateTime.Now.AddDays(1).Date;
            checkin_day.Date = date.Date;
            checkout_day.Date = date.AddDays(1).Date;
            //giờ
            checkout_time.Time = checkin_time.Time;
            //thanh toán - giờ
            checkin_time_final.Text = checkin_time.Time.ToString(@"hh\:mm");
            checkout_time_final.Text = checkin_time.Time.ToString(@"hh\:mm");
            //thanh toán - ngày
            checkin_day_final.Text = date.Date.ToString("dd/MM/yyyy");
            checkout_day_final.Text = date.Date.AddDays(1).ToString("dd/MM/yyyy");

            day_final.Text = "3";

            if(day_underline.IsVisible)
            {
                long total_cost = save_cost_day * long.Parse(day_final.Text);
                addHoaDon.gia = save_cost_day;
                addHoaDon.trigia = total_cost;
                total.Text = String.Format("{0:0,0}", total_cost);
            }    
        }

        private void checkin_day_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            checkin_day_final.Text = checkin_day.Date.ToString("dd/MM/yyyy");
            if (time_underline.IsVisible & checkin_time.Time.Hours <23)
            {
                checkout_day.Date = checkin_day.Date;
            }
            else if(time_underline.IsVisible)
            {
                checkout_day.Date = checkin_day.Date.AddDays(1);
            }    
        }

        private void checkout_day_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(checkout_day.IsVisible)
            {
                checkout_day_final.Text = checkout_day.Date.ToString("dd/MM/yyyy");

                //chuyển đổi để có được số ngày
                TimeSpan timeSpan = checkout_day.Date - checkin_day.Date;
                int day = timeSpan.Days;
                day_final.Text = day.ToString();

                if(day_underline.IsVisible)
                {
                    long total_cost = save_cost_day * long.Parse(day_final.Text);
                    addHoaDon.trigia = total_cost;
                    total.Text = String.Format("{0:0,0}", total_cost);
                }    
            }    
        }

        private void checkin_time_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(time_underline.IsVisible)
            {
                if (time_uses.Text == null)
                {
                    checkout_time.Time = checkin_time.Time.Add(TimeSpan.Parse("1:00:00"));
                }
                else if(checkin_time.Time.Hours == 23)
                {
                    checkout_time.Time = TimeSpan.Parse($"0:{checkin_time.Time.Minutes}:00");
                    checkout_day.Date = checkin_day.Date.AddDays(1);
                }    
                else
                {
                    checkout_time.Time = checkin_time.Time.Add(TimeSpan.Parse($"{time_uses.Text}:00:00"));
                }    
                checkin_time_final.Text = checkin_time.Time.ToString(@"hh\:mm");
                checkout_time_final.Text = checkout_time.Time.ToString(@"hh\:mm");
            }
            else
            {
                checkout_time.Time = checkin_time.Time;
                checkin_time_final.Text = checkin_time.Time.ToString(@"hh\:mm");
                checkout_time_final.Text = checkout_time.Time.ToString(@"hh\:mm");
            }    
        }

        private void name_bank_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (name_bank.Text != "" && name_bank != null)
            {
                addHoaDon.tennganhang = name_bank.Text;
            }
        }

        private void stk_bank_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (stk_bank.Text != "" && stk_bank != null)
            {
                addHoaDon.sotaikhoan = stk_bank.Text;
            }
        }
    }
}