using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_Hangman
{
    public static class UI
    {
        public static void GameHeadline()
        {
            // \t tab alignment; \n new line.
            Console.WriteLine("\t\t***** Hangman Game *****\n\n");
        }

        public static string AskForNewWord (int maxWordCount)
        {
            Console.WriteLine($"Create your own bank of words.");
            for (int wordCount = 0; wordCount < maxWordCount; wordCount++)
            {
                Console.Write($"Enter {wordCount} words: ");
                string newWord = Console.ReadLine().ToUpper().Trim();
                return newWord;
            }
        }

    }
}
