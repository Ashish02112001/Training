using Training;
namespace TestProject1 {
   [TestClass]
   public class UnitTest1 {
      Stack<int> nums = new ();
      TStack<int> myNums = new ();

      [TestMethod]
      public void TestPush () {
         for (int i = 0; i < 5; i++) {
            nums.Push (i + 1); myNums.Push (i + 1);
         }
         Assert.AreEqual (nums.Pop (), myNums.Pop ());
      }
      [TestMethod]
      public void TestPop () {
         myNums.Push (1);
         myNums.Push (2);
         Assert.AreEqual (2, myNums.Pop ());
         Assert.AreEqual (1, myNums.Pop ());
         Assert.ThrowsException<InvalidOperationException> (() => myNums.Pop ());
      }
      [TestMethod]
      public void TestPeek () {
         nums.Push (1); myNums.Push (1);
         Assert.AreEqual (nums.Peek (), myNums.Peek ());
         myNums.Pop ();
         Assert.ThrowsException<InvalidOperationException> (() => myNums.Peek ());
      }
      [TestMethod]
      public void TestIsEmpty () {
         myNums.Push (1);
         myNums.Push (2);
         Assert.IsFalse (myNums.IsEmpty);
         myNums.Pop ();
         myNums.Pop ();
         Assert.IsTrue (myNums.IsEmpty);
      }
   }
}
