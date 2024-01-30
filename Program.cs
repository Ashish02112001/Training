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
         string[] words = File.ReadAllLines ("Dict.txt");
         Func<string, string> sortedWord = word => new string (word.ToCharArray ().OrderBy (x => x).ToArray ());
         Dictionary<string, List<string>> anagrams = new ();
         List<string> anagramChecked = new ();
         foreach (string word in words) {
            //if (anagramChecked.Contains ()) { }
            List<string> list = words.Where (x => x != word && sortedWord (x) == sortedWord (word)).ToList ();
            anagramChecked.Add (word);
            if (list.Count > 0) anagrams.Add (word, list);
         }
         foreach (var anagram in anagrams.OrderByDescending (x => x.Value.Count)) {
            Console.WriteLine ($"{anagram.Value.Count + 1} {anagram.Key} : {string.Join (",", anagram.Value)}");
         }
      }
   }
   #endregion
}
#endregion
