﻿// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// program to print Pascal's triangle
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Pascal's Triangle</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Prints Pascal's triangle for a given row size</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         Console.WriteLine ("Enter number of rows for Pascal triangle to be printed: ");
         int input = int.Parse (Console.ReadLine ());
         int gap = input; 
         for (int r = 0;r < input; r++) {
            Console.Write("".PadRight (gap--));
            for (int c = 0; c <= r; c++) 
               Console.Write ($"{Pvalue (input, r, c)} ");
            Console.WriteLine ();
         }
      }
      /// <summary>Gives the values in a pascal's triangle</summary>
      /// <param name="dim">It is the size of 2D array</param>
      /// <param name="i">row index</param>
      /// <param name="j">column index</param>
      /// <returns>Returns the elements in a pascal's triangle</returns>
      static int Pvalue(int dim,int i,int j) {
         int[,] num = new int[dim,dim];
         if (i == j || j == 0)  num[i, j] = 1; 
         else  num[i, j] = Pvalue(dim,i-1, j-1) + Pvalue (dim,i - 1, j); 
         return num[i, j];
      }
      #endregion
   }
   #endregion
}
