using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class P4_Hangman
    {
        static void Main(string[] args)
        {
            Console.Write("** Hangman Game **\n\n");

            string word = "test";
            List<string> bankOfWords = new List<string>(); //Creating and initializing the list name bankOfWords
            Console.Write($"Create your own back of words. Enter 10 words:\n");

            for (int wordCount = 1; wordCount <= 5; wordCount++) //Adding words to the bankOfWords list
            {
                Console.Write(@$"{wordCount})");
                word = Console.ReadLine();

                //TODO: Fix the loop of repeated word verification 
                /*
                for (int i = 1; i <= wordCount; i++) //Verify if the word already exist in the list
                {
                    if (word == bankOfWords[wordCount])
                    {
                        Console.WriteLine("This word already exist. Please, enter a new one here: ");
                        word = Console.ReadLine();
                    }
                }
                */
                if (String.IsNullOrEmpty(word) || String.IsNullOrWhiteSpace(word)) //Add a word if not empty, null, or spaces
                {
                    Console.WriteLine("Invalidy entry. PLease, try again.");
                }
                else
                {
                    bankOfWords.Add(word.ToLower()); //Adding the word converted to lower case to the bankOfWords list
                }

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