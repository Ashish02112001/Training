// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Given a character array A, along with special character S and sort order O (default order is Ascending),
// print the sorted array by keeping the elements matching S to the last of the array. 
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sort and Swap special character</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This method gets the character array, Special Character and Order then prints sorted and swapped string</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         string input = GetInput ("Enter the elements of character array as a word: ");
         char[] A = (input ?? "").ToLower ().ToCharArray ();
         char S = GetInput ("Enter the special character: ").FirstOrDefault ();
         char O = GetInput ("Enter the sort order, (a)scending or (d)escending: ").FirstOrDefault ();
         Console.WriteLine ($"Sorted and swapped special character: [{SortAndSwapSplChr (A, S, O)}]");
      }

      /// <summary>This method sorts the character array and adds the special character at the last</summary>
      /// <param name="charArr">Given character array</param>
      /// <param name="spChr">Special Character</param>
      /// <param name="order">Order of sort</param>
      /// <returns>Sorted and swapped string seperated by ","</returns>
      static string SortAndSwapSplChr (char[] charArr, char spChr, char order = 'a') {
         List<char> filtered = new ();
         List<char> special = new ();
         foreach (char c in charArr) {
            if (c == spChr) special.Add (c);
            else filtered.Add (c);
         }
         return string.Join (", ", (order == 'd' ? filtered.OrderDescending () : filtered.Order ()).Concat (special));
      }

      /// <summary>Prints the prompt and gets only the ASCII string</summary>
      /// <param name="prompt">Sentence to ask the user for input</param>
      /// <returns>ASCII user input</returns>
      static string GetInput (string prompt) {
         string input;
         for (; ; ) {
            Console.Write ($"{prompt}");
            input = Console.ReadLine ();
            if (input.All (char.IsAsciiLetter)) return input;
            else Console.WriteLine ("Input should contain only letters. Please try again.");
         }
      }
      #endregion
   }
   #endregion
}