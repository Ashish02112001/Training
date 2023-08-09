// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Given an input number, the program calculates the LCM and GCD and display the result in the console window. 
// --------------------------------------------------------------------------------------------


namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>LCM and HCF Generator</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This method gets the inputs from the user and gives the HCF and LCM</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         Console.WriteLine ("Enter a number: ");
         int a = int.Parse(Console.ReadLine ()); 
         int b = int.Parse(Console.ReadLine ());
         Console.WriteLine ($"LCM: {LCM (a, b)}");
         Console.WriteLine ($"HCF: {HCF (a, b)}");
      }
      /// <summary>This method gives the LCM of the two numbers</summary>
      /// <param name="a">1st number</param>
      /// <param name="b">2nd number</param>
      /// <returns>Least Common Multiple of two numbers</returns>
      static int LCM (int a, int b) {
         int max = a > b ? a : b;
         int min = a < b ? a : b;
         for (int i = max; ; i += max) if (i % min == 0) return i;
      }
      /// <summary>This method gives the HCF of the two numbers</summary>
      /// <param name="a">1st number</param>
      /// <param name="b">2nd number</param>
      /// <returns>Highest common Factor</returns>
      static int HCF (int a, int b) {
         int HCF = 1;
         int min = a < b ? a : b;
         for (int j = 1; j <= min; j++) if (a % j == 0 && b % j == 0) { HCF = j;}
         return HCF;
      }
      #endregion
   }
   #endregion
}