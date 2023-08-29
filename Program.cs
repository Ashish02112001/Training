// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// An abecedarian word is a word where all its letters are arranged in alphabetical order.
// Given an array of words, create a function which returns the longest abecedarian word.
// If no word in an array matches the criteria, return an empty string. 
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Abecedarian word</summary>
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
      /// <summary>This method takes the string array and returns the longest Abecederian word</summary>
      /// <param name="words">Given array of strings</param>
      /// <returns>Longest Abcecederian word in the array</returns>
      static string LongAbeced (string[] words) {
         List<string> wordList = new();
         int count = 0;
         foreach (string word in words) {
            if (Abcedarian (word)) { wordList.Add (word); count++; }
            else wordList.Add (" ");
         }
         return wordList.OrderByDescending (a => a.Length).First ();
      }
      /// <summary>This method cheks the word is a Abecedarian or not</summary>
      /// <param name="word">Word</param>
      /// <returns>Returns true if the word is Abecedarian else false</returns>
      static bool Abcedarian(string word) {
         bool valid = false;
         word = word.ToUpper();
         for (int i = 0;i<word.Length-1;i++) { if (word[i] <= word[i + 1]) { valid = true; } else { valid = false; break; } }
         return valid;
      }
   }
   #endregion
}