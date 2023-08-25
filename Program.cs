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
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         for(; ; ) {
            Console.Write ("Enter a number: ");
            int count = 0;
            if (int.TryParse (Console.ReadLine (), out int num)) {
               for (int i = 2; i < num; i++) if (num % i == 0) { count++; break; }
               if (count == 1) Console.WriteLine ($"{num} is not a Prime number");
               else Console.WriteLine ($"{num} is a Prime number");break;
            }else continue;
         }
      }
      #endregion
   }
   #endregion
}