// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
//  program to find the digital root of a given number
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Digital root</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method gets number to find it's digital root</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.Write ("Enter a Number: ");
         int num = int.Parse (Console.ReadLine());
         Console.WriteLine ($"Digital root of {num} is {digitalRoot(num)}");
      }
      #endregion
      /// <summary>This calcultes digital root of a number</summary>
      /// <param name="num">Number from the user</param>
      /// <returns>Gives digital root of the number</returns>
      static int digitalRoot(int num) {
         int sum = 0;
         while (num > 0) {
            int digit = num % 10;
            num /= 10;
            sum += digit;
         }
         if (sum >= 10) return digitalRoot(sum);
         return sum;
      }
   }
   #endregion
}