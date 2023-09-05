// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Password considered to be strong if it satisfies the following criteria: 
// Its length is at least 6. 
// It contains at least one digit. 
// It contains at least one lowercase English character. 
// It contains at least one uppercase English character. 
// It contains at least one special character. The special characters are: !,@,#,$,%,^,&,*,(,),-,+ 
// Input: Password string, Output: Returns whether the password is strong or not with reasons. 
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Password checker</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method gets password as input and checks it is strong or not</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.Write ("Enter a password: ");
         string pWord = Console.ReadLine ();
         PWordCheck(pWord);
      }
      #endregion
      /// <summary>This method returns wheather the password is strong or not with reason</summary>
      /// <param name="pw">Password input from user</param>
      static void PWordCheck (string pw) {
         char[] specialChar = {'!','@','#','$','%','^','&','*','(',')','-','+'};
         bool valid = true;
         if (pw.Length < 6) { Console.WriteLine ("Password must contain atleast 6 characters"); valid = false; }
         if (!pw.Any (char.IsDigit)) { Console.WriteLine ("Password must contain at least one digit"); valid = false; }
         if (!pw.Any (char.IsLower)) {Console.WriteLine ("Password must contain at least one lowercase English character"); valid = false; }
         if (!pw.Any (char.IsUpper)) { Console.WriteLine ("Password must contain at least one uppercase English character."); valid = false; }
         if (!specialChar.Any (x => pw.Contains (x))) { Console.WriteLine ("Password must contain at least one special character"); valid = false; }
         if (valid) Console.WriteLine ("Your Password is strong enough");
      }
   }
   #endregion
}