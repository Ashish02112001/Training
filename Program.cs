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
         Console.WriteLine ("Enter a string to check wheather it is a palindrome: ");
         string input = Console.ReadLine ();
         string reversed = string.Join ("", input.Reverse ());
         if (input == reversed) { Console.WriteLine ($"{input} is a palindrome"); }
         else { Console.WriteLine ($"{input} is not a palindrome"); }
      }
      #endregion
   }
   #endregion
}