﻿using BookingHotel.Models;
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
        List<string> _filterloaigiuong = new List<string>();

        public string[] tinhlist = new string[] { "TP Hồ Chí Minh", "Hà Nội", "Đà Nẵng" };
        public string[] quan_HCM = new string[] { "Quận Thủ Đức", "Quận 1", "Quận 3", "Quận 4", "Quận 5", "Quận 6", "Quận 7", "Quận 8", "Quận 10", "Quận 11", "Quận 12", "Quận Bình Tân", "Quận Bình Thạnh", "Quận Gò Vấp", "Quận Phú Nhuận", "Quận Tân Bình", "Quận Tân Phú", "Huyện Bình Chánh", "Huyện Cần Giờ", "Huyện Củ Chi", "Huyện Hóc Môn", "Huyện Nhà Bè" };
        public string[] quan_HaNoi = new string[] { "Quận Hoàn Kiếm", "Quận Đống Đa", "Quận Ba Đình", "Quận Hai Bà Trưng", "Quận Hoàng Mai", "Quận Thanh Xuân", "Quận Long Biên", "Quận Nam Từ Liêm", "Quận Bắc Từ Liêm", "Quận Tây Hồ", "Quận Cầu Giấy", "Quận Hà Đông", "Thị xã Sơn Tây", "Huyện Ba Vì", "Huyện Chương Mỹ", "Huyện Phúc Thọ", "Huyện Đan Phượng", "Huyện Đông Anh", "Huyện Gia Lâm", "Huyện Hoài Đức", "Huyện Mê Linh", "Huyện Mỹ Đức", "Huyện Phú Xuyên", "Huyện Quốc Oai", "Huyện Sóc Sơn", "Huyện Thạch Thất", "Huyện Thanh Oai", "Huyện Thường Tín", "Huyện Ứng Hòa", "Huyện Thanh Trì" };
        public string[] quan_DaNang = new string[] { "Quận Hải Châu", "Quận Cẩm Lệ", "Quận Thanh Khê", "Quận Liên Chiểu", "Quận Ngũ Hành Sơn", "Quận Sơn Trà", "Huyện Hòa Vang", "Huyện Hoàng Sa"};

        public Page_Filter_Rooms()
        {
            InitializeComponent();
            tinh_filter.ItemsSource = tinhlist;
            giamin_entry.Text = RangeSlider.LowerValue.ToString();
            giamax_entry.Text = RangeSlider.UpperValue.ToString();

            //gán sẵn tỉnh và quận cho hai picker
            if (App.quick_tinh != "")
            {
                tinh_filter.SelectedItem = App.quick_tinh;
                if (App.quick_tinh == "TP Hồ Chí Minh")
                    quan_filter.ItemsSource = quan_HCM;
                else if (App.quick_tinh == "Hà Nội")
                    quan_filter.ItemsSource = quan_HaNoi;
                else
                    quan_filter.ItemsSource = quan_DaNang;
                quan_filter.IsEnabled = true;
                quan_filter.SelectedItem = App.quick_quan;
            }
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

                //refresh so luong phong
                bed_qty.Text = "1";

                //refresh loai phong
                ActiveLoaiphong(Standard, Standard_label, "Basic", true);
                ActiveLoaiphong(Superior, Superior_label, "Superior", true);
                ActiveLoaiphong(Deluxe, Deluxe_label, "Deluxe", true);
                ActiveLoaiphong(Suite, Suite_label, "Suite", true);

                //refresh tien ich cua phong
                ActiveCheckbox(Wifi, wifi_label, "Wifi", true);
                ActiveCheckbox(Tulanh, tulanh_label, "Tủ lạnh", true);
                ActiveCheckbox(Dieuhoa, dieuhoa_label, "Máy lạnh", true);
                //ActiveCheckbox(Cacham, cacham_label, "cacham", true);

                //refresh loai phong
                ActiveLoaiGiuong(Giuongdoi, giuongdoi_label, "Giường đôi", true);
                ActiveLoaiGiuong(Giuongdon, giuongdon_label, "Giường đơn", true);
                //refresh khac
                ActiveKhac(Uudai, uudai_label, "uudai", true);
                ActiveKhac(Noibat, noibat_label, "noibat", true);


                //dat lai bo loc
                _filter.tinh = "";
                _filter.quan = "";
                _filter.sosao = _filtersosao;
                _filter.giamin = (long)RangeSlider.LowerValue;
                _filter.giamax = (long)RangeSlider.UpperValue;
                _filter.tienichs = _filtertienichs;
            }
        }
        
        private void tinh_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tinh_filter.SelectedItem.ToString() == "TP Hồ Chí Minh")
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
            ActiveLoaiphong(frame, label, "Basic");
        }

        private void Superior_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveLoaiphong(frame, label, "Superior");
        }

        private void Deluxe_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveLoaiphong(frame, label, "Deluxe");
        }

        private void Suite_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveLoaiphong(frame, label, "Suite");
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
            ActiveCheckbox(frame, label, "Wifi");
        }

        private void Tulanh_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveCheckbox(frame, label, "Tủ lạnh");
        }

        private void Dieuhoa_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveCheckbox(frame, label, "Máy lạnh");
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
            ActiveLoaiGiuong(frame, label, "Giường đôi");
        }

        private void Giuongdon_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveLoaiGiuong(frame, label, "Giường đơn");
        }

        private void Uudai_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveKhac(frame, label, "uudai");
        }

        private void Noibat_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            ActiveKhac(frame, label, "noibat");
        }

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
            if (tinh_filter.SelectedItem == null || tinh_filter.SelectedItem.ToString() == "-1" || tinh_filter.SelectedItem.ToString() == "")
                _filter.tinh = null;
            else if (tinh_filter.SelectedItem.ToString() == "TP Hồ Chí Minh")
            {
                _filter.tinh = "TP";
            }
            else if (tinh_filter.SelectedItem.ToString() == "Hà Nội")
            {
                _filter.tinh = "Ha";
            }
            else
                _filter.tinh = tinh_filter.SelectedItem.ToString();

            if (quan_filter.SelectedItem == null || quan_filter.SelectedItem.ToString() == "-1" || quan_filter.SelectedItem.ToString() == "")
                _filter.quan = null;
            else
                _filter.quan = quan_filter.SelectedItem.ToString();
            
            _filter.giamin = (long)RangeSlider.LowerValue;
            _filter.giamax = (long)RangeSlider.UpperValue;
            _filter.sogiuong = int.Parse(bed_qty.Text);
            _filter.sosao = _filtersosao;
            _filter.loaiphong = _filterloaiphong;
            _filter.loaigiuong = _filterloaigiuong;
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
                if (_filterloaiphong.Contains(loaiphong))
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
                if (_filterloaiphong.Contains(loaiphong))
                {
                    _filterloaiphong.Remove(loaiphong);
                }
            }
        }

        void ActiveLoaiGiuong(Frame frame, Label label, string loaigiuong, bool filter_delete_all = false)
        {
            if (filter_delete_all)
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (_filterloaigiuong.Contains(loaigiuong))
                {
                    _filterloaigiuong.Remove(loaigiuong);
                }
                return;
            }

            if (frame.BorderColor == Color.FromHex("#ccc"))
            {
                frame.BorderColor = Color.FromHex("#585de4");
                frame.BackgroundColor = Color.FromHex("#e6e6f6");
                label.TextColor = Color.FromHex("#585de4");
                _filterloaigiuong.Add(loaigiuong);
            }
            else
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (_filterloaigiuong.Contains(loaigiuong))
                {
                    _filterloaigiuong.Remove(loaigiuong);
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

        void ActiveKhac (Frame frame, Label label, string khac, bool filter_delete_all = false)
        {
            if (filter_delete_all)
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                _filter.uudai = false;
                _filter.noibat = false;
                return;
            }

            if (frame.BorderColor == Color.FromHex("#ccc"))
            {
                frame.BorderColor = Color.FromHex("#585de4");
                frame.BackgroundColor = Color.FromHex("#e6e6f6");
                label.TextColor = Color.FromHex("#585de4");
                if (khac == "uudai") _filter.uudai = true;
                if (khac == "noibat") _filter.noibat = true;
            }
            else
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (khac == "uudai") _filter.uudai = true;
                if (khac == "noibat") _filter.noibat = true;
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