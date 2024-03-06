// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// A15: Priority queue:
// Assignment is to implement a PriorityQueue<T> using the Heap data structure.
// --------------------------------------------------------------------------------------------

using System.Numerics;

namespace Training {
   #region Program --------------------------------------------------------------------------------
   /// <summary>Priority queue</summary>
   internal class Program {
      #region Methods -----------------------------------------------
      /// <summary>Checks the Priority queue implementation</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         PriorityQueue<int> q = new ();
         Random random = new ();
         for (int i = 0; i < 10; i++) {
            var num = random.Next (0, 20);
            q.Enqueue (num);
         }
         for (int j = 0; j < 10; j++) Console.WriteLine (q.Dequeue ());
      }
      #endregion
   }
   #endregion

   #region Priority queue<T> ----------------------------------------------------------------------
   /// <summary>Custom implementation of Priority queue</summary>
   /// <typeparam name="T">Type of the elements in the queue</typeparam>
   public class PriorityQueue<T> where T : IComparable<T>, INumber<T> {
      #region Property ----------------------------------------------
      public bool IsEmpty { get => mList.Count == 0; }
      #endregion

      #region Methods -----------------------------------------------
      /// <summary>Adds the element into the queue</summary>
      /// <param name="value">Element from the user</param>
      public void Enqueue (T value) {
         mList.Add (value);
         SiftUp (mList.Count - 1);
      }

      /// <summary>Returns and removes the smallest element</summary>
      /// <returns>Smallest element</returns>
      public T Dequeue () {
         if (IsEmpty) throw new InvalidOperationException ("Queue is empty");
         Swap (0, mList.Count - 1);
         T last = mList[^1];
         mList.RemoveAt (mList.Count - 1);
         SiftDown (0);
         return last;
      }
      #endregion

      #region Implementation ----------------------------------------
      /// <summary>Arranges the added element into the queue</summary>
      /// <param name="idx">Index of the added element</param>
      void SiftUp (int idx) {
         int iIdx = (idx - 1) / 2;
         T value = mList[idx];
         if (mList.Count > 1 && value.CompareTo (mList[iIdx]) < 0) {
            Swap (iIdx, idx);
            SiftUp (iIdx);
         }
      }

      /// <summary>Arranges the priority queue after removing the element</summary>
      /// <param name="idx">Index of the element removed</param>
      void SiftDown (int idx) {
         int lIdx = (2 * idx) + 1, rIdx = (2 * idx) + 2, smallVal = idx;
         if (lIdx < mList.Count && mList[lIdx].CompareTo (mList[smallVal]) < 0)
            smallVal = lIdx;
         if (rIdx < mList.Count && mList[rIdx].CompareTo (mList[smallVal]) < 0)
            smallVal = rIdx;
         if (smallVal == idx) return;
         Swap (idx, smallVal);
         SiftDown (smallVal);
      }

      /// <summary>Swaps the elements at the given index</summary>
      /// <param name="i">list index</param>
      /// <param name="j">list index</param>
      void Swap (int i, int j) => (mList[i], mList[j]) = (mList[j], mList[i]);
      #endregion

      #region Private -----------------------------------------------
      List<T> mList = new ();
      #endregion
   }
   #endregion
}