// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// program to display the Fibonacci series given an input
// --------------------------------------------------------------------------------------------


namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Fibonaccci Series</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>User gives the length of the series as input for Fibonacci series to be printed</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         for(; ; ) {
            Console.Write ("Enter the length of Fibonacci series: ");
            if (int.TryParse (Console.ReadLine (), out int end)) {
               Console.WriteLine ("\n------Fibonacci Series------");
               for (int i = 0; i < end; i++) Console.Write ($" {Fibonacci (i)} "); break;
            } else continue;
         }
      }
      #endregion
      /// <summary>Gives the elements of Fibonacci series</summary>
      /// <param name="n">Number of element in Fibonacci series</param>
      /// <returns>Returns nth element of Fibonacci series</returns>
      static int Fibonacci (int n) {
         int[] fib = new int[n];
         switch (n) {
            case 0: return 0;
            case 1: return 1;
            default: return Fibonacci (n - 1) + Fibonacci (n - 2);
         }
      }
   }
   #endregion
}