using BookingHotel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Love : ContentPage
    {
        Hotel Thishotel;
        Room Thisroom;

        async void hienthiks(string urlAPI)
        {
            HttpClient httpClient = new HttpClient();
            var subjectList = await httpClient.GetStringAsync(urlAPI);
            var subjectListConverted = JsonConvert.DeserializeObject<List<Hotel>>(subjectList);
            Love_Collection.ItemsSource = subjectListConverted;
        }

        public Page_Love()
        {
            InitializeComponent();
            hienthiks("https://bookinghotel.onrender.com/hotels");
        }

        private async void Search_Btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//main/search");
        }

        private void Love_Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hotel hotel = e.CurrentSelection[0] as Hotel;
            if (hotel == null)
                return;
            Love_Collection.SelectedItem = SelectableItemsView.EmptyViewProperty;
            Shell.Current.Navigation.PushAsync(new Page_Hotel(hotel));
        }

        private void book_btn_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Hotel hotel = (Hotel)button.CommandParameter;
            Shell.Current.Navigation.PushAsync(new Page_Hotel(hotel));
        }

        private async void delete_btn_Clicked(object sender, EventArgs e)
        {
            ImageButton tab = (ImageButton)sender;
            //Lấy Hotel từ image
            Hotel hotel = (Hotel)tab.CommandParameter;

            bool answer = await DisplayAlert("Cảnh báo", "Bạn chắc chắn muốn xóa khách sạn này khỏi danh sách yêu thích", "Yes", "No");
            if (answer)
            {
                //SwipeItem swipeItem = (SwipeItem)sender;
                //Sanpham sp = swipeItem.CommandParameter as Sanpham;
                //_ = dssp.Remove(sp);
                DisplayAlert("Thong bao",$"Đã xóa {hotel.tenht}","OK");
            }
        }

        private void back_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopAsync();
        }
    }
}