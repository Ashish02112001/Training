// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Reverse a given number and check for palindrome
// --------------------------------------------------------------------------------------------


namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Palindrome check for integers</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method gets integer and checks it's a palindrome or not</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         Console.Write ("Enter a Number: ");
         int num = int.Parse (Console.ReadLine());
         Console.WriteLine ($"Digital root of {num} is {digitalRoot(num)}");
      }
      #endregion
      /// <summary></summary>
      /// <param name="num">Number from the user</param>
      /// <returns>Reversed number from the user</returns>
      static int digitalRoot(int num) {
         int digit = 0, sum = 0;
         while (num > 0) {
            digit = num % 10;
            num /= 10;
            sum += digit;
         }
         if (sum >= 10) return digitalRoot(sum);
         return sum;
      }
   }
   #endregion
}