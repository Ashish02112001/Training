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
         int revNum = reverseNum (num);
         Console.WriteLine ($"Reversed number is {revNum}");
         if (num == revNum) { Console.WriteLine ("It is palindrome"); }
         else { Console.WriteLine ("It is not a palindrome"); }
      }
      #endregion
      /// <summary></summary>
      /// <param name="num">Number from the user</param>
      /// <returns>Reversed number from the user</returns>
      static int reverseNum(int num) {
         int digit = 0, rev = 0;
         while (num > 0) {
            digit = num % 10;
            rev = (rev * 10) + digit;
            num /= 10;
         }
         return rev;
      }
   }
   #endregion
}