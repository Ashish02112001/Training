// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// A12: Wordle
// --------------------------------------------------------------------------------------------

namespace Training {
   #region Program --------------------------------------------------------------------------------
   /// <summary>Wordle Game</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.WriteLine ("Hello, World!");
      }

      /// <summary>Sets the console color based on the current state</summary>
      /// <param name="updateColor">State of the character</param>
      /// <returns>Console color for the given state</returns>
      static ConsoleColor UpdateColorState (State updateColor) => updateColor switch {
         State.PRESENT => ConsoleColor.Blue,
         State.ABSENT => ConsoleColor.DarkGray,
         State.CORRECT => ConsoleColor.Green,
         _ => Console.ForegroundColor
      };

      public enum State { PRESENT, ABSENT, CORRECT }
      #endregion
      #region fields ------------------------------------------------
      static Dictionary<char, ConsoleColor> mCharColor = new ();
      static Dictionary<char, ConsoleColor> mAllColor = new ();
      static bool GameOver;
      static int num;
      static ConsoleKeyInfo currentKey;
      #endregion
   }
   #endregion
}