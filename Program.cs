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

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Spelling Bee Program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method goes through text file to search the words which contains given characters</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         var solWord = new List<string> { };
         var Char = new List<char> { };
         //Reading text file containing Dictionary words
         string[] words = File.ReadAllLines ("W:\\Training\\words.txt"); 
         var newWord = new List<string> { };
         int points = 0;
         char[] letters = { 'U', 'X', 'A', 'L', 'T', 'N', 'E' }; 
         int point;
         var modWord = new List<(int, string)> { };
         //Filtering out words with letter 'U' in text file
         foreach (var word in words) {
            if (word.Contains (letters[0])) {
               if (word.Length >= 4) {
                  newWord.Add (word);
               }
            }
         }
         // Getting words from the list:
         foreach (string word in newWord) {
            int count = 0;
            // Getting letters from the word:
            foreach (char letter in word) {
               if (letters.Contains (letter)) count++;
               if (count == word.Length)
                  solWord.Add (word);
            }
         }
         // Allocating points for the words selected:
         foreach (string word in solWord) {
            if (word.Length == 4) {
               point = 1;
               modWord.Add ((point, word));
            }
            else {
               //Checks wheather the word contains all 7 letters:
               if (letters.All (letter => word.Contains (letter))) {
                  point = word.Length + 7;
                  modWord.Add ((point, word));
               } else {
                  point = word.Length;
                  modWord.Add ((point, word));
               }
            }
            points += point;
         }
         // Ordering the words in decreasing order of points
         foreach (var word in modWord.OrderByDescending (a => a.Item1)){
            Console.WriteLine ($"{word.Item1}. {word.Item2}");
         }
         Console.WriteLine ($"Total : {points}");
         #endregion
      }
      #endregion
   }
}