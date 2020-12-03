using NUnit.Framework;

namespace SupportTests_v2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Check_BCD_to_ABC()
        {
            #region Arrange

            const string str = "BCD";
            const string expected_str = "ABC";

            #endregion

            #region Act

            var actual_str = Support.Coder.Encode(str);

            #endregion

            #region Assert

            Assert.AreEqual(expected_str, actual_str);

            #endregion
        }

        [Test]
        public void Check_ABC_to_BCD()
        {
            #region Arrange

            const string str = "ABC";
            const string expected_str = "BCD";

            #endregion

            #region Act

            var actual_str = Support.Coder.Decode(str);

            #endregion

            #region Assert

            //    Assert.AreEqual(expected_str, actual_str);
            Assert.IsTrue(expected_str == actual_str);

            #endregion
        }
    }
}