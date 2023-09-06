// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// DISPLAY THE INDIVIDUAL DIGITS OF A GIVEN NUMBER 
// Displays the individual digits of a given number, which should also handle decimal digits.
// For example, 355.56 is the input number, output = integral part: 3 5 5; factorial part: 5 6.
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
               int intPart = (int)num;
               decimal fractPart = num - intPart;
               int fractLen = fractPart.ToString ().Length;
               fractLen = fractPart < 0 ? fractLen - 3 : fractLen - 2;
               int fractPartx = (int) ((decimal)Math.Pow (10, fractLen) * fractPart);
               Console.Write ("Integral Part: ");
               PrintDigits (Math.Abs(intPart));
               Console.Write ("\nFractional Part: ");
               PrintDigits (Math.Abs(fractPartx));
               break;
            } else { Console.Write ("Enter a valid number: "); }
         }
      }
      /// <summary>Prints the individual digits</summary>
      /// <param name="num">Number from the user</param>
      static void PrintDigits(int num) {
         while (num > 0) {
            int exp = (int)Math.Pow (10,num.ToString ().Length)/10;
            Console.Write ($"{num / exp} ");
            num %= exp;
         }
      }
      #endregion
   }
   #endregion
}