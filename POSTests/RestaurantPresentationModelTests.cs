using Microsoft.VisualStudio.TestTools.UnitTesting;
using POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Tests
{
    
    [TestClass()]
    public class RestaurantPresentationModelTests
    {
        Model _model;
        RestaurantPresentationModel _restaurantPresentationModel;

        //初始化
        public void Initialization()
        {
            _model = new Model();
            _model.AddMealToOrder("烤鯖魚壽司", "壽司", 10, 1, 10);
            _restaurantPresentationModel = new RestaurantPresentationModel(_model);
        }

        //測試改變combobox時的text會不會改變
        [TestMethod()]
        public void ChangeComboBoxTest()
        {
            Initialization();
            _restaurantPresentationModel.ChangeComboBox(-1);
            _restaurantPresentationModel.ChangeComboBox(10);
            _restaurantPresentationModel.ChangeComboBox(0);
            Assert.AreEqual("壽司", _restaurantPresentationModel.CategoryName);
            _restaurantPresentationModel.ChangeComboBox(1);
            Assert.AreEqual("甜點", _restaurantPresentationModel.CategoryName);
        }

        //測試ListBox中所選取的Meal
        [TestMethod()]
        public void SelectMealTest()
        {
            Initialization();
            _restaurantPresentationModel.SelectMeal(0);
            Assert.AreEqual("烤鯖魚壽司", _restaurantPresentationModel.MealName);
            Assert.IsFalse(_restaurantPresentationModel.DeleteMealButtonEnable);
            _restaurantPresentationModel.SelectMeal(1);
            Assert.AreEqual("稻荷天婦羅壽司", _restaurantPresentationModel.MealName);
            Assert.IsTrue(_restaurantPresentationModel.DeleteMealButtonEnable);
        }

        //測試ListBox中所選取的Category
        [TestMethod()]
        public void SelectCategoryTest()
        {
            Initialization();
            _restaurantPresentationModel.SelectCategory(0);
            Assert.AreEqual("壽司", _restaurantPresentationModel.CategoryName);
            Assert.AreEqual("烤鯖魚壽司", _restaurantPresentationModel.CategoryMeal[0]);
            Assert.IsFalse(_restaurantPresentationModel.DeleteCategoryEnable);
            _restaurantPresentationModel.SelectCategory(1);
            Assert.AreEqual("甜點", _restaurantPresentationModel.CategoryName);
            Assert.AreEqual("巧克力法式金磚", _restaurantPresentationModel.CategoryMeal[0]);
            Assert.IsTrue(_restaurantPresentationModel.DeleteCategoryEnable);
        }

        //測試按下add時的畫面刷新
        [TestMethod()]
        public void AddMealViewTest()
        {
            Initialization();
            _restaurantPresentationModel.AddMealView();
            Assert.AreEqual("", _restaurantPresentationModel.MealName);
            Assert.AreEqual(0, _restaurantPresentationModel.MealPrice);
            Assert.AreEqual("", _restaurantPresentationModel.MealImagePath);
            Assert.AreEqual("", _restaurantPresentationModel.MealDescribe);
        }

        //測試按下Add時的畫面刷新
        [TestMethod()]
        public void AddCategoryViewTest()
        {
            Initialization();
            _restaurantPresentationModel.AddCategoryView();
            Assert.AreEqual("", _restaurantPresentationModel.CategoryName);
            Assert.AreEqual(0, _restaurantPresentationModel.CategoryMeal.Count);
        }

        //測試餐點儲存功能
        [TestMethod()]
        public void SaveMealDataTest()
        {
            Initialization();
            _restaurantPresentationModel.MealName = "烤鯖魚";
            _restaurantPresentationModel.SaveMealData("Edit Meal", 0);
            Assert.AreEqual("烤鯖魚", _model.GetMealList[0].Name);
            _restaurantPresentationModel.MealName = "烤鯖魚";
            _restaurantPresentationModel.MealCategory = "壽司";
            _restaurantPresentationModel.MealPrice = 1000;
            _restaurantPresentationModel.MealImagePath = "/123.jpg";
            _restaurantPresentationModel.MealDescribe = "123";
            _restaurantPresentationModel.SaveMealData("Add Meal", 0);
            Assert.AreEqual(1000, _model.GetMealList[27].Price);
        }

        //測試類別儲存功能
        [TestMethod()]
        public void SaveCategoryDataTest()
        {
            Initialization();
            _restaurantPresentationModel.CategoryName = "不要壽司";
            _restaurantPresentationModel.SaveCategoryData("Edit Category", 0);
            Assert.AreEqual("不要壽司", _model.CategoryList[0].CategoryName);
            _restaurantPresentationModel.SaveCategoryData("Add Category", 0);
            Assert.AreEqual("不要壽司", _model.CategoryList[3].CategoryName);
        }

        //測試新增餐點的按鈕的狀態
        [TestMethod()]
        public void TestAddMealButtonEnable()
        {
            Initialization();
            Assert.IsTrue(_restaurantPresentationModel.AddMealButtonEnable);
            Assert.IsFalse(_restaurantPresentationModel.AddMealButtonEnable = false);
        }

        //測試餐點類別
        [TestMethod()]
        public void TestMealCategory()
        {
            Initialization();
            _restaurantPresentationModel.MealCategory = "Test";
            Assert.AreEqual("Test", _restaurantPresentationModel.MealCategory);
        }

        //測試儲存按鈕的狀態
        [TestMethod()]
        public void TestSaveButtonEnable()
        {
            Initialization();
            Assert.IsFalse(_restaurantPresentationModel.SaveButtonEnable);
            Assert.IsTrue(_restaurantPresentationModel.SaveButtonEnable = true);
        }

        //測試刪除類別按鈕的狀態
        [TestMethod()]
        public void TestDeleteCategoryEnable()
        {
            Initialization();
            Assert.IsTrue(_restaurantPresentationModel.DeleteCategoryEnable);
            Assert.IsFalse(_restaurantPresentationModel.DeleteCategoryEnable = false);
        }

        //設定刪除餐點按鈕的狀態
        [TestMethod()]
        public void TestDeleteMealButtonEnable()
        {
            Initialization();
            Assert.IsTrue(_restaurantPresentationModel.DeleteMealButtonEnable);
            Assert.IsFalse(_restaurantPresentationModel.DeleteMealButtonEnable = false);
            //測試PropertyChanged
            var TestEvents = new List<string>();
            _restaurantPresentationModel.PropertyChanged += ((sender, e) => TestEvents.Add(e.PropertyName));
            _restaurantPresentationModel.DeleteMealButtonEnable = true;
            Assert.IsTrue(TestEvents.Contains("DeleteMealButtonEnable"));
        }
    }
}