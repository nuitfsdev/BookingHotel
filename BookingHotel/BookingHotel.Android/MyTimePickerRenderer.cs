using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BookingHotel.Droid;
using BookingHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TimePicker = Xamarin.Forms.TimePicker;

[assembly: ExportRenderer(typeof(MyTimePicker), typeof(MyTimePickerRenderer))]

namespace BookingHotel.Droid
{
    internal class MyTimePickerRenderer:TimePickerRenderer
    {
        public MyTimePickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);

            }
        }
    }
}