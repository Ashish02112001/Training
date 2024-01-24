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
         DisplayBoard ();
         while (inputs != 9) {
            GameUpdate ();
            DisplayBoard ();
         }
      }
      static void DisplayBoard () {
         Console.OutputEncoding = Encoding.UTF8;
         for (int row = 0; row < 3; row++) {
            for (int col = 0; col < 3; col++) {
               pos
               if (pos != null && pos.Length - pos[row+col] == pos.Length - (row+col)) 
                  Console.Write ($"{pos[row+col]} |");
               else Console.Write ("  │");
            }
            Console.WriteLine ();
            Console.WriteLine ("──────────");

         }
      }
      static void GameUpdate () {
            for (; ; ) {
               char input = (char)Console.ReadKey (true).Key;
               if (char.IsDigit (input)) {
                  ++inputs;
                  key = input - 48;
                  pos[key] = 'p';
                  break;
               }
            }
      }
      static int key;
      static int inputs { get; set; }
      static char[] pos = new char[9];
      #endregion
   }
   #endregion
}