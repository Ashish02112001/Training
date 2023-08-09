// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// program to display a given number in words or Roman numbers,
// The program has  an input mode to choose between words and roman numbers. Accordingly, the output can be displayed. 
// --------------------------------------------------------------------------------------------



namespace Training {
   #region TestProgram---------------------------------------------------------------------------
   /// <summary>Class Program</summary>
   internal class Program {
      #region Methods
      /// <summary>Asks user for a number and is given a choice to conver it to Words or Roman number</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.WriteLine ("Enter a number between 0 and 1000:");
         string input = Console.ReadLine ();
         Console.Write ("Enter type of conversion (R)oman or to (W)ords: ");
         switch (Console.ReadKey ().Key) {
            case ConsoleKey.R: convertToRoman (input); break;
            case ConsoleKey.W: convertToWord (input); break;
            default: Console.WriteLine ("\nEnter a valid choice"); break;
         }
      }
      /// <summary>The function uses array to convert the number to Words</summary>
      /// <param name="input">Input is a number which is to be converted to Words</param>
      static void convertToWord (string input) {
         //nTW stands for number to Words
         string[] nTWO = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
         string[] nTWTeen = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "Nineteen" };
         string[] nTWTens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "Ninety" };
         int num = int.Parse (input);
         if (input.Length == 1) { Console.WriteLine ($"\n{input} - {nTWO[num]}"); } 
         else if (input.Length == 2) {
            if (input[0] == '1') { Console.WriteLine ($"\n{input} - {nTWTeen[num % 10]}"); } 
            else if (input[1] != '0' && input[0] != '1') { Console.WriteLine ($"\n{input} - {nTWTens[num / 10]} {nTWO[num % 10]}"); } 
            else if (input[1] == '0') Console.WriteLine ($"\n{nTWTens[num / 10]}");
         } else if (input.Length == 3) {
            if (input[0] != '0' && input[1] == '0' && input[2] == '0') { Console.WriteLine ($"\n{nTWO[num / 100]} hundred"); } 
            else if (input[0] != '0' && input[1] == '0' && input[2] != '0') { Console.WriteLine ($"\n{input} - {nTWO[num / 100]} hundred and {nTWO[num % 100]}"); } 
            else if (input[0] != '0' && input[1] == '1' && input[2] != '0') { Console.WriteLine ($"\n{input} - {nTWO[num / 100]} hundred and {nTWTeen[(num % 100) % 10]}"); } 
            else if (input[0] != '0' && input[1] != '0' && input[2] == '0') { Console.WriteLine ($"\n{input} - {nTWO[num / 100]} hundred and {nTWTens[(num % 100) / 10]}"); } 
            else if (input[0] != '0' && input[1] != '0' && input[2] != '0') { Console.WriteLine ($"\n{input} - {nTWO[num / 100]} hundred and {nTWTens[(num % 100) / 10]} {nTWO[(num % 100) % 10]}"); }
         } else { Console.WriteLine ($"\nEnter a valid number between 1 & 1000"); }
      }
      /// <summary>The function uses array to convert the number to Roman numverals</summary>
      /// <param name="input"></param>
      static void convertToRoman (string input) {
         //nTR stands for number to Roman.
         string[] nTRO = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
         string[] nTRTens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
         string[] nTRHund = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM", "M" };
         int num = int.Parse (input);
         if (input.Length == 1) { Console.WriteLine ($"\n{input} - {nTRO[num]}"); } else if (input.Length == 2) Console.WriteLine ($"\n{input} - {nTRTens[num / 10]}{nTRO[num % 10]}");
         else if (input.Length == 3) Console.WriteLine ($"\n{input} - {nTRHund[num / 100]}{nTRTens[(num % 100) / 10]}{nTRO[(num % 100) % 10]}");
         else { Console.WriteLine ($"\nEnter a valid number between 1 & 1000"); }
      }
   }
   #endregion
}
#endregion
