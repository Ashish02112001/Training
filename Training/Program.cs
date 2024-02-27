// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.
// ------------------------------------------------------------------------
// A15: Priority queue:
// Assignment is to implement a PriorityQueue<T> using the Heap data structure.
// --------------------------------------------------------------------------------------------

using System;
using System.Numerics;
using System.Reflection;
using System.Xml.XPath;

namespace Training {
   #region Program --------------------------------------------------------------------------------
   /// <summary>Priority queue</summary>
   internal class Program {
      #region Methods -----------------------------------------------
      /// <summary>Checks the Priority queue implementation</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         PriotityQueue<int> q = new ();
         Random random = new ();
         for (int i = 0; i < 10; i++) {
            var num = random.Next (0, 20);
            q.Enqueue (num);
         }
         for (int j = 0; j < 10; j++) Console.WriteLine(q.Dequeue ());
      }
      #endregion
   }
   #endregion

   #region Priority queue<T> ----------------------------------------------------------------------
   /// <summary>Custom implementation of Priority queue</summary>
   /// <typeparam name="T">Type of the elements in the queue</typeparam>
   public class PriotityQueue<T> where T : IComparable<T>, INumber<T> {
      #region Property ----------------------------------------------
      public bool IsEmpty { get { return mList.Count == 0; } }
      #endregion

      #region Methods -----------------------------------------------
      /// <summary>Adds the element into the queue</summary>
      /// <param name="value">Element from the user</param>
      public void Enqueue (T value) {
         mList.Add (value);
         SiftUp (mList.Count - 1);
      }

      /// <summary>Arranges the added element into the queue</summary>
      /// <param name="ind">Index of the added element</param>
      void SiftUp (int ind) {
         int pInd = (ind - 1) / 2;
         T value = mList[ind];
         if (mList.Count > 1 && value.CompareTo (mList[pInd]) < 0) {
            Swap (pInd, ind);
            SiftUp (pInd);
         }
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

      /// <summary>Arranges the priority queue after removing the element</summary>
      /// <param name="ind">Index of the element removed</param>
      void SiftDown (int ind) {
         int lIn = (2 * ind) + 1, rIn = (2 * ind) + 2, smallVal = ind;
         if (lIn < mList.Count && mList[lIn].CompareTo (mList[smallVal]) < 0)
            smallVal = lIn;
         if (rIn < mList.Count && mList[rIn].CompareTo (mList[smallVal]) < 0)
            smallVal = rIn;
         if (smallVal != ind) {
            Swap (ind, smallVal);
            SiftDown (smallVal);
         }
      }

      /// <summary>Swaps the elements at the given index</summary>
      /// <param name="i">list index</param>
      /// <param name="j">list index</param>
      void Swap (int i, int j) => (mList[i], mList[j]) = (mList[j], mList[i]);
      #endregion

      #region Field -------------------------------------------------
      List<T> mList = new ();
      #endregion
   }
   #endregion
}