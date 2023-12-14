namespace Training;

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
   #region Methods --------------------------------------------------
   public double Evaluate (string input) {
      Reset ();
      var tokenizer = new Tokenizer (this, input.Trim ().ToLower ());
      List<Token> tokens = new ();
      for (; ; ) {
         var token = tokenizer.GetNext ();
         if (token is TEnd) break;
         tokens.Add (token);
      }
      TVariable var = null;
      if (tokens.Count > 1 && tokens[0] is TVariable tv && tokens[1] is TOpBinary bin && bin.op == '=') {
         var = tv;
         tokens.RemoveRange (0, 2);
      }
      foreach (var token in tokens) Process (token);
      while (mOperators.Count > 0) ApplyOperator ();
      if (mBasePriority != 0) Error ("Mismatched Parenthesis");
      if (mOperators.Count > 0) Error ("Too many operators");
      if (mOperands.Count > 1) Error ("Too many operands");
      double f = mOperands.Pop ();
      if (var != null) mVariables[var.Name] = f;
      return Math.Round (f, 10);
   }

   /// <summary>Try and get the value of the variable assigned by the user</summary>
   /// <param name="name">Variable name</param>
   /// <returns>Value of the variable</returns>
   public double GetVariable (string name) {
      if (mVariables.TryGetValue (name, out var fl)) return fl;
      Error ("Unknown variable");
      return 0;
   }

   /// <summary>Throws the given error message</summary>
   /// <param name="s">Error message</param>
   /// <exception cref="EvalException">Prints the error message</exception>
   void Error (string s) => throw new EvalException (s);

   /// <summary>Empties the stack and base priority field</summary>
   void Reset () {
      mOperands.Clear ();
      mOperators.Clear ();
      mBasePriority = 0;
   }

   /// <summary>Processes the tokens and pushes it to the proper stack</summary>
   /// <param name="token">Contains the information of individual token</param>
   /// <exception cref="NotImplementedException">Throws the not implemented exception when token is invalid</exception>
   public void Process (Token token) {
      switch (token) {
         case TNumber num: mOperands.Push (num.Value); break;
         case TOperator op:
            op.FinalPriority = op.Priority + mBasePriority;
            while (!OkToPush (op)) ApplyOperator ();
            mOperators.Push (op);
            break;
         case TPunctuation p:
            if (p.Punct == '(') mBasePriority += 10;
            else mBasePriority -= 10;
            break;
         default: throw new NotImplementedException ();
      }
   }
   int mBasePriority = 0;

   /// <summary>Checks whether the operator can be pushed to stack based on priority</summary>
   /// <param name="op">Operator token</param>
   /// <returns>true if the operator can be pushed to the stack otherwise false</returns>
   public bool OkToPush (TOperator op) {
      if (mOperators.Count == 0) return true;
      TOperator prev = mOperators.Peek ();
      if (op is TOpUnary) return true;
      return prev.FinalPriority < op.FinalPriority;
   }

   /// <summary>Applies the operator from the stack to the operand or operands</summary>
   void ApplyOperator () {
      var op = mOperators.Pop ();
      if (op is TOpBinary bin) {
         if (mOperands.Count < 2) Error ("Too less Operands");
         double f1 = mOperands.Pop (), f2 = mOperands.Pop ();
         mOperands.Push (bin.Apply (f2, f1));
      }
      if (op is TOpFunction func) {
         if (mOperands.Count < 1) Error ("Too less Operands");
         double f = mOperands.Pop ();
         mOperands.Push (func.Apply (f));
      }
      if (op is TOpUnary unary) {
         double f = mOperands.Pop ();
         mOperands.Push (unary.Apply (f));
      }
   }
   #endregion
   #region Private fields -------------------------------------------
   Dictionary<string, double> mVariables = new ();
   Stack<double> mOperands = new ();
   Stack<TOperator> mOperators = new ();
   #endregion
}
#endregion