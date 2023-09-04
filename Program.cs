// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// NTH ARMSTRONG NUMBER  
// Write a function to determine the nth Armstrong number input index that needs to be passed as a command-line argument to the application.
// For example, Armstrong.exe 12 should print as 371. Maximum input can be restricted to 25. 
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Nth Armstrong Number</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method gets Nth term of Armstrong number as a command line argument</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         if (int.TryParse (args[0], out var num) && num <= 25) {
            Console.WriteLine ($"{num}th term of Armstrong number is {NthArmstrong (num)}");
         } else {
            Console.WriteLine ("Invalid input. Please enter a positive integer below 25");
         }
      }
      #endregion
      /// <summary>This method prints the Nth Armstrong number</summary>
      /// <param name="nthNum">Nth term</param>
      /// <returns>Nth term of Armstrong number</returns>
      static int NthArmstrong(int nthNum) {
         int count = 0, num = 1;
         while (count <= nthNum) {
            if (Armstrong (num)) { count++; if (count == nthNum) { break; } }
            num++;
         }
         return num;
      }
      /// <summary>Checks the number is Armstrong number or not</summary>
      /// <param name="n">Number to be checked</param>
      /// <returns>True if it is Armstrong number else false</returns>
      static bool Armstrong (int n) {
         double sum = 0, pow = n.ToString ().Length;
         int nCpy = n;
         while (nCpy > 0) {
            int digit = nCpy % 10;
            sum += Math.Pow (digit, pow);
            nCpy /= 10;
         }
         return sum == n;
      }
   }
   #endregion
}