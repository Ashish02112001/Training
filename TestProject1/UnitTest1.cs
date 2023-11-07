using Training;
namespace TestProject1 {
   [TestClass]
   public class UnitTest1 {
      Stack<int> mNums = new ();
      TStack<int> mMyNums = new ();

      [TestMethod]
      public void TestPush () {
         for (int i = 0; i < 5; i++) {
            mNums.Push (i + 1); mMyNums.Push (i + 1);
         }
         Assert.AreEqual (mNums.Pop (), mMyNums.Pop ());
      }

      [TestMethod]
      public void TestPop () {
         mMyNums.Push (1);
         mMyNums.Push (2);
         Assert.AreEqual (2, mMyNums.Pop ());
         Assert.AreEqual (1, mMyNums.Pop ());
         Assert.ThrowsException<InvalidOperationException> (() => mMyNums.Pop ());
      }

      [TestMethod]
      public void TestPeek () {
         mNums.Push (1); mMyNums.Push (1);
         Assert.AreEqual (mNums.Peek (), mMyNums.Peek ());
         mMyNums.Pop ();
         Assert.ThrowsException<InvalidOperationException> (() => mMyNums.Peek ());
      }

      [TestMethod]
      public void TestIsEmpty () {
         mMyNums.Push (1);
         mMyNums.Push (2);
         Assert.IsFalse (mMyNums.IsEmpty);
         mMyNums.Pop ();
         mMyNums.Pop ();
         Assert.IsTrue (mMyNums.IsEmpty);
      }
   }
}
