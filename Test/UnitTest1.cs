using static Training.Program;
namespace Test {
   [TestClass]
   public class UnitTest1 {
      [TestMethod]
      public void TestFileNameParser () {
         var falseTests = new string[]{
            @"Cz:\abc\def\r.txt", @"C:\Readme.txt", @"C:\abc\.bcf",
            @"C:\abc\bcf.", @"Readme.txt", @"C:\abc\def", @"C:\abc d", @"\abcd\Readme.txt", " ",
            @"C:\ab.c\def\r.txt", @"C:\abc:d", @".\abc", ".abc", "abc", @"C:\abc6\def\r.txt",
            @"C:\abc\def\r.txt.txt",@"C:\PROGRAM\DATA\MSOFFICE",@"C:\PROGRAM\DATA",@"C:\PROGRAM",@"\PROGRAM\DATA\MSOFFICE\EXCEL",
            @"C\PROGRAM\DATA\MSOFFICE\EXCEL",@"PROGRAM",@"C:PROGRAM\DATA\MSOFFICE\EXCEL",
         };
         foreach (var fName in falseTests) Assert.AreEqual (("", "", "", ""), FileNameParse (fName));
         Assert.AreEqual (("C", @"PROGRAM\DATA\MSOFFICE", "EXCEL", "EXE"), FileNameParse (@"C:\PROGRAM\DATA\MSOFFICE\EXCEL.EXE"));
         Assert.AreEqual (("D", @"PROGRAM\DATA", "EXCEL", "TXT"), FileNameParse (@"D:\PROGRAM\DATA\EXCEL.TXT"));
         Assert.AreEqual (("C", @"PROGRAM", "EXCEL", "EXE"), FileNameParse (@"C:\PROGRAM\EXCEL.EXE"));
         Assert.AreEqual (("C", @"ABC\DEF", "R", "TXT"), FileNameParse (@"C:\abc\def\r.txt"));
         Assert.AreEqual (("C", @"WORK", "R", "TXT"), FileNameParse (@"C:\work\r.txt"));
      }
   }
}