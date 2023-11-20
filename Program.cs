// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// Program.cs
// A06: Eight Queens
// On a standard chessboard 8 queens have to be placed so that no queen can attack any other. 
// As per the rules of chess, the queen can move horizontally, vertically or in a diagonal.
// No two queens can be on the same row or column or diagonal.
// --------------------------------------------------------------------------------------------
using System.Text;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>FourQueens</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      static int[] queenCol = new int[8];
      static List<int[]> sols = new ();
      static char solChoice;

      /// <summary>This Method prints Eight Queens</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         int soln = 0;
         Console.Write ("Enter your choice to display (A)ll solution or (U)nique solution: ");
         solChoice = (char)Console.ReadKey ().Key;
         EightQueens (0);
         for (; ; ) {
            Console.OutputEncoding = Encoding.UTF8;
            if (soln > sols.Count - 1) break;
            Console.WriteLine ($"\nSolution:{soln + 1} of {sols.Count}");
            for (int row = 0; row < 8; row++) {
               if (row == 0) Console.Write ("┌───┬───┬───┬───┬───┬───┬───┬───┐");
               Console.WriteLine ();
               for (int col = 0; col < 8; col++) {
                  string p = (sols[soln][row] == col) ? "♕" : " ";
                  Console.Write ($"│ {p} ");
               }
               Console.Write ("│");
               if (row != 7) Console.Write ("\n├───┼───┼───┼───┼───┼───┼───┼───┤");
               else Console.Write ("\n└───┴───┴───┴───┴───┴───┴───┴───┘");
            }
            Console.WriteLine ();
            switch (Console.ReadKey ().Key) {
               case ConsoleKey.Enter: soln++; break;
               default: Console.WriteLine ("Press ENTER to print next solution"); break;
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
                  if (solChoice is (char)ConsoleKey.U) { if (!IsIdentical (queenCol)) sols.Add (queenCol.ToArray ()); } else sols.Add (queenCol.ToArray ());
               } else EightQueens (row + 1);
            }
         }
      }

      /// <summary>Checks wheather the position of the queen is safe or not</summary>
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

      /// <summary>Checks wheather the solution is identical to the existing solutuions</summary>
      /// <param name="soln">solution array</param>
      /// <returns>returns true if the solution is identical otherwise false</returns>
      static bool IsIdentical (int[] soln) {
         int[] mirrSol = Mirror (soln);
         List<int[]> rotatedArr = Rotation (soln);
         foreach (int[] sol in sols) {
            if (soln.SequenceEqual (sol) || mirrSol.SequenceEqual (sol)) return true;
            foreach (int[] rotSol in rotatedArr) {
               mirrSol = Mirror (rotSol);
               if (rotSol.SequenceEqual (sol) || mirrSol.SequenceEqual (sol)) return true;
            }
         }
         return false;
      }

      /// <summary>Gives the 3 rotated solutions(90, 180 and 270 degrees) of the given solution array</summary>
      /// <param name="soln">Solution array to be rotated</param>
      /// <returns>List with the rotated solution arrays</returns>
      static List<int[]> Rotation (int[] soln) {
         List<int[]> allRotSol = new ();
         int[] rotSoln = new int[8];
         allRotSol.Add (soln.ToArray ());
         for (int rot = 0; rot < 3; rot++) {
            for (int row = 0; row < soln.Length; row++) rotSoln[7 - soln[row]] = row;
            for (int ind = 0; ind < 8; ind++) soln[ind] = rotSoln[ind];
            allRotSol.Add (rotSoln.ToArray ());
         }
         return allRotSol;
      }

      /// <summary>Gives the mirrored solution of the given solution array</summary>
      /// <param name="sols">Solution array to be mirrored</param>
      /// <returns>Mirrored Solution</returns>
      static int[] Mirror (int[] sols) {
         int[] mirSoln = new int[8];
         for (int row = 7; row >= 0; row--) mirSoln[7 - row] = sols[row];
         return mirSoln;
      }
      #endregion
   }
   #endregion
}