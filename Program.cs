// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Function to print the factorial for the given number
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Factorial of a number</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This method asks the number from the user and gives factorial of it</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.Write ("Enter a Number: ");
         for(; ; ) {
            if (int.TryParse (Console.ReadLine (), out var num)) {
               Console.WriteLine ($"{num}! = {Factorial (num)}");
               break;
            } else Console.Write ("Enter a valid number: ");
         }
      }
      #endregion
      static int Factorial (int num) => (num > 1) ? num * Factorial (num - 1) : 1;
   }
   #endregion
}
