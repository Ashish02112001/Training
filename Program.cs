// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
//  program to display the chess board with all pieces black and white which
//  resembles an actual chess board in the console window using Unicode
//250C - Left upper corner
//2510 - right upper corner
//2500 - hLine
//2502 - vLine
//252C - upper 3 branch
//2534 - lower 3 branch
//251C - Left 3 branch
//2524 - Right 3 branch
//253C - Mid 4 branch
//2514 - Lower left corner
//2518 - lower right corner
// --------------------------------------------------------------------------------------------


using System.Text;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Chess Board</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Prints the Chess board and pieces</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         Console.OutputEncoding = System.Text.Encoding.UTF8;
         for (int i = 0; i < 17; i++){
            Lines (i);
         }
         Console.Write ('\u2666');
         #endregion
      }
      /// <summary>Prints the grids and pieces of chess board</summary>
      /// <param name="row"></param>
      static void Lines (int row) {
         if (row == 0) Top();
         else if (row == 16) Bottom ();
         //Print vertical lines with a space
         else if (row % 2 == 1) {
            Console.Write ('\u2502');
            for (int col = 1; col < 32; col++)
               if (col % 4 == 0) Console.Write ('\u2502');
               else if (row is 1 or 3 or 13 or 15  && Place (col)) PrintPiece (row, col);
               else if (row is not 3 or 13) Console.Write (" ");
            Console.Write ('\u2502');
            Console.WriteLine ();
         }
         //Print howizontal lines with branch to complete a row
         else if (row % 2 is 0) {
            Console.Write ('\u251C');
            for (int col = 1; col < 32; col++) 
               if (col % 4 == 0) Console.Write ('\u253C');
               else Console.Write ('\u2500');
            Console.Write ('\u2524');
            Console.WriteLine ();
         }
      }
      /// <summary>This method gives the position at which the piece is printed</summary>
      /// <param name="n">coloumn position</param>
      /// <returns>True to print in specific position</returns>
      static bool Place (int n) {
         for (int i = 1; i <= 8; i++) {
            int num = (4 * i) - 2;
            if (n == num) return true;
         }
         return false;
      }
      /// <summary>This method prints the pieces at the specific position</summary>
      /// <param name="area">Row of the chess board</param>
      /// <param name="pos">Coloumn(position) of piece</param>
      static void PrintPiece (int area,int pos) {
         char[] BlackPiece = new char[] { '\u2656', '\u2658', '\u2657', '\u2655', '\u2654', '\u2657', '\u2658', '\u2656' };
         char BlackSol = '\u2659';
         char[] WhitePiece = new char[] { '\u265C', '\u265E', '\u265D', '\u265B', '\u265A', '\u265D', '\u265E', '\u265C' };
         char WhiteSol = '\u265F';
         if (area == 1) Console.Write ($"{WhitePiece[(pos + 2) / 4 - 1]}");
         else if (area == 3) Console.Write ($" {WhiteSol}");
         else if (area == 13) Console.Write ($"{BlackSol}");
         else if (area == 15) Console.Write ($"{BlackPiece[(pos + 2) / 4 - 1]}");
      }
      /// <summary>Prints Bottom portion of chess board</summary>
      static void Bottom () {
         Console.Write ('\u2514');
         for (int col = 1; col < 32; col++) 
            if (col % 4 == 0) Console.Write ('\u2534');
            else { Console.Write ('\u2500'); }
         Console.Write ('\u2518');
         Console.WriteLine ();
      }
      /// <summary>Prints Top portion of chess board</summary>
      static void Top () {
         Console.Write ('\u250C');
         for (int col = 1; col < 32; col++)
            if (col % 4 == 0) Console.Write ('\u252C');
            else { Console.Write ('\u2500'); }
         Console.Write ('\u2510');
         Console.WriteLine ();
      }
      #endregion
   }
}