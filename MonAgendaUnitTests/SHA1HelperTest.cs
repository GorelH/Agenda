using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;

namespace MonAgendaUnitTests
{
    [TestClass]
    public class SHA1HelperTest
    {
        [TestMethod]
        public void HashDataTest()
        {
            string input = "test";
            string expected = "169741432292041771551662876811521114523313515247187211";
            string actual = SHA1Helper.HashData(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
