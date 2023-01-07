using BookingHotel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Filter_Rooms : ContentPage
    {
        private RoomFilter _filter = new RoomFilter();
        List<int> _filtersosao = new List<int>();
        List<string> _filtertienichs = new List<string>();
        List<string> _filterloaiphong = new List<string>();
        public string[] tinhlist = new string[] { "Tp Hồ Chí Minh", "Hà Nội", "Đà Nẵng" };
        public string[] quan_HCM = new string[] { "Quận Thủ Đức", "Quận 1", "Quận 3", "Quận 4", "Quận 5", "Quận 6", "Quận 7", "Quận 8", "Quận 10", "Quận 11", "Quận 12", "Quận Bình Tân", "Quận Bình Thạnh", "Quận Gò Vấp", "Quận Phú Nhuận", "Quận Tân Bình", "Quận Tân Phú", "Huyện Bình Chánh", "Huyện Cần Giờ", "Huyện Củ Chi", "Huyện Hóc Môn", "Huyện Nhà Bè" };
        public string[] quan_HaNoi = new string[] { "Quận Hoàn Kiếm", "Quận Đống Đa", "Quận Ba Đình", "Quận Hai Bà Trưng", "Quận Hoàng Mai", "Quận Thanh Xuân", "Quận Long Biên", "Quận Nam Từ Liêm", "Quận Bắc Từ Liêm", "Quận Tây Hồ", "Quận Cầu Giấy", "Quận Hà Đông", "Thị xã Sơn Tây", "Huyện Ba Vì", "Huyện Chương Mỹ", "Huyện Phúc Thọ", "Huyện Đan Phượng", "Huyện Đông Anh", "Huyện Gia Lâm", "Huyện Hoài Đức", "Huyện Mê Linh", "Huyện Mỹ Đức", "Huyện Phú Xuyên", "Huyện Quốc Oai", "Huyện Sóc Sơn", "Huyện Thạch Thất", "Huyện Thanh Oai", "Huyện Thường Tín", "Huyện Ứng Hòa", "Huyện Thanh Trì" };
        public string[] quan_DaNang = new string[] { "Quận Hải Châu", "Quận Cẩm Lệ", "Quận Thanh Khê", "Quận Liên Chiểu", "Quận Ngũ Hành Sơn", "Quận Sơn Trà", "Huyện Hòa Vang", "Huyện Hoàng Sa"};

        public Page_Filter_Rooms()
        {
            InitializeComponent();
            tinh_filter.ItemsSource = tinhlist;
            giamin_entry.Text = RangeSlider.LowerValue.ToString();
            giamax_entry.Text = RangeSlider.UpperValue.ToString();
        }

        private void back_btn_Clicked(object sender, EventArgs e)
        {
            Shell.Current.Navigation.PopAsync();
        }

        private async void clear_btn_Tapped(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Cảnh báo", "Xóa tất cả các mục đã chỉnh sửa", "Yes", "No");
            if (answer)
            {
                //Refresh tinh,quan,rangslider
                tinh_filter.SelectedItem = -1;
                quan_filter.SelectedItem = -1;
                quan_filter.IsEnabled = false;
                RangeSlider.LowerValue = RangeSlider.MinimumValue;
                RangeSlider.UpperValue = RangeSlider.MaximumValue;
                giamin_entry.Text = RangeSlider.LowerValue.ToString();
                giamax_entry.Text = RangeSlider.UpperValue.ToString();

                //refresh sosao
                Sosao(namsao, namsao_label,5, true);
                Sosao(bonsao, bonsao_label,4, true);
                Sosao(basao, basao_label,3, true);

                // refresh tien ich khach san
                //ActiveCheckbox(hoboi, hoboi_label, "hoboi", true);
                //ActiveCheckbox(gym, gym_label, "gym", true);
                //ActiveCheckbox(bar, bar_label, "bar", true);

                //refresh loai phong
                ActiveLoaiphong(Standard, Standard_label, "standard", true);
                ActiveLoaiphong(Superior, Superior_label, "superior", true);
                ActiveLoaiphong(Deluxe, Deluxe_label, "deluxe", true);
                ActiveLoaiphong(Suite, Suite_label, "suite", true);
                ActiveLoaiphong(Connecting, Connecting_label, "connecting", true);

                //refresh tien ich cua phong
                ActiveCheckbox(Wifi, wifi_label, "wifi", true);
                ActiveCheckbox(Tulanh, tulanh_label, "tulanh", true);
                ActiveCheckbox(Dieuhoa, dieuhoa_label, "dieuhoa", true);
                ActiveCheckbox(Cacham, cacham_label, "cacham", true);
                ActiveCheckbox(Giuongdoi, giuongdoi_label, "giuongdoi", true);
                //ActiveCheckbox(Uudai, uudai_label, "uudai", true);
                //ActiveCheckbox(Noibat, noibat_label, "noibat", true);
                ActiveCheckbox(Khac, khac_label, "khac", true);

                //dat lai bo loc
                _filter.tinh = "";
                _filter.huyen = "";
                _filter.sosao = _filtersosao;
                _filter.giamin = (long)RangeSlider.LowerValue;
                _filter.giamax = (long)RangeSlider.UpperValue;
                _filter.tienichs = _filtertienichs;
            }
        }
        
        private void tinh_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tinh_filter.SelectedItem.ToString() == "Tp Hồ Chí Minh")
                quan_filter.ItemsSource = quan_HCM;
            else if (tinh_filter.SelectedItem.ToString() == "Hà Nội")
                quan_filter.ItemsSource = quan_HaNoi;
            else
                quan_filter.ItemsSource = quan_DaNang;
            quan_filter.IsEnabled = true;
        }

        private void quan_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
           //Không làm gì cả, có thể xóa
        }

        //Xử lý các số sao

        private void namsao_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            Sosao(frame, label, 5);
        }

        private void bonsao_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            Sosao(frame, label, 4);
        }

        private void basao_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            Sosao(frame, label, 3);
        }

        private void hoboi_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveCheckbox(frame, label, "hoboi");
        }

        //Xử lý loại phòng

        private void Standard_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveLoaiphong(frame, label, "standard");
        }

        private void Superior_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveLoaiphong(frame, label, "superior");
        }

        private void Deluxe_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveLoaiphong(frame, label, "deluxe");
        }

        private void Suite_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveLoaiphong(frame, label, "suite");
        }

        private void Connecting_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveLoaiphong(frame, label, "connecting");
        }

        private void gym_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveCheckbox(frame, label, "gym");
        }

        private void bar_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveCheckbox(frame, label, "bar");
        }

        private void Wifi_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveCheckbox(frame, label, "wifi");
        }

        private void Tulanh_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveCheckbox(frame, label, "tulanh");
        }

        private void Dieuhoa_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveCheckbox(frame, label, "dieuhoa");
        }

        private void Cacham_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveCheckbox(frame, label, "cacham");
        }

        private void Giuongdoi_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveCheckbox(frame, label, "giuongdoi");
        }

        //private void Uudai_tap_Tapped(object sender, EventArgs e)
        //{
        //    Frame frame = (Frame)sender;
        //    Label label = (Label)frame.Content;
        //    ActiveCheckbox(frame, label, "uudai");
        //}

        //private void Noibat_tap_Tapped(object sender, EventArgs e)
        //{
        //    Frame frame = (Frame)sender;
        //    Label label = (Label)frame.Content;
        //    ActiveCheckbox(frame, label, "noibat");
        //}

        private void RangeSlider_LowerValueChanged(object sender, EventArgs e)
        {
            if (giamin_entry.Text != "")
            {
                giamin_entry.Text = RangeSlider.LowerValue.ToString();
            }
        }

        private void RangeSlider_UpperValueChanged(object sender, EventArgs e)
        {
            if (giamax_entry.Text != "")
            {
                giamax_entry.Text = RangeSlider.UpperValue.ToString();
            }
        }

        private void giamin_entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            int n = 0;
            if (giamin_entry.Text != "" && int.TryParse(giamin_entry.Text, out n))
            {
                if(double.Parse(giamin_entry.Text) >= RangeSlider.MinimumValue && double.Parse(giamin_entry.Text) <= double.Parse(giamax_entry.Text))
                {
                    RangeSlider.LowerValue = int.Parse(giamin_entry.Text);
                }
                else
                {
                    giamin_entry.Text = RangeSlider.LowerValue.ToString();
                    DisplayAlert("Không hợp lê","Giá thấp nhất không hợp lệ!","OK");
                }
            }
        }

        private void giamax_entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            int n=0;
            if(giamax_entry.Text != "" && int.TryParse(giamax_entry.Text, out n) )
            {
                if (double.Parse(giamax_entry.Text) >= double.Parse(giamin_entry.Text) && double.Parse(giamax_entry.Text) <= RangeSlider.MaximumValue )
                {
                    RangeSlider.UpperValue = int.Parse(giamax_entry.Text);
                }
                else
                {
                    giamax_entry.Text = RangeSlider.UpperValue.ToString();
                    DisplayAlert("Không hợp lê", "Giá lớn nhất không hợp lệ!", "OK");
                }

            }
        }

        private async void filter_btn_Clicked(object sender, EventArgs e)
        {
            if (tinh_filter.SelectedItem == null)
                _filter.tinh = null;
            else
                _filter.tinh = tinh_filter.SelectedItem.ToString();

            if (quan_filter.SelectedItem == null)
                _filter.tinh = null;
            else
                _filter.huyen = quan_filter.SelectedItem.ToString();
            _filter.giamin = (long)RangeSlider.LowerValue;
            _filter.giamax = (long)RangeSlider.UpperValue;
            _filter.sogiuong = int.Parse(bed_qty.Text);
            _filter.sosao = _filtersosao;
            _filter.loaiphong = _filterloaiphong;
            _filter.tienichs = _filtertienichs;

            await Shell.Current.Navigation.PushAsync(new Page_Find_Room(_filter));
        }

        void ActiveLoaiphong(Frame frame, Label label, string loaiphong, bool filter_delete_all = false)
        {
            if (filter_delete_all)
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (_filtertienichs.Contains(loaiphong))
                {
                    _filterloaiphong.Remove(loaiphong);
                }
                return;
            }

            if (frame.BorderColor == Color.FromHex("#ccc"))
            {
                frame.BorderColor = Color.FromHex("#585de4");
                frame.BackgroundColor = Color.FromHex("#e6e6f6");
                label.TextColor = Color.FromHex("#585de4");
                _filterloaiphong.Add(loaiphong);
            }
            else
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (_filtertienichs.Contains(loaiphong))
                {
                    _filtertienichs.Remove(loaiphong);
                }
            }
        }

        void ActiveCheckbox(Frame frame, Label label, string tienich, bool filter_delete_all = false )
        {
            if(filter_delete_all)
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (_filtertienichs.Contains(tienich))
                {
                    _filtertienichs.Remove(tienich);
                }
                return;
            }    
            
            if (frame.BorderColor == Color.FromHex("#ccc"))
            {
                frame.BorderColor = Color.FromHex("#585de4");
                frame.BackgroundColor = Color.FromHex("#e6e6f6");
                label.TextColor = Color.FromHex("#585de4");
                _filtertienichs.Add(tienich);
            }
            else
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (_filtertienichs.Contains(tienich))
                {
                    _filtertienichs.Remove(tienich);
                }
            }
        }

        void Sosao(Frame frame, Label label, int sosao, bool filter_delete_all = false)
        {
            if (filter_delete_all)
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (_filtersosao.Contains(sosao))
                {
                    _filtersosao.Remove(sosao);
                }
                return;
            }

            if (frame.BorderColor == Color.FromHex("#ccc"))
            {
                frame.BorderColor = Color.FromHex("#585de4");
                frame.BackgroundColor = Color.FromHex("#e6e6f6");
                label.TextColor = Color.FromHex("#585de4");
                _filtersosao.Add(sosao);
            }
            else
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (_filtersosao.Contains(sosao))
                {
                    _filtersosao.Remove(sosao);
                }
            }
        }

        private void khac_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveCheckbox(frame, label, "khac");
        }

        private void bed_qty_decre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(bed_qty.Text);
            if (old_value > 1)
                bed_qty.Text = $"{old_value - 1}";
        }

        private void bed_qty_incre_Clicked(object sender, EventArgs e)
        {
            int old_value = int.Parse(bed_qty.Text);
            bed_qty.Text = $"{old_value + 1}";
        }
    }
}