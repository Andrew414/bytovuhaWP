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
        public static Image img;
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


        }

        public void display()
        {
            lblName.Text = name;
            lblCategory.Text = category;
            lblDesc.Text = desc;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            display();
        }
    }
}