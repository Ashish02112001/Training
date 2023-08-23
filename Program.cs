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
      #region Methods----------------------------------------------
      /// <summary>Asks user for a number and is given a choice to conver it to Words or Roman number</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.Write ("Enter a number between 0 and 1000: ");
         for(; ; ) {
            if (int.TryParse (Console.ReadLine (), out int input) && input < 1000) {
               Console.Write ("Enter type of conversion (R)oman or to (W)ords: ");
               switch (Console.ReadKey ().Key) {
                  case ConsoleKey.R: Console.WriteLine ($"\n{input} - {ConvertToRoman (input)}"); break;
                  case ConsoleKey.W: Console.WriteLine($"\n{input} - {ConvertToWord (input)}"); break;
                  default: Console.WriteLine ($"\n{input} - {ConvertToWord (input)}"); break; 
               }
               break;
            } else { Console.Write ("Enter a valid number: "); }
         }
      }
      /// <summary>The function uses array to convert the number to Words</summary>
      /// <param name="num">Input is a number which is to be converted to Words</param>
      static string ConvertToWord (int num) {
         //nTW stands for number to Words
         string[] nTWO = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
         string[] nTWTeen = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
         string[] nTWTens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
         string input = num.ToString ();
         //For single digit number
         if (input.Length == 1) return nTWO[num];
         //For two digit number
         else if (input.Length == 2) return (input[1] != '0') ? ((input[0] == '1') ? nTWTeen[num % 10] : nTWTens[num / 10] + " " + nTWO[num % 10]) : nTWTens[num / 10]; 
         //For three digit number
         else return (input[1] == '0' && input[2] == '0') ? ConvertToWord (num / 100) + " hundred" : ConvertToWord (num / 100) + " hundred and " + ConvertToWord (num % 100); 
      }
      /// <summary>The function uses array to convert the number to Roman numerals</summary>
      /// <param name="num">Input is a number which is to be converted to Roman numeral</param>
      static string ConvertToRoman (int num) {
         //nTR stands for number to Roman.
         string[] nTRO = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
         string[] nTRTens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
         string[] nTRHund = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM", "M" };
         string input = num.ToString ();
         //For single digit number
         if (input.Length == 1) return nTRO[num];
         //For two digit number
         else if (input.Length == 2) return nTRTens[num / 10] + ConvertToRoman(num % 10);
         //For three digit number
         else return nTRHund[num / 100] + ConvertToRoman(num % 100);
      }
   }
   #endregion
}
#endregion
