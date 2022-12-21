using BookingHotel.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BookingHotel
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
            Routing.RegisterRoute("main/home",typeof(Page_Home));
            Routing.RegisterRoute("main/book", typeof(Page_Booking));
            Routing.RegisterRoute("main/order", typeof(Page_Order));
            Routing.RegisterRoute("main/love", typeof(Page_Love));
            Routing.RegisterRoute("main/account", typeof(Page_Account));
            Routing.RegisterRoute("main/search", typeof(Page_Search));
            Routing.RegisterRoute("main/announcement", typeof(Page_Announcement));
        }
    }
}
