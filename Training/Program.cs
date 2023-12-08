// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// Program.cs
// A07: Double.Parse
// Implement double.Parse method that takes a string and returns a double
// --------------------------------------------------------------------------------------------

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>double.Parse</summary>
   public class ParseDouble {
      #region Methods ---------------------------------------------
      /// <summary>This method gets a string and try to Parse it to a double</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.WriteLine ("Press Ctrl+C to quit");
         for (; ; ) {
            Console.Write ("Enter a string to be parsed to double: ");
            if (DoubleParse (Console.ReadLine ()!, out double num)) Console.WriteLine ($"Parsed to Double: {num}");
            else Console.WriteLine ("Enter a proper decimal number");
         }
      }

      /// <summary>Tries to Parse the given string to a double. If parsed gives out the converted double</summary>
      /// <param name="s">Given String</param>
      /// <param name="dNum">Parsed double value</param>
      /// <returns>Returns true if the parse is successful otherwise false</returns>
      public static bool DoubleParse (string s, out double dNum) {
         s = s.Trim ().ToLower ();
         int plVal = 0;
         string exp = "0";
         dNum = 0;
         bool validNum = false;
         if (string.IsNullOrEmpty (s)) throw new Exception ("Null or empty string");
         if (IsValidNumber (s)) {
            validNum = true;
            plVal = s.Length;
         } else if (s[0] is '-' or '+' or '.' || char.IsNumber (s[0])) {
            if (s.Contains ('.') || s.Contains ('e')) {
               int eInd = s.IndexOf ("e"), ptInd = s.IndexOf (".");
               if (Math.Abs (eInd - ptInd) == 1 || '.' == s[^1] || 'e' == s[^1]) return validNum;
               if (eInd > 0) { exp = s[(eInd + 1)..]; s = s.Remove (eInd); }
               plVal = ptInd == -1 ? s.Length : ptInd;
               if (ptInd >= 0) s = s.Remove (plVal, 1);
               if (IsValidNumber (s) && IsValidNumber (exp)) validNum = true;
            }
         }
         if (validNum) dNum = StringToDouble (s, plVal - 1, int.Parse (exp));
         return validNum;
      }

      /// <summary>Checks the given string is a valid number or not</summary>
      /// <param name="str">String value</param>
      /// <returns>True if the string is an integer otherwise false</returns>
      static bool IsValidNumber (string str) {
         if (str[0] is '+' or '-') str = str.Remove (0, 1);
         return str.All (char.IsNumber);
      }

      /// <summary>Converts the given string to double</summary>
      /// <param name="nums">Given string value</param>
      /// <param name="plV">Place value of the decimal place</param>
      /// <param name="exp">Exponent</param>
      /// <returns>Number with type double</returns>
      static double StringToDouble (string nums, int plV, int exp) {
         double dParsedNum = 0;
         int fracPart = 0, sign = (nums[0] is '-') ? -1 : 1;
         if (nums[0] is '-' or '+') { nums = nums.Remove (0, 1); plV--; };
         foreach (char digit in nums) { dParsedNum += Math.Pow (10, plV--) * (digit - '0'); if (plV < 0) fracPart++; }
         return Math.Round (dParsedNum * sign * (Math.Pow (10, exp)), Math.Abs (exp) + fracPart);
      }
      #endregion
   }
   #endregion
}