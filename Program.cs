// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Simple Program to Print the text 'Hello, World!' in Console
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sort and Swap special character</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This method sorts the character array and adds the special character at the last</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.Write ("Enter the elements of character array as a word: ");
         char[] A = (Console.ReadLine () ?? "").ToLower ().ToCharArray ();
         Console.Write ("Enter the special character: ");
         char S = Console.ReadLine ().First ();
         Console.WriteLine ("Enter the sort order(Ascending or Descending): ");
         string O = Console.ReadLine () ?? "".ToLower ();
         string filterA = "", sp = "";
         foreach (char c in A) if (c == S) sp += c; else filterA += c;
         char[] sp1 = filterA.ToCharArray ();
         sp1 = ((O == "descending") ? sp1.OrderDescending () : sp1.Order ()).ToArray ();
         Console.WriteLine ($"{string.Join (",", sp1)} {string.Join (",", sp.ToArray ())}");
      }
      #endregion
   }
   #endregion
}