using Training;
namespace TestProject1 {
   [TestClass]
   public class UnitTest1 {
      Queue<int> nums = new ();
      TQueue<int> myNums = new ();
      [TestMethod]
      public void TestPush () {
         for (int i = 0; i < 5; i++) {
            nums.Enqueue (i + 1); myNums.Enqueue (i + 1);
         }
         Assert.AreEqual (nums.Dequeue (), myNums.Dequeue ());
      }
      [TestMethod]
      public void TestPop () {
         myNums.Enqueue (1);
         myNums.Enqueue (2);
         Assert.AreEqual (1, myNums.Dequeue ());
         Assert.AreEqual (2, myNums.Dequeue ());
         Assert.ThrowsException<InvalidOperationException> (() => myNums.Dequeue ());
      }
      [TestMethod]
      public void TestPeek () {
         nums.Enqueue (1); myNums.Enqueue (1);
         Assert.AreEqual (nums.Peek (), myNums.Peek ());
         myNums.Dequeue ();
         Assert.ThrowsException<InvalidOperationException> (() => myNums.Peek ());
      }
      [TestMethod]
      public void TestIsEmpty () {
         myNums.Enqueue (1);
         myNums.Enqueue (2);
         Assert.IsFalse (myNums.IsEmpty);
         myNums.Dequeue ();
         myNums.Dequeue ();
         Assert.IsTrue (myNums.IsEmpty);
      }
   }
}
