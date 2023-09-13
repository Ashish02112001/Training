// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Checks the entered word is an isogram
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Isogram checker</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method checks and prints wheather the given string is isogram or not</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         for(; ; ) {
            Console.Write ("Enter a word: ");
            string input = Console.ReadLine ();
            if (input.All (char.IsAsciiLetter) && input.Length > 0) {
               if (input.Distinct ().Count () == input.Length) Console.WriteLine ($"{input} is an isogram");
               else Console.WriteLine ($"{input} is an not an isogram");
               break;
            } 
         }
      }
      #endregion
   }
   #endregion
}