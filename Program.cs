﻿// --------------------------------------------------------------------------------------------
// Training ~ A training program for new joinees at Metamation, Batch - July 2023.
// Copyright (c) Metamation India.                                              
// ------------------------------------------------------------------------
// Program.cs
// STACK<T> 
// Implement a Stack<T> class using arrays as the underlying data structure. 
// The Stack<T> should start with an initial capacity of 4 and double its capacity when needed. 
// Use the template shown below for implementation. Throw exceptions when necessary. 
// --------------------------------------------------------------------------------------------

using System.Globalization;

namespace Training {
   #region Program ------------------------------------------------------------------------------
   /// <summary>Custom Stack<T> Program</summary>
   internal class Program {
      #region Methods ---------------------------------------------
      /// <summary>Checks for the custom Stack<T>></summary>
      /// <param name="args">arguments</param>
      static void Main (string[] args) {
         TStack<string> things = new ();
         things.Push ("Joystick");
         things.Push ("Mouse");
         things.Push ("Smartphone");
         Console.WriteLine ("Things pushed to the stack: \n\nJoystick \nMouse \nSmartphone\n");
         Console.WriteLine ($"Checking the stack Isempty? : {things.IsEmpty}");
         Console.WriteLine ("peeking last element in the stack..\n");
         string lastThing = things.Peek ();
         Console.WriteLine (lastThing);
         Console.WriteLine ("\nPopping out the elements from the stack..\n");
         string lastOne = things.Pop (), secondLast = things.Pop (), firstOne = things.Pop (); 
         Console.WriteLine (lastOne);
         Console.WriteLine (secondLast);
         Console.WriteLine (firstOne);
         Console.WriteLine ($"\nChecking the stack Isempty? : {things.IsEmpty}");
      }
      #endregion
   }
   #region ClassTStack<T> ------------------------------------------------------------------------------
   /// <summary>Class Stack<T></summary>
   /// <typeparam name="T">Type of the Stack</typeparam>
   class TStack<T> {
      #region Property-----------------------------------
      /// <summary>Returns true if the stack is empty otherwise false</summary>
      public bool IsEmpty => size == 0;
      #endregion
      #region Stack<T>Methods ---------------------------------------------
      /// <summary>Pushes the element into the stack</summary>
      /// <param name="a">Element to push into the Stack</param>
      public void Push (T a) { 
         if (size == capacity) Array.Resize (ref elements, capacity*2);
         elements[size++] = a;
      }
      /// <summary>Returns and removes the element at the top of the stack</summary>
      /// <returns>The top element of the stack</returns>
      public T Pop () => elements[--size];
      /// <summary>Returns the top element of the stack</summary>
      /// <returns>The top element of the stack</returns>
      public T Peek () => elements[size - 1];
      #endregion
      int size = 0, capacity = 4;
      T[] elements = new T[4];
   }
   #endregion
   #endregion
}