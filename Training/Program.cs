// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// A10.2: DoubleEndedQueue<T>
// This is like a queue but we can add or remove i.e. enqueue or dequeue at both the ends at the head and the tail.
// This should allow to add at the head or remove at the head and add to the tail or remove at the tail.
// Implement it using an array of T.
// --------------------------------------------------------------------------------------------

namespace Training {
   #region Program --------------------------------------------------------------------------------
   /// <summary>Custom Double ended Queue<T> Program</summary>
   internal class Program {
      #region Methods -----------------------------------------------
      /// <summary>Checks for the custom Double ended Queue<T></summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         DEndTQueue<int> Nos = new ();
         Nos.RearEnqueue (1);
         Nos.RearEnqueue (2);
         Nos.RearEnqueue (5);
         Nos.FrontEnqueue (3);
         Nos.FrontEnqueue (4);
         for (int i = 0; i < 5; i++) Console.WriteLine (Nos.FrontDequeue ());
      }
      #endregion
   }
   #endregion

   #region Class Double ended TQueue --------------------------------------------------------------
   /// <summary>Double Ended Queue<T></summary>
   /// <typeparam name="T">Type of the Queue</typeparam>
   public class DEndTQueue<T> {
      #region Property ----------------------------------------------
      /// <summary>Returns true if the Queue is empty otherwise false</summary>
      public bool IsEmpty => mCount == 0;
      #endregion

      #region Methods -----------------------------------------------
      /// <summary>Adds the element at the rear end of the Queue</summary>
      /// <param name="a">Element to be added to the Queue</param>
      public void RearEnqueue (T a) {
         if (mCount == mElements.Length) ResizeArr ();
         rear = (rear + 1) % mElements.Length;
         mElements[rear] = a;
         mCount++;
      }

      /// <summary>Returns and removes the element at the rear end of the Queue</summary>
      /// <returns>The element at the rear end of the Queue</returns>
      /// <exception cref="InvalidOperationException">Exception thrown if the queue is empty</exception>
      public T RearDequeue () {
         if (IsEmpty) throw new InvalidOperationException ();
         if (rear == -1) rear = mElements.Length - 1;
         T rearElem = mElements[rear--];
         mCount--;
         return rearElem;
      }

      /// <summary>Adds the element at the front end of the Queue</summary>
      /// <param name="a">Element to be added to the Queue</param>
      public void FrontEnqueue (T a) {
         if (mCount == mElements.Length) ResizeArr ();
         front = (front == -1) ? mElements.Length - 1 : front - 1;
         mElements[front] = a;
         mCount++;
      }

      /// <summary>Returns and removes the element at the front end of the Queue</summary>
      /// <returns>The element at the front end of the Queue</returns>
      /// <exception cref="InvalidOperationException">Exception thrown if the queue is empty</exception>
      public T FrontDequeue () {
         if (IsEmpty) throw new InvalidOperationException ();
         if (front == -1) front = 0;
         T frontElem = mElements[front];
         front = (front + 1) % mElements.Length;
         mCount--;
         return frontElem;
      }

      /// <summary>Expands the length of the array</summary>
      void ResizeArr () {
         T[] expArray = new T[mCount];
         if (rear < front) expArray = (mElements[front..mElements.Length].Concat (mElements[0..(rear + 1)])).ToArray ();
         mElements = expArray;
         front = -1;
         rear = mCount - 1;
         Array.Resize (ref mElements, mCount * 2);
      }
      #endregion

      #region Private Fields ----------------------------------------
      T[] mElements = new T[4];
      int front = -1, rear = -1, mCount = 0;
      #endregion
   }
   #endregion
}