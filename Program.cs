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
         nums.Clear ();
         for (int i = 0; i < nums.Count;i++) { Console.WriteLine (nums[i]); }
      }
      #endregion
   }

   class MyList<T> {
      T[] elements;
      int size = 0;
      int capacity;
      public MyList (int initCap = 4) {
         capacity = initCap;
         elements = new T[initCap];
      }

      public int Count => size;
      public int Capacity => capacity;
      public T this[int index] {
         get => elements[index];
         set {
            elements[index] = value;
         }
      }
      public void Add (T a) {
         if (size == capacity) {
            Array.Resize (ref elements, capacity * 2);
            capacity *= 2;
         }
         elements[size++] = a;
      }
      public bool Remove (T a) {
         if (elements.Contains (a)) {
            for (int i = Array.IndexOf (elements, a); i < size - 1; i++) {
               elements[i] = elements[i + 1];
            }
            elements[size-- - 1] = default;
            return true;
         } else return false;
      }
      public void Clear () { 
         Array.Clear (elements, 0, size);
         size = 0;
      }
      public void Insert (int index, T a) { }
      public void RemoveAt (int index) { }

   }
   #endregion
}