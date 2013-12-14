using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace BytovuhaBy
{
    public partial class MainPage : PhoneApplicationPage
    {
        private int customerId;
        private Helper helper;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        protected override void OnNavigatingFrom(System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            if (e.Uri.IsAbsoluteUri == true && e.Uri.AbsoluteUri == "/LoginPage.xaml")
            {
                Helper.GetHelper().ExitApp();
            }
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            helper = Helper.GetHelper();
            this.customerId = helper.loginpage.CustomerId;
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void lbxCatalog_Tap(object sender, GestureEventArgs e)
        {
            
        }

        private void lbxCatalog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //this.NavigationService.Navigate(new Uri("/MainPage.xaml?id=2", UriKind.Relative));
            pnrAma.DefaultItem = pnrSecond;
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}