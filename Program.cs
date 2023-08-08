// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// program to convert a given decimal number to different forms (Hexadecimal, Binary)
// and display the converted values in the console window. 
// --------------------------------------------------------------------------------------------


namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Decimal to binary and Hexadecimal Conversion</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method converts the input number to binary and hexadecimal equivalent</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {
         Console.WriteLine ("\nEnter a number:");
         string num = Console.ReadLine ();
         int num1 = int.Parse (num);
         Console.WriteLine ($"The binary equivalent is {Convert.ToString(num1, 2)}");
         Console.WriteLine ($"The Hexadecimal equivalent is {num1:X}");
      }
      #endregion
   }
   #endregion
}