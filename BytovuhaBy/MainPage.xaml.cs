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

            helper = Helper.GetHelper();
            helper.mainpage = this;

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
            pnrSecond.Header = Product.CategoryToRussian((e.AddedItems[0] as ItemViewModel).LineFour).ToLower();
            App.ViewModel.LoadGoods((e.AddedItems[0] as ItemViewModel).LineFour);
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ItemViewModel m = e.AddedItems[0] as ItemViewModel;
            helper.details.setup(int.Parse(m.LineFive), m.LineOneNoCat, m.LineFour, m.LineCat, m.ImgUrl);
            helper.details.display();

            this.NavigationService.Navigate(new Uri("/Details.xaml", UriKind.Relative));
        }
    }
}