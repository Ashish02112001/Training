// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Program takes number as an input and returns whether it is a valid Armstrong number or not.
// An Armstrong number is one whose sum of digits raised to the power of the number of digits equal the number itself.
// for example,153 is an Armstrong number because 1^3 + 5^3 + 3^3 = 153. 
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Armstrong number checker</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Checks the number from the user is Armstrong number or not</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.Write ("Enter a number: ");
         for (; ; ) {
            if (int.TryParse (Console.ReadLine (), out int num)) {
               if (ArmstrongNum (num)) { Console.WriteLine ($"{num} is an Armstrong number"); break; } 
               else { Console.WriteLine ($"{num} is not an Armstrong number"); break; }
            } else { Console.Write ("\nEnter a valid number: "); }
         }
      }
      #endregion
      /// <summary>Checks wheather a given number is an Armstrong number</summary>
      /// <param name="num">Number from the user</param>
      /// <returns>True if the number is a armstrong number</returns>
      static bool ArmstrongNum (int num) {
         int numCpy = num;
         double sum = 0, pow = num.ToString ().Length;
         while (numCpy > 0) {
            int digit = numCpy % 10;
            sum += Math.Pow (digit, pow);
            numCpy /= 10;
         }
         return (num == sum);
      }
   }
   #endregion
}