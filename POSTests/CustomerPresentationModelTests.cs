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
    public class CustomerPresentationModelTests
    {
        CustomerPresentationModel _customerPresentationModel;
        Model _model;

        //初始化
        public void Initialization()
        {
            _model = new Model();
            _customerPresentationModel = new CustomerPresentationModel(_model);
        }

        //測試改變頁面時的頁數
        [TestMethod()]
        public void ChangeTotalPageTest()
        {
            Initialization();
            _model.StoreMeal("壽司");
            _customerPresentationModel.ChangeTotalPage();
            Assert.AreEqual(2, _customerPresentationModel.TotalPage);
            Assert.IsTrue(_customerPresentationModel.IsNextPageEnable);
            _model.StoreMeal("甜點");
            _customerPresentationModel.ChangeTotalPage();
            Assert.AreEqual(1, _customerPresentationModel.TotalPage);
            Assert.IsFalse(_customerPresentationModel.IsNextPageEnable);
        }

        //測試點選Next button
        [TestMethod()]
        public void ClickNextPageTest()
        {
            Initialization();
            _customerPresentationModel.TotalPage = 3;
            _customerPresentationModel.GetPage = 1;
            _customerPresentationModel.ClickNextPage();
            Assert.IsFalse(_customerPresentationModel.IsNextPageEnable);
            _customerPresentationModel.TotalPage = 4;
            _customerPresentationModel.GetPage = 1;
            _customerPresentationModel.ClickNextPage();
            Assert.IsTrue(_customerPresentationModel.IsNextPageEnable);
        }

        //測試點選Previous button
        [TestMethod()]
        public void ClickPreviousPageTest()
        {
            Initialization();
            _customerPresentationModel.GetPage = 1;
            _customerPresentationModel.ClickPreviousPage();
            Assert.IsFalse(_customerPresentationModel.IsPreviousPageEnable);
            _customerPresentationModel.GetPage = 2;
            _customerPresentationModel.ClickPreviousPage();
            Assert.IsTrue(_customerPresentationModel.IsPreviousPageEnable);
        }

        //測試改變TabPage
        [TestMethod()]
        public void ChangeTabPageTest()
        {
            Initialization();
            _customerPresentationModel.TotalPage = 1;
            _customerPresentationModel.ChangeTabPage();
            Assert.IsFalse(_customerPresentationModel.IsNextPageEnable);
            _customerPresentationModel.TotalPage = 2;
            _customerPresentationModel.ChangeTabPage();
            Assert.IsTrue(_customerPresentationModel.IsNextPageEnable);
        }

        //測試哪個butoon被點選到
        [TestMethod()]
        public void DetectWhichButtonTest()
        {
            Initialization();
            _customerPresentationModel.GetPage = 0;
            Assert.AreEqual(9, _customerPresentationModel.DetectWhichButton(9, 9));
        }

        //測試點選Button
        [TestMethod()]
        public void ClickButtonTest()
        {
            Initialization();
            _customerPresentationModel.ClickButton();
            Assert.IsTrue(_customerPresentationModel.IsAddEnable);
        }

        //測試目前的頁數
        [TestMethod()]
        public void GetPageTest()
        {
            Initialization();
            _customerPresentationModel.GetPage = 1;
            Assert.AreEqual(1, _customerPresentationModel.GetPage);
            Assert.AreNotEqual(2, _customerPresentationModel.GetPage);
        }

        //測試GetPage回傳的Text
        [TestMethod()]
        public void GetPageTextTest()
        {
            Initialization();
            _customerPresentationModel.TotalPage = 2;
            Assert.AreEqual("Page:1/2", _customerPresentationModel.GetPageText);
        }

        //測試總價錢的Text
        [TestMethod()]
        public void TotalPriceTest()
        {
            Initialization();
            var TestEvents = new List<string>();
            _customerPresentationModel.PropertyChanged += ((sender, e) => TestEvents.Add(e.PropertyName));
            _customerPresentationModel.TotalPrice = "100";
            Assert.AreEqual("Total:100元", _customerPresentationModel.TotalPrice);
            Assert.IsTrue(TestEvents.Contains("totalPrice"));
        }

        //測試Add button的狀態
        [TestMethod()]
        public void TestIsAddEnable()
        {
            Initialization();
            Assert.IsFalse(_customerPresentationModel.IsAddEnable);
            Assert.IsTrue(_customerPresentationModel.IsAddEnable = true);
        }

        //測試next button的狀態
        [TestMethod()]
        public void TestIsNextPageEnable()
        {
            Initialization();
            Assert.IsTrue(_customerPresentationModel.IsNextPageEnable);
            Assert.IsFalse(_customerPresentationModel.IsNextPageEnable = false);
        }

        //測試previous的狀態
        [TestMethod()]
        public void TestIsPreviousPageEnable()
        {
            Initialization();
            Assert.IsFalse(_customerPresentationModel.IsPreviousPageEnable);
            Assert.IsTrue(_customerPresentationModel.IsPreviousPageEnable = true);
        }
    }
}