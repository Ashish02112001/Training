// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// Program.cs
// A10.1:
// Implement file name parser with state machine
// --------------------------------------------------------------------------------------------
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
         State s = State.A;
         Action none = () => { };
         Action todo;
         string folder = "", dLetter = "", flName = "", ext = ".";
         foreach (var ch in fName.Trim ().ToUpper() + '~') {
            (s, todo) = (s, ch) switch {
               (State.A, >= 'A' and <= 'Z') => (State.B, () => dLetter = ch.ToString ()),
               (State.B, ':') => (State.C, none),
               (State.C or State.E, '\\') => (State.D, () => folder += ch),
               (State.D or State.E, >= 'A' and <= 'Z') => (State.E, () => folder += ch),
               (State.E, '.') => (State.F, () => flName += folder[(folder.LastIndexOf ('\\') + 1)..]),
               (State.F or State.G, >= 'A' and <= 'Z') => (State.G, () => ext += ch),
               (State.G, '~') => (State.H, none),
               _ => (State.Z, none),
            };
            todo ();
         }
         if (s == State.H && folder.Count (sep => sep == '\\') > 1) {
            folder = folder[1..].Remove (folder.LastIndexOf ('\\') - 1);
            return (dLetter, folder, flName + ext, ext);
         }
         return ("", "", "", "");
      }
      #endregion
      public enum State { A, B, C, D, E, F, G, H, Z };
   }
   #endregion
}