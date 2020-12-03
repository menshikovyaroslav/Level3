using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using MyMail = Support.Mail;

namespace SupportTests
{
    [TestClass]
    public class Mail
    {
        private MyMail _mail;

        [TestInitialize]
        public void TestPrepare()
        {
            _mail = new MyMail();
        }


        [TestMethod]
        public void Check_Mail_Send()
        {
            // Arrange Act Assert

            #region Arrange

      //      const string expected_str = "ABC";

            #endregion

            #region Act

        //    _mail.SendMail();

        //    Assert.

            #endregion

            #region Assert

       //     Assert.AreEqual(expected_str, actual_str);

            #endregion

        }
    }
}
