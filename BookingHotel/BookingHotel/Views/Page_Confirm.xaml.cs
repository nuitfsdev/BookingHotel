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
    public partial class Page_Confirm : ContentPage
    {
        ForgotPassword thisForgotPassword { get; set; }
        public Page_Confirm(ForgotPassword forgotPassword)
        {
            InitializeComponent();
            thisForgotPassword = forgotPassword;
        }

        private async void Confirm_btn_Clicked(object sender, EventArgs e)
        {
            if (code.Text == "")
            {
                await DisplayAlert("TB", $"Vui lòng điền vào các ô còn trống", "OK");

            }
            else
            {
                thisForgotPassword.verifyCode = code.Text;
                HttpClient httpClient = new HttpClient();
                string json = JsonConvert.SerializeObject(thisForgotPassword);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = null;
                responseMessage = await httpClient.PostAsync("https://bookinghotel.onrender.com/users/confirmCode", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                     await Shell.Current.Navigation.PushAsync(new Page_Fogot_Password(thisForgotPassword));

                }
                else if (responseMessage.StatusCode.ToString() == "NotFound")
                {
                    await DisplayAlert("TB", $"Mã xác thực không đúng!", "OK");
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

        private void register_btn_Tapped(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Register());
        }
    }
}