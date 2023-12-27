using Training;
namespace Test {
   [TestClass]
   public class UnitTest1 {
      TDQueue<int> mNums = new ();
      [TestMethod]
      public void TestRearEnqueue () {
         for (int i = 0; i < 4; i++) mNums.RearEnqueue (i + 1);
         for (int j = 0; j < 4; j++) Assert.AreEqual (j + 1, mNums.FrontDequeue ());
      }

      [TestMethod]
      public void TestFrontEnqueue () {
         for (int i = 0; i < 4; i++) mNums.FrontEnqueue (i + 1);
         for (int j = 0; j < 4; j++) Assert.AreEqual (j + 1, mNums.RearDequeue ());
      }

      [TestMethod]
      public void TestRearDequeue () {
         for (int i = 0; i < 5; i++) {
            if ((i + 1) > 2) mNums.FrontEnqueue (i + 1);
            else mNums.RearEnqueue (2 - i);
         }
         for (int j = 0; j < 5; j++) Assert.AreEqual (j + 1, mNums.RearDequeue ());
         Assert.ThrowsException<InvalidOperationException> (() => mNums.RearDequeue ());
      }

      [TestMethod]
      public void TestFrontDequeue () {
         for (int i = 0; i < 5; i++) {
            if ((i + 1) > 2) mNums.FrontEnqueue (i + 1);
            else mNums.RearEnqueue (2 - i);
         }
         for (int j = 5; j > 0; j--) Assert.AreEqual (j, mNums.FrontDequeue ());
         Assert.ThrowsException<InvalidOperationException> (() => mNums.FrontDequeue ());
      }
   }
}