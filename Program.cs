// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// Program.cs
// Simple Program to Print the text 'Hello, World!' in Console
// --------------------------------------------------------------------------------------------

using System.ComponentModel;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sample program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         ComplexNumber z1 = new ComplexNumber (4, 3);
         ComplexNumber z2 = new ComplexNumber (3, 4);
         ComplexNumber z3 = new ComplexNumber (0, 0);
         Console.WriteLine ($"Given Complex numbers: {z1.realPart} + {z1.imgPart}i and {z2.realPart} + {z2.imgPart}i");
         Console.Write ($"Addition: ");
         z3.Add (z1, z2);
         Console.Write ($"\nSubtraction: ");
         z3.Sub (z1, z2);
         Console.WriteLine ($"\nMagnitude of 1st Complex number: {z1.Norm}");
      }
      #endregion
   }
   #endregion
   public class ComplexNumber {
      public ComplexNumber (int rPart, int iPart) {
         realPart = rPart;
         imgPart = iPart;
      }
      public readonly int realPart, imgPart;

      public void Add (ComplexNumber z1, ComplexNumber z2) {
         int realAdd = z1.realPart + z2.realPart;
         int imgAdd = z1.imgPart + z2.imgPart;
         Console.Write ($"{realAdd} + {imgAdd}i");
      }
      public void Sub (ComplexNumber z1, ComplexNumber z2) {
         int realSub = z1.realPart - z2.realPart;
         int imgSub = z1.imgPart - z2.imgPart;
         char sign = imgPart > 0 ? '+' : '-';
         if (sign == '-') imgSub *= -1;
         Console.Write ($"{realSub} {sign} {imgSub}i");
      }
      public double Norm {
         get {
            double c = realPart*realPart + imgPart*imgPart;
            return (Math.Sqrt (c));
         }
      }
   }
}