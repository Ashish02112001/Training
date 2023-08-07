// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Simple Program to Print the text 'Hello, World!' in Console
// --------------------------------------------------------------------------------------------


using System.Diagnostics.Tracing;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sample program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         int Count = 0;
         string[] words = File.ReadAllLines ("W:/Training/words.txt");
         Dictionary<char, int> lettersCount = new Dictionary<char, int> ();
         foreach (string word in words) {
            foreach (char ch in word) {
               if (lettersCount.ContainsKey (ch)) {
                  Count = lettersCount[ch];
               }
            }
               
         }
         foreach (KeyValuePair<char, int> pair in lettersCount) {
            Console.WriteLine (pair.Key + " = " + pair.Value);
         }
      }
      #endregion
   }
   #endregion
}