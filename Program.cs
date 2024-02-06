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
      static string? Guess { get; set; }
      static int Row { get; set; }
      static int Col { get; set; }
      static bool IsValidWord { get; set; }
      static int Turns { get; set; }
      #endregion

      #region Methods -----------------------------------------------
      /// <summary>Used to set the cursor position and to clear console screen</summary>
      void ClearScreen () => Console.Clear ();

      /// <summary>Displays the game layout and progression</summary>
      public static void DisplayBoard () {
         Console.CursorVisible = false;
         Console.OutputEncoding = Encoding.UTF8;

         for (int r = Row; r < 6; r++) {
            Console.SetCursorPosition (mX, mY + r);
            for (int c = Col; c < 5; c++) {
               if (sCurrentKey != default && sCurrentKey is not ConsoleKey.Enter) {
                  if (Guess?.Length >= 0) {
                     for (int k = 0; k < Guess.Length; k++) {
                        Console.Write (($"{Guess[k]}  ").ToUpper ());
                     }
                     if (Guess.Length != 0) c = Guess.Length - 1;
                  }
                  Row = r;
                  Col = c;
                  if (c == 4 && sCurrentKey is ConsoleKey.Backspace) Console.Write ("◌  ");
                  if (c < 4) Console.Write ("◌  ");
                  sCurrentKey = default;
                  c++;
               } else if (sCurrentKey is ConsoleKey.Enter) {
                  for (int k = 0; k < Guess?.Length; k++) {
                     char chr = Guess[k];
                     if (sCharColor.TryGetValue (chr, out ConsoleColor color)) {
                        Console.ForegroundColor = (Guess.Count (x => x == chr) > 1 && (sNum - 1) == k) ? ConsoleColor.DarkGray : color;
                        Console.Write ((chr + "  ").ToUpper ());
                        if (sAllColor.TryGetValue (Guess[k], out ConsoleColor _)) sAllColor.Remove (Guess[k]);
                        sAllColor.Add (chr, color);
                        Console.ResetColor ();
                     }
                  }
                  if (IsValidWord) {
                     Turns++;
                     if (Turns == 6 || Guess == RandomWord) sGameOver = true;
                     else Guess = Guess?.Remove (0);
                     Console.SetCursorPosition (mX, mY + ++r);
                     Row = r;
                     if (Row < 6) Console.Write ("◌  ");
                     Col = 0;
                  } else {
                     Console.SetCursorPosition (mX - 4, sResultRow);
                     Console.WriteLine ($"{Guess} is not a word");
                  }
                  sCurrentKey = default;
               } else if (r == 0 && c == 0) Console.Write ("◌  ");
               else Console.Write ("·  ");
            }
         }

         Console.SetCursorPosition (mX - 6, mY + sHeight);
         Console.WriteLine (new string ('_',25));
         Console.SetCursorPosition (mX - 3, mY + sHeight + 2);
         int winHeight = mY + sHeight + 2;
         int alpCnt = 0;
         for (char alp = 'A'; alp <= 'Z'; alp++) {
            if (sAllColor.TryGetValue (alp, out ConsoleColor color)) {
               Console.ForegroundColor = color;
               Console.Write (alp + "  ");
               Console.ResetColor ();
            } else Console.Write (alp + "  ");
            alpCnt++;
            if (alpCnt % 7 == 0) Console.SetCursorPosition (mX - 3, ++winHeight);
         }
         sResultRow = winHeight + 2;
         sCharColor.Clear ();
      }

      /// <summary>This method contains the method sequence of the game flow</summary>
      public void Run () {
         ClearScreen ();
         SelectWord ();
         DisplayBoard ();
         while (!sGameOver) {
            sCurrentKey = ReadKey ();
            UpdateGameState (sCurrentKey);
            DisplayBoard ();
         }
         PrintResult ();
      }

      /// <summary>Selects a random 5 letter word from the Puzzle.txt</summary>
      string SelectWord () => RandomWord = sPuzzle[new Random ().Next (sPuzzle.Length)];

      /// <summary>Reads the input key from the user</summary>
      /// <returns>Key pressed by the user</returns>
      ConsoleKey ReadKey () {
         for (; ; ) {
            var letter = Console.ReadKey (true);
            if (char.IsAsciiLetter (letter.KeyChar) && Col < 4) return letter.Key;
            if (letter.Key is ConsoleKey.Backspace && Guess?.Length > 0) {
               Console.SetCursorPosition (mX - 4, sResultRow);
               Console.WriteLine ("                          ");
               Guess = Guess.Remove (Guess.Length - 1, 1);
               return letter.Key;
            }
            if (Col == 4 && letter.Key is ConsoleKey.Enter) return letter.Key;
         }
      }

      /// <summary>Prints the final game result</summary>
      static void PrintResult () {
         Console.SetCursorPosition (mX - 6, sResultRow);
         Console.ForegroundColor = Guess == RandomWord ? ConsoleColor.Green : ConsoleColor.Yellow;
         Console.WriteLine (Guess == RandomWord ? $"You found the word in {Turns} tries" : $"Sorry - the word was {RandomWord}");
         Console.ResetColor ();
      }

      /// <summary>Updates the game status based on the key pressed</summary>
      /// <param name="keyPressed">Key pressed by the user</param>
      public static void UpdateGameState (ConsoleKey keyPressed) {
         ConsoleColor color;
         char currentKey = char.ToUpper ((char)keyPressed);
         if (currentKey is >= 'A' and <= 'Z') Guess += currentKey;
         if (Guess?.Length % 5 == 0 && keyPressed is ConsoleKey.Enter) {
            Guess = Guess?.ToUpper ();
            if (sDictWords.Contains (Guess)) {
               IsValidWord = true;
               for (int pos = 0; pos < Guess?.Length; pos++) {
                  char ch = Guess[pos];
                  if (RandomWord?[pos] == Guess[pos]) color = UpdateColorState (State.Correct);
                  else if (RandomWord!.Contains (ch)) {
                     if (Guess.Count (x => x == ch) > 1 && sNum == 0) { sNum = pos + 1; continue; } else color = UpdateColorState (State.Present);
                  } else color = UpdateColorState (State.Absent);
                  if (!sCharColor.ContainsKey (ch)) sCharColor.Add (ch, color);
               }
            } else IsValidWord = false;
         }
      }

      /// <summary>Sets the console color based on the current state</summary>
      /// <param name="updateColor">State of the character</param>
      /// <returns>Console color for the given state</returns>
      static ConsoleColor UpdateColorState (State updateColor) => updateColor switch {
         State.Present => ConsoleColor.Blue,
         State.Absent => ConsoleColor.DarkGray,
         State.Correct => ConsoleColor.Green,
         _ => Console.ForegroundColor
      };

      public enum State { Present, Absent, Correct }
      #endregion

      #region fields ------------------------------------------------
      static string[] sPuzzle = File.ReadAllLines ("Puzzle.txt");
      static readonly string[] sDictWords = File.ReadAllLines ("Dict.txt");
      static Dictionary<char, ConsoleColor> sCharColor = new (), sAllColor = new ();
      static int sHeight = 6, sWidth = 7, mX = (Console.WindowWidth / 2) - sWidth, mY = (Console.WindowHeight / 2) - sHeight, sNum, sResultRow;
      static bool sGameOver;
      static ConsoleKey sCurrentKey;
      #endregion
   }
   #endregion
}