// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Eight Queens
// --------------------------------------------------------------------------------------------
using System.Text;
using System.Text.Json.Nodes;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>FourQueens</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      static int[] queenCol = new int[8];
      static int[][] allSols = new int[92][];
      static bool isSolFound = false;

      /// <summary>This Method prints Eight Queens</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         EightQueens (0);
         Console.OutputEncoding = Encoding.UTF8;
         for (int row = 0; row < 8; row++) {
            if (row == 0) Console.Write ("┌───┬───┬───┬───┬───┬───┬───┬───┐");
            Console.WriteLine ();
            for (int col = 0; col < 8; col++) {
               char p = (queenCol[row] == col) ? 'Q' : ' ';
               Console.Write ($"│ {p} ");
            }
            Console.Write ("│");
            if (row != 7) Console.Write ("\n├───┼───┼───┼───┼───┼───┼───┼───┤");
            else Console.Write ("\n└───┴───┴───┴───┴───┴───┴───┴───┘");
         }
      }

      /// <summary>This Method gives the position of four Queens to be placed</summary>
      /// <param name="row">Row Index</param>
      static void EightQueens (int row) {
         for (int col = 0; col < queenCol.Length; col++) {
            if (IsQueenSafe (row, col)) {
               queenCol[row] = col;
               if (row == 7)  isSolFound = true; else EightQueens (row + 1);
            }
            if (isSolFound) return;
         }
      }
      static void Solutions () {
         
      }
      /// <summary>Checks the position of the queen is safe or not</summary>
      /// <param name="row">Row Index</param>
      /// <param name="col">Column Index</param>
      /// <returns>True if the position of the Queen is safe otherwise false</returns>
      static bool IsQueenSafe (int row, int col) {
         for (int prevRow = 0; prevRow < row; prevRow++) {
            int rowDiff = Math.Abs (row - prevRow);
            int colDiff = Math.Abs (col - queenCol[prevRow]);
            if (rowDiff == colDiff || colDiff == 0) return false;
         }
         return true;
      }
      #endregion
   }
   #endregion
}