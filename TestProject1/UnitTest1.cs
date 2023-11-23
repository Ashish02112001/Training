using Training;
namespace TestProject1 {
   [TestClass]
   public class UnitTest1 {
      Queue<int> mNums = new ();
      TQueue<int> mMyNums = new ();

      [TestMethod]
      public void TestEnqueue () {
         mNums.Enqueue (1); mMyNums.Enqueue (1);
         Assert.AreEqual (mNums.Dequeue (), mMyNums.Dequeue ());
      }

      [TestMethod]
      public void TestDequeue () {
         mMyNums.Enqueue (1);
         mMyNums.Enqueue (2);
         mMyNums.Enqueue (3);
         mMyNums.Enqueue (4);
         Assert.AreEqual (1, mMyNums.Dequeue ());
         mMyNums.Enqueue (5);
         Assert.AreEqual (2, mMyNums.Dequeue ());
         Assert.AreEqual (3, mMyNums.Dequeue ());
         Assert.AreEqual (4, mMyNums.Dequeue ());
         Assert.AreEqual (5, mMyNums.Dequeue ());
         //To test the expansion of arrary size:
         for (int i = 0;i<5;i++) mMyNums.Enqueue (i+1);
         for (int i = 0; i < 5; i++) mMyNums.Dequeue ();
         Assert.ThrowsException<InvalidOperationException> (() => mMyNums.Dequeue ());
      }

      [TestMethod]
      public void TestPeek () {
         mNums.Enqueue (1); mMyNums.Enqueue (1);
         Assert.AreEqual (mNums.Peek (), mMyNums.Peek ());
         mMyNums.Dequeue ();
         Assert.ThrowsException<InvalidOperationException> (() => mMyNums.Peek ());
      }

      [TestMethod]
      public void TestIsEmpty () {
         mMyNums.Enqueue (1);
         mMyNums.Enqueue (2);
         Assert.IsFalse (mMyNums.IsEmpty);
         mMyNums.Dequeue ();
         mMyNums.Dequeue ();
         Assert.IsTrue (mMyNums.IsEmpty);
      }
   }
}
