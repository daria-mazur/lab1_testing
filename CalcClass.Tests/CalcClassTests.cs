using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcClassBr;
using System;

namespace CalcClass.Tests
{
    [TestClass]
    public class CalcClassTests
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", 
            "TestList.xml", 
            "TestWithValidData", 
            DataAccessMethod.Sequential)]
        public void TestValidData()
        {
            long a = Convert.ToInt64(TestContext.DataRow["a"]);
            long b = Convert.ToInt64(TestContext.DataRow["b"]);
            int expected = Convert.ToInt32(TestContext.DataRow["expected"]);

            int actual = CalcClassBr.CalcClass.Add(a, b);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", 
            "TestList.xml", 
            "TestWithInvalidData", 
            DataAccessMethod.Sequential)]
        public void TestInvalidData()
        {
            long a = Convert.ToInt64(TestContext.DataRow["a"]);
            long b = Convert.ToInt64(TestContext.DataRow["b"]);

            // Оскільки очікується виняток, результат нам не потрібен
            CalcClassBr.CalcClass.Add(a, b);
        }
    }
}
