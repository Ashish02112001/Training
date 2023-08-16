// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Printing multiplication tables from 1 to 10 in a tabular form on a console with a line gap between each table.
// --------------------------------------------------------------------------------------------


namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Print Tables</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Prints multiplycation table from 1 to 10</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         for (int tab = 1;tab <= 10; tab++) {
            for (int num = 1; num <= 10;num++) 
               Console.WriteLine ($"{tab} * {num,3} = {tab*num}");
            Console.WriteLine ();
         }
      }
      #endregion
   }
   #endregion
}