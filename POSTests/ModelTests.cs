using POS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace POS.Tests
{
    [TestClass()]
    public class ModelTests
    {
        int _testNumber = 0;
        //測試頁面更新
        [TestMethod()]
        public void RefreshTest()
        {
            Model model = new Model();
            _testNumber = 0;
            model._modelChanged += TestDelegate;
            model.Refresh();
            Assert.AreEqual(10, _testNumber);
        }

        //關閉客戶端視窗
        [TestMethod()]
        public void CloseCustomerTest()
        {
            Model model = new Model();
            _testNumber = 0;
            model._customerClosed += TestDelegate;
            model.CloseCustomer();
            Assert.AreEqual(10, _testNumber);
        }

        //關閉後台端視窗
        [TestMethod()]
        public void CloseRestaurantTest()
        {
            Model model = new Model();
            _testNumber = 0;
            model._restaurantClosed += TestDelegate;
            model.CloseRestaurant();
            Assert.AreEqual(10, _testNumber);
        }

        //用來測試Delegate
        public void TestDelegate()
        {
            _testNumber = 10;
        }

        //測試儲存當前頁面的餐點
        [TestMethod()]
        public void StoreMealTest()
        {
            Model model = new Model();
            List<Meal> meal = new List<Meal>();
            for (int i = 0; i < 15; i++)
            {
                meal.Add(model.GetMealList[i]);
            }
            model.StoreMeal("壽司");
            CollectionAssert.AreEqual(meal, model.GetTabPageMealList);
        }

        //測試餐點的描述
        [TestMethod()]
        public void GetMealDescribeTest()
        {
            Model model = new Model();
            Assert.AreEqual("烤鯖魚壽司，是菜單最推薦吃的壽司，新鮮的鯖魚，鮮甜美味", model.GetMealDescribe(0));
        }

        //測試刪除類別中的餐點
        [TestMethod()]
        public void DeleteCategoryMealTest()
        {
            Model model = new Model();
            model.DeleteCategoryMeal(0);
            for (int i = 0; i < model.GetMealList.Count; i++)
            {
                Assert.AreNotEqual("壽司", model.GetMealList[i].Category);
            }
        }

        //測試新增餐點到Order中
        [TestMethod()]
        public void AddMealToOrderTest()
        {
            Model model = new Model();
            model.AddMealToOrder("test", "test", 1, 1, 1);
            Assert.AreEqual("test", model.OrderList[0].Name);
            Assert.AreEqual("test", model.OrderList[0].Category);
            Assert.AreEqual(1, model.OrderList[0].UnitPrice);
            Assert.AreEqual(1, model.OrderList[0].Quantity);
            Assert.AreEqual(1, model.OrderList[0].Subtotal);
        }

        //測試更新訂單中的資訊
        [TestMethod()]
        public void UpdateOrderTest()
        {
            Model model = new Model();
            int orderInex = 0;
            int mealIndex = 0;
            Assert.AreEqual(0, model.OrderList.Count);
            model.AddMealToOrder("test", "test", 1, 1, 1);
            model.UpdateOrder(orderInex, mealIndex);
            Assert.AreEqual("烤鯖魚壽司", model.OrderList[orderInex].Name);
            Assert.AreEqual("壽司", model.OrderList[orderInex].Category);
            Assert.AreEqual(10, model.OrderList[orderInex].UnitPrice);
        }

        //測試檢查Meal的category是不是和要更改的一樣
        [TestMethod()]
        public void DetectMealCategoryEqualTest()
        {
            Model model = new Model();
            List<int> temp = new List<int>();
            string oldCategoryName = "壽司";
            string newCategoryName = "測試";
            model.DetectMealCategoryEqual(oldCategoryName, newCategoryName);
            Assert.AreEqual("測試", model.GetMealList[0].Category);
            Assert.AreNotEqual("測試", model.GetMealList[15].Category);
        }

        //測試訂單中的類別是不是和要更改的類別一樣
        [TestMethod()]
        public void DetectOrderCategoryEqualTest()
        {
            Model model = new Model();
            model.AddMealToOrder("食物", "測試", 1, 1, 1);
            model.AddMealToOrder("食物二", "測試二", 1, 1, 1);
            model.DetectOrderCategoryEqual("測試", "測試正確");
            Assert.AreEqual("測試正確", model.OrderList[0].Category);
            Assert.AreNotEqual("測試正確", model.OrderList[1].Category);
        }

        //測試訂單中的名子是不是和要更改的類別一樣
        [TestMethod()]
        public void DetectOrderNameEqualTest()
        {
            Model model = new Model();
            model.AddMealToOrder("稻荷天婦羅壽司", "甜點", 1, 1, 1);
            model.DetectOrderNameEqual(0, "稻荷天婦羅壽司");
            Assert.AreEqual("烤鯖魚壽司", model.OrderList[0].Name);
            Assert.AreEqual("壽司", model.OrderList[0].Category);
            Assert.AreEqual(10, model.OrderList[0].UnitPrice);
        }

        //測試獲得總價錢
        [TestMethod()]
        public void GetPriceTest()
        {
            Model model = new Model();
            for (int i = 1; i <= 5; i++)
            {
                model.AddMealToOrder("test", "test", i, 1, i);
            }
            Assert.AreEqual(15, model.GetPrice());
            Assert.AreNotEqual(14, model.GetPrice());
        }

        //測試計算Button生成的位置
        [TestMethod()]
        public void CalculatePointTest()
        {
            Model model = new Model();
            Assert.AreEqual(2, model.CalculatePoint(0)[0]);
            Assert.AreEqual(10, model.CalculatePoint(0)[1]);
            Assert.AreEqual(137, model.CalculatePoint(4)[0]);
            Assert.AreEqual(135, model.CalculatePoint(4)[1]);
            Assert.AreEqual(272, model.CalculatePoint(8)[0]);
            Assert.AreEqual(260, model.CalculatePoint(8)[1]);
        }

        //測試類別的List
        [TestMethod()]
        public void CategoryListTest()
        {
            Model model = new Model();
            Assert.AreEqual("壽司", model.CategoryList[0].CategoryName);
        }
    }
}