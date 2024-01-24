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
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         string[] inputs = File.ReadAllLines ("input.txt");
         int red = 0, green = 0, blue = 0;
         foreach (string nIDp in inputs){
            string[] tries = nIDp.Split (';');
            foreach (string el in tries) {
               if (el is "red") red += el.IndexOf(el) - 
               if (el is "green") green +=
               if (el is "blue") blue +=
            }
         }
      }
      #endregion
   }
   #endregion
}