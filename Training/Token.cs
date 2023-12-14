namespace Training;
#region Class token -------------------------------------------------------------------------------
public class Token { }
class TNumber : Token {
   public virtual double Value { get; }
}
class TLiteral : TNumber {
   public TLiteral (double num) => mLit = num;
   public override double Value => mLit;
   public override string ToString () => $"Literal: {Literal}";
   public double Literal => mLit;
   readonly double mLit;
}
class TVariable : TNumber {
   public TVariable (Evaluator eval, string name) {
      mVar = name;
      mEval = eval;
   }
   public override double Value => mEval.GetVariable (Name);
   public override string ToString () => $"Var: {Name}";
   public string Name => mVar;
   readonly string mVar;
   readonly Evaluator mEval;
}
public class TOperator : Token {
   public virtual int Priority { get; }
   public int FinalPriority { get; set; }
}
class TOpBinary : TOperator {
   public TOpBinary (char binop) => mBin = binop;
   public override string ToString () => $"Binary: {op}";
   public override int Priority
      => op switch {
         '+' or '-' => 1,
         '*' or '/' => 2,
         '^' => 3,
         '=' => 4,
         _ => throw new NotImplementedException (),
      };
   public double Apply (double a, double b)
      => op switch {
         '+' => a + b,
         '-' => a - b,
         '*' => a * b,
         '/' => a / b,
         '^' => Math.Pow (a, b),
         _ => throw new NotImplementedException ()
      };
   public char op => mBin;
   readonly char mBin;
}
class TOpFunction : TOperator {
   public TOpFunction (string func) => mFunc = func;
   public override string ToString () => $"function: {Func}";
   public override int Priority => 5;
   public double Apply (double f) {
      return Func switch {
         "sin" => Math.Sin (D2R (f)),
         "cos" => Math.Cos (D2R (f)),
         "tan" => Math.Tan (D2R (f)),
         "log" => Math.Log (f),
         "exp" => Math.Exp (f),
         "sqrt" => Math.Sqrt (f),
         "asin" => R2D (Math.Asin (f)),
         "acos" => R2D (Math.Acos (f)),
         "atan" => R2D (Math.Atan (f)),
         _ => throw new NotImplementedException ()
      };
      double D2R (double f) => f * (Math.PI / 180);
      double R2D (double f) => f * (180 / Math.PI);
   }
   public string Func => mFunc;
   readonly string mFunc;
}
class TOpUnary : TOperator {
   public TOpUnary (char Un) => mUnary = Un;
   public override string ToString () => $"Unary: {Unary}";
   public override int Priority => Unary is '-' or '+' ? 1 : 0;
   public double Apply (double n) {
      return Unary == '+' ? n : -n;
   }
   public char Unary => mUnary;
   readonly char mUnary;
}
class TEnd : Token {
   public override string ToString () => $"End";
}
class TError : Token {
   public TError (string msg) => mMessage = msg;
   public override string ToString () => $"Error {Message}";
   public string Message => mMessage;
   readonly string mMessage;
}
class TPunctuation : Token {
   public TPunctuation (char punctu) => mPunct = punctu;
   public override string ToString () => $"Punctuation: {Punct}";
   public char Punct => mPunct;
   readonly char mPunct;
}
#endregion