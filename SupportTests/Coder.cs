using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupportTests
{
    [TestClass]
    public class Coder
    {
        private string str;

        [TestInitialize]
        public void TestPrepare()
        {
            str = "BCD";
        }


        [TestMethod]
        public void Check_ABC_to_FFF()
        {
            // Arrange Act Assert

            #region Arrange

            const string expected_str = "ABC";

            #endregion

            #region Act

            var actual_str = Support.Coder.Encode(str);

            #endregion

            #region Assert

            Assert.AreEqual(expected_str, actual_str);

            #endregion

        }
    }
}
