// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// Program.cs
// Queue<T> 
// Implement a Queue<T> using arrays as the underlying data structure.
// The queue should grow the array when needed. If the array does not have to be grown,
// both Enqueue and Dequeue should be constant time (O(1)) operations. Throw exceptions as needed.
// --------------------------------------------------------------------------------------------

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Custom Queue<T> Program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Checks for the custom Queue<T>></summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         TQueue<int> squareNos = new ();
         squareNos.Enqueue (1);
         squareNos.Enqueue (4);
         squareNos.Enqueue (9);
         squareNos.Enqueue (16);
         squareNos.Enqueue (25);
         Console.WriteLine ("Things added to the queue: \n\n1 \n4 \n9\n16\n25 \n36 \n49\n64\n");
         Console.WriteLine ($"Checking the Queue Isempty? : {squareNos.IsEmpty}");
         Console.WriteLine ("peeking first element in the queue..\n");
         Console.WriteLine (squareNos.Peek ());
         Console.WriteLine ("\nDequeuing the elements from the queue..\n");
         Console.WriteLine (squareNos.Dequeue ());
         Console.WriteLine (squareNos.Dequeue ());
         squareNos.Enqueue (36);
         Console.WriteLine (squareNos.Dequeue ());
         Console.WriteLine (squareNos.Dequeue ());
         squareNos.Enqueue (49);
         squareNos.Enqueue (64);
         Console.WriteLine (squareNos.Dequeue ());
         Console.WriteLine (squareNos.Dequeue ());
         Console.WriteLine (squareNos.Dequeue ());
         Console.WriteLine (squareNos.Dequeue ());
         Console.WriteLine ($"\nChecking the Queue Isempty? : {squareNos.IsEmpty}");
      }
      #endregion
   }
   #endregion

   #region ClassTQueue <T> -------------------------------------------------------------------------
   /// <summary>Class Queue<T></summary>
   /// <typeparam name="T">Type of the Queue</typeparam>
   public class TQueue<T> {
      #region Property ----------------------------------------------
      /// <summary>Returns true if the Queue is empty otherwise false</summary>
      public bool IsEmpty => mCount == 0;
      #endregion

      #region Queue<T>Methods ---------------------------------------
      /// <summary>Pushes the element into the Queue</summary>
      /// <param name="a">Element to be added to the Queue</param>
      public void Enqueue (T a) {
         if (mCount == elements.Length) {
            T[] expElements = new T[mCount * 2];
            mEnIndex = mCount;
            for (int i = 0; i < elements.Length; i++) expElements[i] = Dequeue ();
            elements = expElements;
            mCount = mEnIndex;
         }
         elements[mEnIndex++] = a;
         if (mEnIndex == elements.Length) mEnIndex = 0;
         mCount++;
      }

      /// <summary>Returns and removes the element at the top of the Queue</summary>
      /// <returns>The top element of the Queue</returns>
      public T Dequeue () {
         if (IsEmpty) throw new InvalidOperationException ();
         T firstEl = default!;
         firstEl = elements[mDeIndex];
         mCount--;
         elements[mDeIndex++] = default!;
         if (mDeIndex == elements.Length) mDeIndex = 0;
         return firstEl;
      }

      /// <summary>Returns the top element of the Queue</summary>
      /// <returns>The top element of the Queue</returns>
      public T Peek () {
         if (IsEmpty) throw new InvalidOperationException ();
         return elements[mDeIndex];
      }
      #endregion 

      #region PrivateFields -----------------------------------------
      T[] elements = new T[4];
      int mEnIndex = 0, mDeIndex = 0, mCount = 0;
      #endregion
   }
   #endregion
}