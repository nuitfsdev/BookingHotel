﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Behaviors;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookingHotel.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_User_Info : ContentPage
    {
        public Page_User_Info()
        {
            InitializeComponent();
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.Navigation.PopAsync();
        }

        private async void change_avatar_Clicked(object sender, EventArgs e)
        {
            var file = await FilePicker.PickAsync();

            if (file.FileName.EndsWith(".png") || file.FileName.EndsWith(".jpg"))
            {
                change_avatar.Source = file.FullPath;
            }

            else return;
        }
    }
}