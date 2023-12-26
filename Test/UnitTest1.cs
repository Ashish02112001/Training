using Training;
namespace Test {
   [TestClass]
   public class UnitTest1 {
      TDQueue<int> mNums = new ();
      [TestMethod]
      public void TestRearEnqueue () {
         mNums.RearEnqueue (1);
         mNums.RearEnqueue (2);
         Assert.AreEqual (1, mNums.FrontDequeue ());
         Assert.AreEqual (2, mNums.FrontDequeue ());
      }
      [TestMethod]
      public void TestFrontEnqueue () {
         mNums.FrontEnqueue (1);
         mNums.FrontEnqueue (2);
         Assert.AreEqual (1, mNums.RearDequeue ());
         Assert.AreEqual (2, mNums.RearDequeue ());
      }
      [TestMethod]
      public void TestRearDequeue () {
         mNums.RearEnqueue (2);
         mNums.RearEnqueue (1);
         mNums.FrontEnqueue (3);
         mNums.FrontEnqueue (4);
         mNums.FrontEnqueue (5);
         Assert.AreEqual (1, mNums.RearDequeue ());
         Assert.AreEqual (2, mNums.RearDequeue ());
         Assert.AreEqual (3, mNums.RearDequeue ());
         Assert.AreEqual (4, mNums.RearDequeue ());
         Assert.AreEqual (5, mNums.RearDequeue ());
         Assert.ThrowsException<InvalidOperationException> (() => mNums.RearDequeue ());
      }
      [TestMethod]
      public void TestFrontDequeue () {
         mNums.RearEnqueue (2);
         mNums.RearEnqueue (1);
         mNums.FrontEnqueue (3);
         mNums.FrontEnqueue (4);
         mNums.FrontEnqueue (5);
         Assert.AreEqual (5, mNums.FrontDequeue ());
         Assert.AreEqual (4, mNums.FrontDequeue ());
         Assert.AreEqual (3, mNums.FrontDequeue ());
         Assert.AreEqual (2, mNums.FrontDequeue ());
         Assert.AreEqual (1, mNums.FrontDequeue ());
         Assert.ThrowsException<InvalidOperationException> (() => mNums.FrontDequeue ());
      }
   }
}