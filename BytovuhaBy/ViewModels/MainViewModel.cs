using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace BytovuhaBy
{
    public class MainViewModel : INotifyPropertyChanged
    {
        Helper helper;

        public MainViewModel()
        {
            this.Categories = new ObservableCollection<ItemViewModel>();
            this.CategoryItems = new ObservableCollection<ItemViewModel>();

            helper = Helper.GetHelper();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Categories { get; private set; }
        public ObservableCollection<ItemViewModel> CategoryItems { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadGoods(string category)
        {

            string page; 
            System.Threading.Thread.Sleep(1000);
            do
            {
                   page = helper.GetPageGoods("http://" + helper.loginpage.tbxServer.Text + "/wpproducts/");
                   System.Threading.Thread.Sleep(500);
            } while (page.Length < 10);

            page = page.Replace("<HEAD>", "\\").Replace("</HEAD>", "\\").
                        Replace("<BODY>", "\\").Replace("</BODY>", "\\").
                        Replace("<HTML>", "\\").Replace("</HTML>", "\\").
                        Replace("<BR>", "\\");

            List<Product> products = new List<Product>();

            string[] lines = page.Split(new char[] { '\r', '\n', '\\' }, StringSplitOptions.RemoveEmptyEntries);

            //MessageBox.Show(page.Length.ToString() + "\n" +  lines.Length.ToString() + "\n" + page);
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {

            this.Categories.Add(new ItemViewModel() { LineOne = "Все продукты", LineFour = "" });
            this.Categories.Add(new ItemViewModel() { LineOne = "Стиральные машины", LineFour = "Washing_machines" });
            this.Categories.Add(new ItemViewModel() { LineOne = "Электроника", LineFour = "Electronics" });
            this.Categories.Add(new ItemViewModel() { LineOne = "Чайники", LineFour = "Pots" });
            this.Categories.Add(new ItemViewModel() { LineOne = "Тостеры", LineFour = "Tosters" });

            LoadGoods("");

            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}