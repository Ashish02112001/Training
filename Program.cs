// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Given a character array A, along with special character S and sort order O (default order is Ascending),
// print the sorted array by keeping the elements matching S to the last of the array. 
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sort and Swap special character</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This method gets the character array, Special Character and Order then prints sorted and swapped string</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.Write ("Enter the elements of character array as a word: ");
         char[] A = (Console.ReadLine () ?? "").ToLower ().ToCharArray ();
         Console.WriteLine ("Enter the special character: ");
         char S = Console.ReadLine ()[0];
         Console.WriteLine ("Enter the sort order(ascending(a) or Descending(d)): ");
         char O = Console.ReadLine ()[0];
         //string O = Console.ReadLine () ?? "".ToLower ();
         Console.WriteLine ($"Sorted and swapped special characrter: [{SortAndSwapSplChr (A, S, O)}]");
      }
      /// <summary>This method sorts the character array and adds the special character at the last</summary>
      /// <param name="A">Given character array</param>
      /// <param name="S">Special Character</param>
      /// <param name="O">Order of sort</param>
      /// <param name="filterA">optional variable to store the letters excluding special characters</param>
      /// <param name="spChr">optional variable to store special characters from a given array</param>
      /// <returns>Sorted and swapped string seperated by ","</returns>
      static string SortAndSwapSplChr (char[] A, char S, char O, string filterA = "", string spChr = "") {
         foreach (char c in A) if (c == S) spChr += c; else filterA += c;
         char[] filterArr = filterA.ToCharArray ();
         filterArr = ((O == 'd') ? filterArr.OrderDescending () : filterArr.Order ()).ToArray ();
         return ($"{string.Join (",", filterArr)},{string.Join (",", spChr.ToArray ())}");
      }
      #endregion
   }
   #endregion
}