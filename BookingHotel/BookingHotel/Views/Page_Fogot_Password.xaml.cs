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
    public partial class Page_Fogot_Password : ContentPage
    {
        ForgotPassword thisForgotPassword;
        public Page_Fogot_Password(ForgotPassword forgotPassword)
        {
            InitializeComponent();
            thisForgotPassword = forgotPassword;
        }

        private async void Login_Btn_Clicked(object sender, EventArgs e)
        {
            if (password.Text == "" || confirmPassword.Text == "")
            {
                await DisplayAlert("TB", $"Vui lòng điền vào các ô còn trống", "OK");

            }
            else if (password.Text != confirmPassword.Text)
            {
                await DisplayAlert("TB", $"Nhập lại mật khẩu không đúng!", "OK");
            }
            else
            {
                thisForgotPassword.password = password.Text;
                HttpClient httpClient = new HttpClient();
                string json = JsonConvert.SerializeObject(thisForgotPassword);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = null;
                responseMessage = await httpClient.PostAsync("https://bookinghotel.onrender.com/users/resetPassword", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    await Shell.Current.GoToAsync(state: "//login");

                }
                else
                {
                    await DisplayAlert("TB", $"Đã xảy ra lỗi", "OK");
                }

            }
           
        }

        private void login_btn_Tapped(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(state: "//login");
        }

        private async void register_btn_Tapped(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Register());
        }
    }
}