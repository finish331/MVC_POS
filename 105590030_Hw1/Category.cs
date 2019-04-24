using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class Category : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string _categoryName;
        const string CATEGORY_NAME = "CategoryName";
        public Category(string categoryName)
        {
            _categoryName = categoryName;
            NotifyPropertyChanged(CATEGORY_NAME);
        }

        public string CategoryName
        {
            get
            {
                return _categoryName;
            }
            set
            {
                _categoryName = value;
                NotifyPropertyChanged(CATEGORY_NAME);
            }
        }

        //有資訊更動時，會通知
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
