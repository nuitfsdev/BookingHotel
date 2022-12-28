using BookingHotel.Models;
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
    public partial class Page_Rooms : ContentPage
    {
        Hotel Thishotel;
        Room Thisroom;
        public ObservableCollection<Room> dsr;
        void hienthiks()
        {
            dsr = new ObservableCollection<Room>();
            dsr.Add(new Room { ID = 1 });
            dsr.Add(new Room { ID = 2 });
            dsr.Add(new Room { ID = 3 });
            dsr.Add(new Room { ID = 4 });
            dsr.Add(new Room { ID = 5 });
            Rooms_Collection.ItemsSource = dsr;
        }

        public Page_Rooms(Hotel hotel)
        {
            InitializeComponent();
            Thishotel = hotel;
            hienthiks();
        }

        private void book_btn_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Room room = (Room)btn.CommandParameter;
            Shell.Current.Navigation.PushAsync(new Page_Booking_Info(Thishotel, room));
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private void Rooms_Collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Thisroom = e.CurrentSelection[0] as Room;
            if (Thisroom == null)
                return;
            Rooms_Collection.SelectedItem = SelectableItemsView.EmptyViewProperty;
            Shell.Current.Navigation.PushAsync(new Page_Room_Info(Thishotel, Thisroom));
        }
    }
}