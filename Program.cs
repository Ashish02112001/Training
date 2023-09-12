// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// SWAP INDICES 
// Display random series of numbers to the user and ask them to provide two index values 
// which need to be swapped and display the swapped result to the user.
// For example, 4 8 7 5 6 9 enter the index to be swapped: 2 3 outputs to be: 4 8 5 7 6 9.
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Swap Indices</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This method swaps the random number with the indices given by the user</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         int[] nums = new int[6];
         for (int i = 0; i < nums.Length; i++) {
            int n = new Random ().Next (1, 10);
            if (!nums.Contains (n)) nums[i] = n;
            else { --i; }
         }
         Console.Write ("Random number: ");
         foreach (int digit in nums) { Console.Write ($"{digit} "); }
         for (; ; ) {
            Console.WriteLine ("\nEnter two indices to be swapped(0 - 5): ");
            if (int.TryParse (Console.ReadLine (), out int i1) && i1 < 6 && int.TryParse (Console.ReadLine (), out int i2) && i2 < 6) {
               (nums[i1], nums[i2]) = (nums[i2], nums[i1]);
               Console.Write ("Result after swapping: ");
               foreach (int digit in nums) { Console.Write ($"{digit} "); }
               break;
            }
         }
      }
      #endregion
   }
   #endregion
}