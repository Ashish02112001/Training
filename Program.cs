// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// DISPLAY THE INDIVIDUAL DIGITS OF A GIVEN NUMBER 
// Displays the individual digits of a given number, which should also handle decimal digits.
// For example, 355.56 is the input number, output = integral part: 3 5 5; fractional part: 5 6.
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Display individual digits</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method gets input number from the user and prints the individual digits</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.Write ("Enter a number: ");
         for (; ; ) {
            if (decimal.TryParse (Console.ReadLine (), out var num)) {
               string numStr = num.ToString ();
               string[] digits = numStr.Split ('.');
               Console.Write ("Integral part: ");
               foreach (char iP in digits[0]) Console.Write ($"{iP} ");
               if (digits.Length == 2) {
                  Console.Write ("\nFractional part: ");
                  foreach (char fP in digits[1]) Console.Write ($"{fP} ");
               }
               break;
            } else { Console.Write ("Enter a valid number: "); }
         }
      }

      #endregion
   }
   #endregion
}