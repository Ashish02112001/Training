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
         Console.Write ("\nEnter a number: ");
         for (; ; )
            if (int.TryParse (Console.ReadLine (), out int result)) {
               Console.WriteLine ($"The binary equivalent is {Convert.ToString (result, 2)}");
               Console.WriteLine ($"The Hexadecimal equivalent is {result:X}");
               break;
            }
            else Console.Write ("Enter a valid number: ");
      }
      #endregion
   }
   #endregion
}