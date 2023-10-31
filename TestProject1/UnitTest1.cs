using Training;
namespace TestProject1 {
   [TestClass]
   public class UnitTest1 {
      Stack<int> nums = new ();
      TStack<int> TNums = new ();
      [TestMethod]
      public void TestPush () {
         for (int i = 0; i < 5; i++) {
            nums.Push (i + 1); TNums.Push (i + 1);
         }
         Assert.AreEqual (nums.Pop (), TNums.Pop ());
      }
      [TestMethod]
      public void TestPop () {
         TNums.Push (1);
         TNums.Push (2);
         Assert.AreEqual (2, TNums.Pop ());
         Assert.AreEqual (1, TNums.Pop ());
         Assert.ThrowsException<InvalidOperationException> (() => TNums.Pop ());
      }
      [TestMethod]
      public void TestPeek () {
         nums.Push (1); TNums.Push (1);
         Assert.AreEqual (nums.Peek (), TNums.Peek ());
         TNums.Pop ();
         Assert.ThrowsException<InvalidOperationException> (() => TNums.Peek ());
      }
      [TestMethod]
      public void TestIsEmpty () {
         TNums.Push (1);
         TNums.Push (2);
         Assert.IsFalse (TNums.IsEmpty);
         TNums.Pop ();
         TNums.Pop ();
         Assert.IsTrue (TNums.IsEmpty);
      }
   }
}
