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
            if (int.TryParse (Console.ReadLine (), out var num) ) {
               Console.WriteLine ($"{num}th term of Armstrong number is {NthArmstrong (num)}"); break;
            } else {
               Console.WriteLine ("Invalid input. Please enter a positive integer");
            }
         }
      }
      static string NthArmstrong (int nth) {
         string path = "W:/Cache.txt";
         if (File.Exists (path)) {
            List<string> nums = File.ReadAllLines (path).ToList();
            if (nth < nums.Count) return nums[nth - 1];
            else { return $"{CalculateNthArmstrong (nth)}"; }
         } else { FileStream fs = File.Create ("C:/Cache.txt"); return $"{CalculateNthArmstrong (nth)}"; };
      }
      static void AppendNthArmsToCache(int num) {
         string path = "W:/Cache.txt";
         string n = num.ToString ();
         List<string> nums = File.ReadAllLines (path).ToList();
         using StreamWriter sw = File.AppendText(path);
         if (!nums.Contains(n))sw.WriteLine (num);
      }
      /// <summary>This method prints the Nth Armstrong number</summary>
      /// <param name="nthNum">Nth term</param>
      /// <returns>Nth term of Armstrong number</returns>
      static int CalculateNthArmstrong (int nthNum) {
         string path = "W:/Cache.txt";
         List<string> nums = File.ReadAllLines (path).ToList ();
         int count, num;
         if (nums.Count > 0) {
            count = nums.Count;
            num = int.Parse(nums.Last());
         }else {count = 0;num = 1; }
         while (count <= nthNum) {
            if (Armstrong (num)) { 
               count++;
               AppendNthArmsToCache (num); 
               if (count == nthNum) { break; } 
            }
            num++;
         }
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