// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs

// The program can assume a word list is given as a text file, and that the daily choice of 7 letters is provided as an array of 7 chars:

//char[] letters = { 'U', 'X', 'A', 'L', 'T', 'N', 'E' }
//your program should find all valid spelling bee words form the given dictionary:
//each word is at least 4 letters long
//each word uses only the 7 seed letters
//each word must use the first letter (in this case, U)
//any letter can be used more than once

//The score is then computed like this:

//4 letter words score 1 point
//longer words score as many points as there are letters
//any word that uses all 7 seed letters (called pangrams) gets an additional 7 bonus points
// --------------------------------------------------------------------------------------------

using System.Linq.Expressions;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Spelling Bee Program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method goes through text file to search the words which contains given characters</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         // Reading text file containing Dictionary words
         var solWords = new List<string> ();
         string[] words = File.ReadAllLines ("W:\\Training\\words.txt");
         char[] letters = { 'U', 'X', 'A', 'L', 'T', 'N', 'E' };
         var modWords = new List<(int, string)> { };
         // Filtering out words with letter 'U' in text file
         var baseKey = letters[0];
         foreach (var word in words.Where (x => x.Contains (baseKey) && x.Length >= 4)) {
            // Getting letters from the word:
            bool iFound = true;
            foreach (char letter in word)
               if (!letters.Contains (letter))
                  iFound = false;

            if (iFound) solWords.Add (word);
         }

         // Allocating points for the words selected:
         int totalPoints = 0, point;
         foreach (string word in solWords) {
            if (word.Length == 4) point = 1;
            else {
               //Checks wheather the word contains all 7 letters:
               if (letters.All (x => word.Contains (x))) point = word.Length + 7;
               else point = word.Length;
            }
            modWords.Add ((point, word));
            totalPoints += point;
         }

         // Ordering the words in decreasing order of points
         foreach (var word in modWords.OrderByDescending (a => a.Item1)) {
            if (word.Item1 == 15) Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine ($"{word.Item1,3}. {word.Item2}");
            Console.ResetColor ();
         }

         Console.WriteLine ($"Total: {totalPoints}");
         #endregion
      }
      #endregion
   }
}