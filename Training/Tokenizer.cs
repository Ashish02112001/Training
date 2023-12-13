namespace Training;
class Tokenizer {
   public Tokenizer (Evaluator eval, string input) {
      mText = input;
      mEval = eval;
      mN = 0;
   }
   readonly string mText;
   readonly Evaluator mEval;
   int mN;
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
   readonly string[] mFuncs = { "sin", "cos", "tan", "sqrt", "log", "exp", "asin", "acos", "atan" };
}