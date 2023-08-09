// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Simple Program to Print the text 'Hello, World!' in Console
// --------------------------------------------------------------------------------------------


namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sample program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         string[] words = File.ReadAllLines ("W:/Training/words.txt");
         Dictionary<char, int> lettersCount = new Dictionary<char, int> ();
         foreach (string word in words) {
            foreach (char ch in word) {
               if (lettersCount.ContainsKey (ch)) lettersCount[ch]++;
               else lettersCount.Add (ch, 1);
            }
         }
         int count = 0;
         foreach (KeyValuePair<char, int> pair in lettersCount.OrderByDescending(a => a.Value)) {
            if (pair.Key >= 'A' && pair.Key <= 'Z') Console.WriteLine ($"{pair.Key} = {pair.Value}"); count++;
            if (count == 7) Console.WriteLine ("----------These 7 letters can be used for spell bee game----------");
         } 
      }
      #endregion
   }
   #endregion
}