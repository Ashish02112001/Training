// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// ABECEDERIAN word
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sample program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         string[] words = {"AEGILOPS","BILLOWY","ALMOST","level","Habits" };
         Console.WriteLine($"Given Words: ");
         foreach (string word in words) { Console.Write ($"{word} "); }
         Console.WriteLine ($"\nLongest ABECEDERIAN word: {LongAbeced (words)}");
      }
      #endregion
      static string LongAbeced (string[] words) {
         List<string> wordList = new();
         int count = 0;
         foreach (string word in words) {
            if (Abcedarian (word)) { wordList.Add (word); count++; }
            else wordList.Add (" ");
         }
         return wordList.OrderByDescending (a => a.Length).First ();
      }
      static bool Abcedarian(string word) {
         bool valid = false;
         word = word.ToUpper();
         for (int i = 0;i<word.Length-1;i++) { if (word[i] <= word[i + 1]) { valid = true; } else { valid = false; break; } }
         return valid;
      }
   }
   #endregion
}