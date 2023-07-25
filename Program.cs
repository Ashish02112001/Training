namespace Training {
   internal class Program {
      static void Main (string[] args) {
         int n = new Random ().Next (1, 101), guess;
         Console.Write("Enter your guess between 1 to 100:");
         for (; ; ) {
            guess = int.Parse(Console.ReadLine());
            if (guess == n) { Console.WriteLine ("You guessed correctly"); break;}
            if (guess < n) { Console.WriteLine ("Your guess is too low"); }
            if (guess > n) { Console.WriteLine ("Your guess is too high"); }
             
         } 
         
      }
   }
}