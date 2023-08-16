// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Simple Program to Print the text 'Hello, World!' in Console
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
   /// <summary>Sample program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {

         Console.OutputEncoding = System.Text.Encoding.UTF8;
         for (int i = 0; i < 17; i++){
            Lines (i);
         }
         Console.Write ('\u265A');
         #endregion
      }
      static void Lines (int n) {
         if (n is 0) Top();
         else if (n is 16) Bottom ();
         //Print vertical lines with a space
         else if (n % 2 is 1) {
            Console.Write ('\u2502');
            for (int j = 1; j < 32; j++) 
               if (j % 4 == 0) Console.Write ('\u2502');
               else Console.Write (" ");
            Console.Write ('\u2502');
            Console.WriteLine ();
         }
         //Print howizontal lines with branch to complete a row
         else if (n % 2 is 0) {
            Console.Write ('\u251C');
            for (int j = 1; j < 32; j++) 
               if (j % 4 == 0) Console.Write ('\u253C');
               else Console.Write ('\u2500');
            Console.Write ('\u2524');
            Console.WriteLine ();
         }
      }
      static void Bottom () {
         Console.Write ('\u2514');
         for (int j = 1; j < 32; j++) 
            if (j % 4 == 0) Console.Write ('\u2534');
            else { Console.Write ('\u2500'); }
         Console.Write ('\u2518');
         Console.WriteLine ();
      }
      #endregion
      static void Top () {
         Console.Write ('\u250C');
         for (int j = 1; j < 32; j++) 
            if (j % 4 == 0) Console.Write ('\u252C');
            else { Console.Write ('\u2500'); }
         Console.Write ('\u2510');
         Console.WriteLine ();
      }
   }
}