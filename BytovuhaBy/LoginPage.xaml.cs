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
    public partial class LoginPage : PhoneApplicationPage
    {
        Helper helper = null;
        public int CustomerId = -1;

        public LoginPage()
        {
            InitializeComponent();
            //MessageBox.Show("http://" + tbxServer.Text + "/");
            //webCheck.Navigate(new Uri("http://" + tbxServer.Text + "/"));
            helper = Helper.GetHelper();
            helper.loginpage = this;

            new MainPage();
            new Details();
            LoadData();
        }

        public void LoadData()
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void tbxPass_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            
        }

        private void ShowBadLogin()
        {
            lblWrong.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
        }

        private bool checkresponse(string username, string pass, string page)
        {
            try
            {
                page = page.Replace("<HEAD>", "|").Replace("</HEAD>", "|").
                            Replace("<BODY>", "|").Replace("</BODY>", "|").
                            Replace("<HTML>", "|").Replace("</HTML>", "|").
                            Replace("<BR>", "|");
                string[] parsed = page.Split(new char[] { '<', '>', ' ', '|', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                return (username == parsed[1] && pass == parsed[2]);
            }
            catch
            {
                return false;
            }
        }

        private void btnLogin_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int customerId = -1;
            string page;
            do
            {
                page = helper.GetPage("http://" + tbxServer.Text + "/wplogin/" + tbxLogin.Text + "/" + tbxPass.Password);
                System.Threading.Thread.Sleep(1000);
            } while ((page.Length > 1000 || page.Length < 5) 
                || !checkresponse(tbxLogin.Text, tbxPass.Password, page)); // usually 4K+, I know how dirty is this hack...
            page = page.Replace("<HEAD>", "|").Replace("</HEAD>", "|").
                        Replace("<BODY>", "|").Replace("</BODY>", "|").
                        Replace("<HTML>", "|").Replace("</HTML>", "|").
                        Replace("<BR>", "|");
            string[] parsed = page.Split(new char[] { '<', '>', ' ', '|', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                customerId = int.Parse(parsed[0]);
                if (customerId == -1)
                {
                    ShowBadLogin();
                }
                else
                {
                    CustomerId = customerId;
                    this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
            }
            catch (Exception)
            {
                ShowBadLogin();
            }
        }
    }
}