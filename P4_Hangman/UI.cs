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
        /// Print game's name on console 
        /// </summary>
        public static void GameHeadline()
        {
            // \t tab alignment; \n new line.
            Console.WriteLine("\t\t***** Hangman Game *****\n\n");
        }
        
        /// <summary>
        /// Asks for a word input <string>
        /// </summary>
        /// <param name="totalNumWords">Add a total number of words</param>
        /// <param name="wordCount">Initiate the word count. Recommended to start with zero.</param>
        /// <returns>Returns the word <string> </returns>
        public static string AskForNewWord(int totalNumWords, int wordCount)
        {
            if (wordCount == 0)
            {
                Console.WriteLine($"Create your own bank of words. Add {totalNumWords} word.");
            }
            Console.Write($"Enter word number {wordCount + 1}: ");
            string newWord = Console.ReadLine().ToUpper().Trim();
            return newWord;
        }

    }
}
