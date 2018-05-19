using System;

namespace GuessinGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Prompt for name
            Console.WriteLine("Hello! What is your name? ");
            String name = Console.ReadLine();

            // Greet the player
            Console.WriteLine("\nNice to meet you {0}. \nI am your computer and we" +
                              "are going to play a game today!", name);

            // -1 signifies that the user has not yet guesses
            int guess = -1;

            Random random = new Random();
            int correct = random.Next(1, 101);

            // Prompt user for a guess
            Console.WriteLine("\nI'm thinking of a number between 1 and 100! " +
                              "\nUsing divide and conquer, " +
                              " you should be able to guess this in "
                              + (int)Math.Log(100, 2) + " tries!\n" +
                              "Can you guess it in 6? \n");

            // Keeping track of guesses
            int numGuesses = 0;
            while(correct != guess)
            {
                Console.WriteLine("You have used {0} guesses.\n Your Guess:", numGuesses);
                String guessIn = Console.ReadLine();
                // Set text to red to signify error
                Console.ForegroundColor = ConsoleColor.Red;
                if (Int32.TryParse(guessIn, out guess))
                {
                    String res = HigherOrLower(correct, guess);
                    Console.WriteLine("Sorry {0} is not correct. Guess {1}!", guess, res);
                }
                else
                {
                    Console.WriteLine("That is not a number! Try again!");

                }
                // Update number of guesses
                numGuesses += 1;
                // Set text back to original color
                Console.ResetColor();
            }

            // Let them know they used the algorithm incorrectly
            if (numGuesses > (int)Math.Log(100, 2))
            {
                Console.WriteLine("You can do better!");
            }

            else
            {
                Console.WriteLine("You have successfully used divide and conquer!");
            }
        }

        // Function for higher or lower
        public static String HigherOrLower(int correct, int guess)
        {
            if (correct > guess)
            {
                return "HIGHER";
            }
            else return "LOWER";
        }
    }
}
