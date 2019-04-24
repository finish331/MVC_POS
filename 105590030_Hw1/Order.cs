using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class Order : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        const string NAME = "Name";
        const string CATEGORY = "Category";
        const string UNIT_PRICE = "UnitPrice";
        const string QUANTITY = "Quantity";
        const string SUBTOTAL = "Subtotal";
        string _name;
        string _category;
        int _unitPrice;
        int _quantity;
        int _subtotal;

        public Order()
        {

        }

        public Order(string name, string category, int unitPrice, int quantity, int subtotal)
        {
            _name = name;
            _category = category;
            _unitPrice = unitPrice;
            _quantity = quantity;
            _subtotal = subtotal;
        }

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

        public int UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
                _subtotal = _unitPrice * _quantity;
                NotifyPropertyChanged(SUBTOTAL);
                NotifyPropertyChanged(UNIT_PRICE);
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                _subtotal = _unitPrice * _quantity;
                NotifyPropertyChanged(QUANTITY);
                NotifyPropertyChanged(SUBTOTAL);
            }
        }

        public int Subtotal
        {
            get
            {
                return _subtotal;
            }
            set
            {
                _subtotal = value;
                NotifyPropertyChanged(SUBTOTAL);
            }
        }

        //有資訊更動時，會送出
        void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
