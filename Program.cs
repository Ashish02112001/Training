// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Program to generate all string character permutations.
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>String permutations generator</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This method gets a string and gives the permutations of the string</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         int count = 1;
         Console.WriteLine ("Enter a word: ");
         string word = Console.ReadLine() ?? "";
         Console.WriteLine ($"Permutation of the word {word}");
         foreach (string str in Permute1 (word).Distinct()) { Console.WriteLine ($"{count, 4}. {str}"); count++; }
      }
      /// <summary>Generates the permutation of the given word</summary>
      /// <param name="word">Word for which permutations has to be generated</param>
      /// <returns>A string array with the permutations of the word</returns>
      static List<string> Permute1 (string word) {
         List<string> result = new();
         if (word.Length == 1) { result.Add (word); return result; }
         for (int i = 0; i < word.Length; i++) {
            char start = word[i];
            string remainingStr = word.Remove (i, 1);
            var remWords = Permute1 (remainingStr);
            foreach (string str in remWords) result.Add(start + str);
         }
         return result;
      }
      #endregion
   }
   #endregion
}