using Training;
namespace Test {
   [TestClass]
   public class UnitTest1 {

      [TestMethod]
      public void TestCorrectGuess () {
         new Wordle (new Tuple<string, List<string>> ("LEMON", new List<string> { "RIVER", "LAKES", "LEVEL", "LEMON" })).Run ();
         Assert.IsTrue (CheckTextFilesEqual ("../../../../Training/data/Test_file.txt", "../../../../Training/data/CorrectGuess.txt"));
      }

      [TestMethod]
      public void TestWrongGuess () {
         new Wordle (new Tuple<string, List<string>> ("LEMON", new List<string> { "RIVER", "LAKES", "LAYER", "LADEN", "LATER", "LEVEL" })).Run ();
         Assert.IsTrue (CheckTextFilesEqual ("../../../../Training/data/Test_file.txt", "../../../../Training/data/WrongGuess.txt"));
      }

      [TestMethod]
      public void TestIncompleteGuess () {
         new Wordle (new Tuple<string, List<string>> ("LEMON", new List<string> { "RIVER", "LAKES", "LAY" })).Run ();
         Assert.IsTrue (CheckTextFilesEqual ("../../../../Training/data/IncompleteGuess.txt", "../../../../Training/data/Test_file.txt"));
      }

      bool CheckTextFilesEqual (string f1, string f2) {
         if (File.ReadAllText (f1) == File.ReadAllText (f2)) return true;
         var p = System.Diagnostics.Process.Start ("C:\\Program Files\\WinMerge\\WinMergeU.exe", $"\"{f1}\" \"{f2}\"");
         p.WaitForExit ();
         return false;
      }
   }
}