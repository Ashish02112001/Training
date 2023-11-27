using static Training.ParseDouble;
namespace Test {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void TestDoubleDotParseIsTrue () {
         Assert.IsTrue (DoubleDotParse ("11", out double num));
         Assert.AreEqual (11, num);
         Assert.IsTrue (DoubleDotParse ("+11.23", out num));
         Assert.AreEqual (11.23, num);
         Assert.IsTrue (DoubleDotParse ("-11.23", out num));
         Assert.AreEqual (-11.23, num);
         Assert.IsTrue (DoubleDotParse ("11.23e2", out num));
         Assert.AreEqual (1123, num);
         Assert.IsTrue (DoubleDotParse ("11.23E3", out num));
         Assert.AreEqual (11230, num);
         Assert.IsTrue (DoubleDotParse ("11e1", out num));
         Assert.AreEqual (110, num);
         Assert.IsTrue (DoubleDotParse (".5", out num));
         Assert.AreEqual (0.5, num);
         Assert.IsTrue (DoubleDotParse ("-3.15e-1", out num));
         Assert.AreEqual (-0.315, num);
         Assert.IsTrue (DoubleDotParse ("+3.5e+4", out num));
         Assert.AreEqual (35000, num);
         Assert.IsTrue (DoubleDotParse ("+12e-4", out num));
         Assert.AreEqual (0.0012, num);
         Assert.IsTrue (DoubleDotParse ("-12.3562e-4", out num));
         Assert.AreEqual (-0.00123562, num);
      }
      [TestMethod]
      public void TestDoubleDotParseIsFalse () {
         Assert.IsFalse (DoubleDotParse ("-1e", out _));
         Assert.IsFalse (DoubleDotParse ("+1e", out _));
         Assert.IsFalse (DoubleDotParse ("e3", out _));
         Assert.IsFalse (DoubleDotParse ("-.e3", out _));
         Assert.IsFalse (DoubleDotParse ("+e.3", out _));
         Assert.IsFalse (DoubleDotParse ("-3.e", out _));
         Assert.IsFalse (DoubleDotParse ("+3e.", out _));
         Assert.IsFalse (DoubleDotParse ("a", out _));
         Assert.IsFalse (DoubleDotParse ("-1e.", out _));
         Assert.IsFalse (DoubleDotParse ("+1E.", out _));
         Assert.IsFalse (DoubleDotParse ("12.4e", out _));
         Assert.IsFalse (DoubleDotParse ("12.e", out _));
         Assert.IsFalse (DoubleDotParse ("23.q", out _));
         Assert.IsFalse (DoubleDotParse ("23.", out _));
         Assert.IsFalse (DoubleDotParse ("-65.0f", out _));
         Assert.IsFalse (DoubleDotParse ("+23.q", out _));
      }
   }
}