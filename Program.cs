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
         string word = "RED";
         Console.WriteLine ($"Permutation of the word {word}");
         foreach (string str in Permute1 (word)) { Console.WriteLine ($"{count,4}. {str}"); count++; }
      }
      /// <summary>Gets an integer and calculates factorial</summary>
      /// <param name="n">number for which factorial is to be calculated</param>
      /// <returns>Factorial of n</returns>
      static int Factorial (int n) {
         int result = 1;
         while (n > 0) {
            result *= n; 
            n--;
         }
         return result;
      }
      /// <summary>Generates the permutation of the given word</summary>
      /// <param name="word">Word for which permutations has to be generated</param>
      /// <returns>A string array with the permutations of the word</returns>
      static string[] Permute1 (string word) {
         int count = Factorial (word.Length);
         string[] result = new string [count];
         if (word.Length == 1) { result[0] = word; return result; }
         for (int i = 0; i < word.Length; i++) {
            char start = word[i];
            string remainingStr = word.Remove (i, 1);
            var remWords = Permute1 (remainingStr);
            int tCount = Factorial (remainingStr.Length);
            for (int k = 0;  k < tCount; k++) result[k + i * tCount] = start + remWords[k];
         }
         return result;
      }
      #endregion
   }
   #endregion
}