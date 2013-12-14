using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BytovuhaBy
{
    public class Product
    {
        public Product() { }

        public int id;

        public string name;
        public int price;
        public string category;
        public string image_url;
        public string description;

        public static string CategoryToRussian(string category)
        {
            if (category == "") return "Все продукты";
            if (category == "Washing_machines") return "Стиральные машины";
            if (category == "Electronics") return "Электроника";
            if (category == "Pots") return "Чайники";
            if (category == "Tosters") return "Тостеры";

            return "";
        }

        public static string CategoryItemToRussian(string category)
        {
            if (category == "Washing_machines") return "Стиральная машина";
            if (category == "Electronics") return "Ноутбук";
            if (category == "Pots") return "Чайник";
            if (category == "Tosters") return "Тостер";

            return "";
        }
    }
}
