// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// NTH ARMSTRONG NUMBER  
// Write a function to determine the nth Armstrong number input index that needs to be passed as a command-line argument to the application.
// For example, Armstrong.exe 12 should print as 371. Maximum input can be restricted to 25. 
// --------------------------------------------------------------------------------------------
using System.IO;
using System.Reflection;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Nth Armstrong Number</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method gets Nth term of Armstrong number and prints it</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         for (; ; ) {
            Console.Write ("Enter Nth term of Armstrong number to be printed: ");
            if (int.TryParse (Console.ReadLine (), out var num)) {
               Console.WriteLine ($"{num}th term of Armstrong number is {NthArmstrong (num)}"); break;
            } else {
               Console.WriteLine ("Invalid input. Please enter a positive integer");
            }
         }
      }
      /// <summary>Cache.txt file placed in location of the Executable file</summary>
      static string path = Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location) + "\\Cache.txt";
      /// <summary>Storing the contents of cache file in a list</summary>
      static List<string> nums = new ();
      /// <summary>Inserts the Armstron numbers the cache file</summary>
      /// <param name="num">Armstrong number</param>
      static void AppendNthArmsToCache (string num) {
         string n = num.ToString ();
         using StreamWriter sw = File.AppendText (path);
         sw.WriteLine (num);
      }
      /// <summary>Displays Nth Armstrong number if it's in cache file else calculates it</summary>
      /// <param name="nth">User input</param>
      /// <returns>Nth Armstrong number</returns>
      static string NthArmstrong (int nth) {
         if (File.Exists (path)) {
            nums = File.ReadAllLines (path).ToList ();
            if (nth < nums.Count) return nums[nth - 1];
            else return $"{CalculateNthArmstrong (nth)}";
         } else { FileStream fs = File.Create (path); return $"{CalculateNthArmstrong (nth)}"; };
      }
      /// <summary>This method calculates and returns Nth Armstrong number</summary>
      /// <param name="nthNum">Nth term</param>
      /// <returns>Nth term of Armstrong number</returns>
      static int CalculateNthArmstrong (int nthNum) {
         int count, num;
         if (nums.Count > 0) {
            count = nums.Count;
            num = int.Parse (nums.Last ()) + 1;
         } else { count = 0; num = 1; }
         nums = new List<string> ();
         while (count <= nthNum) {
            if (Armstrong (num)) {
               count++;
               nums.Add (num.ToString ());
               if (count == nthNum) break;
            }
            num++;
         }
         foreach (string n in nums) AppendNthArmsToCache (n);
         return num;
      }
      /// <summary>Checks the number is Armstrong number or not</summary>
      /// <param name="n">Number to be checked</param>
      /// <returns>True if it is Armstrong number else false</returns>
      static bool Armstrong (int n) {
         double sum = 0, pow = n.ToString ().Length;
         int nCpy = n;
         while (nCpy > 0) {
            int digit = nCpy % 10;
            sum += Math.Pow (digit, pow);
            nCpy /= 10;
         }
         return sum == n;
      }
      #endregion
   }
   #endregion
}