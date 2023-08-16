// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
//program to print a diamond using asterisk.The input can be the number of rows (half the height) 
// --------------------------------------------------------------------------------------------


using System.Collections.Generic;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Print Diamond pattern</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Asks the user for number of rows for Diamond pattern</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         Console.Write ("\nEnter a number of rows for diamond pattern: ");
         for (; ; ) {
            if (int.TryParse(Console.ReadLine(), out int rows)) {
               int limit = (rows + 1) * 2;
               int gap = rows;
               Diamond (limit, gap); break;
            }
            else { Console.Write ("\nEnter a valid number of row: "); }
         }
      }
      /// <summary>This functions prints the spaces for a given number</summary>
      /// <param name="n">n is the number os spaces required</param>
      static void space(int n) {
         string gap = " ";
         for (int i = 0;i < n; i++) gap += " ";
         Console.Write (gap);
      }
      /// <summary>Prints Diamond for a given limit</summary>
      /// <param name="limit">Maximum amount of the asterik used in a row</param>
      /// <param name="gap">Maximum amount of space given in a row</param>
      static void Diamond (int limit,int gap) {
         for (int i = 1; i <= limit; i += 2) {
            space (gap);
            for (int j = 0; j < i; j++)
               Console.Write ("*");
            Console.WriteLine (); gap--;
         }
         gap = 1;
         for (int i = limit - 3; i >= 1; i -= 2) {
            space (gap);
            for (int j = 0; j < i; j++)
               Console.Write ("*");
            Console.WriteLine (); gap++;
         }
      }
      #endregion
   }
   #endregion
}