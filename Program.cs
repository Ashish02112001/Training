// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// program takes a number as input and displays whether it is a prime number or not.
// --------------------------------------------------------------------------------------------


namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Prime number checker</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Gets an number from a user and checks it's a prime number</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         Console.Write ("Enter a number: ");
         int num = int.Parse (Console.ReadLine ()), count = 0;
         for (int i = 1; i <= num; i++) if (num % i == 0) count++;
         if (count == 2) Console.WriteLine ($"{num} is a Prime number");
         else Console.WriteLine ($"{num} is a not a Prime number");
      }
      #endregion
   }
   #endregion
}