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
    public class CategoryTests
    {
        Category _category;
        //初始化
        public void Initialization()
        {
            _category = new Category("類別");
        }

        //測試類別中的名子
        [TestMethod()]
        public void TestCategoryName()
        {
            Initialization();
            Assert.AreEqual("類別", _category.CategoryName);
            var TestEvents = new List<string>();
            _category.PropertyChanged += ((sender, e) => TestEvents.Add(e.PropertyName));
            _category.CategoryName = "更改類別";
            Assert.IsTrue(TestEvents.Contains("CategoryName"));
        }
    }
}