namespace Training;

#region Class tokenizer ---------------------------------------------------------------------------
/// <summary>Splits the expression into individual tokens</summary>
class Tokenizer {
   public Tokenizer (Evaluator eval, string input) {
      mText = input;
      mEval = eval;
      mN = 0;
   }

   #region Methods --------------------------------------------------
   /// <summary>Gets the token one by one from the expression</summary>
   /// <returns>Individual token</returns>
   public Token GetNext () {
      while (mN < mText.Length) {
         char ch = mText[mN++];
         if (ch == ' ') continue;
         if (ch is '+' or '-' or '*' or '/' or '^' or '=') {
            if (ch is '-' or '+' && (mN - 1 == 0 || mText[mN - 2] is '+' or '-' or '*' or '/' or '^' or '(')) return new TOpUnary (ch);
            if (mN > 4 && mFuncs.Contains (mText[(mN - 5)..(mN - 2)])) return new TOpUnary (ch);
            return new TOpBinary (ch);
         }
         if (ch is >= '0' and <= '9') return GetLiteral ();
         if (ch is >= 'a' and <= 'z') return GetIdentifier ();
         if (ch is '(' or ')') return new TPunctuation (ch);
         return new TError ($"Unexpected Character {ch}");
      }
      return new TEnd ();
   }

   /// <summary>Gets literal and returns parsed value to literal token</summary>
   /// <returns>New Literal token</returns>
   Token GetLiteral () {
      int start = mN - 1;
      while (mN < mText.Length) {
         char ch = mText[mN++];
         if (ch is (>= '0' and <= '9') or '.') continue;
         mN--; break;
      }
      string num = mText.Substring (start, mN - start);
      return new TLiteral (double.Parse (num));
   }

   /// <summary>Gets the variable or function name and returns the particular token</summary>
   /// <returns>Function or Variable token</returns>
   Token GetIdentifier () {
      int start = mN - 1;
      while (mN < mText.Length) {
         char ch = mText[mN++];
         if (ch is (>= '0' and <= '9') or (>= 'a' and <= 'z')) continue;
         mN--; break;
      }
      string identifier = mText[start..mN];
      return mFuncs.Contains (identifier) ? new TOpFunction (identifier) : new TVariable (mEval, identifier);
   }
   #endregion
   #region Private fields -------------------------------------------
   readonly string[] mFuncs = { "sin", "cos", "tan", "sqrt", "log", "exp", "asin", "acos", "atan" };
   readonly string mText;
   readonly Evaluator mEval;
   int mN;
   #endregion
}
#endregion