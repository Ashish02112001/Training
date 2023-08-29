// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Palindrome Checker
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Palindrome Checker</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method Checks the user input is palindrome or not</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.WriteLine ("Enter a string to check wheather it is a palindrome: ");
         string uInput = Console.ReadLine (), input = uInput.Trim ().ToLower ().Replace (" ", "");
         string reversed = string.Join ("", input.Reverse ());
         if (input == reversed) { Console.WriteLine ($"{uInput} is a palindrome"); }
         else { Console.WriteLine ($"{uInput} is not a palindrome"); }
      }
      #endregion
   }
   #endregion
}