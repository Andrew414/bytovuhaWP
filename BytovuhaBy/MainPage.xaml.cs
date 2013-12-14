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
        public int customerId;
        Helper helper;
        int hops = 0;

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
            App.ViewModel.LoadBasket(customerId);
        }

        private void lbxCatalog_Tap(object sender, GestureEventArgs e)
        {
            
        }

        private void lbxCatalog_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1)
                return;

            //this.NavigationService.Navigate(new Uri("/MainPage.xaml?id=2", UriKind.Relative));
            pnrAma.DefaultItem = pnrSecond;
            pnrSecond.Header = Product.CategoryToRussian((e.AddedItems[0] as ItemViewModel).LineFour).ToLower();
            App.ViewModel.LoadGoods((e.AddedItems[0] as ItemViewModel).LineFour);
            App.ViewModel.LoadGoods((e.AddedItems[0] as ItemViewModel).LineFour);
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1)
                return;
            
            ItemViewModel m = e.AddedItems[0] as ItemViewModel;
            helper.details.setup(int.Parse(m.LineFive), m.LineOneNoCat, m.LineFour, m.LineCat, m.ImgUrl);
            helper.details.display();

            this.NavigationService.Navigate(new Uri("/Details.xaml", UriKind.Relative));
        }

        private void ListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1)
                return;

            ItemViewModel f = e.AddedItems[0] as ItemViewModel;
            ItemViewModel m = App.ViewModel.CompleteData[0];
            foreach (var i in App.ViewModel.CompleteData)
            {
                if (i.LineFive == f.LineTwo)
                {
                    m = i;
                    break;
                }
            }
            helper.details.setup(int.Parse(m.LineFive), m.LineOneNoCat, m.LineFour, m.LineCat, m.ImgUrl);
            helper.details.display();

            this.NavigationService.Navigate(new Uri("/Details.xaml", UriKind.Relative));
        }

        private void btnPay_Tap(object sender, GestureEventArgs e)
        {
            string address = "http://" + helper.loginpage.tbxServer.Text + "/wppay/" + helper.mainpage.customerId.ToString();
            //MessageBox.Show(address);
            helper.GetPageOnce(address);
            App.ViewModel.ClearBasket();
            pnrAma.DefaultItem = pnrFirst;
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}