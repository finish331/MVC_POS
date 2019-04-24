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
    public class OrderTests
    {
        //測試餐點名子以及通知的功能
        [TestMethod()]
        public void TestName()
        {
            Order order = new Order();
            var TestEvents = new List<string>();
            order.PropertyChanged += ((sender, e) => TestEvents.Add(e.PropertyName));
            order.Name = "Test";
            Assert.AreEqual("Test", order.Name);
            Assert.IsTrue(TestEvents.Contains("Name"));
        }

        //測試餐點的數量
        [TestMethod()]
        public void TestQuantity()
        {
            Order order = new Order();
            order.Quantity = 2;
            order.UnitPrice = 20;
            Assert.AreEqual(2, order.Quantity);
            Assert.AreEqual(40, order.Subtotal);
        }

        //測試某一個餐點的總價
        [TestMethod()]
        public void TestSubtotal()
        {
            Order order = new Order();
            order.Subtotal = 20;
            Assert.AreEqual(20, order.Subtotal);
        }
    }
}