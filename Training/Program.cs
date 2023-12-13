// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// Program.cs
// Simple Program to Print the text 'Hello, World!' in Console
// --------------------------------------------------------------------------------------------

using System.Text.RegularExpressions;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sample program</summary>
   public class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         var eval = new Evaluator ();
         for (; ; ) {
            Console.Write (">");
            try {
               string input = Console.ReadLine () ?? "";
               double result = eval.Evaluate (input);
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine (Math.Round (result, 10));
               Console.ResetColor ();
            } catch (Exception ex) {
               Console.ForegroundColor = ConsoleColor.Red;
               Console.WriteLine (ex.Message);
               Console.ResetColor ();
            }
         }
         #endregion
      }
      #endregion
   }
}