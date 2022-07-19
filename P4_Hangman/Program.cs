using System;

namespace P4_Hangman // Note: actual namespace depends on the project name.
{
    internal class Program
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

                if (String.IsNullOrEmpty(word) || String.IsNullOrWhiteSpace(word)) //Verify if word is empty, null, or spaces
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

            Console.WriteLine("\nHere are your saved words:");
            foreach (string item in bankOfWords) //Printing the bankOfWords items for the player verify the words inserted
            {
                Console.WriteLine(item);
            }

            string confirmation = "";
            Console.Write("Are you happy with your list? (Yes/No) ");
            confirmation = Console.ReadLine(); 
            
            if (confirmation.ToLower() != "yes" && confirmation.ToLower() != "no") //Confirming if the player entered a valid confirmation word
            {
                Console.Write("This is an invalid entry. Choose Yes or No to proceed: ");
                confirmation = Console.ReadLine();
            }
            if (confirmation.ToLower() == "no") //Confirming if the player would like to proceed in the game
            {
                Console.Write("Sorry to hear that! See you next time.");
                Environment.Exit(0); //Exits the console, forcing the game to end 
            }


                


            
        }
    }
}