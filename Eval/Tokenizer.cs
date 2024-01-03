﻿namespace Eval;

#region Class tokenizer ---------------------------------------------------------------------------
/// <summary>Splits the expression into individual tokens</summary>
class Tokenizer {
   public Tokenizer (Evaluator eval, string text) {
      mText = text; mN = 0; mEval = eval;
   }
   readonly Evaluator mEval;  // The evaluator that owns this 
   readonly string mText;     // The input text we're parsing through
   int mN;                    // Position within the text

   #region Methods --------------------------------------------------
   /// <summary>Gets the token one by one from the expression</summary>
   /// <returns>Individual token</returns>
   public Token Next (List<Token> tokens) {
      while (mN < mText.Length) {
         char ch = char.ToLower (mText[mN++]);
         switch (ch) {
            case ' ' or '\t': continue;
            case '+' or '-':
               if (ch is '+' or '-' && tokens.Count == 0 || tokens[^1] is TOperator or TPunctuation { Punct: '(' } or TOpUnary) return new TOpUnary (mEval, ch);
               return new TOpArithmetic (mEval, ch);
            case '*' or '/' or '^' or '=':
               return new TOpArithmetic (mEval, ch);
            case (>= '0' and <= '9') or '.': return GetNumber ();
            case '(' or ')':
               mEval.BasePriority += ch == '(' ? 10 : -10;
               return new TPunctuation (ch);
            case >= 'a' and <= 'z': return GetIdentifier ();
            default: return new TError ($"Unknown symbol: {ch}");
         }
      }
      return new TEnd ();
   }

   /// <summary>Gets the variable or function name and returns the particular token</summary>
   /// <returns>Function or Variable token</returns>
   Token GetIdentifier () {
      int start = mN - 1;
      while (mN < mText.Length) {
         char ch = char.ToLower (mText[mN++]);
         if (ch is >= 'a' and <= 'z') continue;
         mN--; break;
      }
      string sub = mText[start..mN];
      if (mFuncs.Contains (sub)) return new TOpFunction (mEval, sub);
      else return new TVariable (mEval, sub);
   }
   readonly string[] mFuncs = { "sin", "cos", "tan", "sqrt", "log", "exp", "asin", "acos", "atan" };

   /// <summary>Gets literal and returns parsed value to literal token</summary>
   /// <returns>New Literal token</returns>
   Token GetNumber () {
      int start = mN - 1;
      while (mN < mText.Length) {
         char ch = mText[mN++];
         if (ch is (>= '0' and <= '9') or '.') continue;
         mN--; break;
      }
      // Now, mN points to the first character of mText that is not part of the number
      string sub = mText[start..mN];
      if (double.TryParse (sub, out double f)) return new TLiteral (f);
      return new TError ($"Invalid number: {sub}");
   }
   #endregion
}
#endregion