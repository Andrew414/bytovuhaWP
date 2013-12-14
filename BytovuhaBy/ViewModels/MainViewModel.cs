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
            this.CompleteData = new ObservableCollection<ItemViewModel>();
            this.BasketItems = new ObservableCollection<ItemViewModel>();

            helper = Helper.GetHelper();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Categories { get; private set; }
        public ObservableCollection<ItemViewModel> CategoryItems { get; private set; }
        public ObservableCollection<ItemViewModel> CompleteData { get; private set; }
        public ObservableCollection<ItemViewModel> BasketItems { get; private set; }

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
            CategoryItems.Clear();

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

            foreach (var i in lines)
            {
                string[] line = i.Split(new char[] { '|' }, StringSplitOptions.None);


                Product product;
                try
                {
                    product = new Product() 
                        { 
                            id = int.Parse(line[0]), 
                            name = line[1],
                            price = int.Parse(line[2]),
                            category = line[3],
                            image_url = line[4],
                            description = line[5],
                        };
                    if (category == "" || category == product.category)
                    {
                        products.Add(product);
                    }
                }
                catch (Exception)
                {

                }
            }

            foreach (var i in products)
            {
                Image img = new Image();
                BitmapImage src = new BitmapImage();
                string uri = "http://" + (helper = Helper.GetHelper()).loginpage.tbxServer.Text + i.image_url;
                //string uri = @"http://st.gdefon.com/wallpapers_original/wallpapers/147278_kotik_1680x1050_(www.GdeFon.ru).jpg";
                //string uri = @"/arrowr.png";
                src.UriSource = new Uri(uri, UriKind.RelativeOrAbsolute);
                img.Source = src;

                //MessageBox.Show(uri);

                ItemViewModel item = new ItemViewModel()
                    {
                        LineOne = i.name,
                        LineTwo = i.price.ToString(),
                        LineThree = i.category,
                        LineFour = i.description,
                        LineFive = i.id.ToString(),

                        LineOneNoCat = i.name.Replace("Стиральная машина ","").Replace("Ноутбук ", "")
                                .Replace("Чайник ", "").Replace("Тостер ", ""),
                        LineCat = Product.CategoryItemToRussian(i.category),
                        LineInfo = Product.CategoryItemToRussian(i.category) + ", " + "$" + i.price.ToString(), 

                        ImgUrl = uri,
                        Image = img
                    };
                this.CategoryItems.Add(item);
            }

            //MessageBox.Show(page.Length.ToString() + "\n" +  lines.Length.ToString() + "\n" + page);
        }

        public void LoadCompleteData()
        {
            CompleteData.Clear();

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

            foreach (var i in lines)
            {
                string[] line = i.Split(new char[] { '|' }, StringSplitOptions.None);


                Product product;
                try
                {
                    product = new Product()
                    {
                        id = int.Parse(line[0]),
                        name = line[1],
                        price = int.Parse(line[2]),
                        category = line[3],
                        image_url = line[4],
                        description = line[5],
                    };
                        
                    products.Add(product);
                }
                catch (Exception)
                {

                }
            }

            foreach (var i in products)
            {
                Image img = new Image();
                BitmapImage src = new BitmapImage();
                string uri = "http://" + (helper = Helper.GetHelper()).loginpage.tbxServer.Text + i.image_url;
                //string uri = @"http://st.gdefon.com/wallpapers_original/wallpapers/147278_kotik_1680x1050_(www.GdeFon.ru).jpg";
                //string uri = @"/arrowr.png";
                src.UriSource = new Uri(uri, UriKind.RelativeOrAbsolute);
                img.Source = src;

                //MessageBox.Show(uri);

                ItemViewModel item = new ItemViewModel()
                {
                    LineOne = i.name,
                    LineTwo = i.price.ToString(),
                    LineThree = i.category,
                    LineFour = i.description,
                    LineFive = i.id.ToString(),

                    LineOneNoCat = i.name.Replace("Стиральная машина ", "").Replace("Ноутбук ", "")
                            .Replace("Чайник ", "").Replace("Тостер ", ""),
                    LineCat = Product.CategoryItemToRussian(i.category),
                    LineInfo = Product.CategoryItemToRussian(i.category) + ", " + "$" + i.price.ToString(),

                    ImgUrl = uri,
                    Image = img
                };
                this.CompleteData.Add(item);
            }

            //MessageBox.Show(page.Length.ToString() + "\n" +  lines.Length.ToString() + "\n" + page);
        }

        public void ClearBasket()
        {
            BasketItems.Clear();
        }

        public void LoadBasket(int userid)
        {
            BasketItems.Clear();

            string page;
            System.Threading.Thread.Sleep(1000);
            do
            {
                page = helper.GetPageGoods("http://" + helper.loginpage.tbxServer.Text + "/wpbuyings/");
                System.Threading.Thread.Sleep(500);
            } while (page.Length < 10);

            page = page.Replace("<HEAD>", "\\").Replace("</HEAD>", "\\").
                        Replace("<BODY>", "\\").Replace("</BODY>", "\\").
                        Replace("<HTML>", "\\").Replace("</HTML>", "\\").
                        Replace("<BR>", "\\");

            List<BuyingInfo> infos = new List<BuyingInfo>();

            string[] lines = page.Split(new char[] { '\r', '\n', '\\' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var i in lines)
            {
                string[] line = i.Split(new char[] { '|' }, StringSplitOptions.None);


                BuyingInfo info;
                try
                {
                    info = new BuyingInfo()
                    {
                        customerId = int.Parse(line[0]),
                        productId = int.Parse(line[1]),
                        amount = int.Parse(line[2]),
                    };
                    if (info.customerId == userid)
                    {
                        infos.Add(info);
                    }
                }
                catch (Exception)
                {

                }
            }

            foreach (var i in infos)
            {
                string productName = "";
                foreach (var j in CompleteData)
                {
                    if (i.productId.ToString() == j.LineFive)
                    {
                        productName = j.LineOneNoCat;
                        break;
                    }
                }

                string productPrice = "";
                foreach (var j in CompleteData)
                {
                    if (i.productId.ToString() == j.LineFive)
                    {
                        productPrice = j.LineTwo;
                        break;
                    }
                }

                string uri = "";
                foreach (var j in CompleteData)
                {
                    if (i.productId.ToString() == j.LineFive)
                    {
                        uri = j.ImgUrl;
                        break;
                    }
                }

                string lineInfo = i.amount + " шт, $" + productPrice;

                ItemViewModel item = new ItemViewModel()
                {
                    LineOne = i.customerId.ToString(),
                    LineTwo = i.productId.ToString(),
                    LineThree = i.amount.ToString(),
                    LineFour = productName,
                    LineFive = productPrice,

                    LineOneNoCat = "",
                    LineCat = "",
                    LineInfo = lineInfo,

                    ImgUrl = uri,
                };
                this.BasketItems.Add(item);
            }

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
            LoadCompleteData();
            LoadBasket(0);

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