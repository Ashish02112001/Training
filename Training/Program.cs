﻿// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// Program.cs
// A10.1:
// Implement file name parser with state machine
// --------------------------------------------------------------------------------------------
using static Training.Program.State;
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>File Name Parser</summary>
   public class Program {
      #region Methods ---------------------------------------------
      /// <summary>Gets a string as input and gives drive, folder path, file name and extension of the file</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.WriteLine (@"The file path must 
         1. Only contain alphabets and folder names separated by '\'
         2. End with filename.extension");
         Console.WriteLine ("Enter a file path:");
         string s = Console.ReadLine ()!;
         (string dLetter, string folPath, string filName, string ext) = FileNameParse (s);
         if (string.IsNullOrEmpty (dLetter)) { Console.WriteLine ("Enter a valid file path name"); return; }
         Console.WriteLine ($"Drive letter: {dLetter}");
         Console.WriteLine ($"Folder Path: {folPath}");
         Console.WriteLine ($"File name: {filName}");
         Console.WriteLine ($"Extension: {ext}");
      }

      /// <summary>When given a string it parses it into parts and returns the components of file path</summary>
      /// <param name="fName">Given string</param>
      /// <returns>Tuple consisting of the drive, folder path, file name and extension of the file</returns>
      /// See file://FileNameParser.png
      public static (string driveLetter, string folderPath, string fileName, string extension) FileNameParse (string fName) {
         State s = A;
         Action none = () => { }, todo;
         string folder = "", drive = "", file = "", ext = "";
         foreach (var ch in fName.Trim ().ToUpper () + '~') {
            (s, todo) = (s, ch) switch {
               (A, >= 'A' and <= 'Z') => (B, () => drive = ch.ToString ()),
               (B, ':') => (C, none),
               (C, '\\') => (D, none),
               (D or E, >= 'A' and <= 'Z') => (E, () => folder += ch),
               (E, '\\') => (F, none),
               (F or G, >= 'A' and <= 'Z') => (G, () => file += ch),
               (G, '\\') => (F, () => { folder += '\\' + file; file = string.Empty; }),
               (G, '.') => (H, none),
               (H or I, >= 'A' and <= 'Z') => (I, () => ext += ch),
               (I, '~') => (J, none),
               _ => (Z, none),
            };
            todo ();
         }
         return (s == J) ? (drive, folder, file, ext) : ("", "", "", "");
      }
      #endregion
      public enum State { A, B, C, D, E, F, G, H, I, J, Z };
   }
   #endregion
}