using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace BytovuhaBy
{
    public partial class Details : PhoneApplicationPage
    {
        public static string name;
        public static string desc;
        public static string category;
        public static string img;
        public static int id;

        Helper helper = null;

        public Details()
        {
            InitializeComponent();
            helper = Helper.GetHelper();
            helper.details = this;
        }

        public void setup(int id_, string name_, string desc_, string cat_, string imgurl_)
        {
            id = id_;
            name = name_;
            desc = desc_;
            category = cat_;

            img = imgurl_;
        }

        public void display()
        {
            lblName.Text = name;
            lblCategory.Text = category;
            lblDesc.Text = desc;

            System.Windows.Media.Imaging.BitmapImage src = new System.Windows.Media.Imaging.BitmapImage();
            src.UriSource = new Uri(img, UriKind.Absolute);
            imgPic.Source = src;

        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            display();
        }

        private void btnBuy_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string address = "http://" + helper.loginpage.tbxServer.Text + "/wpbuy/" + helper.mainpage.customerId.ToString() + "/" + id.ToString();
            //MessageBox.Show(address);
            helper.GetPageOnce(address);
            App.ViewModel.LoadBasket(helper.mainpage.customerId);
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}