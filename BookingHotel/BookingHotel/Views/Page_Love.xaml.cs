﻿using BookingHotel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        public ObservableCollection<Hotel> dsks;
        void hienthiks()
        {
            dsks = new ObservableCollection<Hotel>();
            
            Love_Collection.ItemsSource = dsks;
        }

        public Page_Love()
        {
            InitializeComponent();
            hienthiks();
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
            Thishotel = dsks[0];
            Shell.Current.Navigation.PushAsync(new Page_Room_Info(Thishotel,Thisroom));
        }
    }
}