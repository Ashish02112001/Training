// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Write a method, for a given money X along with price P of a chocolate and required wrappers W for a chocolate in exchange,
// return the maximum number of chocolates C you can get along with any unused money X and wrappers W. 
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Chocolate Wrappers</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Gets the votes and gives the winner</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         int X = 30, P = 5, W = 5;
         Console.WriteLine (ChocoWrappers(X,P,W));
         //for (; ; ) {
         //   Console.Write ("Enter your vote for contestants(A to Z): ");
         //   S = Console.ReadLine () ?? "";
         //   if (S.All (char.IsAsciiLetter) && S.Length > 0) {
         //      var majority = VotesCounter (S);
         //      Console.WriteLine ($"The winner is {majority.ch} with {majority.n} votes");
         //      break;
         //   }
         //}
      }
      /// <summary></summary>
      /// <param name="X"></param>
      /// <param name="P"></param>
      /// <param name="W"></param>
      /// <returns></returns>
      static (int C, int X, int W) ChocoWrappers (int X, int P,int W) {
         int wraperchocoCount = (X / P) - W;
         return (wraperchocoCount > 0) ? ChocoWrappers((X/P),W,wraperchocoCount) : (X+W, )
         //return (wraperchocoCount > 0) ? ((X / P) + wraperchocoCount, X % P, X % (X / P)) : ((X / P), X % P, 1);
      }
      #endregion
   }
   #endregion
}