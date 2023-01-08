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
    public partial class Page_Find_Room : ContentPage
    {
        //Hotel thishotel;
        async void hienthidsphong(string urlAPI)
        {
            HttpClient httpClient = new HttpClient();
            var RoomList = await httpClient.GetStringAsync(urlAPI);
            var RoomListConverted = JsonConvert.DeserializeObject<List<Room>>(RoomList);
            RoomList_Collection.ItemsSource = RoomListConverted;
        }

        public Page_Find_Room()
        {
            InitializeComponent();
            hienthidsphong("https://bookinghotel.onrender.com/rooms");
        }

        bool filter = false;

        public Page_Find_Room(RoomFilter roomFilter)
        {
            InitializeComponent();
            filter = true;
            if (roomFilter == null)
            {
                hienthidsphong("https://bookinghotel.onrender.com/rooms");
            }
            else
            {
                string queryString = "";
                if (roomFilter.tinh != null)
                {
                    queryString = queryString + $"tinh={roomFilter.tinh}";
                }
                if (roomFilter.huyen != null)
                {
                    if (queryString != "")
                    {
                        queryString = queryString + $"&huyen={roomFilter.huyen}";

                    }
                    else
                    {
                        queryString = queryString + $"huyen={roomFilter.huyen}";
                    }

                }
                if (roomFilter.sosao.Count > 0)
                {
                    if (queryString != "")
                    {
                        foreach (var item in roomFilter.sosao)
                        {
                            queryString = queryString + $"&sosao[]={item}";
                        }
                    }
                    else
                    {
                        foreach (var item in roomFilter.sosao)
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
                if (roomFilter.giamin != null)
                {
                    if (queryString != "")
                    {
                        queryString = queryString + $"&giamin={roomFilter.giamin}";

                    }
                    else
                    {
                        queryString = queryString + $"giamin={roomFilter.giamin}";
                    }

                }
                if (roomFilter.giamax != null)
                {
                    if (queryString != "")
                    {
                        queryString = queryString + $"&giamax={roomFilter.giamax}";

                    }
                    else
                    {
                        queryString = queryString + $"giamax={roomFilter.giamax}";
                    }
                }
                if(roomFilter.sogiuong != null)
                {
                    if (queryString != "")
                    {
                        queryString = queryString + $"&sogiuong={roomFilter.sogiuong}";

                    }
                    else
                    {
                        queryString = queryString + $"sogiuong={roomFilter.sogiuong}";
                    }
                }
                if (roomFilter.loaigiuong.Count >0)
                {
                    if (queryString != "")
                    {
                        foreach (var item in roomFilter.loaigiuong)
                        {
                            queryString = queryString + $"&loaigiuong[]={item}";
                        }
                    }
                    else
                    {
                        foreach (var item in roomFilter.loaigiuong)
                        {
                            if (queryString.Contains("loaigiuong"))
                            {
                                queryString = queryString + $"&loaigiuong[]={item}";
                            }
                            else
                            {
                                queryString = queryString + $"loaigiuong[]={item}";
                            }
                        }
                    }
                }
                if (roomFilter.tienichs.Count > 0)
                {
                    if (queryString != "")
                    {
                        foreach (var item in roomFilter.tienichs)
                        {
                            queryString = queryString + $"&tienichs[]={item}";
                        }
                    }
                    else
                    {
                        foreach (var item in roomFilter.tienichs)
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
                if (roomFilter.khac.Count > 0)
                {
                    if (queryString != "")
                    {
                        foreach (var item in roomFilter.khac)
                        {
                            queryString = queryString + $"&khac[]={item}";
                        }
                    }
                    else
                    {
                        foreach (var item in roomFilter.khac)
                        {
                            if (queryString.Contains("khac"))
                            {
                                queryString = queryString + $"&khac[]={item}";
                            }
                            else
                            {
                                queryString = queryString + $"khac[]={item}";
                            }
                        }
                    }
                }
                if (roomFilter.loaiphong.Count >0)
                {
                    if (queryString != "")
                    {
                        foreach (var item in roomFilter.loaiphong)
                        {
                            queryString = queryString + $"&loaiphong[]={item}";
                        }
                    }
                    else
                    {
                        foreach (var item in roomFilter.loaiphong)
                        {
                            if (queryString.Contains("loaiphong"))
                            {
                                queryString = queryString + $"&loaiphong[]={item}";
                            }
                            else
                            {
                                queryString = queryString + $"loaiphong[]={item}";
                            }
                        }
                    }
                }    

                DisplayAlert("TB", queryString, "OK");
                hienthidsphong($"https://bookinghotel.onrender.com/rooms?{queryString}");
            }
        }

        private async void RoomList_Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room room = e.CurrentSelection[0] as Room;
            if (room == null)
                return;
            RoomList_Collection.SelectedItem = SelectableItemsView.EmptyViewProperty;

            HttpClient httpClient = new HttpClient();
            var Hotel = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/hotels?maht={room.maht}");
            var HotelConverted = JsonConvert.DeserializeObject<List<Hotel>>(Hotel);

            await Shell.Current.Navigation.PushAsync(new Page_Room_Info(HotelConverted[0], room));
        }

        private async void Filter_btn_Clicked(object sender, EventArgs e)
        {
            if (filter == true)
            {
                await Shell.Current.GoToAsync(state: "../");
            }
            else
            {
                await Shell.Current.GoToAsync(state: "//main/findroom/roomfilter");
            }
            
        }

        private async void book_btn_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Room room = (Room)btn.CommandParameter;

            HttpClient httpClient = new HttpClient();
            var Hotel = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/hotels?maht={room.maht}");
            var HotelConverted = JsonConvert.DeserializeObject<List<Hotel>>(Hotel);

            await Shell.Current.Navigation.PushAsync(new Page_Booking_Info(HotelConverted[0], room));
        }

        private async void KS_btn_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Room room = (Room)btn.CommandParameter;

            HttpClient httpClient = new HttpClient();
            var Hotel = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/hotels?maht={room.maht}");
            var HotelConverted = JsonConvert.DeserializeObject<List<Hotel>>(Hotel);

            await Shell.Current.Navigation.PushAsync(new Page_Hotel(HotelConverted[0]));
        }

        //async void LayHotel(string maht)
        //{
        //    HttpClient httpClient = new HttpClient();
        //    var Hotel = await httpClient.GetStringAsync($"https://bookinghotel.onrender.com/hotels?maht={maht}");
        //    var HotelConverted = JsonConvert.DeserializeObject<List<Hotel>>(Hotel);
        //    thishotel = HotelConverted[0];
        //}

    }
}