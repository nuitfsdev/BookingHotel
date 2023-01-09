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
    public partial class Page_Email_Confirm_Forgot_Password : ContentPage
    {
        public Page_Email_Confirm_Forgot_Password()
        {
            InitializeComponent();
            email.Text = "";
        }

        private async void Confirm_btn_Clicked(object sender, EventArgs e)
        {
            if (email.Text == "")
            {
                await DisplayAlert("TB", $"Vui lòng điền vào các ô còn trống", "OK");

            }
            else
            {
                ForgotPassword forgotPassword = new ForgotPassword();
                forgotPassword.email = email.Text;
                HttpClient httpClient = new HttpClient();
                string json = JsonConvert.SerializeObject(forgotPassword);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = null;
                responseMessage = await httpClient.PostAsync("https://bookinghotel.onrender.com/users/forgotPassword", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    await Shell.Current.Navigation.PushAsync(new Page_Confirm(forgotPassword));

                }
                else if (responseMessage.StatusCode.ToString() == "NotFound")
                {
                    await DisplayAlert("TB", $"Email không tồn tại!", "OK");
                }
                else
                {
                    await DisplayAlert("TB", $"Đã xảy ra lỗi", "OK");
                }

            }
        }

        private async void login_btn_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//login");
        }

        private async void register_btn_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//register");
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//login");
        }
    }
}