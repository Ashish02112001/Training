// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// A14.1
// Find all the anagrams and sort them based on the anagrams count from the words in the
// word list
// --------------------------------------------------------------------------------------------

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Anagrams</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Lists anagrams of the word in the word list</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         string[] words = File.ReadAllLines ("words.txt");
         Func<string, string> sortedWord = word => new string (word.ToCharArray ().OrderBy (x => x).ToArray ());
         Dictionary<string, List<string>> anagrams = new ();
         foreach (string word in words) {
            string sWord = sortedWord (word);
            if (anagrams.TryGetValue (sWord, out List<string>? anagramWord)) anagramWord.Add (word);
            else anagrams[sWord] = new List<string> { word };
         }
         using (StreamWriter sw = new StreamWriter ("Anagrams.txt")) {
            foreach (var anagram in anagrams.OrderByDescending (x => x.Value.Count)) {
               if (anagram.Value.Count > 1) {
                  string printLine = $"{anagram.Value.Count} {string.Join (",", anagram.Value)}";
                  sw.WriteLine (printLine);
               }
            }
         }
         Console.WriteLine (@"Anagrams are stored in \bin\Debug\net7.0\Anagrams.txt");
      }
   }
   #endregion
}
#endregion
