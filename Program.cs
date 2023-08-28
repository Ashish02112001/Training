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
            bool isogram = true;
            Console.WriteLine ("Enter a word: ");
            string input = Console.ReadLine ();
            if (input.All (char.IsAsciiLetter)) {
               foreach (var letter in input) {
                  if (input.Count (x => x == letter) > 1) { Console.WriteLine ($"{input} is an not an isogram"); isogram = false; break; }
               }
               if (isogram) { Console.WriteLine ($"{input} is an isogram"); }
               break;
            } else continue;
         }
      }
      #endregion
   }
   #endregion
}