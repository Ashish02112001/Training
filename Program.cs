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
      /// <param name="args">Arguments</param>
      static void Main (string[] args) {
         MyList<string> seaStory = new ();
         Console.WriteLine ("Adding Elements to Mylist(seaStory)...");
         seaStory.Add ("boat");
         seaStory.Add ("star");
         seaStory.Add ("sea");
         seaStory.Add ("pirate");
         seaStory.Add ("Yatch");
         seaStory.Add ("Shell");
         seaStory.Add ("Telescope");
         Console.WriteLine ("Printing elements in the seaStory...");
         PrintElementsAndCount(seaStory);
         Console.WriteLine ("Removing the element .\"Sea\" in the list");
         seaStory.Remove ("sea");
         PrintElementsAndCount (seaStory);
         Console.WriteLine ("Removing 1st index element from the list");
         seaStory.RemoveAt (1);
         PrintElementsAndCount (seaStory);
         Console.WriteLine("Inserting the element \"sea\" at the 2nd index");
         seaStory.Insert (2,"sea");
         PrintElementsAndCount (seaStory);
         Console.WriteLine ("Inserting additional 3 elements at the 1st, 2nd and 3rd index..");
         seaStory.Insert (1, "Fight");
         seaStory.Insert (2, "Sword");
         seaStory.Insert (3, "log");
         PrintElementsAndCount(seaStory);
         Console.WriteLine ("Clearing all elements");
         seaStory.Clear ();
         PrintElementsAndCount (seaStory);
      }
      static void PrintElementsAndCount (MyList<string> list) {
         for (int i = 0; i < list.Count; i++) Console.WriteLine ("\t" + list[i]);
         Console.WriteLine ($"Count: {list.Count}");
         Console.WriteLine ($"Capacity: {list.Capacity}");
      }
      #endregion
   }
   #endregion

   /// <summary>Custom List</summary>
   /// <typeparam name="T">List type</typeparam>
   #region MyList_Class ------------------------------------------------------------------------------
   class MyList<T> {
      /// <summary>Constructor for the class MyList</summary>
      /// <param name="initCap">Initial capacity for the list</param>
      public MyList (int initCap = 4) {
         mSize = 0;
         mElements = new T[initCap];
      }
      #region Properties-----------------------------------------------
      /// <summary>Returns the number of elements in the list</summary>
      public int Count => mSize;
      /// <summary>Returns the current limit of the list</summary>
      public int Capacity => mElements.Length;

      /// <summary>This assigns the value to a specified index or to return the element of the specified index in a list</summary>
      /// <param name="index">Index of the list</param>
      /// <returns>Element of the specific index in a list</returns>
      /// <exception cref="Exception">Index out of the range exception</exception>
      public T this[int index] {
         get {
            if (index >= mSize || index < 0) throw new IndexOutOfRangeException();
            else return mElements[index];
         }
         set {
            if (index > Capacity || index < 0) throw new IndexOutOfRangeException ();
            mElements[index] = value;
         }
      }
      #endregion
      #region Methods---------------------------------------------
      /// <summary>Adds a specified element to the list</summary>
      /// <param name="a">Element to be added inside the list</param>
      public void Add (T a) {
         ExpandArraySize ();
         mElements[mSize++] = a;
      }
      /// <summary>Removes a specified element from the list</summary>
      /// <param name="a">Element to be removed from the list</param>
      /// <returns>Returns true if the element is present in the list otherwise false</returns>
      public bool Remove (T a) {
         if (mElements.Contains (a)) {
            for (int i = Array.IndexOf (mElements, a); i < mSize - 1; i++) mElements[i] = mElements[i + 1];
            mElements[mSize-- - 1] = default;
            return true;
         }return false;
      }
      /// <summary>Clears all the elements in the list</summary>
      public void Clear () {
         Array.Clear (mElements, 0, mSize);
         mElements = new T[4];
         mSize = 0;
      }
      /// <summary>Inserts a given element at a specified index</summary>
      /// <param name="index">Index at which the element has to be insereted</param>
      /// <param name="a">Element to be inserted in the list</param>
      public void Insert (int index, T a) {
         ExpandArraySize ();
         if (index > mSize) throw new IndexOutOfRangeException ();
         mSize++;
         for (int i = mSize - 1; i >= index + 1; i--) mElements[i] = mElements[i - 1];
         mElements[index] = a;
      }
      /// <summary>Removes the element at the specified index</summary>
      /// <param name="index">Index at which the element has to be removed</param>
      public void RemoveAt (int index) {
         if (Remove (mElements[index])) return;
         throw new IndexOutOfRangeException();
      }
      void ExpandArraySize () { if (mSize == mElements.Length) Array.Resize (ref mElements, mElements.Length * 2); }

      #endregion
      T[] mElements;
      int mSize;
   }
   #endregion
}