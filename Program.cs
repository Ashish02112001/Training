// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// Program.cs
// Simple Program to Print the text 'Hello, World!' in Console
// --------------------------------------------------------------------------------------------

using System.Text;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sample program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
      }
      static void DisplayBoard () {
         Console.OutputEncoding = Encoding.UTF8;
         Console.WriteLine ("\t│\t│\n \t│\t│");
         Console.WriteLine ("────────────────────────");
         Console.WriteLine ("\t│\t│\n \t│\t│");
         Console.WriteLine ("────────────────────────");
         Console.WriteLine ("\t│\t│\n \t│\t│");
      }
      static void Game () {
         for (int row = 0; row )
         //while (inputs != 9) {
         //   ConsoleKey key = Console.ReadKey (true).Key;
            
         //}
      }
      static int inputs { get; set; }
      #endregion
   }
   #endregion
}