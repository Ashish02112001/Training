// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// Simple Program to Print the text 'Hello, World!' in Console
// --------------------------------------------------------------------------------------------
namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Sample program</summary>
   class Program {
      #region Methods ---------------------------------------------
      /// <summary>This Method prints "Hello, World!"</summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         MyList<int> nums = new ();
         nums.Add (1);
         nums.Add (3);
         nums.Add (4);
         nums.Add (5);
         nums.Add (6);
         nums.Add (7);
         nums.Insert(1, 2);
         nums.Insert (7, 8);
         nums.RemoveAt(4);
         for (int i = 0; i < nums.Count; i++) { Console.WriteLine (nums[i]); }
         //Console.WriteLine (nums.Count);
      }
      #endregion
   }
   /// <summary>Custom List</summary>
   /// <typeparam name="T">list type</typeparam>
   class MyList<T> {
      T[] elements;
      int size = 0;
      int capacity;
      /// <summary></summary>
      /// <param name="initCap"></param>
      public MyList (int initCap = 4) {
         capacity = initCap;
         elements = new T[initCap];
      }
      /// <summary></summary>
      public int Count => size;
      public int Capacity => capacity;
      public T this[int index] {
         get => elements[index];
         set {
            elements[index] = value;
         }
      }
      /// <summary>Adds a specified element to the list</summary>
      /// <param name="a"></param>
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
         } else return false;
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
         size++;
         for (int i = size-1; i >= index+1; i--) elements[i] = elements[i - 1];
         elements[index] = a;   
      }
      /// <summary>Removes the element at the specified index</summary>
      /// <param name="index">Index at which the element has to be removed</param>
      public void RemoveAt (int index) {
         if (index < size) {
            for (int i = index; i < size - 1; i++) elements[i] = elements[i + 1];
            elements[size-- - 1] = default;
         } 
      }
         
   }
   #endregion
}