﻿using BookingHotel.Models;
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
    public partial class Page_Search : ContentPage
    {
        public ObservableCollection<Hotel> dsks;
        async void hienthiks()
        {
            //dsks = new ObservableCollection<Hotel>();
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4 });

            //Search_Collection.ItemsSource = dsks;
            HttpClient httpClient = new HttpClient();
            var subjectList = await httpClient.GetStringAsync("https://bookinghotel.onrender.com/hotels");
            var subjectListConverted = JsonConvert.DeserializeObject<List<Hotel>>(subjectList);
            Search_Collection.ItemsSource = subjectListConverted;
        }
        public Page_Search()
        {
            InitializeComponent();
            hienthiks();
            search_entry.Focus();
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "../");
        }

        private async void filter_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//main/filter");
        }

        private void Add_Like_List_Tapped(object sender, EventArgs e)
        {
            Image tab = (Image)sender;
            if (tab.Source.ToString() == "File: heartWhite.png")
            {
                tab.Source = "heart.png";
                DisplayAlert("Thông báo", "Đã thêm vào yêu thích", "OK");
            }
            else
            {
                tab.Source = "heartWhite.png";
            }
        }

        private void Search_Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hotel hotel = e.CurrentSelection[0] as Hotel;
            if (hotel == null)
                return;
            Search_Collection.SelectedItem = SelectableItemsView.EmptyViewProperty;
            Shell.Current.Navigation.PushAsync(new Page_Hotel(hotel));
        }
    }
}