namespace Eval;
#region Class evaluator and exception -------------------------------------------------------------
/// <summary>Throws Exception with the given message</summary>
class EvalException : Exception {
   public EvalException (string message) : base (message) { }
}
/// <summary>This class contains methods to Evaluate the given expression</summary>
public class Evaluator {
   /// <summary>Evaluates the individual tokens and returns the result</summary>
   /// <param name="input">Given input string</param>
   /// <returns>Result of the expression</returns>
   public double Evaluate (string text) {
      List<Token> tokens = new ();
      mOperators.Clear ();
      mOperands.Clear ();
      var tokenizer = new Tokenizer (this, text);
      for (; ; ) {
         var token = tokenizer.Next ();
         if (token is TEnd) break;
         if (token is TError err) throw new EvalException (err.Message);
         tokens.Add (token);
      }
      // Check if this is a variable assignment
      TVariable? tVariable = null;
      if (tokens.Count > 2 && tokens[0] is TVariable tvar && tokens[1] is TOpArithmetic { Op: '=' }) {
         tVariable = tvar;
         tokens.RemoveRange (0, 2);
      }
      foreach (var t in tokens) Process (t);
      while (mOperators.Count > 0) ApplyOperator ();
      double f = mOperands.Pop ();
      if (tVariable != null) mVars[tVariable.Name] = f;
      return f;
   }

   /// <summary>Priority given for the operators inside brackets</summary>
   public int BasePriority { get; set; }

   /// <summary>Try and get the value of the variable assigned by the user</summary>
   /// <param name="name">Variable name</param>
   /// <returns>Value of the variable</returns>
   public double GetVariable (string name) {
      if (mVars.TryGetValue (name, out double f)) return f;
      throw new EvalException ($"Unknown variable: {name}");
   }
   readonly Dictionary<string, double> mVars = new ();

   /// <summary>Processes the tokens and pushes it to the proper stack</summary>
   /// <param name="token">Contains the information of individual token</param>
   /// <exception cref="NotImplementedException">Throws the not implemented exception when token is invalid</exception>
   void Process (Token token) {
      switch (token) {
         case TNumber num:
            mOperands.Push (num.Value);
            break;
         case TOperator op:
            while (mOperands.Count > 0 && mOperators.Count > 0 && mOperators.Peek ().Priority >= op.Priority)
               ApplyOperator ();
            mOperators.Push (op);
            break;
         case TPunctuation:
            break;
         default:
            throw new EvalException ($"Unknown token: {token}");
      }
   }
   readonly Stack<double> mOperands = new ();
   readonly Stack<TOperator> mOperators = new ();

   /// <summary>Applies the operator from the stack to the operand or operands</summary>
   void ApplyOperator () {
      var op = mOperators.Pop ();
      var f1 = mOperands.Pop ();
      switch (op) {
         case TOpFunction func:
            mOperands.Push (func.Evaluate (f1)); break;
         case TOpArithmetic arith:
            var f2 = mOperands.Pop ();
            mOperands.Push (arith.Evaluate (f2, f1));
            break;
         case TOpUnary unary:
            mOperands.Push (unary.Evaluate (f1)); break;
      }
   }
}
#endregion