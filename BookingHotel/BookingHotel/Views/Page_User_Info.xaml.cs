using BookingHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Behaviors;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_User_Info : ContentPage
    {
        public Page_User_Info()
        {
            InitializeComponent();
            User user = App.BookingDb.GetUser();
            user_name.Text = user.name;
            user_email.Text = user.email;
            user_telephone.Text = user.sdt;
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private void change_avatar_Clicked(object sender, EventArgs e)
        {

        }

        private async void save_btn_Clicked(object sender, EventArgs e)
        {
            if (user_name.Text == "" || user_email.Text == "" || user_telephone.Text == "")
            {
                await DisplayAlert("TB", $"Vui lòng điền vào các ô còn trống", "OK");

            }
            else if (isValidEmail(user_email.Text) == false)
            {
                await DisplayAlert("Thông báo", "Email không hợp lệ", "OK");
            }
            else
            {
                UpdateUser updateUser = new UpdateUser();
                updateUser.name = user_name.Text;
                updateUser.email = user_email.Text;
                updateUser.sdt = user_telephone.Text;
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage responseMessage = null;
                string json = JsonConvert.SerializeObject(updateUser);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.BookingDb.GetToken());
                responseMessage = await httpClient.PutAsync("https://bookinghotel.onrender.com/users/me", content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    await DisplayAlert("Thông báo", "Cập nhật thành công", "Ok");
                    User user = App.BookingDb.GetUser();
                    user.name = user_name.Text;
                    user.email = user_email.Text;
                    user.sdt = user_telephone.Text;
                    App.BookingDb.UpdateUser(user);
                }
                else
                {
                    await DisplayAlert("Thông báo", "Thất bại!", "Ok");
                }    
            }
        }

        private void user_email_Unfocused(object sender, FocusEventArgs e)
        {
            if (isValidEmail(user_email.Text) == false)
            {
                DisplayAlert("Thông báo", "Email không hợp lệ!", "OK");
            }
        }
        bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
    }
}