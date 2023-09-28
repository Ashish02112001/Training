// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Write a method, for a given money X along with price P of a chocolate and required wrappers W for a chocolate in exchange,
// return the maximum number of chocolates C you can get along with any unused money X and wrappers W. 
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Chocolate Wrappers</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method gets three integer inputs from user and gives the result </summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         Console.WriteLine ("Enter the money(X) you have to buy chocolates");
         Console.WriteLine ("Enter the price of a chocolate(P)");
         Console.WriteLine ("Enter the required wrappers(W) for a Chocolate in exchange in order");
         for (; ; ) {
            if (int.TryParse (Console.ReadLine (), out int money) && int.TryParse (Console.ReadLine (), out int price) && int.TryParse (Console.ReadLine (), out int wrapExchange)) {
               Console.WriteLine ($"(X = {money}, P = {price}, W = {wrapExchange})");
               var result = ChocoWrappers (money, price, wrapExchange);
               Console.WriteLine ($"(C = {result.maxChoco}, X = {result.remRs}, W = {result.remWrap})");
               Console.WriteLine ("Maximum Chocolates bought(C), Remaining money(X) and wrappers(W)");
               break;
            } else { Console.WriteLine ("Enter the integer values for X, P and W"); }
         }
      }
      /// <summary>calculates the maximum number of chocolates, unused money and wrappers</summary>
      /// <param name="initRs">Initial money</param>
      /// <param name="unitPrice">Price of a chocolate</param>
      /// <param name="wrapPrice">Requird wrapper for a chocolate in exchange</param>
      /// <returns>maximum chocolates, unused money and wrappers remaining</returns>
      static (int maxChoco, int remRs, int remWrap) ChocoWrappers (int initRs, int unitPrice, int wrapPrice) {
         int totalChoco = initRs / unitPrice, wrapCount = totalChoco;
         while (wrapCount >= wrapPrice) {
            wrapCount -= wrapPrice;
            wrapCount++;
            totalChoco++;
         }
         return (totalChoco, initRs % unitPrice, wrapCount);
      }
      #endregion
   }
   #endregion
}