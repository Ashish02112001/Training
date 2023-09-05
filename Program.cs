// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// program to print a diamond using asterisk.The input can be the number of rows (half the height) 
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Print Diamond pattern</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Asks the user for number of rows for Diamond pattern</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.WriteLine ("Note: Row size must be below 55");
         Console.Write ("\nEnter a number of rows for diamond pattern: ");
         for (; ; ) {
            if (int.TryParse(Console.ReadLine(), out int rows) && rows <= 55) {
               int limit = (rows + 1) * 2;
               int gap = rows+1;
               Diamond (limit, gap);break;
            }
            else { Console.Write ("\nEnter a valid number below 55: "); }
         }
      }
      /// <summary>Prints Diamond for a given limit</summary>
      /// <param name="limit">Maximum amount of the asterik used in a row</param>
      /// <param name="Space">Maximum amount of space given in a row</param>
      static void Diamond (int limit,int Space) {
         string gap = " ";
         for (int i = 1; i <= limit; i += 2) {
            Console.Write(gap.PadRight(Space--));
            for (int j = 0; j < i; j++)
               Console.Write ("*");
            Console.WriteLine (); 
         }
         Space = 2;
         for (int i = limit - 3; i >= 1; i -= 2) { 
            Console.Write(gap.PadRight (Space++));
            for (int j = 0; j < i; j++)
               Console.Write ("*");
            Console.WriteLine (); 
         }
      }
      #endregion
   }
   #endregion
}