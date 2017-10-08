using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucky_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declared Variables
            double jackPot = 10000000;
            double sameNumber = 0;
            int lowestNumber;
            int highestNumber;
            
            int[] randomNumbers = new int[6];
            int[] guessedNumbers = new int[6];


            //Main Program
            Console.WriteLine("Would you like to play a game of Lucky Numbers? With this game you have a \nchance of winning 10,000,000 dollars. Proceed: Yes or no?");
            string playAgain = Console.ReadLine();
            while (playAgain.ToLower() == "yes")
            {

                Console.WriteLine("Thank you for playing the Lucky Numbers game, first you will need to choose a \nstarting number. This is going to be the lowest number in your range.");
                lowestNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Thank you, now you will need to choose your ending number. This is going to \nbe the highest number in your range.");
                highestNumber = int.Parse(Console.ReadLine());

                //Random Number Generator with Stretch Task
                Random rando = new Random();
                for (int i = 0; i < randomNumbers.Length; i++)
                {
                    randomNumbers[i] = rando.Next(lowestNumber, highestNumber);
                    //For the stretch task I re-rolled if the random numbers array contained the currently indexed number.
                    if(randomNumbers.Contains(randomNumbers[i]))
                    {
                        randomNumbers[i] = rando.Next(lowestNumber, highestNumber);
                    }
                    //Console.WriteLine(randomNumbers[i]);
                }

                //User Guesses
                Console.WriteLine("Great! Now you will need to guess 6 lucky numbers.");
                for (int i = 0; i < guessedNumbers.Length; i++)
                {
                    Console.WriteLine("Please enter guess number " + (i + 1) + ".");
                    guessedNumbers[i] = int.Parse(Console.ReadLine());
                    while (guessedNumbers[i] < lowestNumber || guessedNumbers[i] > highestNumber)
                    {
                        Console.WriteLine("Please enter a number that is in between " + lowestNumber + " and " + highestNumber + ".");
                        guessedNumbers[i] = int.Parse(Console.ReadLine());
                    }
                }
                Console.WriteLine("Thank you for choosing your numbers!");
                for (int i = 0; i < guessedNumbers.Length; i++)
                {
                    Console.WriteLine(guessedNumbers[i]);
                }
                
                //Number Checker
                for (int i = 0; i < randomNumbers.Length; i++)
                {
                    if (randomNumbers.Contains(guessedNumbers[i]))
                    {
                        sameNumber++;
                    }
                }

                //Winng Numbers
                Console.WriteLine("These are the winning numbers!");
                for (int i = 0; i < randomNumbers.Length; i++)
                {
                    Console.WriteLine("Lucky Number: " + randomNumbers[i]);
                }

                //Winnings Prompt
                Console.WriteLine("You guessed " + sameNumber + " numbers correctly!");
                double totalGuesses = 6;
                double winnings = (jackPot / totalGuesses) * sameNumber;
                Console.WriteLine("You won $" + Math.Round(winnings,2).ToString("#,##0.00") + "!");
               
                //Closing Statement
                Console.WriteLine("Would you like to play Lucky Numbers again?");
                playAgain = Console.ReadLine();

            }
            Console.WriteLine("Thanks for playing!");
        }
    }
}
