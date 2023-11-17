// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// Program.cs
// Eight Queens
// --------------------------------------------------------------------------------------------
using System.Text;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>FourQueens</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      static int[] queenCol = new int[8];
      static List<int[]> allSols = new ();

      /// <summary>This Method prints Eight Queens</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         int soln = 0;
         EightQueens (0);
         for (; ; ) {
            Console.OutputEncoding = Encoding.UTF8;
            if (soln > allSols.Count-1) break;
            Console.WriteLine ($"Solution:{soln + 1} of {allSols.Count}");
            for (int row = 0; row < 8; row++) {
               if (row == 0) Console.Write ("┌───┬───┬───┬───┬───┬───┬───┬───┐");
               Console.WriteLine ();
               for (int col = 0; col < 8; col++) {
                  string p = (allSols[soln][row] == col) ? "♕" : " ";
                  Console.Write ($"│ {p} ");
               }
               Console.Write ("│");
               if (row != 7) Console.Write ("\n├───┼───┼───┼───┼───┼───┼───┼───┤");
               else Console.Write ("\n└───┴───┴───┴───┴───┴───┴───┴───┘");
            }
            Console.WriteLine ();
            switch (Console.ReadKey ().Key) {
               case ConsoleKey.Enter: soln++; break;
            }
         }
      }

      /// <summary>This Method gives the position of four Queens to be placed</summary>
      /// <param name="row">Row Index</param>
      static void EightQueens (int row) {
         for (int col = 0; col < queenCol.Length; col++) {
            if (IsQueenSafe (row, col)) {
               queenCol[row] = col;
               if (row == 7) {
                  if (!IsIdentical (queenCol)) 
                  allSols.Add (queenCol.ToArray());
               } else EightQueens (row + 1);
            }
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

      /// <summary>
      /// 
      /// </summary>
      static void FilterUniqueSolutions () {
         foreach (int[] colSol in allSols) {
            int[] rotSoln = new int[8];
            int[] mirSoln = new int[8];
            for (int rot = 0; rot < 3; rot++) {
               for (int row = 0; row < colSol.Length; row++) {
                  rotSoln[7 - colSol[row]] = row;
               }
               for (int row = 7; row >= 0; row--) mirSoln[7 - row] = colSol[row];
               for (int ind = 0; ind < 8; ind++) colSol[ind] = rotSoln[ind];
            }
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="soln"></param>
      /// <returns></returns>
      static bool IsIdentical (int[] soln) {
         int[] mirrSol = Mirror (soln);
         List<int[]> rotatedArr = Rotation (soln);
         foreach (int[] sol in allSols) {
            if (soln.SequenceEqual (sol) || mirrSol.SequenceEqual (sol)) return true;
            foreach (int[] rotSol in rotatedArr) {
               mirrSol = Mirror (rotSol);
               if (rotSol.SequenceEqual(sol) || mirrSol.SequenceEqual(sol)) return true;
            }
         }
         return false;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="soln"></param>
      /// <returns></returns>
      static List<int[]> Rotation (int[] soln) {
            List<int[]> allRotSol = new ();
            int[] rotSoln = new int[8];
         allRotSol.Add (soln.ToArray());
         for (int rot = 0; rot < 3; rot++) {
            for (int row = 0; row < soln.Length; row++) {
               rotSoln[7 - soln[row]] = row;
            }
            for(int ind = 0;ind < 8;ind++) soln[ind] = rotSoln[ind];
            allRotSol.Add (rotSoln.ToArray());
         }
         return allRotSol;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="sols"></param>
      /// <returns></returns>
      static int[] Mirror (int[] sols) {
            int[] mirSoln = new int[8];
            for (int row = 7; row >= 0; row--) mirSoln[7 - row] = sols[row];
            return mirSoln;
      }
      #endregion
   }
   #endregion
}