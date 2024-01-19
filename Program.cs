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
         Wordle game = new ();
         game.Run ();
      }
      #endregion
   }
   #region class Wordle ---------------------------------------------------------------------------
   /// <summary>Wordle Implementation</summary>
   public class Wordle {
      #region Properties --------------------------------------------
      static string? mRandomWord { get; set; }
      static string? mGuessedWord { get; set; }
      static int mRow { get; set; }
      static int mCol { get; set; }
      static bool mIsDictContains { get; set; }
      static int mTurns { get; set; }
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
         for (int boardRow = mRow; boardRow < 6; boardRow++) {
            Console.SetCursorPosition (21, 7 + boardRow);
            for (int boardCol = mCol; boardCol < 5; boardCol++) {
               if (currentKey != default && currentKey.Key is not ConsoleKey.Enter) {
                  if (mGuessedWord?.Length >= 0) {
                     for (int k = 0; k < mGuessedWord.Length; k++) {
                        Console.Write ((mGuessedWord[k] + "  ").ToUpper ());
                     }
                     if (mGuessedWord.Length != 0) boardCol = mGuessedWord.Length - 1;
                  }
                  mRow = boardRow;
                  mCol = boardCol;
                  if (boardCol == 4) {
                     if (currentKey.Key is ConsoleKey.Backspace) Console.Write ("◌  ");
                  }
                  if (boardCol < 4) Console.Write ("◌  ");
                  currentKey = default;
                  boardCol++;
               } else if (currentKey.Key is ConsoleKey.Enter) {
                  for (int k = 0; k < mGuessedWord?.Length; k++) {
                     char chr = mGuessedWord[k];
                     if (mCharColor.TryGetValue (chr, out ConsoleColor color)) {
                        Console.ForegroundColor = (mGuessedWord.Count (x => x == chr) > 1 && num == k) ? ConsoleColor.DarkGray : color;
                        Console.Write ((chr + "  ").ToUpper ());
                        if (mAllColor.ContainsKey (mGuessedWord[k])) mAllColor.Remove (mGuessedWord[k]);
                        mAllColor.Add (chr, color);
                        Console.ResetColor ();
                     }
                  }
                  if (mIsDictContains) {
                     mTurns++;
                     if (mTurns == 6 || mGuessedWord == mRandomWord) GameOver = true;
                     else mGuessedWord = mGuessedWord?.Remove (0);
                     Console.SetCursorPosition (21, 7 + ++boardRow);
                     mRow = boardRow;
                     if (mRow < 6) Console.Write ("◌  ");
                     mCol = 0;
                  } else {
                     Console.SetCursorPosition (17, 20);
                     Console.WriteLine ($"{mGuessedWord} is not a word");
                  }
                  currentKey = default;
               } else if (boardRow == 0 && boardCol == 0) Console.Write ("◌  ");
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
         Random random = new Random ();
         mRandomWord = puzzle[random.Next (0, puzzle.Length)];
      }

      /// <summary>Reads the input key from the user</summary>
      /// <returns>Key pressed by the user</returns>
      ConsoleKeyInfo ReadKey () {
         for (; ; ) {
            var letter = Console.ReadKey (true);
            if (char.IsAsciiLetter (letter.KeyChar) && mCol < 4) return letter;
            if (letter.Key is ConsoleKey.Backspace && mGuessedWord?.Length > 0 && mGuessedWord != null) {
               Console.SetCursorPosition (17, 20);
               Console.WriteLine ("                          ");
               mGuessedWord = mGuessedWord.Remove (mGuessedWord.Length - 1, 1);
               return letter;
            }
            if (mCol == 4 && letter.Key is ConsoleKey.Enter) return letter;
         }
      }

      /// <summary>Prints the final game result</summary>
      static void PrintResult () {
         if (mGuessedWord == mRandomWord) {
            Console.SetCursorPosition (15, 20);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine ($"You found the word in {mTurns} tries");
            Console.ResetColor ();
         } else {
            Console.SetCursorPosition (15, 20);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ($"Sorry - the word was {mRandomWord}");
            Console.ResetColor ();
         }
      }

      /// <summary>Updates the game status based on the key pressed</summary>
      /// <param name="keyPressed">Key pressed by the user</param>
      public static void UpdateGameState (ConsoleKeyInfo keyPressed) {
         ConsoleColor color;
         string[] dictWords = File.ReadAllLines ("Dict.txt");
         if (keyPressed.KeyChar is >= 'a' and <= 'z' || keyPressed.KeyChar is >= 'A' and <= 'Z') mGuessedWord += keyPressed.KeyChar;
         if (mGuessedWord?.Length % 5 == 0 && keyPressed.Key is ConsoleKey.Enter) {
            mGuessedWord = mGuessedWord?.ToUpper ();
            if (dictWords.Contains (mGuessedWord)) {
               mIsDictContains = true;
               for (int pos = 0; pos < mGuessedWord?.Length; pos++) {
                  char ch = mGuessedWord[pos];
                  if (mRandomWord?[pos] == mGuessedWord[pos]) {
                     color = UpdateColorState (State.CORRECT);
                  } else if (mRandomWord!.Contains (ch)) {
                     if (mGuessedWord.Count (x => x == ch) > 1) { num = pos; continue; } else color = UpdateColorState (State.PRESENT);
                  } else color = UpdateColorState (State.ABSENT);
                  if (!mCharColor.ContainsKey (ch)) mCharColor.Add (ch, color);
               }
            } else mIsDictContains = false;
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
      static Dictionary<char, ConsoleColor> mCharColor = new ();
      static Dictionary<char, ConsoleColor> mAllColor = new ();
      static bool GameOver;
      static int num;
      static ConsoleKeyInfo currentKey;
      #endregion
   }
   #endregion
}
#endregion