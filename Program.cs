// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Function to print the factorial for the given number
// --------------------------------------------------------------------------------------------
using System.Numerics;
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Factorial of a number</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This method asks the number from the user and gives factorial of it</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         for (; ; ) {
            Console.Write ("Enter a Number: ");
            if (int.TryParse (Console.ReadLine (), out var num) && num > 0) {
               Console.WriteLine ($"{num}! = {Factorial (num)}"); 
            } 
         }
      }
      #endregion
      /// <summary>Gets the number and calculates the factorial of it</summary>
      /// <param name="num">Number from the user</param>
      /// <returns>Factorial of the number</returns>
      static BigInteger Factorial (int num) {
         BigInteger fact = 1;
         for (int i = 1; i <= num; i++) {
            fact*= i;
         }
         return fact;
      }
   }
   #endregion
}
