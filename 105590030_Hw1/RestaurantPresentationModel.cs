using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class RestaurantPresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        const string MEAL_CATEGORY = "MealCategory";
        const string MEAL_NAME = "MealName";
        const string MEAL_IMAGE_PATH = "MealImagePath";
        const string MEAL_PRICE = "MealPrice";
        const string MEAL_DESCRIBE = "MealDescribe";
        const string DELETE_MEAL_BUTTON_ENABLE = "DeleteMealButtonEnable";
        const string CATEGORY_MEAL = "CategoryMeal";
        const string CATEGORY_NAME = "CategoryName";
        const string DELETE_CATEGORY_ENABLE = "DeleteCategoryEnable";
        const string EDIT_MEAL = "Edit Meal";
        const string ADD_MEAL = "Add Meal";
        const string EDIT_CATEGORY = "Edit Category";
        const string ADD_CATEGORY = "Add Category";
        const string ADD_MEAL_BUTTON_ENABLE = "AddMealButtonEnable";
        const string SAVE_BUTTON_ENABLE = "SaveButtonEnable";
        Model _model;
        string _mealName;
        string _mealImagePath;
        string _mealCategory;
        string _mealDescribe;
        string _categoryName;
        int _mealPrice;
        bool _addMealButtonEnable = true;
        bool _deleteMealButtonEnable = true;
        bool _saveButtonEnable = false;
        bool _deleteCategoryEnable = true;
        BindingList<String> _categoryMeal = new BindingList<string>();

        public RestaurantPresentationModel(Model model)
        {
            _model = model;
        }

        //當點選類別時，會同步改變_categoryName
        public void ChangeComboBox(int selectIndex)
        {
            if (selectIndex >= 0 && selectIndex < _model.CategoryList.Count)
            {
                _categoryName = _model.CategoryList[selectIndex].CategoryName;
            }
            NotifyPropertyChanged(MEAL_CATEGORY);
        }

        //隨著點到的餐點改變資訊
        public void SelectMeal(int selectIndex)
        {
            Meal meal = new Meal();
            meal = _model.GetMealList[selectIndex];
            _mealName = meal.Name;
            _mealPrice = meal.Price;
            _mealCategory = meal.Category;
            _mealImagePath = meal.ImagePath;
            _mealDescribe = meal.Describe;
            for (int i = 0; i < _model.OrderList.Count; i++)
            {
                if (_mealName == _model.OrderList[i].Name)
                {
                    _deleteMealButtonEnable = false;
                    break;
                }
                else
                {
                    _deleteMealButtonEnable = true;
                }
            }
            _saveButtonEnable = true;
            NotifyPropertyChanged(MEAL_NAME);//通知一次所有都會變?
            NotifyPropertyChanged(DELETE_MEAL_BUTTON_ENABLE);
        }

        //隨點選到的類別改變資訊
        public void SelectCategory(int selectIndex)
        {
            _categoryMeal.Clear();
            Meal meal = new Meal();
            _categoryName = _model.CategoryList[selectIndex].CategoryName;
            for ( int i = 0; i < _model.GetMealList.Count; i++)
            {
                meal = _model.GetMealList[i];
                if ( _categoryName == meal.Category)
                {
                    _categoryMeal.Add(meal.Name);
                }
            }
            for (int i = 0; i < _model.OrderList.Count; i++)
            {
                if (_categoryName == _model.OrderList[i].Category)
                {
                    _deleteCategoryEnable = false;
                    break;
                }
                else
                {
                    _deleteCategoryEnable = true;
                }
            }
            NotifyPropertyChanged(CATEGORY_MEAL);
            NotifyPropertyChanged(CATEGORY_NAME);
            NotifyPropertyChanged(DELETE_CATEGORY_ENABLE);
        }

        //提供一個可以新增的view
        public void AddMealView()
        {
            _mealName = "";
            _mealPrice = 0;
            _mealImagePath = "";
            _mealDescribe = "";
            NotifyPropertyChanged(MEAL_NAME);
            NotifyPropertyChanged(MEAL_IMAGE_PATH);
            NotifyPropertyChanged(MEAL_PRICE);
            NotifyPropertyChanged(MEAL_DESCRIBE);
        }

        //設定新增類別的畫面
        public void AddCategoryView()
        {
            _categoryName = "";
            _categoryMeal.Clear();
            NotifyPropertyChanged(CATEGORY_NAME);
            NotifyPropertyChanged(CATEGORY_MEAL);
        }

        //按下儲存按鈕時，判斷是編輯還是新增
        public void SaveMealData(string eventName, int index)
        {
            string mealName;
            if (eventName == EDIT_MEAL)
            {
                mealName = _model.GetMealList[index].Name;//先記錄改變前的餐點名稱
                _model.GetMealList[index].Name = _mealName;
                _model.GetMealList[index].Price = _mealPrice;
                _model.GetMealList[index].ImagePath = _mealImagePath;
                _model.GetMealList[index].Category = _mealCategory;
                _model.GetMealList[index].Describe = _mealDescribe;
                _model.DetectOrderNameEqual(index, mealName);
            }
            else if (eventName == ADD_MEAL)
            {
                _model.GetMealList.Add(new Meal(_mealName, _mealPrice, _mealImagePath, _mealDescribe, _mealCategory));
            }
        }

        //按下儲存類別按鈕時，判斷是編輯還是新增
        public void SaveCategoryData(string eventName, int index)
        {
            string categoryName;
            if (eventName == EDIT_CATEGORY)
            {
                categoryName = _model.CategoryList[index].CategoryName;
                _model.CategoryList[index].CategoryName = _categoryName;
                _model.DetectMealCategoryEqual(categoryName, _categoryName);
                _model.DetectOrderCategoryEqual(categoryName,_categoryName);
            }
            if (eventName == ADD_CATEGORY)
            {
                _model.CategoryList.Add(new Category(_categoryName));
            }
        }

        public string MealName
        {
            get
            {
                return _mealName;
            }
            set
            {
                _mealName = value;
                NotifyPropertyChanged(MEAL_NAME);
            }
        }

        public string MealImagePath
        {
            get
            {
                return _mealImagePath;
            }
            set
            {
                _mealImagePath = value;
                NotifyPropertyChanged(MEAL_IMAGE_PATH);
            }
        }

        public string MealCategory
        {
            get
            {
                return _mealCategory;
            }
            set
            {
                _mealCategory = value;
                NotifyPropertyChanged(MEAL_CATEGORY);
            }
        }

        public string MealDescribe
        {
            get
            {
                return _mealDescribe;
            }
            set
            {
                _mealDescribe = value;
                NotifyPropertyChanged(MEAL_DESCRIBE);
            }
        }

        public int MealPrice
        {
            get
            {
                return _mealPrice;
            }
            set
            {
                _mealPrice = value;
                NotifyPropertyChanged(MEAL_PRICE);
            }
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

        public BindingList<string> CategoryMeal
        {
            get
            {
                return _categoryMeal;
            }
        }

        public bool AddMealButtonEnable
        {
            get
            {
                return _addMealButtonEnable;
            }
            set
            {
                _addMealButtonEnable = value;
                NotifyPropertyChanged(ADD_MEAL_BUTTON_ENABLE);
            }
        }

        public bool DeleteMealButtonEnable
        {
            get
            {
                return _deleteMealButtonEnable;
            }
            set
            {
                _deleteMealButtonEnable = value;
                NotifyPropertyChanged(DELETE_MEAL_BUTTON_ENABLE);
            }
        }

        public bool SaveButtonEnable
        {
            get
            {
                return _saveButtonEnable;
            }
            set
            {
                _saveButtonEnable = value;
                NotifyPropertyChanged(SAVE_BUTTON_ENABLE);
            }
        }

        public bool DeleteCategoryEnable
        {
            get
            {
                return _deleteCategoryEnable;
            }
            set
            {
                _deleteCategoryEnable = value;
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
