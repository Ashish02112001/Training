﻿// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Four Queens Try
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>FourQueens</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      static int[] queenCol = new int[4];
      static bool isSolFound = false;

      /// <summary>This Method prints Four Queens</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         FourQueens (0);
         for (int row = 0; row < 4; row++) {
            for (int col = 0; col < 4; col++) {
               if (queenCol[row] == col) Console.Write ("Q ");
               else Console.Write (". ");
            }
            Console.WriteLine ();
         }
      }

      /// <summary>This Method gives the position of four Queens to be placed</summary>
      /// <param name="row">Row Index</param>
      static void FourQueens (int row) {
         for (int col = 0; col < queenCol.Length; col++) {
            if (IsQueenSafe (row, col)) {
               queenCol[row] = col;
               if (row == 3)  isSolFound = true; else FourQueens (row + 1);
            }
            if (isSolFound) return;
         }
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