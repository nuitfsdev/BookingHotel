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
    public partial class Page_Search : ContentPage
    {
        async void hienthiks(string urlAPI)
        {
            HttpClient httpClient = new HttpClient();
            var subjectList = await httpClient.GetStringAsync(urlAPI);
            var subjectListConverted = JsonConvert.DeserializeObject<List<Hotel>>(subjectList);
            Search_Collection.ItemsSource = subjectListConverted;
        }

        bool filter=false;
        public Page_Search()
        {
            InitializeComponent();
            hienthiks("https://bookinghotel.onrender.com/hotels");
            search_entry.Focus();
        }
        public Page_Search(HotelFilter hotelFilter)
        {
            InitializeComponent();
            filter=true;
            if(hotelFilter == null)
            {
                hienthiks("https://bookinghotel.onrender.com/hotels");
            }
            else
            {
                string queryString = "";
                if (hotelFilter.tinh != null)
                {
                    queryString = queryString + $"tinh={hotelFilter.tinh}";
                }
                if (hotelFilter.huyen != null)
                {
                    if (queryString != "")
                    {
                      queryString = queryString + $"&quan={hotelFilter.huyen}";

                    }
                    else
                    {
                      queryString = queryString + $"quan={hotelFilter.huyen}";
                    }

                }
                if (hotelFilter.sosao.Count>0)
                {
                    if (queryString != "")
                    {
                       foreach(var item in hotelFilter.sosao)
                        {
                            queryString = queryString + $"&sosao[]={item}";
                        }
                    }
                    else
                    {
                        foreach(var item in hotelFilter.sosao)
                        {
                            if (queryString.Contains("sosao"))
                            {
                                queryString = queryString + $"&sosao[]={item}";
                            }
                            else
                            {
                                queryString = queryString + $"sosao[]={item}";
                            }
                        }    
                    }
                }
                if (hotelFilter.giamin != null)
                {
                    if (queryString != "")
                    {
                        queryString = queryString + $"&giamin={hotelFilter.giamin}";

                    }
                    else
                    {
                        queryString = queryString + $"giamin={hotelFilter.giamin}";
                    }

                }
                if (hotelFilter.giamax != null)
                {
                    if (queryString != "")
                    {
                        queryString = queryString + $"&giamax={hotelFilter.giamax}";

                    }
                    else
                    {
                        queryString = queryString + $"giamax={hotelFilter.giamax}";
                    }
                }
                if (hotelFilter.tienichs.Count > 0)
                {
                    if (queryString != "")
                    {
                        foreach (var item in hotelFilter.tienichs)
                        {
                            queryString = queryString + $"&tienichs[]={item}";
                        }
                    }
                    else
                    {
                        foreach (var item in hotelFilter.tienichs)
                        {
                            if (queryString.Contains("tienichs"))
                            {
                                queryString = queryString + $"&tienichs[]={item}";
                            }
                            else
                            {
                                queryString = queryString + $"tienichs[]={item}";
                            }
                        }
                    }
                }

                DisplayAlert("TB", queryString, "OK");
                hienthiks($"https://bookinghotel.onrender.com/hotels?{queryString}");
            }
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//main");
        }

        private async void filter_btn_Clicked(object sender, EventArgs e)
        {
            if (filter == true)
            {
                await Shell.Current.GoToAsync(state: "../");
            }
            else
            {
                await Shell.Current.GoToAsync(state: "//main/search/filter");
            }    
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

        private void search_btn_Clicked(object sender, EventArgs e)
        {
            if (search_entry.Text != null)
                hienthiks($"https://bookinghotel.onrender.com/hotels?tenht={search_entry.Text}");
            else
                hienthiks("https://bookinghotel.onrender.com/hotels");
        }

        private void search_entry_Unfocused(object sender, FocusEventArgs e)
        {
            if (search_entry.Text != null)
                hienthiks($"https://bookinghotel.onrender.com/hotels?tenht={search_entry.Text}");
            else
                hienthiks("https://bookinghotel.onrender.com/hotels");
        }
    }
}