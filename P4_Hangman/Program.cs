using System;

namespace P4_Hangman // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("** Hangman Game **\n\n");

            //BLOCK 1 - List of words creation
            string word = "";
            List<string> bankOfWords = new List<string>(); //Creates and initializes the list named bankOfWords
            Console.Write($"Create your own back of words. Enter 10 words:\n");

            for (int wordCount = 0; wordCount < 1; wordCount++) //Add words to the bankOfWords list
            {
                Console.Write(@$"{wordCount + 1})");
                word = Console.ReadLine();

                //If TRUE loop again. If FALSE go to repeated word verification
                while (String.IsNullOrEmpty(word) || String.IsNullOrWhiteSpace(word)) //Verifies if the word is empty, null, or spaces
                {
                   
                    Console.WriteLine("Null and spaces are invalidy entries. Please, try again.");
                    Console.Write("Enter a valid word: ");
                    word = Console.ReadLine();
                
                }

                //If TRUE loop again. If FALSE go to Add word to the list
                while (bankOfWords.Contains(word)) //Verifies if the word is repeated
                {
                    Console.WriteLine("This word already exist in your list.");
                    Console.Write("Enter a new word: ");
                    word = Console.ReadLine();
                }

                bankOfWords.Add(word.ToLower()); //Adds a lower case converted word to the list

             }

            Console.WriteLine("\nHere are your saved words:");
            foreach (string item in bankOfWords) //Print the bankOfWords items for the player
            {
                Console.WriteLine(item);
            }

            string confirmation = "";
            Console.Write("\nAre you happy with your list? (Y/N) ");
            confirmation = Console.ReadLine(); 
            
            while (confirmation.ToLower() != "y" && confirmation.ToLower() != "n") //Confirms if the player entered a valid confirmation word
            {
                Console.Write("This is an invalid entry. Choose Yes or No to proceed: ");
                confirmation = Console.ReadLine();
            }
            if (confirmation.ToLower() == "n") //Confirms if the player would like to proceed in the game
            {
                Console.Write("Sorry to hear that! See you next time.");
                Environment.Exit(0); //Exits the console, forcing the game to end 
            }

            //BLOCK 2 - Pick a random word from the list
            Random rnd = new Random();
            int wordIndex = rnd.Next(bankOfWords.Count);
            string pickedWord = bankOfWords[wordIndex];

            Console.WriteLine(pickedWord);

            //BLOCK 3 - Discover if a character is part of the picked word
            string guessedLetter;
            string displayWord = pickedWord;
            char[] displayWordChars = displayWord.ToCharArray(); //Converts the displayWord from String to a Character Array
            
            for (int i= 0; i < displayWordChars.Length; i++) //Hides the secrete word 
            {
                displayWordChars[i] = '*';
            }
            displayWord = new string (displayWordChars); //Converts the hidden word from the Character Array to a String in order to display on the console
            Console.WriteLine($"\nYou have {pickedWord.Length} guesses to find out the secrete word.\nWord: {displayWord}");

           
            for (int i = 0; i < displayWord.Length; i++) //Players input their letter guesses
            {
                Console.Write($"{i + 1}) Guess a letter: ");
                guessedLetter = Console.ReadLine().ToLower();
                
                for (int j = 0; j < displayWord.Length; j++) //Verifies if the guesses are correct and slowly reveals the hidden word to the players
                {
                    
                    if (guessedLetter == pickedWord[j].ToString())
                    {
                        displayWordChars[j] = pickedWord[j];
                    }
                }
                displayWord = new string(displayWordChars);
                Console.WriteLine($"Updated word: {displayWord}");// Shows the updated secrete word to the players


                //TODO: Fix the loop of repeated words
                char[] repeatedLettersChars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                for (int j = 0; j < repeatedLettersChars.Length; j++)
                {
                    
                    if (repeatedLettersChars[j] == '*')
                    {
                        Console.WriteLine($"You already guessed the letter {guessedLetter.ToUpper()}");
                        Console.Write("Try again: ");
                        guessedLetter = Console.ReadLine().ToLower();
                        repeatedLettersChars[j] = '*';

                        displayWord = new string(displayWordChars);
                        Console.WriteLine($"Updated word: {displayWord}");// Shows the updated secrete word to the players
                    }
                    
                    if (repeatedLettersChars.ToString().Contains(guessedLetter))
                    { 
                        repeatedLettersChars[j] = '*';
                    }
                }
                
            }

        }
            
            
        
            //BLOCK 4 - Draw the shape of the hangman

        
    }
}