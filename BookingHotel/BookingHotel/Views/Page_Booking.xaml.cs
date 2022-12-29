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
    public partial class Page_Booking : ContentPage
    {
        public ObservableCollection<Hotel> dsks;
        async void hienthiks()
        {
            //dsks= new ObservableCollection<Hotel>();
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });
            //dsks.Add(new Hotel { HinhAnhKH = "ksdemo.jpg", TenKH = "Khách sạn Hải Âu", Tinh = "Tp Hồ Chí Minh", QuanHuyen = "Thủ Đức", GiaMin = "500000", GiaMax = "2000000", RateKH = 4, Mota="asdf asdf adsf adsf gad fga ffsđ fasg asd fa sdg asdf asd fa dga sdf asd gasdf asd f adg gasd fa sdg asdf a sdg asd f asdg a sdf ads ga sdf adsd ga sdf asd gasdf a dg asd ga gs  asdf a gasd gda agsdg asg asdg asg et ths th rtyj tyk ụy dtyj dtyj srjs tth s h stgh srtgsth shth sehsth sthsths sdhs hshs" });

            //Booking_Collection.ItemsSource = dsks;
            HttpClient httpClient = new HttpClient();
            var subjectList = await httpClient.GetStringAsync("https://bookinghotel.onrender.com/hotels");
            var subjectListConverted = JsonConvert.DeserializeObject<List<Hotel>>(subjectList);
            Booking_Collection.ItemsSource = subjectListConverted;
        }

        public Page_Booking()
        {
            InitializeComponent();
            hienthiks();
        }

        private void Add_Like_List_Tapped(object sender, EventArgs e)
        {
            ImageButton tab =(ImageButton)sender;
            //Lấy Hotel từ image
            Hotel hotel = (Hotel)tab.CommandParameter;

            if (tab.Source.ToString() == "File: heartWhite.png")
            {
                tab.Source = "heart.png";
                DisplayAlert("Thông báo",$"Đã thêm {hotel.tenht} vào yêu thích","OK");
            }
            else
            {
                tab.Source = "heartWhite.png";
            }
        }

        private async void Search_Btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "//main/search");
        }

        private void Booking_Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Hotel hotel = e.CurrentSelection[0] as Hotel;
            if (hotel == null)
                return;
            Booking_Collection.SelectedItem = SelectableItemsView.EmptyViewProperty;
            Shell.Current.Navigation.PushAsync(new Page_Hotel(hotel));
        }

        private void noibat_Clicked(object sender, EventArgs e)
        {
            noibat.TextColor = Color.FromHex("#585de4");
            noibat.BorderColor = Color.FromHex("#585de4");
            noibat.FontAttributes = FontAttributes.Bold;
            uudai.TextColor = Color.Gray;
            uudai.BorderColor = Color.FromHex("#ccc");
            uudai.FontAttributes = FontAttributes.None;
        }

        private void uudai_Clicked(object sender, EventArgs e)
        {
            noibat.TextColor = Color.Gray;
            noibat.BorderColor = Color.FromHex("#ccc");
            noibat.FontAttributes = FontAttributes.None;
            uudai.TextColor = Color.FromHex("#585de4");
            uudai.BorderColor = Color.FromHex("#585de4");
            uudai.FontAttributes = FontAttributes.Bold;
        }
    }
}