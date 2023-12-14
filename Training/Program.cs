// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// Program.cs
// A09: Expression Evaluator
// Add a TOpUnary class (derived from TOperator) to keep things clean. Later we might add other unary operators.
// Simple Program to Print the text 'Hello, World!' in Console
// --------------------------------------------------------------------------------------------

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Expression Evaluator</summary>
   public class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method gets a mathematic expression and evaluates it</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         var eval = new Evaluator ();
         for (; ; ) {
            Console.Write (">");
            try {
               string input = Console.ReadLine () ?? "";
               if (input == "exit") break;
               double result = eval.Evaluate (input);
               Console.ForegroundColor = ConsoleColor.Green;
               Console.WriteLine (result);
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