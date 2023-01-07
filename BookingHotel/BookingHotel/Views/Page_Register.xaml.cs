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
    public partial class Page_Register : ContentPage
    {
        public Page_Register()
        {
            InitializeComponent();
            password.Text = "";
            email.Text = "";
            sdt.Text = "";
            name.Text = "";
            confirmPassword.Text = "";
        }

        private void login_btn_Tapped(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(state: "//login");
        }

        private async void Register_btn_Clicked(object sender, EventArgs e)
        {
            if (name.Text=="" || email.Text == ""|| sdt.Text=="" || password.Text == "" || confirmPassword.Text=="")
            {
                await DisplayAlert("TB", $"Vui lòng điền vào các ô còn trống", "OK");

            }
            else if (password.Text != confirmPassword.Text)
            {
                await DisplayAlert("TB", $"Nhập lại mật khẩu không đúng!", "OK");
            }
            else
            {
                SignUp signUp=new SignUp();
                signUp.email = email.Text;
                signUp.password = password.Text;
                signUp.sdt = sdt.Text;
                signUp.name = name.Text;

                HttpClient httpClient = new HttpClient();
                string json = JsonConvert.SerializeObject(signUp);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = null;
                responseMessage = await httpClient.PostAsync("https://bookinghotel.onrender.com/users", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string contentRes = await responseMessage.Content.ReadAsStringAsync();
                    LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(contentRes);
                    await DisplayAlert("TB", $"{loginResponse.user.name}", "OK");
                    await Shell.Current.GoToAsync("//main/home");
                    password.Text = "";
                    email.Text = "";
                    sdt.Text = "";
                    name.Text = "";
                    confirmPassword.Text = "";

                }
                else
                {
                    await DisplayAlert("TB", $"Đã có lỗi xảy ra", "OK");
                }

            }
        }

        private void terms_btn_Tapped(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PushAsync(new Page_Term());
        }
    }
}