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
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.Write ("Enter the elements of character array as a word: ");
         char[] letters = (Console.ReadLine () ?? "").ToCharArray ();
         //char[] A = letters
         Console.Write ("Enter the special character: ");
         char S = Console.ReadLine ().First();
         Console.WriteLine ("Enter the sort order(Ascending or Descending): ");
         string O = Console.ReadLine () ?? "".ToLower ();
         //char[] filterA = new char[A.Length];
         string filterA = "";
         string sp = "";
         //foreach (char c in letters) { if (c != S) filterA = filterA.Append (c).ToArray (); }
         foreach (char c in letters)
            if (c == S)
               sp += c;
            else filterA += c;
         char[] sp1 = filterA.ToCharArray();
         sp1 = ((O == "descending") ? sp1.OrderDescending () : sp1.Order ()).ToArray();

         //int sCnt = 2;
         //for (int i = 0; i < sCnt; i++) filterA[^1] = S;
         //int sCnt = 0;
         //if (A.Contains (S)) {
         //   for (int i = 0; i < A.Length-1; i++) {
         //      if (A[i] == S) {
         //         A = A[..i].Concat (A[(i + 1)..]).ToArray ();
         //         Array.Resize (ref A, A.Length + 1);
         //         A[^1] = S;
         //      }
         //   }
         //}
         Console.WriteLine ($"{string.Join (",", sp1)} {string.Join(",",sp.ToArray())}");
      }
      #endregion
   }
   #endregion
}