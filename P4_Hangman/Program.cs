using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class P4_Hangman
    {
        static void Main(string[] args)
        {
            Console.Write("** Hangman Game **\n\n");

            string word = "";
            List<string> bankOfWords = new List<string>(); //Creating and initializing the list name bankOfWords
            Console.Write($"Create your own back of words. Enter 10 words:\n");

            for (int wordCount = 1; wordCount <= 5; wordCount++) //Adding words to the list
            {
                Console.Write(@$"{wordCount})");
                word = Console.ReadLine();
                bankOfWords.Add(word.ToLower());           
            }

            Console.WriteLine("Confirm your words:");
            foreach (string item in bankOfWords) //Printing the list items for the player verify the words inserted
            {
                Console.WriteLine(item);
            }
            
        }
    }
}