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
    public class MealTests
    {
        [TestMethod()]
        public void TestPrice()
        {
            Meal meal = new Meal();
            meal.Price = 10;
            Assert.AreEqual(10, meal.Price);
            var TestEvents = new List<string>();
            meal.PropertyChanged += ((sender, e) => TestEvents.Add(e.PropertyName));
            meal.Price = 20;
            Assert.IsTrue(TestEvents.Contains("Price"));
        }

        [TestMethod()]
        public void TestName()
        {
            Meal meal = new Meal();
            meal.Name = "Test";
            Assert.AreEqual("Test", meal.Name);
        }

        [TestMethod()]
        public void TestImagePath()
        {
            Meal meal = new Meal();
            meal.ImagePath = "./test.jpg";
            Assert.AreEqual("./test.jpg", meal.ImagePath);
        }

        [TestMethod()]
        public void TestCategory()
        {
            Meal meal = new Meal();
            meal.Category = "TestCategory";
            Assert.AreEqual("TestCategory", meal.Category);
        }

        [TestMethod()]
        public void TestDescribe()
        {
            Meal meal = new Meal();
            meal.Describe = "This is Test";
            Assert.AreEqual("This is Test", meal.Describe);
        }
    }
}