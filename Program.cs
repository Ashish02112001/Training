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
         for (int i = 0; i < seaStory.Count; i++) Console.WriteLine ("\t" + seaStory[i]);
         Console.WriteLine ($"Count: {seaStory.Count}");
         Console.WriteLine ($"Capacity: {seaStory.Capacity}");
         Console.WriteLine ("Removing 'Yatch' from the list");
         seaStory.Remove ("Yatch");
         for (int i = 0; i < seaStory.Count; i++) Console.WriteLine ("\t" + seaStory[i]);
         Console.WriteLine ($"Count: {seaStory.Count}");
         Console.WriteLine ($"Capacity: {seaStory.Capacity}");
         Console.WriteLine ("Removing 1st index element from the list");
         seaStory.RemoveAt(1);
         for (int i = 0; i < seaStory.Count; i++) Console.WriteLine ("\t" + seaStory[i]);
         Console.WriteLine ($"Count: {seaStory.Count}");
         Console.WriteLine ($"Capacity: {seaStory.Capacity}");
      }
      #endregion
   }
   /// <summary>Custom List</summary>
   /// <typeparam name="T">list type</typeparam>
   class MyList<T> {
      T[] elements;
      int size = 0;
      int capacity;

      /// <summary>Constructor for the class MyList</summary>
      /// <param name="initCap">Initial capacity for the list</param>
      public MyList (int initCap = 4) {
         capacity = initCap;
         elements = new T[initCap];
      }
      /// <summary>returns the number of elements in the list</summary>
      public int Count => size;
      /// <summary>returns the current limit of the list</summary>
      public int Capacity => capacity;
      /// <summary>This assigns the value to a specified index or to return the element of the specified index in a list</summary>
      /// <param name="index">index of the list</param>
      /// <returns>element of the specific index in a list</returns>
      /// <exception cref="Exception">Index out of the range exception</exception>
      public T this[int index] {
         get {
            if (index >= size || index < 0) throw new Exception ("Index was outside the bounds of the List.");
            else return elements[index];
         }
         set {
            if (index > Capacity || index < 0) throw new Exception ("Index was outside the bounds of the List.");
            elements[index] = value;
         }
      }
      /// <summary>Adds a specified element to the list</summary>
      /// <param name="a">Element to be added inside the list</param>
      public void Add (T a) {
         if (size == capacity) {
            Array.Resize (ref elements, capacity * 2);
            capacity *= 2;
         }
         elements[size++] = a;
      }
      /// <summary>Removes a specified element from the list</summary>
      /// <param name="a">element to be removed from the list</param>
      /// <returns>returns true if the element is present in the list otherwise false</returns>
      public bool Remove (T a) {
         if (elements.Contains (a)) {
            for (int i = Array.IndexOf (elements, a); i < size - 1; i++) elements[i] = elements[i + 1];
            elements[size-- - 1] = default;
            return true;
         } else throw new InvalidOperationException ();
      }
      /// <summary>Clears all the elements in the list</summary>
      public void Clear () {
         Array.Clear (elements, 0, size);
         size = 0;
      }
      /// <summary>Inserts a given element at a specified index</summary>
      /// <param name="index">Index at which the element has to be insereted</param>
      /// <param name="a">element to be inserted in the list</param>
      public void Insert (int index, T a) {
         if (index > size) { throw new Exception ("Index was outside the bounds of the List."); }
         for (int i = size - 1; i >= index + 1; i--) elements[i] = elements[i - 1];
         elements[index] = a;
         size++;

      }
      /// <summary>Removes the element at the specified index</summary>
      /// <param name="index">Index at which the element has to be removed</param>
      public void RemoveAt (int index) {
         if (index > size) { throw new Exception ("Index was outside the bounds of the List."); }
         for (int i = index; i < size - 1; i++) elements[i] = elements[i + 1];
         elements[size-- - 1] = default;
      }
   }
   #endregion
}