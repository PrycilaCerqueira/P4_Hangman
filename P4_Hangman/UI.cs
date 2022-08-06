using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_Hangman
{
    public static class UI
    {
        /// <summary>
        /// It prints game's name on console 
        /// </summary>
        public static void GameHeadline()
        {
            // \t tab alignment; \n new line.
            Console.WriteLine("\t\t***** Hangman Game *****\n\n");
        }
        
        /// <summary>
        /// It asks for a string input
        /// </summary>
        /// <param name="question">Add a question (string)</param>
        /// <param name="sCount">Initiate the word count (integer)</param>
        /// <returns>Returns the new input (string) </returns>
        public static string AskForNewInput(string question, int sCount)
        {
            if (sCount == 0)
            {
                Console.WriteLine(question);
            }
            Console.Write($"{sCount + 1}- ");
            string newInput = Console.ReadLine().ToUpper().Trim();
            return newInput;
        }

        /// <summary>
        /// It prints on the console the final version of the word bank to the players
        /// </summary>
        /// <param name="bankOfWords">List of inserted words</param>
        public static void ShowBankOfWords (List <string> bankOfWords)
        {
            Console.WriteLine("\nHere are your saved words:");
            foreach (string word in bankOfWords)
            {
                Console.WriteLine(word);
            }
        }

        /// <summary>
        /// It asks the player a Yes/No confirmation
        /// </summary>
        /// <returns>Returns a string (answer) </returns>
        public static bool YesNoAnswer()
        {
            Console.Write("\nWould you like to continue the game? Enter Y for yes: ");
            string answer = Console.ReadLine().ToUpper().Trim();

            if (answer == "Y")
            {
                Console.Clear();//Clear the console, so the player won't see the bank of words
                return true;
            }
            else
            {
                Console.WriteLine("See you next time!");
                return false;
            }
                      
        }

        /// <summary>
        /// It prints an invalid entry message on the console
        /// </summary>
        public static void PrintInvalidMsg()
        {
            Console.WriteLine("Null and spaces are invalidy entries. Try again!\n");
        }

        /// <summary>
        /// It prints a repeated entry message on the console
        /// </summary>
        /// <param name="sRepeated">Repeated string entry </param>
        public static void PrintRepeatedMsg(string sRepeated)
        {
            Console.WriteLine($"-{sRepeated.ToUpper()}- is a repeated entry. Try again!\n");
        }

        /// <summary>
        /// It prints a not contain message on the console
        /// </summary>
        /// <param name="sNotContain">Not contain string entry</param>
        public static void PrintNotContainMsg(string sNotContain)
        {
            Console.WriteLine($"The letter -{sNotContain.ToUpper()}- is not in the secret word.");
        }
      
        /// <summary>
        /// It informs the players whether they Win or Lose the game 
        /// </summary>
        /// <param name="wordStatus">Updated version of the displayWord</param>
        /// <param name="realWord">Show the picked word by the system</param>
        public static void WinLoseGame(string wordStatus, string realWord)
        {
            if (!wordStatus.Contains("*"))
            {
                Console.Clear();
                Console.WriteLine($"***** You win! *****");
                Console.WriteLine($"The word was {realWord}.");


            }
            else
            {
                Console.Clear();
                Console.WriteLine($"***** You lose! *****");
                Console.WriteLine($"The word was {realWord}, and you guessed up to this point: {wordStatus}.\n");
            }
            
            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
                //empty
            }
        }
      
    }
}

