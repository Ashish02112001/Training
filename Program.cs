// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// program to implement a simple guessing game :
// The computer thinks of a random number between 1 and 100, and the user has to guess it.
// The user can enter an number, and the computer will respond with one of these:
// - Your guess is too high - Your guess is too low - You guessed correctly
// --------------------------------------------------------------------------------------------

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>simple guessing game</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method gets a random number and the user has to guess it</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         /// Main Method creates a random number and compares it with the guess of the user
         var mode = GetMode ();
         Console.WriteLine (mode);
         int max = GetMax (mode);
         int n = new Random ().Next (1, max + 1), guess = 0;
         Console.WriteLine ($"Enter your guess between 1 to {max}: ");
         for (; ; ) {
            Console.Write ("> ");
            if (int.TryParse (Console.ReadLine (), out guess)) {
               if (guess == n) { Console.WriteLine ("You guessed Correctly"); break; }
               if (guess < n) { Console.WriteLine ("Your guess is too low"); }
               if (guess > n) { Console.WriteLine ("Your guess is too high"); } 
            } else { Console.WriteLine ("Enter a Valid number"); }
         }
      }

     static Mode GetMode () {
         /// GetMode gets the difficulty level from the user 
         Console.Write ("Select a mode (E)asy, (M)edium, (H)ard:");
         for (; ; ) {
            var key = Console.ReadKey (true).Key;
            switch (key) {
               case ConsoleKey.E: return Mode.Easy;
               case ConsoleKey.M: return Mode.Medium;
               case ConsoleKey.H: return Mode.Hard;
               default: return Mode.Medium;
            }
         }
      }
     static int GetMax (Mode mode) {
         /// GetMax gets sets the Maximum rang for the difficulty level selected by user
         switch (mode) {
            case Mode.Easy: return 10;
            case Mode.Hard: return 1000;
            default: return 100;
         }
      }
      /// <summary> 3 Levels of difficulty is declared under enumeration data type </summary>
      enum Mode { Easy, Medium, Hard }
      #endregion
   }
   #endregion
}




















