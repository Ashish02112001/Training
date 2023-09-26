// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Given a string S to a method, with each character in it representing a vote for a contestant, return the winner with the most votes.
// If 2 or more contestants have the same number of votes, the contestant who got the first vote among them is declared a winner. 
// Input Criteria: Character representation is Case-Insensitive and Alphabet. S should not be empty. 
// Use at least 1 keyword/technique: in, out, ref, optional parameters, multiple return values. 
// --------------------------------------------------------------------------------------------
using System.Reflection;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sample program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         string S;
         for (; ; ) {
            Console.Write ("Enter your vote for contestants(A to Z): ");
            S = Console.ReadLine () ?? "";
            if (S.All (char.IsAsciiLetter) && S.Length > 0) {
               var majority = VotesCounter (S);
               Console.WriteLine ($"The winner is {majority.ch} with {majority.n} votes");
               break;
            }
         }
      }
      static (char ch, int n) VotesCounter (string votes) {
         votes = votes.ToLower ();
         Dictionary<char, int> votesCounter = new Dictionary<char, int> ();
         foreach (char vote in votes) votesCounter[vote] = votesCounter.TryGetValue (vote, out int voteCount) ? ++voteCount : 1;
         var winner = votesCounter.OrderByDescending (x => x.Value).First ();
         return (winner.Key, winner.Value);
      }
      #endregion
   }
   #endregion
}