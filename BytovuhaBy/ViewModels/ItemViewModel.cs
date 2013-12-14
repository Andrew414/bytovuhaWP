using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BytovuhaBy
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private Image _img;

        public Image Image
        {
            get
            {
                return _img;
            }
            set
            {
                if (value != _img)
                {
                    _img = value;
                    NotifyPropertyChanged("Image");
                }
            }
        }

        private string _lineFour;

        public string LineFour
        {
            get
            {
                return _lineFour;
            }
            set
            {
                if (value != _lineFour)
                {
                    _lineFour = value;
                    NotifyPropertyChanged("LineFour");
                }
            }
        }

        private string _lineFive;

        public string LineFive
        {
            get
            {
                return _lineFive;
            }
            set
            {
                if (value != _lineFive)
                {
                    _lineFive = value;
                    NotifyPropertyChanged("LineFive");
                }
            }
        }

        private string _lineonenocat;
        public string LineOneNoCat
        {
            get
            {
                return _lineonenocat;
            }
            set
            {
                if (value != _lineonenocat)
                {
                    _lineonenocat = value;
                    NotifyPropertyChanged("LineOneNoCat");
                }
            }
        }

        private string _linecat;
        public string LineCat
        {
            get
            {
                return _linecat;
            }
            set
            {
                if (value != _linecat)
                {
                    _linecat = value;
                    NotifyPropertyChanged("LineCat");
                }
            }
        }

        private string _lineinfo;
        public string LineInfo
        {
            get
            {
                return _lineinfo;
            }
            set
            {
                if (value != _lineinfo)
                {
                    _lineinfo = value;
                    NotifyPropertyChanged("LineInfo");
                }
            }
        }

        private string _imgurl;

        public string ImgUrl
        {
            get
            {
                return _imgurl;
            }
            set
            {
                if (value != _imgurl)
                {
                    _imgurl = value;
                    NotifyPropertyChanged("ImgUrl");
                }
            }
        } 

        private string _lineOne;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineOne
        {
            get
            {
                return _lineOne;
            }
            set
            {
                if (value != _lineOne)
                {
                    _lineOne = value;
                    NotifyPropertyChanged("LineOne");
                }
            }
        }

        private string _lineTwo;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineTwo
        {
            get
            {
                return _lineTwo;
            }
            set
            {
                if (value != _lineTwo)
                {
                    _lineTwo = value;
                    NotifyPropertyChanged("LineTwo");
                }
            }
        }

        private string _lineThree;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public string LineThree
        {
            get
            {
                return _lineThree;
            }
            set
            {
                if (value != _lineThree)
                {
                    _lineThree = value;
                    NotifyPropertyChanged("LineThree");
                }
            }
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