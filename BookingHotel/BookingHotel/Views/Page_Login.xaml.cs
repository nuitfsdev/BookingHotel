using BookingHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Login : ContentPage
    {
        public Page_Login()
        {
            InitializeComponent();
            detail.TranslateTo(0, 0, 1000);
            email.Text = "";
            password.Text = "";

            if (App.BookingDb.CheckLoginResponse())
            {
                Shell.Current.GoToAsync("//main/home");
            }  
        }


        private async void Login_Btn_Clicked(object sender, EventArgs e)
        {
            if(email.Text=="" || password.Text == "")
            {
                await DisplayAlert("TB", $"Vui lòng điền vào các ô còn trống", "OK");

            }
            //else if (isValidEmail(email.Text) == false)
            //{
            //    await DisplayAlert("Thông báo", "Email không hợp lệ", "OK");
            //}
            else
            {
                Login login = new Login();
                login.email = email.Text;
                login.password = password.Text;
                HttpClient httpClient = new HttpClient();
                string json = JsonConvert.SerializeObject(login);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = null;
                responseMessage = await httpClient.PostAsync("https://bookinghotel.onrender.com/users/login", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string contentRes = await responseMessage.Content.ReadAsStringAsync();
                    LoginResponse loginResponse =JsonConvert.DeserializeObject<LoginResponse>(contentRes); 
                    //tạo một User và Token lưu trong CSDL của người dùng
                    App.BookingDb.CreateLoginResponse(loginResponse);
                    await Shell.Current.GoToAsync("//main/home");
                    password.Text = "";
                    email.Text = "";
                }
                else
                {
                    await DisplayAlert("TB", $"Thông tin đăng nhập không hợp lệ!\nVui lòng đăng nhập lại.", "OK");
                }

            }

        }

        private async void register_btn_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//register");
        }

        private void terms_btn_Tapped(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Term());
        }

        private void fogot_pass_Tapped(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Email_Confirm_Forgot_Password());
        }

        private void email_Completed(object sender, EventArgs e)
        {
           
        }

        private void password_Completed(object sender, EventArgs e)
        {
           
        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            

        }

        private void email_Unfocused(object sender, FocusEventArgs e)
        {
            //if (isValidEmail(email.Text) == false)
            //{
            //    DisplayAlert("Thông báo", "Email không hợp lệ!", "OK");
            //}
        }

        private void password_Unfocused(object sender, FocusEventArgs e)
        {
           
        }
        //bool isValidEmail(string inputEmail)
        //{
        //    string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
        //          @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
        //          @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        //    Regex re = new Regex(strRegex);
        //    if (re.IsMatch(inputEmail))
        //        return (true);
        //    else
        //        return (false);
        //}
    }
}