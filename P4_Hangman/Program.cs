using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class P4_Hangman
    {
        static void Main(string[] args)
        {
            Console.Write("** Hangman Game **\n\n");

            string word = "";
            List<string> bankOfWords = new List<string>(); //Creating and initializing the list named bankOfWords
            Console.Write($"Create your own back of words. Enter 10 words:\n");

            for (int wordCount = 1; wordCount <= 3; wordCount++) //Adding words to the bankOfWords list
            {
                Console.Write(@$"{wordCount})");
                word = Console.ReadLine();

                if (String.IsNullOrEmpty(word) || String.IsNullOrWhiteSpace(word)) //Add a word if not empty, null, or spaces
                {
                    Console.WriteLine("Null and spaces are invalidy entries. Please, try again.");
                    Console.Write("Enter a valid word: ");
                    word = Console.ReadLine();
                }
                         
                foreach (string existentWord in bankOfWords) //Verify if the word already exist in the list
                {
                    if (word == existentWord)
                    {
                        Console.WriteLine("This word already exist in your list.");
                        Console.Write("Enter a new word: ");
                        word = Console.ReadLine();
                    }
                }
                
                bankOfWords.Add(word.ToLower()); //Adding a word converted to lower case to the list

             }

            Console.WriteLine("\nConfirm your words:");
            foreach (string item in bankOfWords) //Printing the bankOfWords items for the player verify the words inserted
            {
                Console.WriteLine(item);
            }

            //TODO: Add a IF structure for the user confirm wether the list is valid or not.


            
        }
    }
}