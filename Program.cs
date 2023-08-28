// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Given two input number, the program calculates the LCM and GCD and display the result in the console window. 
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>LCM and HCF Generator</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This method gets the inputs from the user and gives the HCF and LCM</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         for(; ;){
            Console.WriteLine ("Enter two numbers: ");
            if (int.TryParse (Console.ReadLine (), out int a) && int.TryParse (Console.ReadLine (), out int b) && a != 0 && b != 0) {
               if (b > a) (a, b) = (b, a);
               Console.WriteLine ($"LCM: {LCM (a, b)}");
               Console.WriteLine ($"HCF: {HCF (a, b)}");break;
            } else Console.WriteLine ("Enter valid numbers.");
         }
      }
      /// <summary>This method gives the LCM of the two numbers</summary>
      /// <param name="a">1st number</param>
      /// <param name="b">2nd number</param>
      /// <returns>Least Common Multiple of two numbers</returns>
      static int LCM (int a, int b) { for (int i = a; ; i += a) if (i % b == 0) return i; }
      
      /// <summary>This method gives the HCF of the two numbers</summary>
      /// <param name="a">1st number</param>
      /// <param name="b">2nd number</param>
      /// <returns>Highest common Factor of two numbers</returns>
      static int HCF (int a, int b) { for (int j = b; ; j--) if (a % j == 0 && b % j == 0)  return j; }
      #endregion
   }
   #endregion
}