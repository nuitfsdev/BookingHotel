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
    public partial class Page_Home : ContentPage
    {
        public ObservableCollection<Hotel> listHotel;
        string diadiem;
        DateTime ngayden;

        async public void KhachSanNoiBat()
        {
            List<string> listDiaDiem = new List<string>();
            listDiaDiem.Add("TP Hồ Chí Minh");
            listDiaDiem.Add("Đà Nẵng");
            listDiaDiem.Add("Hà Nội");
            diadiem_pk.ItemsSource = listDiaDiem;
            List<string> listQuanHuyen = new List<string>();
            listQuanHuyen.Add("Quận Thủ Đức");
            listQuanHuyen.Add("Quận 2");
            listQuanHuyen.Add("Quận 1");
            quanhuyen_pk.ItemsSource = listQuanHuyen;
            ngayden_dpk.MinimumDate = DateTime.Today;
            ngaydi_dpk.MinimumDate = DateTime.Today;
            ngaydi_dpk.MinimumDate = DateTime.Today.AddDays(1);
            HttpClient httpClient = new HttpClient();
            var ksnoibatList = await httpClient.GetStringAsync("https://bookinghotel.onrender.com/hotels?noibat=true");
            var ksnoibatListConverted = JsonConvert.DeserializeObject<List<Hotel>>(ksnoibatList);
            khachsannoibat.ItemsSource = ksnoibatListConverted;
            var ksuudaiList = await httpClient.GetStringAsync("https://bookinghotel.onrender.com/hotels?uudai=true");
            var ksuudaiListConverted = JsonConvert.DeserializeObject<List<Hotel>>(ksuudaiList);
            khachsanuudai.ItemsSource = ksuudaiListConverted;
            chuongtrinhkhuyenmai.ItemsSource = ksnoibatListConverted;
            tintucnoibat.ItemsSource = ksuudaiListConverted;
        }
        public Page_Home()
        {
            InitializeComponent();
            List<Banner> bannerList = new List<Banner>();
            bannerList.Add(new Banner { Image="Banner1.png"});
            bannerList.Add(new Banner { Image = "Banner2.png" });
            bannerList.Add(new Banner { Image = "Banner3.png" });
            bannerList.Add(new Banner { Image = "Banner4.png" });
            bannerList.Add(new Banner { Image = "Banner5.png" });

            BannerCarousel.ItemsSource = bannerList;


            Device.StartTimer(TimeSpan.FromSeconds(2), (Func<bool>)(() =>
            {
                BannerCarousel.Position = (BannerCarousel.Position + 1) %  indicatorView.Count;
                return true;
            }));

            KhachSanNoiBat();
        }

        //private async void announcement_icon_Clicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync(state: "//main/announcement");
        //}

        //private async void home_search_Tapped(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync(state: "//main/search");
        //}

        //private async void search_icon_Clicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync(state: "//main/search");
        //}

        private void quickSearch_btn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("TB", $"{diadiem_pk.SelectedItem} {quanhuyen_pk.SelectedItem} {ngayden_dpk.Date.ToString("dd-MM-yyyy")} {ngaydi_dpk.Date.ToString("dd-MM-yyyy")}", "Ok");
        }

        private void diadiem_pk_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyPicker myPicker = (MyPicker)sender;
            diadiem=myPicker.SelectedItem as string;
            
        }

        private void quanhuyen_pk_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ngayden_dpk_DateSelected(object sender, DateChangedEventArgs e)
        {
            MyDatePicker myDateNgayDen = (MyDatePicker)sender;
            ngayden = myDateNgayDen.Date;
        }

        private void ngaydi_dpk_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

    
        private async void search_icon_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//main/search",true);
        }

        private async void bell_icon_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//main/announcement",true);

        }

        private void noibat_item_Tapped(object sender, EventArgs e)
        {
            Frame tab = (Frame)sender;
            Hotel hotel = tab.BindingContext as Hotel;

            Shell.Current.Navigation.PushAsync(new Page_Hotel(hotel));
        }

        private void uudai_item_Tapped(object sender, EventArgs e)
        {
            Frame tab = (Frame)sender;
            Hotel hotel = tab.BindingContext as Hotel;

            Shell.Current.Navigation.PushAsync(new Page_Hotel(hotel));
        }

        private void khuyenmai_item_Tapped(object sender, EventArgs e)
        {

        }

        private void tintuc_item_Tapped(object sender, EventArgs e)
        {

        }
    }
}