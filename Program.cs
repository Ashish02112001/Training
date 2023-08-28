// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Reduce a string of lowercase characters by deleting a pair of adjacent letters that match. 
// Input: aaabccddd, Output: abd
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Reduced string</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints the reduced string for a given string</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         int i = 0;
         for(; ; ) {
            Console.WriteLine ("Enter a word: ");
            string input = Console.ReadLine ();
            if (input.All (char.IsAsciiLetterLower)) {
               while (i < input.Length - 1) if (input[i] == input[i + 1]) { input = input.Remove (i, 2); } else i++;
               Console.WriteLine ($"Reduced String: {input}"); break;
            } else Console.WriteLine ("Try again with lower case alphabets");continue;
         }
      }
      #endregion
   }
   #endregion
}