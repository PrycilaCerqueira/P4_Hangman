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
            Console.Write("\n Would you like to continue the game? Enter Y for yes:   ");
            string answer = Console.ReadLine().ToUpper().Trim();

            if (answer == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
                      
        }

        
      
      

    }
}
