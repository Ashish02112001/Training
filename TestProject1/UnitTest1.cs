using Training;
namespace TestProject1{
   [TestClass]
   public class UnitTest1{
      List<int> nums = new ();
      MyList<int> myNums = new ();

      [TestMethod]
      public void TestAdd () {
         nums.Add (1); myNums.Add (1);
         nums.Add (2); myNums.Add (2);
         nums.Add (3); myNums.Add (3);
         Assert.AreEqual (nums[0], myNums[0]);
         nums[0] = 0; myNums[0] = 0;
         nums.Clear (); myNums.Clear ();
      }

      [TestMethod]
      public void TestRemove () {
         nums.Add (1); myNums.Add (1);
         nums.Add (2); myNums.Add (2);
         nums.Remove (2); Assert.IsTrue (myNums.Remove (2));
         Assert.AreEqual (nums.Count, myNums.Count);
         Assert.IsFalse (myNums.Remove (5));
         Assert.ThrowsException<IndexOutOfRangeException> (() => myNums[4]);
         nums.Clear (); myNums.Clear ();
      }
      [TestMethod]
      public void TestInsert () {
         nums.Add (1); myNums.Add (1);
         nums.Add (3); myNums.Add (3);
         nums.Insert (1, 2); myNums.Insert (1, 2);
         Assert.AreEqual (nums[1], myNums[1]);
         Assert.ThrowsException<IndexOutOfRangeException> (() => myNums.Insert (4, 5));
         nums.Clear (); myNums.Clear ();
      }
      [TestMethod]
      public void TestClear () {
         nums.Add (1); myNums.Add (1);
         nums.Add (2); myNums.Add (2);
         nums.Clear (); myNums.Clear ();
         Assert.AreEqual (0, myNums.Count);
         nums.Clear (); myNums.Clear ();

      }
      [TestMethod]
      public void TestRemoveAt () {
         nums.Add (1); myNums.Add (1);
         nums.Add (2); myNums.Add (2);
         nums.RemoveAt (1); myNums.RemoveAt (1);
         Assert.AreEqual (nums.Count, myNums.Count);
         Assert.ThrowsException<IndexOutOfRangeException> (() => myNums.RemoveAt (8));
         nums.Clear (); myNums.Clear ();
      }
      [TestMethod]
      public void TestCapacity () {
         myNums.Add (1);
         myNums.Add (2);
         myNums.Add (3);
         myNums.Add (4);
         myNums.Add (5);
         Assert.AreEqual (8, myNums.Capacity);
      }
   }
}
