// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Simple Program to Print the text 'Hello, World!' in Console
// --------------------------------------------------------------------------------------------


namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sample program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguements</param>
      static void Main (string[] args) {

         Console.WriteLine ("\nEnter a number:");
         string num = Console.ReadLine ();
         int num1 = int.Parse (num);
         Console.WriteLine ($"The binary equivalent is {Convert.ToString(num1, 2)}");
         Console.WriteLine ($"The Hexadecimal equivalent is {num1:X}");
         //Stack<int> binNum = new Stack<int> ();
         //while (num1 > 0) {
         //   binNum.Push (num1 % 2);
         //   num1 /= 2;
         //}
         //Console.Write ("Binary Equivalent is : ");
         //while (binNum.Count > 0) {
         //   Console.Write(binNum.Pop ());
         //}
         //char[] HexD = { 'A', 'B', 'C', 'D', 'E', 'F' };

      }
      
      #endregion
   }
   #endregion
}