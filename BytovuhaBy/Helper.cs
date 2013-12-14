using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace BytovuhaBy
{
    class Helper
    {
        private Helper() { }
        private static Helper inst = null;

        public static Helper GetHelper() 
        {
            if (inst == null) inst = new Helper();
            return inst;
        }

        public CookieContainer cookie;

        public LoginPage loginpage;
        public MainPage mainpage;
        public Details details;
        public bool getPageReady = false;

        //private void myBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        //{
        //    dynamic doc = loginpage.webCheck.;
        //    dynamic htmlText = doc.documentElement.InnerHtml;
        //    string htmlstring = htmlText;
        //}

        //public static string GetPage(string path)
        //{
        //    WebRequest request = WebRequest.Create(path);
        //    WebResponse response = request.getRes
        //}

        public string GetPage(string path)
        {
            getPageReady = false;
            loginpage.webCheck.Navigate(new Uri(path));
            loginpage.webCheck.LoadCompleted += webCheck_LoadCompleted;
            //while (!getPageReady) ;
            System.Threading.Thread.Sleep(100);
            return loginpage.webCheck.SaveToString();
        }

        public string GetPageGoods(string path)
        {
            getPageReady = false;
            loginpage.webCheckGoods.Navigate(new Uri(path));
            loginpage.webCheckGoods.LoadCompleted += webCheck_LoadCompleted;
            //while (!getPageReady) ;
            System.Threading.Thread.Sleep(100);
            return loginpage.webCheckGoods.SaveToString();
        }

        public string GetPageBuyings(string path)
        {
            getPageReady = false;
            loginpage.webCheckBuyings.Navigate(new Uri(path));
            loginpage.webCheckBuyings.LoadCompleted += webCheck_LoadCompleted;
            //while (!getPageReady) ;
            System.Threading.Thread.Sleep(100);
            return loginpage.webCheckBuyings.SaveToString();
        }

        void webCheck_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            getPageReady = true; 
        }

        private void GetPageHWR(string path)
        {
            System.Uri targetUri = new System.Uri(path);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(targetUri);
            request.BeginGetResponse(new AsyncCallback(ReadWebRequestCallback), request);
        }

        private void ReadWebRequestCallback(IAsyncResult callbackResult)
        {
            HttpWebRequest myRequest = (HttpWebRequest)callbackResult.AsyncState;
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.EndGetResponse(callbackResult);
            using (StreamReader httpwebStreamReader = new StreamReader(myResponse.GetResponseStream()))
            {
                string results = httpwebStreamReader.ReadToEnd();
                //TextBlockResults.Text = results; //-- on another thread!
                
            }
        }

        public void ExitApp()
        {
            throw new Exception("killing the app");
        }
    }
}
