using BookingHotel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_Filter : ContentPage
    {
        private HotelFilter _filter= new HotelFilter();
        List<int> _filtersosao = new List<int>();
        List<string> _filtertienichs = new List<string>();

        public Page_Filter()
        {
            InitializeComponent();
            giamin_entry.Text=RangeSlider.LowerValue.ToString();
            giamax_entry.Text = RangeSlider.UpperValue.ToString();
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(state: "../");
        }

        private void clear_btn_Tapped(object sender, EventArgs e)
        {

        }

        private void tinh_filter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void quan_filter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void namsao_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            if (frame.BorderColor == Color.FromHex("#ccc"))
            {
                frame.BorderColor = Color.FromHex("#585de4");
                frame.BackgroundColor = Color.FromHex("#e6e6f6");

                label.TextColor= Color.FromHex("#585de4");
                _filtersosao.Add(5);
            }
            else
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if(_filtersosao.Contains(5))
                {
                    _filtersosao.Remove(5);
                }    
            }
        }

        private void bonsao_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            if (frame.BorderColor == Color.FromHex("#ccc"))
            {
                frame.BorderColor = Color.FromHex("#585de4");
                frame.BackgroundColor = Color.FromHex("#e6e6f6");
                label.TextColor = Color.FromHex("#585de4");
                _filtersosao.Add(4);
            }
            else
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (_filtersosao.Contains(4))
                {
                    _filtersosao.Remove(4);
                }
            }
        }

        private void basao_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            if (frame.BorderColor == Color.FromHex("#ccc"))
            {
                frame.BorderColor = Color.FromHex("#585de4");
                frame.BackgroundColor = Color.FromHex("#e6e6f6");
                label.TextColor = Color.FromHex("#585de4");
                _filtersosao.Add(3);
            }
            else
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (_filtersosao.Contains(3))
                {
                    _filtersosao.Remove(3);
                }
            }
        }

        private void hoboi_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            if (frame.BorderColor == Color.FromHex("#ccc"))
            {
                frame.BorderColor = Color.FromHex("#585de4");
                frame.BackgroundColor = Color.FromHex("#e6e6f6");
                label.TextColor = Color.FromHex("#585de4");
                _filtertienichs.Add("hoboi");
            }
            else
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (_filtertienichs.Contains("hoboi"))
                {
                    _filtertienichs.Remove("hoboi");
                }
            }
        }

        private void gym_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            if (frame.BorderColor == Color.FromHex("#ccc"))
            {
                frame.BorderColor = Color.FromHex("#585de4");
                frame.BackgroundColor = Color.FromHex("#e6e6f6");
                label.TextColor = Color.FromHex("#585de4");
                _filtertienichs.Add("gym");
            }
            else
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (_filtertienichs.Contains("gym"))
                {
                    _filtertienichs.Remove("gym");
                }
            }
        }

        private void bar_tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = (Frame)sender;
            Label label = (Label)frame.Content;
            if (frame.BorderColor == Color.FromHex("#ccc"))
            {
                frame.BorderColor = Color.FromHex("#585de4");
                frame.BackgroundColor = Color.FromHex("#e6e6f6");
                label.TextColor = Color.FromHex("#585de4");
                _filtertienichs.Add("bar");
            }
            else
            {
                frame.BorderColor = Color.FromHex("#ccc");
                frame.BackgroundColor = Color.FromHex("#fff");
                label.TextColor = Color.DimGray;
                if (_filtertienichs.Contains("bar"))
                {
                    _filtertienichs.Remove("bar");
                }
            }
        }

        private void RangeSlider_LowerValueChanged(object sender, EventArgs e)
        {
            giamin_entry.Text = RangeSlider.LowerValue.ToString();
            _filter.giamin = (long)RangeSlider.LowerValue;
        }

        private void RangeSlider_UpperValueChanged(object sender, EventArgs e)
        {
            giamax_entry.Text = RangeSlider.UpperValue.ToString();
            _filter.giamax = (long)RangeSlider.UpperValue;
        }

        private void giamin_entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            //RangeSlider.LowerValue=int.Parse(giamin_entry.Text);
            if(giamin_entry.Text != ""){
            _filter.giamin = long.Parse(giamin_entry.Text);
            }
        }

        private void giamax_entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            //RangeSlider.UpperValue = int.Parse(giamax_entry.Text);
            if (giamax_entry.Text != "")
            {
                _filter.giamax = long.Parse(giamax_entry.Text);
            }

        }

        private  async void filter_btn_Clicked(object sender, EventArgs e)
        {
            _filter.sosao = _filtersosao;
            _filter.tienichs = _filtertienichs;
            await Shell.Current.Navigation.PushAsync(new Page_Search(_filter));
        }
    }
}