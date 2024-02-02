// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// A12: Wordle
// --------------------------------------------------------------------------------------------

using System.Text;
namespace Training {
   #region Program --------------------------------------------------------------------------------
   /// <summary>Wordle Game</summary>
   internal class Program {
      #region Methods -----------------------------------------------
      /// <summary>This Method runs the wordle game</summary>
      static void Main () {
         new Wordle ().Run ();
      }
      #endregion
   }
   #endregion
   #region class Wordle ---------------------------------------------------------------------------
   /// <summary>Wordle Implementation</summary>
   public class Wordle {
      #region Properties --------------------------------------------
      static string? RandomWord { get; set; }
      static string? GuessedWord { get; set; }
      static int Row { get; set; }
      static int Col { get; set; }
      static bool IsValidWord { get; set; }
      static int Turns { get; set; }
      #endregion

      #region Methods -----------------------------------------------
      /// <summary>Used to set the cursor position and to clear console screen</summary>
      void ClearScreen () {
         Console.SetWindowSize (Console.WindowWidth / 2, Console.WindowHeight);
         Console.Clear ();
      }

      /// <summary>Displays the game layout and progression</summary>
      public static void DisplayBoard () {
         Console.CursorVisible = false;
         Console.OutputEncoding = Encoding.UTF8;
         for (int r = Row; r < 6; r++) {
            Console.SetCursorPosition (21, 7 + r);
            for (int c = Col; c < 5; c++) {
               if (currentKey != default && currentKey is not ConsoleKey.Enter) {
                  if (GuessedWord?.Length >= 0) {
                     for (int k = 0; k < GuessedWord.Length; k++) {
                        Console.Write (($"{GuessedWord[k]}  ").ToUpper ());
                     }
                     if (GuessedWord.Length != 0) c = GuessedWord.Length - 1;
                  }
                  Row = r;
                  Col = c;
                  if (c == 4 && currentKey is ConsoleKey.Backspace) Console.Write ("◌  ");
                  if (c < 4) Console.Write ("◌  ");
                  currentKey = default;
                  c++;
               } else if (currentKey is ConsoleKey.Enter) {
                  for (int k = 0; k < GuessedWord?.Length; k++) {
                     char chr = GuessedWord[k];
                     if (mCharColor.TryGetValue (chr, out ConsoleColor color)) {
                        Console.ForegroundColor = (GuessedWord.Count (x => x == chr) > 1 && (num - 1) == k) ? ConsoleColor.DarkGray : color;
                        Console.Write ((chr + "  ").ToUpper ());
                        if (mAllColor.ContainsKey (GuessedWord[k])) mAllColor.Remove (GuessedWord[k]);
                        mAllColor.Add (chr, color);
                        Console.ResetColor ();
                     }
                  }
                  if (IsValidWord) {
                     Turns++;
                     if (Turns == 6 || GuessedWord == RandomWord) GameOver = true;
                     else GuessedWord = GuessedWord?.Remove (0);
                     Console.SetCursorPosition (21, 7 + ++r);
                     Row = r;
                     if (Row < 6) Console.Write ("◌  ");
                     Col = 0;
                  } else {
                     Console.SetCursorPosition (17, 20);
                     Console.WriteLine ($"{GuessedWord} is not a word");
                  }
                  currentKey = default;
               } else if (r == 0 && c == 0) Console.Write ("◌  ");
               else Console.Write ("·  ");
            }
         }
         Console.SetCursorPosition (15, 13);
         Console.WriteLine ("_________________________");
         Console.SetCursorPosition (18, 15);
         int winHeight = 15;
         int alpCnt = 0;
         for (char alp = 'A'; alp <= 'Z'; alp++) {
            if (mAllColor.TryGetValue (alp, out ConsoleColor color)) {
               Console.ForegroundColor = color;
               Console.Write (alp + "  ");
               Console.ResetColor ();
            } else Console.Write (alp + "  ");
            alpCnt++;
            if (alpCnt % 7 == 0) Console.SetCursorPosition (18, ++winHeight);
         }
         mCharColor.Clear ();
      }

      /// <summary>This method contains the method sequence of the game flow</summary>
      public void Run () {
         ClearScreen ();
         SelectWord ();
         DisplayBoard ();
         while (!GameOver) {
            currentKey = ReadKey ();
            UpdateGameState (currentKey);
            DisplayBoard ();
         }
         PrintResult ();
      }

      /// <summary>Selects a random 5 letter word from the Puzzle.txt</summary>
      void SelectWord () {
         string[] puzzle = File.ReadAllLines ("Puzzle.txt");
         Random random = new ();
         RandomWord = puzzle[random.Next (0, puzzle.Length)];
      }

      /// <summary>Reads the input key from the user</summary>
      /// <returns>Key pressed by the user</returns>
      ConsoleKey ReadKey () {
         for (; ; ) {
            var letter = Console.ReadKey (true);
            if (char.IsAsciiLetter (letter.KeyChar) && Col < 4) return letter.Key;
            if (letter.Key is ConsoleKey.Backspace && GuessedWord?.Length > 0 && GuessedWord != null) {
               Console.SetCursorPosition (17, 20);
               Console.WriteLine ("                          ");
               GuessedWord = GuessedWord.Remove (GuessedWord.Length - 1, 1);
               return letter.Key;
            }
            if (Col == 4 && letter.Key is ConsoleKey.Enter) return letter.Key;
         }
      }

      /// <summary>Prints the final game result</summary>
      static void PrintResult () {
         if (GuessedWord == RandomWord) {
            Console.SetCursorPosition (15, 20);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine ($"You found the word in {Turns} tries");
            Console.ResetColor ();
         } else {
            Console.SetCursorPosition (15, 20);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ($"Sorry - the word was {RandomWord}");
            Console.ResetColor ();
         }
      }

      /// <summary>Updates the game status based on the key pressed</summary>
      /// <param name="keyPressed">Key pressed by the user</param>
      public static void UpdateGameState (ConsoleKey keyPressed) {
         ConsoleColor color;
         char currentKey = char.ToUpper ((char)keyPressed);
         if (currentKey is >= 'A' and <= 'Z') GuessedWord += currentKey;
         if (GuessedWord?.Length % 5 == 0 && keyPressed is ConsoleKey.Enter) {
            GuessedWord = GuessedWord?.ToUpper ();
            if (dictWords.Contains (GuessedWord)) {
               IsValidWord = true;
               for (int pos = 0; pos < GuessedWord?.Length; pos++) {
                  char ch = GuessedWord[pos];
                  if (RandomWord?[pos] == GuessedWord[pos]) {
                     color = UpdateColorState (State.CORRECT);
                  } else if (RandomWord!.Contains (ch)) {
                     if (GuessedWord.Count (x => x == ch) > 1 && num == 0) { num = pos + 1; continue; } else color = UpdateColorState (State.PRESENT);
                  } else color = UpdateColorState (State.ABSENT);
                  if (!mCharColor.ContainsKey (ch)) mCharColor.Add (ch, color);
               }
            } else IsValidWord = false;
         }
      }

      /// <summary>Sets the console color based on the current state</summary>
      /// <param name="updateColor">State of the character</param>
      /// <returns>Console color for the given state</returns>
      static ConsoleColor UpdateColorState (State updateColor) => updateColor switch {
         State.PRESENT => ConsoleColor.Blue,
         State.ABSENT => ConsoleColor.DarkGray,
         State.CORRECT => ConsoleColor.Green,
         _ => Console.ForegroundColor
      };

      public enum State { PRESENT, ABSENT, CORRECT }
      #endregion
      #region fields ------------------------------------------------
      static readonly string[] dictWords = File.ReadAllLines ("Dict.txt");
      static Dictionary<char, ConsoleColor> mCharColor = new (), mAllColor = new ();
      static bool GameOver;
      static int num;
      static ConsoleKey currentKey;
      #endregion
   }
   #endregion
}