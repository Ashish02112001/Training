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
         Console.WriteLine ("Enter the length of Fibonacci series: ");
         int end = int.Parse(Console.ReadLine());
         Console.WriteLine("\n------Fibonacci Series------");
         int count = 2, i = 0, j = 1;
         Console.Write ($"{i} {j}");
         while (count <= end) {
            int result = i + j;
            Console.Write ($" {result}");
            i = j; j = result;
            count++;
         }
         Console.WriteLine ();
      }
      #endregion
   }
   #endregion
}