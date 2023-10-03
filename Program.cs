// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Simple Program to Print the text 'Hello, World!' in Console
// --------------------------------------------------------------------------------------------


namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sample program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         Console.WriteLine ("Enter number of elements: ");
         string letters = Console.ReadLine () ?? "";
         char[] A = letters.ToCharArray ();
         Console.WriteLine ("Enter the special character: ");
         char S = (char)Console.Read();
         Console.WriteLine ("Enter the sort order(Ascending or Descending): ");
         string O = Console.ReadLine() ?? "";
         A = O == "descending" ? A.OrderByDescending(x => x).ToArray() : A.Order().ToArray();
         Array.Resize(ref A, A.Length + 1);
         A[A.Length-1] = S;
         foreach (char ch in A) Console.Write ($"{ch}, ");
      }
      #endregion
   }
   #endregion
}