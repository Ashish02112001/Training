// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// program to implement a Inverse simple guessing game by checking the reminder:
// The user thinks of a random number between 1 and 128, and the computer has to guess it.
// The computer asks simple questions and the user has to enter (Y)es or (N)o
// --------------------------------------------------------------------------------------------


namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Inverse Guessing game by checking the reminder</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Tells the user to get started with the Inverse guessing game</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         Console.WriteLine ("Think of a number between 1 & 128, I will guess it..");
         Console.WriteLine ("Press any KEY to start");
         Console.ReadKey (true);
         double sol = guessNum ();
         Console.WriteLine ($"\nThe number you have thought is {sol}");
      }
      /// <summary>The user answers the yes or no questions, with that the computer will search for the number by binarysearch method</summary>
      /// <returns>Final number thought by the user</returns>
      static double guessNum () {
         double rem = 0;
         for (int i = 1; i <= 7; i++) {
            double x = Math.Pow (2, i);
            Console.Write ($"\nIs the reminder is {rem} when divided by {x} : ");
            //Initialising flag to 1 to check the case or default statement is being executed
            int flag = 1;
            var Key = Console.ReadKey ().Key;
            switch (Key) {
               case ConsoleKey.Y: flag = 1; break;
               case ConsoleKey.N: rem = rem + (x/2) ; flag = 1; break;
               default: Console.WriteLine ("\nEnter a valid key : 'y' for Yes or 'n' for No"); flag = 0; break;
            }//If the user presses other than y or n, the loop is extended until the user gives right choice
            if (flag == 0) i -= 1;
            #endregion
         }
         return rem;
         #endregion
      }
      
   }
}