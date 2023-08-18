// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Program to build a frequency table with occurrence of all the letters in the dictionary text file.
// The output should be a list of a letters with its occurrence count in descending order.
// Display the first 7 letters to be used as the seed for the Spelling Bee program.
// --------------------------------------------------------------------------------------------


namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Extension of spell bee</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints the frequency of letters in a dictionary text file</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         string[] words = File.ReadAllLines ("C:/Training/words.txt");
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