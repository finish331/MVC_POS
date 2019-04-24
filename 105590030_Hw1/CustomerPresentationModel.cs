using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace POS
{
    public class CustomerPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Model _model;
        const string PAGE = "Page:";
        const string MONEY_TOTAL = "Total:";
        const char MONEY_UNIT = '元';
        const char SLASH = '/';
        const string GET_PAGE_TEXT = "GetPageText";
        const string IS_NEXT_PAGE_ENABLE = "IsNextPageEnable";
        const string IS_PREVIOUS_PAGE_ENABLE = "IsPreviousPageEnable";
        const string IS_ADD_ENABLE = "IsAddEnable";
        const string TOTAL_PRICE = "totalPrice";
        const int ONE = 1;
        const int TWO = 2;
        const int TEN = 10;
        int _page = 0;
        int _totalPage;
        bool _nextPage = true;
        bool _previousPage = false;
        bool _addButton = false;
        string _totalPrice;
        BindingList<Meal> _mealList = new BindingList<Meal>();

        public CustomerPresentationModel(Model model)
        {
            _model = model;
        }

        //檢測總頁數的改變並判斷next的按鈕的enable
        public void ChangeTotalPage()
        {
            _totalPage = _model.GetTabPageMealList.Count / TEN + ONE;
            if (_page + ONE == _totalPage)
            {
                _nextPage = false;
            }
            else
            {
                _nextPage = true;
            }
            Notify(IS_NEXT_PAGE_ENABLE);
            Notify(GET_PAGE_TEXT);
        }

        //點擊NextPage後的狀態改變
        public void ClickNextPage()
        {
            _page += 1;
            if (_page + ONE == _totalPage)
            {
                _nextPage = false;
            }
            else
            {
                _nextPage = true;
            }
            _previousPage = true;
            _addButton = false;
            Notify(GET_PAGE_TEXT);
            Notify(IS_NEXT_PAGE_ENABLE);
            Notify(IS_PREVIOUS_PAGE_ENABLE);
            Notify(IS_ADD_ENABLE);
        }

        //點擊PreviousPage後的狀態改變
        public void ClickPreviousPage()
        {
            _page -= 1;
            _nextPage = true;
            if (_page > 0)
            {
                _previousPage = true;
            }
            else
            {
                _previousPage = false;
            }
            _addButton = false;
            Notify(GET_PAGE_TEXT);
            Notify(IS_NEXT_PAGE_ENABLE);
            Notify(IS_PREVIOUS_PAGE_ENABLE);
            Notify(IS_ADD_ENABLE);
        }

        //切換tabPage時，判斷總頁數及button狀態
        public void ChangeTabPage()
        {
            _page = 0;
            if ( _page + ONE == _totalPage)
            {
                _nextPage = false;
            }
            else
            {
                _nextPage = true;
            }
            _previousPage = false;
            _addButton = false;
            Notify(GET_PAGE_TEXT);
            Notify(IS_NEXT_PAGE_ENABLE);
            Notify(IS_PREVIOUS_PAGE_ENABLE);
            Notify(IS_ADD_ENABLE);
        }

        //判斷目前哪個button被點到
        public int DetectWhichButton(int position, int size)
        {
            return (_page * size) + position;
        }

        public string GetPageText
        {
            get
            {
                return PAGE + (_page + ONE).ToString() + SLASH + _totalPage.ToString();
            }
        }

        //點擊餐點Button後Add Button的狀態變化
        public void ClickButton()
        {
            _addButton = true;
        }

        //取得總頁數
        public int TotalPage
        {
            get
            {
                return _totalPage;
            }
            set
            {
                _totalPage = value;
            }
        }

        //取得目前的page
        public int GetPage
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value;
            }
        }

        //回傳Next的Enable
        public bool IsNextPageEnable
        {
            get
            {
                return _nextPage;
            }
            set
            {
                _nextPage = value;
            }
        }

        //回傳Previous的Enable
        public bool IsPreviousPageEnable
        {
            get
            {
                return _previousPage;
            }
            set
            {
                _previousPage = value;
            }
        }

        //回傳Add的Enable
        public bool IsAddEnable
        {
            get
            {
                return _addButton;
            }
            set
            {
                _addButton = value;
            }
        }

        public string TotalPrice
        {
            get
            {
                return MONEY_TOTAL + _totalPrice + MONEY_UNIT;
            }
            set
            {
                _totalPrice = value;
                Notify(TOTAL_PRICE);
            }
        }

        //資訊改變時，通知
        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
