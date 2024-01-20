// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// Program.cs
// Simple Program to Print the text 'Hello, World!' in Console
// --------------------------------------------------------------------------------------------

using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Xml.Serialization;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sample program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         //Wordle.DisplayBoard ();
         //Console.ReadLine ();
         Wordle game = new Wordle ();
         game.Run ();
         //Console.WindowWidth = 5;
         //Console.WindowHeight = 3;
      }
      #endregion
   }
   public class Wordle {
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
      void SelectWord () {
         string[] puzzle = File.ReadAllLines ("Puzzle.txt");
         Random random = new Random ();
         randomWord = puzzle[random.Next (0, puzzle.Length)];
      }
      static string? randomWord { get; set; }
      ConsoleKeyInfo ReadKey () {
         for (; ; ) {
            var letter = Console.ReadKey (true);
            if (char.IsAsciiLetter (letter.KeyChar) && col < 4) return letter;
            if (letter.Key is ConsoleKey.Backspace && guessedWord?.Length > 0 && guessedWord != null) {
              guessedWord = guessedWord.Remove (guessedWord.Length - 1, 1);
               return letter;
            }
            if (col == 4 && letter.Key is ConsoleKey.Enter) return letter;
         }
      }
      public static void UpdateGameState (ConsoleKeyInfo keyPressed) {
         ConsoleColor color;
         string[] dictWords = File.ReadAllLines ("Dict.txt");
         if (keyPressed.KeyChar is >= 'a' and <= 'z') guessedWord += keyPressed.KeyChar;
         if (guessedWord?.Length % 5 == 0 && keyPressed.Key is ConsoleKey.Enter) {
            guessedWord = guessedWord?.ToUpper ();
            if (dictWords.Contains (guessedWord)) {
               foreach (char ch in guessedWord!) {
                  if (randomWord?.IndexOf (ch) == guessedWord.IndexOf (ch)) color = UpdateColorState (State.CORRECT);
                  else if (randomWord!.Contains (ch)) color = UpdateColorState (State.PRESENT);
                  else color = UpdateColorState (State.ABSENT);
                  if (!mCharColor.ContainsKey (ch)) mCharColor.Add (ch, color);
               }
            }
         }
      }
      static string? guessedWord { get; set; }
      static ConsoleColor UpdateColorState (State updateColor) => updateColor switch {
         State.PRESENT => ConsoleColor.Blue,
         State.ABSENT => ConsoleColor.DarkGray,
         State.CORRECT => ConsoleColor.Green,
         _ => Console.ForegroundColor
      };
      public enum State { PRESENT, ABSENT, CORRECT }
      public static void DisplayBoard () {
         Console.OutputEncoding = Encoding.UTF8;
         for (int boardRow = row; boardRow < 6; boardRow++) {
            Console.SetCursorPosition (47, 7 + boardRow);
            for (int boardCol = col; boardCol < 5; boardCol++) {
               if (currentKey != default && currentKey.Key is not ConsoleKey.Enter) {
                  printAlp = false;
                  if (guessedWord?.Length >= 0) {
                     for (int k = 0; k < guessedWord.Length; k++) {
                        Console.Write ((guessedWord[k] + " ").ToUpper ());
                     }
                     if (guessedWord.Length != 0) boardCol = guessedWord.Length-1 ;
                  }
                  row = boardRow;
                  col = boardCol;
                  if (boardCol == 4) {
                     if (currentKey.Key is ConsoleKey.Backspace) Console.Write ("◌ ");
                  }
                  if (boardCol < 4 ) Console.Write ("◌ ");
                  currentKey = default;
                  boardCol++;
               }
               else if (currentKey.Key is ConsoleKey.Enter) {
                  for (int k = 0; k < guessedWord?.Length; k++) {
                     if (mCharColor.TryGetValue (guessedWord[k], out ConsoleColor color)) {
                        Console.ForegroundColor = color;
                        Console.Write ((guessedWord[k] + " ").ToUpper ());
                        Console.ResetColor ();
                     }
                  }
                  printAlp = true;
                  guessedWord = guessedWord?.Remove(0);
                  turns++;
                  Console.SetCursorPosition (47, 7 + ++boardRow);
                  row = boardRow;
                  Console.Write ("◌ ");
                  col = 0;
                  currentKey = default;
                  break;
               } else if (boardRow == 0 && boardCol == 0 || currentKey.Key is ConsoleKey.Enter) Console.Write ("◌ ");
               else Console.Write ("· ");
            }
         }
         Console.SetCursorPosition (42, 15);
         int winHeight = 15;
         int alpCnt = 0;
         if (guessedWord?.Length is null or 0 || printAlp is true) {
            for (char alp = 'A'; alp <= 'Z'; alp++) {
               if (mCharColor.TryGetValue (alp, out ConsoleColor color)) {
                  Console.ForegroundColor = color;
                  Console.Write (alp + "  ");
                  Console.ResetColor ();
               } else Console.Write (alp + "  ");
               alpCnt++;
               if (alpCnt % 7 == 0) Console.SetCursorPosition (42, ++winHeight);
            }
            mCharColor.Clear ();
         }
      }
      static void PrintResult () {
         if (guessedWord == randomWord) {
            Console.WriteLine ("You won");
            turns = 6;
         }
      }
      static int row { get; set; }
      static int col { get; set; }
      static Dictionary<char, ConsoleColor> mCharColor = new ();
      static bool printAlp { get; set; }


      void ClearScreen () => Console.Clear ();
      bool GameOver => turns == 6;
      static int turns { get; set; }
      static ConsoleKeyInfo currentKey;


   }

}
#endregion