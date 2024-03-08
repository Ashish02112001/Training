using Training;

namespace Test {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void TestDequeue () {
         PriorityQueue<int> queue = new ();
         List<int> list = new ();
         Random random = new ();
         // Enqueue 20 random numbers between 1 to 50
         for (int i = 0; i < 20; i++) {
            var num = random.Next (0, 51);
            queue.Enqueue (num);
            list.Add (num);
         }
         Assert.IsFalse (queue.IsEmpty);
         list.Sort ();
         // Dequeue and checking with sorted list
         for (int j = 0; j < 20; j++) {
            Assert.AreEqual (list[0], queue.Dequeue ());
            list.RemoveAt (0);
         }
         Assert.IsTrue (queue.IsEmpty);
      }

      [TestMethod]
      public void TestEnqueue () {
         PriorityQueue<char> queue = new ();
         List<char> list = new ();
         Random random = new ();
         // Enqueue 10 random characters between A to Z
         for (int i = 0; i < 10; i++) {
            var ch = (char)random.Next ('A', 'Z');
            queue.Enqueue (ch);
            list.Add (ch);
            list.Sort ();
            Assert.AreEqual (list[0], queue.Dequeue ());
            list.RemoveAt (0);
         }
      }
   }
}