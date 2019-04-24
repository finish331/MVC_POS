using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace POS
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        public event ModelChangedEventHandler _customerClosed;
        public event ModelChangedEventHandler _restaurantClosed;
        const int ONE = 1;
        const int TWO = 2;
        const int THREE = 3;
        const int FIVE = 5;
        const int SIX = 6;
        const int EIGHT = 8;
        const int NINE = 9;
        const int WIDTH_GRID = 135;
        const int HEIGHT_GRID1 = 10;
        const int HEIGHT_GRID2 = 135;
        const int HEIGHT_GRID3 = 260;
        const string MEAL_TEXT = "/meal.txt";
        const string MEAL_PRICE = "/mealPrice.txt";
        const string MEAL_PICTURE = "/picture.txt";
        const string MEAL_DESCRIPTION = "/mealDescription.txt";
        const string MEAL_CATEGORY = "/Category.txt";
        const char WRAP = '\n';
        string _sameString = "";
        string _projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        List<String> _mealText = new List<String>();
        List<String> _mealPicture = new List<String>();
        List<String> _mealDescribe = new List<String>();
        List<int> _mealPrice = new List<int>();
        List<String> _mealCategory = new List<string>();
        List<Meal> _storeTabPageMeal = new List<Meal>();
        BindingList<Category> _categoryList = new BindingList<Category>();
        BindingList<Meal> _mealList = new BindingList<Meal>();
        BindingList<Order> _orderList = new BindingList<Order>();

        public Model()
        {
            String tempString;
            StreamReader fileMeal = new StreamReader(_projectPath + MEAL_TEXT);
            StreamReader filePrice = new StreamReader(_projectPath + MEAL_PRICE);
            StreamReader filePicture = new StreamReader(_projectPath + MEAL_PICTURE);
            StreamReader fileDescribe = new StreamReader(_projectPath + MEAL_DESCRIPTION);
            StreamReader fileCategory = new StreamReader(_projectPath + MEAL_CATEGORY);
            while ((tempString = fileMeal.ReadLine()) != null)
            {
                _mealText.Add(tempString);
                tempString = "";
            }
            while ((tempString = filePrice.ReadLine()) != null)
            {
                _mealPrice.Add(Int32.Parse(tempString));
                tempString = "";
            }
            while ((tempString = filePicture.ReadLine()) != null)
            {
                _mealPicture.Add(tempString);
                tempString = "";
            }
            while ((tempString = fileDescribe.ReadLine()) != null)
            {
                _mealDescribe.Add(tempString);
                tempString = "";
            }
            while ((tempString = fileCategory.ReadLine()) != null)
            {
                _mealCategory.Add(tempString);
                if (_sameString != tempString)
                {
                    _categoryList.Add(new Category(tempString));
                    _sameString = tempString;
                }
                tempString = "";
            }
            for (int i = 0; i < _mealText.Count(); i++)
            {
                _mealList.Add(new Meal(_mealText[i], _mealPrice[i],_mealPicture[i],_mealDescribe[i],_mealCategory[i]));
            }
        }

        //更新
        public void Refresh()
        {
            NotifyObserver();
        }

        //呼叫
        void NotifyObserver()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }

        //關閉客戶端視窗的delegate
        public void CloseCustomer()
        {
            if (_customerClosed != null)
            {
                _customerClosed();
            }
        }

        //關閉餐廳視窗的delegate
        public void CloseRestaurant()
        {
            if (_restaurantClosed != null)
            {
                _restaurantClosed();
            }
        }

        public List<Meal> GetTabPageMealList
        {
            get
            {
                return _storeTabPageMeal;
            }
        }

        //儲存當前頁面的菜單
        public void StoreMeal(string tabPageText)
        {
            _storeTabPageMeal.Clear();
            for (int i = 0; i < _mealList.Count; i++)
            {
                if (_mealList[i].Category == tabPageText)
                {
                    _storeTabPageMeal.Add(_mealList[i]);
                }
            }
        }

        //提供需要的List回傳
        public BindingList<Meal> GetMealList
        {
            get
            {
                return _mealList;
            }
        }

        public BindingList<Category> CategoryList
        {
            get
            {
                return _categoryList;
            }
        }

        //取出position的餐點描述
        public string GetMealDescribe(int position)
        {
            return _mealList[position].Describe;
        }

        public BindingList<Order> OrderList
        {
            get
            {
                return _orderList;
            }
        }

        //刪除類別中的餐點
        public void DeleteCategoryMeal(int categoryIndex)
        {
            string category = _categoryList[categoryIndex].CategoryName;
            for (int i = 0; i < _mealList.Count; i++)
            {
                if (_mealList[i].Category == category)
                {
                    _mealList.RemoveAt(i);
                    i -= 1;
                }
            }
        }

        //將點的餐點加入點菜中
        public void AddMealToOrder(string name, string category, int unitPrice, int quantity, int subtotal)
        {
            _orderList.Add(new Order(name, category, unitPrice, quantity, subtotal));
        }

        //更新order的值
        public void UpdateOrder(int orderIndex, int mealIndex)
        {
            _orderList[orderIndex].Name = _mealList[mealIndex].Name;
            _orderList[orderIndex].Category = _mealList[mealIndex].Category;
            _orderList[orderIndex].UnitPrice = _mealList[mealIndex].Price;
        }

        //判斷餐點的類別是否要更改，如找到相同的則更換為舊的
        public void DetectMealCategoryEqual(string oldCategoryName, string newCategoryName)
        {
            for (int i = 0; i < _mealList.Count; i++)
            {
                if (_mealList[i].Category == oldCategoryName)
                {
                    _mealList[i].Category = newCategoryName;
                }
            }
        }

        //判斷訂餐的類別是否要更改，如找到相同的則更換為新的
        public void DetectOrderCategoryEqual(string oldCategoryName, string newCategoryName)
        {
            for (int i = 0; i < _orderList.Count; i++)
            {
                if (_orderList[i].Category == oldCategoryName)
                {
                    _orderList[i].Category = newCategoryName;
                }
            }
        }

        //判斷訂餐的屬性是否要更改，如要則名子價錢類別都會一併更改
        public void DetectOrderNameEqual(int index, string mealName)
        {
            for (int i = 0; i < _orderList.Count; i++)
            {
                if (_orderList[i].Name == mealName)
                {
                    UpdateOrder(i, index);
                }
            }
        }

        //計算餐點總價
        public int GetPrice()
        {
            int totalPrice = 0;
            for (int i = 0; i < _orderList.Count; i++)
            {
                totalPrice += _orderList[i].Subtotal;
            }
            return totalPrice;
        }

        //計算動態生成button的座標
        public int[] CalculatePoint(int orderIndex)
        {
            int[] point = new int[TWO];//兩個位元為X座標及Y座標
            if (orderIndex <= TWO)
            {
                point[0] = (orderIndex * WIDTH_GRID) + TWO;
                point[1] = HEIGHT_GRID1;
            }
            else if (orderIndex <= FIVE)
            {
                point[0] = ((orderIndex - THREE) * WIDTH_GRID) + TWO;
                point[1] = HEIGHT_GRID2;
            }
            else if (orderIndex < NINE)
            {
                point[0] = ((orderIndex - SIX) * WIDTH_GRID) + TWO;
                point[1] = HEIGHT_GRID3;
            }
            return point;
        }
    }
}
