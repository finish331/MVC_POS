using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class Meal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        const string NAME = "Name";
        const string PRICE = "Price";
        const string IMAGE_PATH = "ImagePath";
        const string DESCRIBE = "Describe";
        const string CATEGORY = "Category";
        string _name;
        string _imagePath;
        string _describe;
        string _category;
        int _price;

        public Meal()
        {
        }

        //初始化
        public Meal(string name,int price,string picturePath,string describe,string category)
        {
            _name = name;
            _price = price;
            _imagePath = picturePath;
            _describe = describe;
            _category = category;
        }

        //回傳餐點的價錢
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                NotifyPropertyChanged(PRICE);
            }
        }

        //回傳餐點的名子
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged(NAME);
            }
        }

        //取得餐點圖片路徑
        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
                NotifyPropertyChanged(IMAGE_PATH);
            }
        }

        //取得餐點描述
        public string Describe
        {
            get
            {
                return _describe;
            }
            set
            {
                _describe = value;
                NotifyPropertyChanged(DESCRIBE);
            }
        }

        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                NotifyPropertyChanged(CATEGORY);
            }
        }

        //有資料更動時，會通知
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
