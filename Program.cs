// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Program to Swap a two number
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Number Swap</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Gets two numbers from the user and swaps it</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.WriteLine ("Enter two numbers: ");
         if (int.TryParse (Console.ReadLine(), out var a) && int.TryParse(Console.ReadLine(),out var b)) {
            Console.WriteLine ($"Before Swaping: \na = {a} \nb = {b}");
            Swap (ref a, ref b);
            Console.WriteLine ($"After Swaping: \na = {a} \nb = {b}");
         }
      }
      /// <summary>Gets two number and swaps it</summary>
      /// <param name="a">1st number</param>
      /// <param name="b">2nd number</param>
      static void Swap (ref int a,ref int b) { (a, b) = (b, a); }
      #endregion
   }
   #endregion
}