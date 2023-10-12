// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Implement a custom MyList<T> class using arrays as the underlying data structure.
// The MyList<T> should start with an initial capacity of 4 and double its capacity when needed.
// Throw exceptions when necessary. 
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>MyList<T></summary>
   class Program {
      #region Methods ---------------------------------------------
      /// <summary>Tests the custom MyList<T></summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         MyList<string> seaStory = new ();
         Console.WriteLine ("Adding Elements to Mylist(seaStory)...");
         seaStory.Add ("boat");
         seaStory.Add ("star");
         seaStory.Add ("sea");
         seaStory.Add ("pirate");
         seaStory.Add ("Yatch");
         Console.WriteLine ("Printing elements in the seaStory...");
         PrintElementsAndCount(seaStory);
         Console.WriteLine ("Removing the element \"Sea\" in the list");
         seaStory.Remove ("sea");
         PrintElementsAndCount (seaStory);
         Console.WriteLine ("Removing 1st index element from the list");
         seaStory.RemoveAt (1);
         PrintElementsAndCount (seaStory);
         Console.WriteLine("Inserting the element \"sea\" at the 2nd index");
         seaStory.Insert (2,"sea");
         PrintElementsAndCount (seaStory);
         Console.WriteLine ("Clearing all elements");
         seaStory.Clear();
         PrintElementsAndCount(seaStory);
      }
      static void PrintElementsAndCount (MyList<string> list) {
         for (int i = 0; i < list.Count; i++) Console.WriteLine ("\t" + list[i]);
         Console.WriteLine ($"Count: {list.Count}");
         Console.WriteLine ($"Capacity: {list.Capacity}");
      }
      #endregion
   }

   /// <summary>Custom List</summary>
   /// <typeparam name="T">list type</typeparam>
   #region MyList_Class ------------------------------------------------------------------------------
   class MyList<T> {
      /// <summary>Constructor for the class MyList</summary>
      /// <param name="initCap">Initial capacity for the list</param>
      public MyList (int initCap = 4) {
         mSize = 0;
         mCapacity = initCap;
         mElements = new T[initCap];
      }
      #region Properties-----------------------------------------------
      /// <summary>returns the number of elements in the list</summary>
      public int Count => mSize;
      /// <summary>returns the current limit of the list</summary>
      public int Capacity => mCapacity;

      /// <summary>This assigns the value to a specified index or to return the element of the specified index in a list</summary>
      /// <param name="index">index of the list</param>
      /// <returns>element of the specific index in a list</returns>
      /// <exception cref="Exception">Index out of the range exception</exception>
      public T this[int index] {
         get {
            if (index >= mSize || index < 0) throw new Exception ("Index was outside the bounds of the List.");
            else return mElements[index];
         }
         set {
            if (index > Capacity || index < 0) throw new Exception ("Index was outside the bounds of the List.");
            mElements[index] = value;
         }
      }
      #endregion
      #region Methods---------------------------------------------
      /// <summary>Adds a specified element to the list</summary>
      /// <param name="a">Element to be added inside the list</param>
      public void Add (T a) {
         if (mSize == mCapacity) {
            Array.Resize (ref mElements, mCapacity * 2);
            mCapacity *= 2;
         }
         mElements[mSize++] = a;
      }
      /// <summary>Removes a specified element from the list</summary>
      /// <param name="a">element to be removed from the list</param>
      /// <returns>returns true if the element is present in the list otherwise false</returns>
      public bool Remove (T a) {
         if (mElements.Contains (a)) {
            for (int i = Array.IndexOf (mElements, a); i < mSize - 1; i++) mElements[i] = mElements[i + 1];
            mElements[mSize-- - 1] = default;
            return true;
         } else throw new InvalidOperationException ();
      }
      /// <summary>Clears all the elements in the list</summary>
      public void Clear () {
         Array.Clear (mElements, 0, mSize);
         mSize = 0;
      }
      /// <summary>Inserts a given element at a specified index</summary>
      /// <param name="index">Index at which the element has to be insereted</param>
      /// <param name="a">element to be inserted in the list</param>
      public void Insert (int index, T a) {
         if (index > mSize) { throw new Exception ("Index was outside the bounds of the List."); }
         mSize++;
         for (int i = mSize - 1; i >= index + 1; i--) mElements[i] = mElements[i - 1];
         mElements[index] = a;

      }
      /// <summary>Removes the element at the specified index</summary>
      /// <param name="index">Index at which the element has to be removed</param>
      public void RemoveAt (int index) {
         if (index > mSize) { throw new Exception ("Index was outside the bounds of the List."); }
         for (int i = index; i < mSize - 1; i++) mElements[i] = mElements[i + 1];
         mElements[mSize-- - 1] = default;
      }
      #endregion
      T[] mElements;
      int mSize;
      int mCapacity;
   }
   #endregion
   #endregion
}