// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// program to implement a Inverse simple guessing game :
// The user thinks of a random number between 1 and 100, and the computer has to guess it.
// The computer asks simple questions and the user has to enter (Y)es or (N)o
// --------------------------------------------------------------------------------------------

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sample program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Upper and lower limits are set</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         int lower = 0, upper = 100;
         Console.WriteLine ("Think of a number between 1 & 100, I will guess it..");
         Console.WriteLine ("Press any KEY to start");
         Console.ReadKey (true);
         int num = guessNum (upper, lower);
         Console.WriteLine ($"\nThe number you have thought is {num}");
      }
      /// <summary>The user answers the yes or no questions, with that the computer will search for the number by binarysearch method</summary>
      /// <param name="max">Maximum Guess limit</param>
      /// <param name="min">Minimum Guess limit</param>
      /// <returns>Returns final number thought by the user</returns>
      static int guessNum (int max, int min) {
         for (int i = 0; i < 7; i++) {
            int mid = (max + min) / 2;
            //Initialising flag to 1 to check the case or default statement is being executed
            int flag = 1;
            Console.Write ($"\nIs the number more than {mid} Press (Y)es or (N)o? ");
            var Key = Console.ReadKey ().Key;
            switch (Key) {
               case ConsoleKey.Y: min = mid; mid = (max + min) / 2; flag = 1; break;
               case ConsoleKey.N: max = mid; mid = (max + min) / 2; flag = 1; break;
               default: Console.WriteLine ("\nEnter a valid key : 'y' for Yes or 'n' for No"); flag = 0; break;
            }//If the user presses other than y or n, the loop is extended until the user gives right choice
            if (flag == 0)  i -= 1; 
         }
         return max;
         #endregion
      }
      #endregion
   }
}